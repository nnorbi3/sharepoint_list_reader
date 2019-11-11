namespace sp_client
{
    partial class ListSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListSearchForm));
            this.tbSearchedList = new System.Windows.Forms.TextBox();
            this.btSearchList = new System.Windows.Forms.Button();
            this.laSearchList = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.laDivider = new System.Windows.Forms.Label();
            this.laLoading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbSearchedList
            // 
            this.tbSearchedList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearchedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSearchedList.Location = new System.Drawing.Point(35, 93);
            this.tbSearchedList.Name = "tbSearchedList";
            this.tbSearchedList.Size = new System.Drawing.Size(253, 19);
            this.tbSearchedList.TabIndex = 0;
            // 
            // btSearchList
            // 
            this.btSearchList.BackColor = System.Drawing.SystemColors.Highlight;
            this.btSearchList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearchList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btSearchList.ForeColor = System.Drawing.Color.White;
            this.btSearchList.Location = new System.Drawing.Point(35, 143);
            this.btSearchList.Name = "btSearchList";
            this.btSearchList.Size = new System.Drawing.Size(254, 40);
            this.btSearchList.TabIndex = 3;
            this.btSearchList.Text = "Search";
            this.btSearchList.UseVisualStyleBackColor = false;
            this.btSearchList.Click += new System.EventHandler(this.btSearchList_Click);
            // 
            // laSearchList
            // 
            this.laSearchList.BackColor = System.Drawing.Color.White;
            this.laSearchList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.laSearchList.ForeColor = System.Drawing.SystemColors.Highlight;
            this.laSearchList.Location = new System.Drawing.Point(35, 2);
            this.laSearchList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laSearchList.Name = "laSearchList";
            this.laSearchList.Size = new System.Drawing.Size(253, 28);
            this.laSearchList.TabIndex = 28;
            this.laSearchList.Text = "Search for a list";
            this.laSearchList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.White;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btCancel.Location = new System.Drawing.Point(35, 188);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(253, 39);
            this.btCancel.TabIndex = 29;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // laDivider
            // 
            this.laDivider.BackColor = System.Drawing.Color.Gray;
            this.laDivider.Location = new System.Drawing.Point(33, 115);
            this.laDivider.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laDivider.Name = "laDivider";
            this.laDivider.Size = new System.Drawing.Size(255, 2);
            this.laDivider.TabIndex = 30;
            // 
            // laLoading
            // 
            this.laLoading.BackColor = System.Drawing.Color.White;
            this.laLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laLoading.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.laLoading.ForeColor = System.Drawing.SystemColors.Highlight;
            this.laLoading.Location = new System.Drawing.Point(0, 0);
            this.laLoading.Name = "laLoading";
            this.laLoading.Size = new System.Drawing.Size(323, 266);
            this.laLoading.TabIndex = 32;
            this.laLoading.Text = "Loading...";
            this.laLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.laLoading.Visible = false;
            // 
            // ListSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(323, 266);
            this.ControlBox = false;
            this.Controls.Add(this.laLoading);
            this.Controls.Add(this.laDivider);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.laSearchList);
            this.Controls.Add(this.btSearchList);
            this.Controls.Add(this.tbSearchedList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ListSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearchedList;
        private System.Windows.Forms.Button btSearchList;
        private System.Windows.Forms.Label laSearchList;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label laDivider;
        private System.Windows.Forms.Label laLoading;
    }
}