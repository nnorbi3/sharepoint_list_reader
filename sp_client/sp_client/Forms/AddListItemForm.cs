﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.WebControls;
using Microsoft.VisualBasic;
using sp_client.Interfaces;
using Form = System.Windows.Forms.Form;

namespace sp_client
{
    public partial class AddListItemForm : Form, IForm
    {
        public AddListItemForm()
        {
            InitializeComponent();
        }

        public MainForm Main { get; set; }
        private List<Column> formData;
        private List<Control> controlsList;

        private void NewListItemForm_Load(object sender, EventArgs e)
        {
            formData = Main.GetInputFormData();
            InputFormFactory.FormSetup(panelControls, formData, out controlsList);
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            List<string> columns = new List<string>();
            List<string> fields = new List<string>();
            bool filled = true;

            InputFormFactory.CreateInputForm(formData, controlsList, ref columns, ref fields, ref filled);

            if (filled)
            {
                Main.NewItem(columns, fields);
                this.Close();
            }
            else
            {
                Main.DisplayErrorMessage(new Exceptions.Error(Exceptions.ErrorType.Alert, "All fields must be filled!"));
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
