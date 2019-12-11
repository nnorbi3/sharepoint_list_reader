using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace sp_client
{
    public partial class LoginForm : Form
    {
        public MainForm Main { get; set; }

        private string defaultUrl;

        private string defaultUn;

        private string defaultPw;

        private bool rememberMe;

        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            tbPassword.BackColor = Color.White;
            tbUsername.BackColor = Color.White;
            tbUrl.BackColor = Color.White;
            cbRememberMe.BackColor = Color.White;

            InitUserData();
            FillData(tbUrl, defaultUrl);
            FillData(tbUsername, defaultUn);
            FillData(tbPassword, defaultPw);
        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            if (InputCheck())
            {
                laLoading.Visible = true;
                Main.ConnectToSite(tbUrl.Text, tbUsername.Text, tbPassword.Text);
                FormClosed += LoginForm_FormClosed;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            laLoading.Visible = false;
        }

        public void LoadingVisibleFalse()
        {
            laLoading.Visible = false;
        }

        private void InitUserData()
        {
            defaultUrl = Properties.Settings.Default.URL;
            defaultUn = Properties.Settings.Default.Username;
            defaultPw = Properties.Settings.Default.Password;
            rememberMe = Properties.Settings.Default.RememberMe;
            if (rememberMe) cbRememberMe.Checked = true;
        }

        private void FillData(Control tb, string text)
        {
            tb.Text = text;
            tb.ForeColor = Color.Black;
        }

        private bool InputCheck()
        {
            if (tbPassword.Text == "" || tbUrl.Text == "")
            {
                Alert();
                return false;
            }

            if (cbRememberMe.Checked)
            {
                Properties.Settings.Default.URL = tbUrl.Text;
                Properties.Settings.Default.Username = tbUsername.Text;
                Properties.Settings.Default.Password = tbPassword.Text;
                Properties.Settings.Default.RememberMe = true;
            }
            else
            {
                Properties.Settings.Default.URL = "";
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.RememberMe = false;
            }
            Properties.Settings.Default.Save();

            return true;
        }

        private void Alert()
        {
            MessageBox.Show("All fields must be filled!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Main.CancelConnection();
        }
    }
}
