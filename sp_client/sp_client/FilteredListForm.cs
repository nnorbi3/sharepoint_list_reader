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
    public partial class FilteredListForm : Form
    {
        public FilteredListForm()
        {
            InitializeComponent();
        }

        private MainForm main;

        public MainForm Main
        {
            get { return main; }
            set { main = value; }
        }

        private void FilteredListForm_Load(object sender, EventArgs e)
        {
            cbColumns.DataSource = main.GetFilterColumns();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            main.DataGridSetup(dgvFilteredList,main.SetFilterDataSource(cbColumns.SelectedIndex));
        }
    }
}
