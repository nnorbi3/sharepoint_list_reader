using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exceptions;
using Logic;
using Microsoft.SharePoint.Client;
using Microsoft.VisualBasic;
using Form = System.Windows.Forms.Form;

namespace sp_client
{
    public partial class MainForm : Form
    {
        private SharepointLogic logic;

        private LoginForm loginForm;

        private List<int> dgvSPItemIds;

        private List<int> dgvSelectedSPItemIds;

        private List<Column> dataTable;

        public MainForm()
        {
            InitializeComponent();
        }

        public void EnableComponents(bool enable)
        {
            if (logic.Connected)
            {
                ViewSetup(enable);
            }
        }

        #region Connected, ViewSetup

        private void ViewSetup(bool enable)
        {
            if (enable)
            {
                userToolStripMenuItem.Text = logic.GetUsername();
                siteToolStripMenuItem.Text = logic.GetURL();
                DataGridSetup(dgvDataTable);
            }
            else
            {
                userToolStripMenuItem.Text = "";
                siteToolStripMenuItem.Text = "";
                connectToolStripMenuItem.Enabled = false;
            }
            bgTemplate.Visible = enable;
            disconnectToolStripMenuItem.Enabled = enable;
            userToolStripMenuItem.Visible = enable;
            siteToolStripMenuItem.Visible = enable;

            menuStrip.Items[1].Enabled = enable;
        }

        #endregion

        #region Tools(connect, disconnect, list search)

        public void ConnectToSite(string URL, string username, string password)
        {
            logic = new SharepointLogic(URL, username, password);

            try
            {
                logic.ConnectAndAuthenticate();
                logic.Connected = true;
                EnableComponents(true);
                loginForm.Close();
                lbLists.DataSource = logic.GetListNames();
                SearchList(lbLists.SelectedItem.ToString());
            }
            catch (Error e)
            {
                MessageBox.Show(e.Message, e.Type.ToString(),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                loginForm.LoadingVisibleFalse();
            }
        }

        public void CancelConnection()
        {
            loginForm.Close();
        }

        private void siteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start($"{siteToolStripMenuItem.Text}");
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginForm = new LoginForm();
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
            EnableComponents(false);
            connectToolStripMenuItem.Enabled = true;
            dgvDataTable.DataSource = null;
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

        public void SearchList(string listName)
        {
            laCurrentList.Text = listName;
            dgvDataTable.ClearSelection();
            logic.CurrentListTitle = listName;
            ShowList();
        }

        #endregion

        #region About(version)

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0", "Version", MessageBoxButtons.OK);
        }

        #endregion

        #region List_show-refresh

        private async void ShowList()
        {
            await Task.Factory.StartNew(() =>
            {
                dataTable = logic.ReadList(new CamlQuery());
            });
            if (dataTable != null)
            {
                List<int> selectedRows = GetSelectedRows();
                DisplayUserTable(dataTable);
                ReSelectRowsAfterRefresh(selectedRows);
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

        private async void timerRefreshList_Tick(object sender, EventArgs e)
        {
            laLoading.Visible = true;
            ShowList();
        }

        private async void btRefreshList_Click(object sender, EventArgs e)
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

            SetDataGridSource(dgvDataTable, dt);
            bgTemplate.Visible = true;
        }

        public void SetDataGridSource(DataGridView dgv, DataTable dataSource)
        {
            dgv.DataSource = dataSource;
        }

        public void DataGridSetup(DataGridView dgv)
        {
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

        public async void NewItem(List<string> columns, List<string> fields)
        {
            await logic.AddItemToList(columns, fields);
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

        public async void EditSelectedListItem(List<string> columns, List<string> fields, int itemId)
        {
            await logic.EditListItem(columns, fields, itemId);
            ShowList();
        }

        #endregion

        #region Delete_list_items

        private async void btRemoveItemFromList_Click(object sender, EventArgs e)
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
                        CamlQuery query = logic.CreateDeleteUserQuery(deleteList[i]);
                        await logic.RemoveItemFromList(query);
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
