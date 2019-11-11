using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint;
using View = System.Windows.Forms.View;

namespace sp_client
{
    class SharepointTools
    {
        //https://diakoffice.sharepoint.com/sites/clientapptest2
        private string url;
        private string username;
        private SecureString password;

        public string SearchedList { get; set; }

        private ClientContext client;
        private List list;
        public bool Connected { get; set; }


        public SharepointTools()
        {
        }

        public SharepointTools(string url, string username, string password)
        {
            this.url = url;
            this.username = username;
            this.password = new SecureString();
            foreach (char c in password)
            {
                this.password.AppendChar(c);
            }
        }

        public string Url()
        {
            return this.url;
        }

        public string Username()
        {
            return this.username;
        }

        private void TrimContext()
        {
            this.url.Trim();
            this.username.Trim();
        }

        #region Connection_establishment_and_setup

        public bool ConnectAndAuthenticate()
        {
            TrimContext();
            try
            {
                client = new ClientContext(this.url);

                try
                {
                    try
                    {
                        client.Credentials =
                            new SharePointOnlineCredentials(this.username, this.password); //online login
                        client.ExecuteQuery();
                    }
                    catch (NotSupportedException)
                    {
                        client.Credentials =
                            new NetworkCredential(this.username, this.password); //on-premise(local) login
                        client.ExecuteQuery();
                    }

                }
                catch (ClientRequestException)
                {
                    MessageBox.Show("Something went wrong. Check your credentials", "Authentication error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                catch (IdcrlException)
                {
                    MessageBox.Show("Incorrect username or password", "Authentication error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Incorrect username. Username must be an e-mail address", "Authentication error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                catch (WebException)
                {
                    MessageBox.Show("Something went wrong. Check your credentials", "Authentication error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Requested site not found.", "Invalid URL", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }



            return true;
        }

        public List<string> ReadListsOnSite()
        {
            List<string> lists = new List<string>();
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
                    lists.Add(l.Title);
                }
            }

            return lists;
        }

        #endregion

        #region Read_list

        public List<ColumnField> ReadLookupListValues(string columnName)
        {
            List<ColumnField> lookupValueList = new List<ColumnField>();

            list = client.Web.Lists.GetByTitle(SearchedList);
            Field field = list.Fields.GetByInternalNameOrTitle(columnName); //field = column
            FieldLookup lookupField = client.CastTo<FieldLookup>(field);
            client.Load(lookupField);
            client.ExecuteQuery();
            Guid lookupListId = new Guid(lookupField.LookupList); //returns associated list id

            //Retrieve associated List
            List lookupList = client.Web.Lists.GetById(lookupListId);
            ListItemCollection lookupValuesColl = lookupList.GetItems(new CamlQuery());
            client.Load(lookupList);
            client.Load(lookupValuesColl);
            client.ExecuteQuery();

            foreach (ListItem item in lookupValuesColl)
            {
                ColumnField temp = new ColumnField();
                temp.FieldValue = item[columnName].ToString();
                temp.FieldId = int.Parse(item["ID"].ToString());
                lookupValueList.Add(temp);
            }

            return lookupValueList;
        }

        #region Read_field_values

        private void ReadLookupValues(ListItemCollection fieldCollection, ref Column column)
        {
            foreach (ListItem item in fieldCollection)
            {
                ColumnField columnField = new ColumnField();

                columnField.FieldId = int.Parse(item["ID"].ToString());
                if (item[column.ColumnStaticName] != null)
                {
                    FieldLookupValue value = (FieldLookupValue)item[column.ColumnStaticName];
                    columnField.FieldValue = value.LookupValue;
                }
                else
                {
                    columnField.FieldValue = null;
                }
                column.ColumnFields.Add(columnField);
            }
        }

        private void ReadTextValues(ListItemCollection fieldCollection, ref Column column)
        {
            foreach (ListItem item in fieldCollection)
            {
                ColumnField columnField = new ColumnField();

                columnField.FieldId = int.Parse(item["ID"].ToString());
                if (item[column.ColumnStaticName] != null)
                {
                    if (item[column.ColumnStaticName] is DateTime)
                    {
                        columnField.FieldValue = ((DateTime)item[column.ColumnStaticName]).ToString("yyyy.MM.dd");
                    }
                    else
                    {
                        columnField.FieldValue = item[column.ColumnStaticName].ToString();
                    }

                }
                else
                {
                    columnField.FieldValue = null;
                }
                column.ColumnFields.Add(columnField);
            }
        }

        private List<ColumnField> ReadMultiChoiceValues(Field field, ref Column column)
        {
            FieldChoice choiceField = (FieldChoice)field;
            List<ColumnField> multiChoiceValues = new List<ColumnField>();
            foreach (string str in choiceField.Choices)
            {
                ColumnField choice = new ColumnField();
                choice.FieldValue = str;
                multiChoiceValues.Add(choice);
            }

            return multiChoiceValues;
        }

        #endregion

        public List<Column> ReadList(CamlQuery qry)
        {
            try
            {
                List<Column> columns = new List<Column>();
                list = client.Web.Lists.GetByTitle(SearchedList);
                FieldCollection colCollection = list.Fields;
                ListItemCollection fieldCollection = list.GetItems(qry);
                client.Load(fieldCollection);
                client.Load(colCollection);
                client.ExecuteQuery();

                foreach (Field field in colCollection)
                {
                    if (field.Required || !field.Hidden && field.CanBeDeleted)
                    {
                        Column newColumn = new Column();
                        newColumn.ColumnName = field.Title;
                        newColumn.ColumnStaticName = field.StaticName;
                        newColumn.ColumnFields = new List<ColumnField>();

                        switch (field.FieldTypeKind)
                        {
                            case FieldType.Lookup:
                                newColumn.ColumnMultipleValues = ReadLookupListValues(field.StaticName);
                                newColumn.ColumnType = typeof(FieldLookupValue);
                                ReadLookupValues(fieldCollection, ref newColumn);
                                break;
                            case FieldType.Text:
                                newColumn.ColumnType = typeof(string);
                                ReadTextValues(fieldCollection, ref newColumn);
                                break;
                            case FieldType.Boolean:
                                newColumn.ColumnType = typeof(bool);
                                ReadTextValues(fieldCollection, ref newColumn);
                                break;
                            case FieldType.DateTime:
                                newColumn.ColumnType = typeof(DateTime);
                                ReadTextValues(fieldCollection, ref newColumn);
                                break;
                            case FieldType.Choice:
                                newColumn.ColumnType = typeof(FieldChoice);
                                ReadTextValues(fieldCollection, ref newColumn);
                                newColumn.ColumnMultipleValues = ReadMultiChoiceValues(field, ref newColumn);
                                break;
                        }

                        columns.Add(newColumn);
                    }
                }

                return columns;
            }
            catch (WebException)
            {
                MessageBox.Show("Couldn't reach site. Try again later", "Connection error", MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
                return null;
            }
            catch (ServerException)
            {
                MessageBox.Show($"Can't find list '{SearchedList}'", "Search error", MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
                return null;
            }
            catch (PropertyOrFieldNotInitializedException)
            {
                MessageBox.Show("Unable to load items", "Initialization error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        #endregion

        #region Add_item

        public void AddItemToList(List<string> columns, List<string> fields)
        {
            ListItemCreationInformation listInfo = new ListItemCreationInformation();
            ListItem newListItem = list.AddItem(listInfo);
            for (int i = 0; i < columns.Count; i++)
            {
                newListItem[columns[i]] = fields[i];
            }
            newListItem.Update();
            client.ExecuteQuery();
        }

        #endregion

        #region Remove_item

        public void RemoveItemFromList(CamlQuery deleteUserQuery)
        {
            ListItemCollection deleteCollection = list.GetItems(deleteUserQuery);

            client.Load(deleteCollection);
            client.ExecuteQuery();

            foreach (ListItem item in deleteCollection)
            {
                item.DeleteObject();
            }
            client.ExecuteQuery();
        }

        public CamlQuery CreateDeleteUserQuery(int id)
        {
            CamlQuery query = new CamlQuery();
            query.ViewXml = string.Format(
                $@"<View><Query><Where><Eq><FieldRef Name='ID'/><Value Type='Text'>{id}</Value></Where></Eq></Query></View>");
            return query;
        }

        #endregion

        #region Edit_item

        public void EditListItem(List<string> columns, List<string> fields, int itemId)
        {
            ListItem editItem = list.GetItemById(itemId);
            for (int i = 0; i < columns.Count; i++)
            {
                editItem[columns[i]] = fields[i];
            }
            editItem.Update();
            client.ExecuteQuery();
        }

        #endregion

    }
}
