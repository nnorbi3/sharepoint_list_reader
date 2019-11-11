namespace sp_client
{
    partial class FilteredListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilteredListForm));
            this.dgvFilteredList = new System.Windows.Forms.DataGridView();
            this.btClose = new System.Windows.Forms.Button();
            this.cbColumns = new System.Windows.Forms.ComboBox();
            this.btSubmit = new System.Windows.Forms.Button();
            this.laFilterFor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilteredList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFilteredList
            // 
            this.dgvFilteredList.AllowUserToAddRows = false;
            this.dgvFilteredList.AllowUserToDeleteRows = false;
            this.dgvFilteredList.AllowUserToResizeColumns = false;
            this.dgvFilteredList.AllowUserToResizeRows = false;
            this.dgvFilteredList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFilteredList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvFilteredList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFilteredList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilteredList.Location = new System.Drawing.Point(13, 52);
            this.dgvFilteredList.Name = "dgvFilteredList";
            this.dgvFilteredList.RowHeadersVisible = false;
            this.dgvFilteredList.Size = new System.Drawing.Size(672, 385);
            this.dgvFilteredList.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.White;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btClose.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btClose.Location = new System.Drawing.Point(13, 488);
            this.btClose.Margin = new System.Windows.Forms.Padding(4);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(671, 36);
            this.btClose.TabIndex = 16;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // cbColumns
            // 
            this.cbColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColumns.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbColumns.FormattingEnabled = true;
            this.cbColumns.Location = new System.Drawing.Point(340, 9);
            this.cbColumns.Name = "cbColumns";
            this.cbColumns.Size = new System.Drawing.Size(166, 29);
            this.cbColumns.TabIndex = 17;
            // 
            // btSubmit
            // 
            this.btSubmit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btSubmit.ForeColor = System.Drawing.Color.White;
            this.btSubmit.Location = new System.Drawing.Point(13, 444);
            this.btSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(672, 37);
            this.btSubmit.TabIndex = 18;
            this.btSubmit.Text = "Submit";
            this.btSubmit.UseVisualStyleBackColor = false;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // laFilterFor
            // 
            this.laFilterFor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.laFilterFor.ForeColor = System.Drawing.SystemColors.Highlight;
            this.laFilterFor.Location = new System.Drawing.Point(207, 8);
            this.laFilterFor.Name = "laFilterFor";
            this.laFilterFor.Size = new System.Drawing.Size(127, 29);
            this.laFilterFor.TabIndex = 19;
            this.laFilterFor.Text = "Filter for:";
            // 
            // FilteredListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 537);
            this.ControlBox = false;
            this.Controls.Add(this.laFilterFor);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.cbColumns);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.dgvFilteredList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FilteredListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FilteredListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilteredList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFilteredList;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ComboBox cbColumns;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.Label laFilterFor;
    }
}