namespace sp_client
{
    partial class AddListItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddListItemForm));
            this.btSubmit = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.laAddNewItem = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btSubmit
            // 
            this.btSubmit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btSubmit.ForeColor = System.Drawing.Color.White;
            this.btSubmit.Location = new System.Drawing.Point(152, 383);
            this.btSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(269, 36);
            this.btSubmit.TabIndex = 14;
            this.btSubmit.Text = "Submit";
            this.btSubmit.UseVisualStyleBackColor = false;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btCancel.Location = new System.Drawing.Point(152, 427);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(269, 36);
            this.btCancel.TabIndex = 15;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // laAddNewItem
            // 
            this.laAddNewItem.BackColor = System.Drawing.Color.White;
            this.laAddNewItem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.laAddNewItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.laAddNewItem.Location = new System.Drawing.Point(13, 0);
            this.laAddNewItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laAddNewItem.Name = "laAddNewItem";
            this.laAddNewItem.Size = new System.Drawing.Size(546, 28);
            this.laAddNewItem.TabIndex = 18;
            this.laAddNewItem.Text = "New Item";
            this.laAddNewItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControls
            // 
            this.panelControls.AutoScroll = true;
            this.panelControls.BackColor = System.Drawing.Color.White;
            this.panelControls.Location = new System.Drawing.Point(12, 31);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(548, 336);
            this.panelControls.TabIndex = 30;
            // 
            // AddListItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(572, 495);
            this.ControlBox = false;
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.laAddNewItem);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddListItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.NewListItemForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label laAddNewItem;
        private System.Windows.Forms.Panel panelControls;
    }
}