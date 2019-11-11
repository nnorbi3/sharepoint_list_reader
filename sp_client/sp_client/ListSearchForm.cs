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
    public partial class ListSearchForm : Form
    {
        public ListSearchForm()
        {
            InitializeComponent();
        }

        private MainForm main;

        public MainForm Main
        {
            get { return main; }
            set { main = value; }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSearchList_Click(object sender, EventArgs e)
        {
            laLoading.Visible = true;
            main.SearchList(tbSearchedList.Text);
            this.Close();
        }
    }
}
