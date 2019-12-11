using Logic;
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
    public partial class EditListItemForm : Form
    {
        public MainForm Main { get; set; }
        private List<Column> formData;
        private List<Label> labels;
        private List<Control> controlsList;
        private List<string> editRow;

        public EditListItemForm()
        {
            InitializeComponent();
        }

        private void EditListItemForm_Load(object sender, EventArgs e)
        {
            formData = Main.GetInputFormData();
            editRow = Main.GetSelectedRowData();
            InputFormFactory.FormSetup(panelControls, formData, out controlsList, editRow);
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            List<string> columns = new List<string>();
            List<string> fields = new List<string>();
            bool filled = true;
            int itemId = int.Parse(editRow[editRow.Count - 1]);

            InputFormFactory.CreateInputForm(formData, controlsList, ref columns, ref fields, ref filled);

            if (filled)
            {
                Main.EditSelectedListItem(columns, fields, itemId);
                this.Close();
            }
            else
            {
                MessageBox.Show("All fields must be filled!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
