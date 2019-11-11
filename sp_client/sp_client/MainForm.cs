using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using Microsoft.VisualBasic;
using Form = System.Windows.Forms.Form;

namespace sp_client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private SharepointTools tool;
        private LoginForm loginForm;
        private List<int> dgvSPItemIds;
        private List<int> dgvSelectedSPItemIds;
        private List<Column> dataTable;

        private bool state;

        public bool EnableComponents
        {
            get { return state; }
            set
            {
                state = value;
                if (UserConnected())
                {
                    ViewSetup();
                }
                else
                {
                    connectToolStripMenuItem.Enabled = true;
                }

            }
        }

        #region Connected, ViewSetup

        private bool UserConnected()
        {
            return tool.Connected;
        }

        private void ViewSetup()
        {
            if (state)
            {
                userToolStripMenuItem.Text = tool.Username();
                siteToolStripMenuItem.Text = tool.Url();
            }
            else
            {
                userToolStripMenuItem.Text = "";
                siteToolStripMenuItem.Text = "";
                laGetStarted.Visible = !state;
                connectToolStripMenuItem.Enabled = !state;
            }
            bgTemplate.Visible = state;
            listSearchToolStripMenuItem.Enabled = state;
            disconnectToolStripMenuItem.Enabled = state;
            userToolStripMenuItem.Visible = state;
            siteToolStripMenuItem.Visible = state;
            
            menuStrip.Items[1].Enabled = state;
        }

        #endregion

        #region Tools(connect, disconnect, list search)

        public void ConnectToSite(string url, string username, string password)
        {
            tool = new SharepointTools(url, username, password);
            if (tool.ConnectAndAuthenticate())
            {
                tool.Connected = true;
                EnableComponents = true;
                loginForm.Close();
                lbLists.DataSource = tool.ReadListsOnSite();
                SearchList(lbLists.SelectedItem.ToString());
            }
            else
            {
                loginForm.ConnectingFailure();
            }
        }

        public void CancelConnectToSite()
        {
            tool = new SharepointTools();
            tool.Connected = false;
            EnableComponents = false;
            loginForm.Close();
        }

        private void siteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"{siteToolStripMenuItem.Text}");
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginForm = new LoginForm();
            connectToolStripMenuItem.Enabled = false;
            loginForm.Main = this;
            loginForm.Show();
            loginForm.Focus();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            timerRefreshList.Stop();
            EnableComponents = false;
            //connectToolStripMenuItem.Enabled = true;
            //listSearchToolStripMenuItem.Enabled = false;
            //menuStrip.Items[1].Enabled = false;
            //userToolStripMenuItem.Text = "";
            //siteToolStripMenuItem.Text = "";
            //userToolStripMenuItem.Visible = false;
            //siteToolStripMenuItem.Visible = false;
            //bgTemplate.Visible = false;
            dgvDataTable.DataSource = null;
            //laGetStarted.Visible = true;
        }

        private void lbLists_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbLists.SelectedIndex != -1)
            {
                Rectangle selectedItemRectangle = lbLists.GetItemRectangle(lbLists.SelectedIndex);
                if (selectedItemRectangle.Contains(e.Location))
                {
                    laLoading.Visible = true;
                    SearchList(lbLists.SelectedItem.ToString());
                }
            }
        }

        private void listSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForAList();
        }

        private void SearchForAList()
        {
            dgvDataTable.ClearSelection();
            ListSearchForm searchForm = new ListSearchForm();
            searchForm.Main = this;
            searchForm.Show();
            searchForm.Focus();
        }

        public void SearchList(string listName)
        {
            laCurrentList.Text = listName;
            dgvDataTable.ClearSelection();
            tool.SearchedList = listName;
            ShowList();
        }

        #endregion

        #region About(version)

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 0.8", "Version", MessageBoxButtons.OK);
        }

        #endregion

        #region List_show-refresh

        private void ShowList()
        {
            dataTable = tool.ReadList(new CamlQuery());
            if (dataTable != null)
            {
                List<int> selectedRows = GetSelectedRows();
                DisplayUserTable(dataTable);
                ReSelectRowsAfterRefresh(selectedRows);
            }
            else
            {
                SearchForAList();
            }

            laLoading.Visible = false;
        }

        private void ReSelectRowsAfterRefresh(List<int> selectedRows)
        {
            if (dgvDataTable.RowCount != 0)
            {
                dgvDataTable.Rows[0].Selected = false;

                for (int i = 0; i < selectedRows.Count; i++)
                {
                    dgvDataTable.Rows[selectedRows[i]].Selected = true;
                }
            }
        }

        private List<int> GetSelectedRows()
        {
            List<int> selectedRowSPIds = new List<int>();

            for (int i = 0; i < dgvDataTable.SelectedRows.Count; i++)
            {
                selectedRowSPIds.Add(dgvDataTable.SelectedRows[i].Index);
            }

            return selectedRowSPIds;
        }

        private void timerRefreshList_Tick(object sender, EventArgs e)
        {
            laLoading.Visible = true;
            ShowList();
        }

        private void btRefreshList_Click(object sender, EventArgs e)
        {
            laLoading.Visible = true;
            ShowList();
        }

        #endregion

        #region List_refresh_rate_setter

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerRefreshList.Enabled = false;

            timerOff.Checked = true;
            timer10Seconds.Checked = false;
            timer30Seconds.Checked = false;
            timer60Seconds.Checked = false;
            timer2Minutes.Checked = false;
        }

        private void tenSecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerRefreshList.Enabled = true;
            timerRefreshList.Interval = 10000;
            timerRefreshList.Start();

            timerOff.Checked = false;
            timer10Seconds.Checked = true;
            timer30Seconds.Checked = false;
            timer60Seconds.Checked = false;
            timer2Minutes.Checked = false;
        }

        private void thirtySecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerRefreshList.Enabled = true;
            timerRefreshList.Interval = 30000;
            timerRefreshList.Start();

            timerOff.Checked = false;
            timer10Seconds.Checked = false;
            timer30Seconds.Checked = true;
            timer60Seconds.Checked = false;
            timer2Minutes.Checked = false;
        }

        private void sixtySecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerRefreshList.Enabled = true;
            timerRefreshList.Interval = 60000;
            timerRefreshList.Start();

            timerOff.Checked = false;
            timer10Seconds.Checked = false;
            timer30Seconds.Checked = false;
            timer60Seconds.Checked = true;
            timer2Minutes.Checked = false;
        }

        private void twoMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerRefreshList.Enabled = true;
            timerRefreshList.Interval = 120000;
            timerRefreshList.Start();

            timerOff.Checked = false;
            timer10Seconds.Checked = false;
            timer30Seconds.Checked = false;
            timer60Seconds.Checked = false;
            timer2Minutes.Checked = true;
        }

        #endregion

        #region DataGrid_show-setup

        private void DisplayUserTable(List<Column> columns)
        {
            dgvSPItemIds = new List<int>();
            DataTable dt = new DataTable();
            for (int i = 0; i < columns.Count; i++)
            {
                dt.Columns.Add(columns[i].ColumnName);
            }

            for (int i = 0; i < columns[0].ColumnFields.Count; i++)
            {
                string[] newRow = new string[columns.Count];
                int j = 0;
                dgvSPItemIds.Add(columns[j].ColumnFields[i].FieldId);
                while (j < columns.Count)
                {
                    if (columns[j].ColumnFields[i].FieldValue != null)
                    {
                        newRow[j] = columns[j].ColumnFields[i].FieldValue;
                    }
                    else
                    {
                        newRow[j] = null;
                    }
                    j++;
                }

                dt.Rows.Add(newRow);
            }

            DataGridSetup(dgvDataTable, dt);
            bgTemplate.Visible = true;
        }

        public void DataGridSetup(DataGridView dgv, DataTable dataSource)
        {
            dgv.DataSource = dataSource;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(94, 91, 100);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 13, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.MultiSelect = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].DisplayIndex = i;
            }
        }

        #endregion

        #region Add_list_item

        private void btAddItemToList_Click(object sender, EventArgs e)
        {
            AddListItemForm itemForm = new AddListItemForm();
            itemForm.Main = this;
            itemForm.Show();
            itemForm.Focus();
        }

        public List<Column> GetInputFormData()
        {
            List<Column> formData = new List<Column>();

            for (int i = 0; i < dataTable.Count; i++)
            {
                Column temp = new Column();
                temp.ColumnName = dataTable[i].ColumnName;
                temp.ColumnStaticName = dataTable[i].ColumnStaticName;
                temp.ColumnType = dataTable[i].ColumnType;
                temp.ColumnMultipleValues = dataTable[i].ColumnMultipleValues;
                formData.Add(temp);
            }

            return formData;
        }

        public void NewItem(List<string> columns, List<string> fields)
        {
            tool.AddItemToList(columns, fields);
            ShowList();
        }

        #endregion

        #region Edit_list_item

        private void btEditSelectedRow_Click(object sender, EventArgs e)
        {
            if (dgvDataTable.SelectedRows.Count == 1)
            {
                EditListItemForm editForm = new EditListItemForm();
                editForm.Main = this;
                editForm.Show();
                editForm.Focus();
            }
            else
            {
                if (dgvDataTable.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Only one item can be selected for editing!", "Alert", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("No items selected!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public List<string> GetSelectedRowData()
        {
            List<string> editRow = new List<string>();

            for (int i = 0; i < dgvDataTable.SelectedRows[0].Cells.Count; i++)
            {
                editRow.Add(dgvDataTable.SelectedRows[0].Cells[i].Value.ToString());
            }

            editRow.Add(dgvSPItemIds[dgvDataTable.SelectedRows[0].Index].ToString());

            return editRow;
        }

        public void EditSelectedListItem(List<string> columns, List<string> fields, int itemId)
        {
            tool.EditListItem(columns, fields, itemId);
            ShowList();
        }

        #endregion

        #region Delete_list_items

        private void btRemoveItemFromList_Click(object sender, EventArgs e)
        {
            if (dgvDataTable.SelectedRows.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show(
                    $"Are you sure you want do delete {dgvDataTable.SelectedRows.Count} item(s)?", "Alert",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    laLoading.Visible = true;
                    List<int> deleteList = CreateDeleteList();
                    for (int i = 0; i < deleteList.Count; i++)
                    {
                        CamlQuery query = tool.CreateDeleteUserQuery(deleteList[i]);
                        tool.RemoveItemFromList(query);
                    }

                    dgvDataTable.ClearSelection();
                    ShowList();
                }
            }
            else
            {
                MessageBox.Show("No items selected!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<int> CreateDeleteList()
        {
            List<int> deleteList = new List<int>();
            for (int i = 0; i < dgvDataTable.SelectedRows.Count; i++)
            {
                deleteList.Add(dgvSPItemIds[dgvDataTable.SelectedRows[i].Index]);
            }

            return deleteList;
        }

        #endregion

        #region Filter_list_item

        public List<string> GetFilterColumns()
        {
            List<string> columns = new List<string>();
            for (int i = 0; i < dataTable.Count; i++)
            {
                columns.Add(dataTable[i].ColumnName);
            }

            return columns;
        }

        public DataTable SetFilterDataSource(int columnId)
        {
            DataTable dataSource = new DataTable();
            for (int i = 0; i < dgvDataTable.ColumnCount; i++)
            {
                dataSource.Columns.Add(dgvDataTable.Columns[i].Name);
            }

            for (int i = 0; i < dgvDataTable.RowCount; i++)
            {
                if (dgvDataTable.Rows[i].Cells[columnId].Value.ToString() ==
                    dgvDataTable.SelectedRows[0].Cells[columnId].Value.ToString())
                {
                    string[] row = new string[dgvDataTable.ColumnCount];
                    for (int j = 0; j < dgvDataTable.ColumnCount; j++)
                    {
                        row[j] = dgvDataTable.Rows[i].Cells[j].Value.ToString();
                    }

                    dataSource.Rows.Add(row);
                }
            }

            return dataSource;
        }

        private void btFilterForSelectedItem_Click(object sender, EventArgs e)
        {
            if (dgvDataTable.SelectedRows.Count == 1)
            {
                FilteredListForm filterForm = new FilteredListForm();
                filterForm.Main = this;
                filterForm.Show();
                filterForm.Focus();
            }
            else
            {
                if (dgvDataTable.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Only one item can be selected for filtering!", "Alert", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("No items selected!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion


    }
}
