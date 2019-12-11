namespace sp_client
{
    partial class EditListItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditListItemForm));
            this.btCancel = new System.Windows.Forms.Button();
            this.btSubmit = new System.Windows.Forms.Button();
            this.laEditItem = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            this.SuspendLayout();
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
            this.btCancel.TabIndex = 24;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
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
            this.btSubmit.TabIndex = 23;
            this.btSubmit.Text = "Submit";
            this.btSubmit.UseVisualStyleBackColor = false;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // laEditItem
            // 
            this.laEditItem.BackColor = System.Drawing.Color.White;
            this.laEditItem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.laEditItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.laEditItem.Location = new System.Drawing.Point(13, 0);
            this.laEditItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laEditItem.Name = "laEditItem";
            this.laEditItem.Size = new System.Drawing.Size(546, 28);
            this.laEditItem.TabIndex = 27;
            this.laEditItem.Text = "Edit Item";
            this.laEditItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControls
            // 
            this.panelControls.AutoScroll = true;
            this.panelControls.BackColor = System.Drawing.Color.White;
            this.panelControls.Location = new System.Drawing.Point(12, 31);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(548, 336);
            this.panelControls.TabIndex = 29;
            // 
            // EditListItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(572, 495);
            this.ControlBox = false;
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.laEditItem);
            this.Controls.Add(this.panelControls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditListItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.EditListItemForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.Label laEditItem;
        private System.Windows.Forms.Panel panelControls;
    }
}