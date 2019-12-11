using Logic;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sp_client
{
    public static class InputFormFactory
    {
        public static void CreateInputForm(List<Column> formData, List<Control> controlsList,
           ref List<string> columns, ref List<string> fields, ref bool filled)
        {
            foreach (Column column in formData)
            {
                columns.Add(column.ColumnStaticName);
            }

            for (int i = 0; i < controlsList.Count; i++)
            {
                if (controlsList[i].GetType() == typeof(RichTextBox) && controlsList[i].Text != "")
                {
                    fields.Add(controlsList[i].Text);
                }
                else if (controlsList[i].GetType() == typeof(ComboBox))
                {
                    int j = 0;
                    bool l = true;
                    while (l && j < formData[i].ColumnMultipleValues.Count)
                    {
                        if (controlsList[i].Text == formData[i].ColumnMultipleValues[j].FieldValue)
                        {
                            if (formData[i].ColumnType == typeof(FieldLookupValue))
                            {
                                fields.Add(formData[i].ColumnMultipleValues[j].FieldId.ToString());
                            }
                            else
                            {
                                fields.Add(formData[i].ColumnMultipleValues[j].FieldValue);
                            }
                            l = false;
                        }

                        j++;
                    }
                }
                else if (controlsList[i].GetType() == typeof(CheckBox))
                {
                    int value = ((CheckBox)controlsList[i]).Checked ? 1 : 0;
                    fields.Add(value.ToString());
                }
                else if (controlsList[i].GetType() == typeof(DateTimePicker))
                {
                    DateTime date = ((DateTimePicker)controlsList[i]).Value;
                    fields.Add(date.ToString());
                }
            }

            int k = 0;
            while (k < controlsList.Count)
            {
                if (controlsList[k].GetType() == typeof(RichTextBox) && controlsList[k].Text == "")
                {
                    filled = false;
                }

                k++;
            }
        }


        public static void FormSetup(Panel panelControls, List<Column> formData, out List<Control> controlsList, List<string> editRow = null)
        {
            int top = 1;

            controlsList = new List<Control>();
            for (int i = 0; i < formData.Count; i++)
            {
                AddLabel(panelControls, formData[i].ColumnName, top);

                if (formData[i].ColumnType == typeof(string))
                {
                    AddTextBox(panelControls, editRow, ref controlsList, top, i);
                }
                else if (formData[i].ColumnType == typeof(FieldLookupValue) || formData[i].ColumnType == typeof(FieldChoice))
                {
                    AddComboBox(panelControls, formData, editRow, ref controlsList, top, i);
                }
                else if (formData[i].ColumnType == typeof(bool))
                {
                    AddCheckBox(panelControls, editRow, ref controlsList, top, i);
                }
                else if (formData[i].ColumnType == typeof(DateTime))
                {
                    AddDatePicker(panelControls, ref controlsList, top);
                }

                top++;
            }
        }

        #region AddControl

        private static void AddLabel(Panel panelControls, string columnName, int top)
        {
            Label la = new Label();
            panelControls.Controls.Add(la);
            LabelSetup(la, top, columnName);
        }

        private static void AddTextBox(Panel panelControls, List<string> editRow, ref List<Control> controlsList, int top,
            int index)
        {
            RichTextBox tb = new RichTextBox();
            panelControls.Controls.Add(tb);
            TextBoxSetup(tb, top);
            if (editRow != null) tb.Text = editRow[index];
            controlsList.Add(tb);

            Label divider = new Label();
            panelControls.Controls.Add(divider);
            DividerSetup(divider, tb);
        }

        private static void AddComboBox(Panel panelControls, List<Column> formData, List<string> editRow,
            ref List<Control> controlsList, int top, int index)
        {
            ComboBox cb = new ComboBox();
            panelControls.Controls.Add(cb);
            cb.DataSource = formData[index].ColumnMultipleValues.Select(x => x.FieldValue).ToList();
            ComboBoxSetup(cb, top);
            if (editRow != null) cb.Text = editRow[index];
            controlsList.Add(cb);
        }

        private static void AddCheckBox(Panel panelControls, List<string> editRow, ref List<Control> controlsList, int top, int index)
        {
            CheckBox chB = new CheckBox();
            panelControls.Controls.Add(chB);
            SetControlPosition(chB, top);
            if (editRow != null)
                chB.Checked = editRow[index] == "True";
            controlsList.Add(chB);
        }

        private static void AddDatePicker(Panel panelControls, ref List<Control> controlsList, int top)
        {
            DateTimePicker dt = new DateTimePicker();
            panelControls.Controls.Add(dt);
            SetControlPosition(dt, top);
            dt.Format = DateTimePickerFormat.Short;
            controlsList.Add(dt);
        }

        #endregion

        #region ControlSetup

        private static void SetControlPosition(Control control, int top)
        {
            control.Top = top * 50;
            control.Left = 200;
        }

        private static void ComboBoxSetup(ComboBox cb, int top)
        {
            SetControlPosition(cb, top);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private static void LabelSetup(Label la, int top, string columnName)
        {
            la.Top = top * 50;
            la.Left = 100;
            la.Text = columnName;
            la.AutoSize = false;
            la.Size = new Size(90, 20);
            la.BackColor = Color.White;
            la.ForeColor = Color.Black;
            la.Font = new Font("Segoe UI", (float)9.75, FontStyle.Bold);
        }

        private static void TextBoxSetup(RichTextBox tb, int top)
        {
            SetControlPosition(tb, top);
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
            tb.Size = new Size(197, 17);
            tb.Multiline = false;
            tb.BorderStyle = BorderStyle.None;
            tb.Font = new Font("Arial", (float)9.75);
        }

        private static void DividerSetup(Label divider, RichTextBox tb)
        {
            divider.Top = tb.Top + tb.Height + 5;
            divider.Left = tb.Left;
            divider.Size = new Size(197, 2);
            divider.BackColor = SystemColors.Highlight;
        }

        #endregion
    }
}
