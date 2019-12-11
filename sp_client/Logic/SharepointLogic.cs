using Data;
using Exceptions;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SharepointLogic
    {
        private IConnecter connecter;
        private ClientContext client;
        private List currentList;
        public bool Connected { get; set; }

        public string CurrentListTitle
        {
            get { return currentList.Title; }
            set
            {
                currentList = client.Web.Lists.GetByTitle(value);
            }
        }

        public SharepointLogic(string URL, string username, string password)
        {
            this.connecter = new Connecter(URL, username, password);
        }

        public void ConnectAndAuthenticate()
        {
            connecter.ConnectAndAuthenticate();
            this.client = connecter.Client;
        }

        public string GetURL()
        {
            return connecter.GetURL();
        }

        public string GetUsername()
        {
            return connecter.GetUsername();
        }

        #region READ

        /// <summary>
        /// Returns the list names from the current site.
        /// </summary>
        /// <returns>string.</returns>
        public List<string> GetListNames()
        {
            List<string> listNames = new List<string>();
            Web site = client.Web;
            ListCollection coll = site.Lists;
            IEnumerable<List> resultCollection = client.LoadQuery(
                coll.Include(
                    l => l.Title,
                    l => l.Id,
                    l => l.DefaultViewUrl,
                    l => l.BaseType).Where(l => l.BaseType == BaseType.GenericList && !l.Hidden)
            );
            client.Load(coll);
            client.ExecuteQuery();
            foreach (List l in resultCollection)
            {
                if (!l.DefaultViewUrl.Contains("PublishedFeed") &&
                    l.DefaultViewUrl.Contains("Lists"))
                {
                    listNames.Add(l.Title);
                }
            }

            return listNames;
        }

        /// <summary>
        /// Reads all values of the current list.
        /// </summary>
        /// <param name="qry">Input query.</param>
        /// <returns>Column.</returns>
        public List<Column> ReadList(CamlQuery qry)
        {
            try
            {
                List<Column> columns = new List<Column>();
                FieldCollection columnCollection = currentList.Fields;
                ListItemCollection columnFieldCollection = currentList.GetItems(qry);
                client.Load(columnFieldCollection);
                client.Load(columnCollection);
                client.ExecuteQuery();

                foreach (Field field in columnCollection)
                {
                    if (field.Required || !field.Hidden && field.CanBeDeleted)
                    {
                        Column newColumn = new Column { ColumnName = field.Title, ColumnStaticName = field.StaticName, ColumnFields = new List<ColumnField>() };

                        switch (field.FieldTypeKind)
                        {
                            case FieldType.Lookup:
                                newColumn.ColumnMultipleValues = ReadLookupListValues(field.StaticName);
                                newColumn.ColumnType = typeof(FieldLookupValue);
                                ReadLookupValues(columnFieldCollection, ref newColumn);
                                break;
                            case FieldType.Text:
                                newColumn.ColumnType = typeof(string);
                                ReadTextValues(columnFieldCollection, ref newColumn);
                                break;
                            case FieldType.Boolean:
                                newColumn.ColumnType = typeof(bool);
                                ReadTextValues(columnFieldCollection, ref newColumn);
                                break;
                            case FieldType.DateTime:
                                newColumn.ColumnType = typeof(DateTime);
                                ReadTextValues(columnFieldCollection, ref newColumn);
                                break;
                            case FieldType.Choice:
                                newColumn.ColumnType = typeof(FieldChoice);
                                ReadTextValues(columnFieldCollection, ref newColumn);
                                newColumn.ColumnMultipleValues = ReadMultichoiceValues(field);
                                break;
                        }

                        columns.Add(newColumn);
                    }
                }

                return columns;
            }
            catch (WebException)
            {
                throw new Error(ErrorType.ConnectionError, "Couldn't reach site. Try again later!");
            }
            catch (ServerException)
            {
                throw new Error(ErrorType.ActionError, $"Can't find list '{CurrentListTitle}'.");
            }
            catch (PropertyOrFieldNotInitializedException)
            {
                throw new Error(ErrorType.ActionError, "Unable to load items.");
            }
            catch (ArgumentException)
            {
                throw new Error(ErrorType.ActionError, "Error.");
            }
        }

        /// <summary>
        /// Reads the values of a multichoice type column.
        /// </summary>
        /// <param name="column">Multichoice field.</param>
        /// <returns>ColumnField</returns>
        private List<ColumnField> ReadMultichoiceValues(Field column)
        {
            FieldChoice choiceField = (FieldChoice)column;
            List<ColumnField> multichoiceValues = new List<ColumnField>();
            foreach (string value in choiceField.Choices)
            {
                ColumnField choice = new ColumnField();
                choice.FieldValue = value;
                multichoiceValues.Add(choice);
            }

            return multichoiceValues;
        }

        /// <summary>
        /// Reads the values of text type column.
        /// </summary>
        /// <param name="columnFieldCollection">All fields of a column.</param>
        /// <param name="newColumn">New column.</param>
        private void ReadTextValues(ListItemCollection columnFieldCollection, ref Column newColumn)
        {
            foreach (ListItem field in columnFieldCollection)
            {
                ColumnField columnField = new ColumnField();

                columnField.FieldId = int.Parse(field["ID"].ToString());
                if (field[newColumn.ColumnStaticName] != null)
                {
                    if (field[newColumn.ColumnStaticName] is DateTime)
                    {
                        columnField.FieldValue = ((DateTime)field[newColumn.ColumnStaticName]).ToString("yyyy.MM.dd");
                    }
                    else
                    {
                        columnField.FieldValue = field[newColumn.ColumnStaticName].ToString();
                    }
                }
                else
                {
                    columnField.FieldValue = null;
                }
                newColumn.ColumnFields.Add(columnField);
            }
        }

        /// <summary>
        /// Reads lookup values of a lookup type column.
        /// </summary>
        /// <param name="columnFieldCollection">All fields of a column.</param>
        /// <param name="newColumn">New column.</param>
        private void ReadLookupValues(ListItemCollection columnFieldCollection, ref Column newColumn)
        {
            foreach (ListItem field in columnFieldCollection)
            {
                ColumnField columnField = new ColumnField();

                columnField.FieldId = int.Parse(field["ID"].ToString());
                if (field[newColumn.ColumnStaticName] != null)
                {
                    FieldLookupValue value = (FieldLookupValue)field[newColumn.ColumnStaticName];
                    columnField.FieldValue = value.LookupValue;
                }
                else
                {
                    columnField.FieldValue = null;
                }

                newColumn.ColumnFields.Add(columnField);
            }
        }

        /// <summary>
        /// Reads values from the referenced list(lookup list) for the current column.
        /// </summary>
        /// <param name="fieldStaticName">Static name of the field.</param>
        /// <returns>ColumnField.</returns>
        private List<ColumnField> ReadLookupListValues(string fieldStaticName)
        {
            List<ColumnField> lookupListValues = new List<ColumnField>();

            Field field = currentList.Fields.GetByInternalNameOrTitle(fieldStaticName); // field = column
            FieldLookup lookupField = client.CastTo<FieldLookup>(field);
            client.Load(lookupField);
            client.ExecuteQuery();
            Guid lookupListId = new Guid(lookupField.LookupList); // Returns associated list id

            // Retrieve associated List
            List lookupList = client.Web.Lists.GetById(lookupListId);
            ListItemCollection lookupValuesColl = lookupList.GetItems(new CamlQuery());
            client.Load(lookupList);
            client.Load(lookupValuesColl);
            client.ExecuteQuery();

            foreach (ListItem item in lookupValuesColl)
            {
                ColumnField temp = new ColumnField();
                temp.FieldValue = item[fieldStaticName].ToString();
                temp.FieldId = int.Parse(item["ID"].ToString());
                lookupListValues.Add(temp);
            }

            return lookupListValues;
        }

        #endregion

        #region CREATE

        public Task AddItemToList(List<string> columns, List<string> fields)
        {
            return Task.Factory.StartNew(() =>
            {
                ListItem newListItem = currentList.AddItem(new ListItemCreationInformation());
                for (int i = 0; i < columns.Count; i++)
                {
                    newListItem[columns[i]] = fields[i];
                }

                newListItem.Update();
                client.ExecuteQuery();
            });
        }

        #endregion

        #region UPDATE

        public Task EditListItem(List<string> columns, List<string> fields, int itemId)
        {
            return Task.Factory.StartNew(() =>
            {
                ListItem editItem = currentList.GetItemById(itemId);
                for (int i = 0; i < columns.Count; i++)
                {
                    editItem[columns[i]] = fields[i];
                }

                editItem.Update();
                client.ExecuteQuery();
            });
        }

        #endregion

        #region DELETE

        public Task RemoveItemFromList(CamlQuery deleteUserQuery)
        {
            return Task.Factory.StartNew(() =>
            {
                ListItemCollection deleteCollection = currentList.GetItems(deleteUserQuery);

                client.Load(deleteCollection);
                client.ExecuteQuery();

                foreach (ListItem item in deleteCollection)
                {
                    item.DeleteObject();
                }
                client.ExecuteQuery();
            });
        }

        public CamlQuery CreateDeleteUserQuery(int id)
        {
            CamlQuery query = new CamlQuery();
            query.ViewXml = string.Format(
                $@"<View><Query><Where><Eq><FieldRef Name='ID'/><Value Type='Text'>{id}</Value></Where></Eq></Query></View>");
            return query;
        }

        #endregion
    }
}
