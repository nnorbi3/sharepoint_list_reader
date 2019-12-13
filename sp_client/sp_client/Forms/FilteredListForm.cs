using sp_client.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sp_client
{
    public partial class FilteredListForm : Form, IForm
    {
        public FilteredListForm()
        {
            InitializeComponent();
        }

        public MainForm Main { get; set; }

        private void FilteredListForm_Load(object sender, EventArgs e)
        {
            cbColumns.DataSource = Main.GetFilterColumns();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            Main.SetDataGridSource(dgvFilteredList, Main.SetFilterDataSource(cbColumns.SelectedIndex));
        }
    }
}
