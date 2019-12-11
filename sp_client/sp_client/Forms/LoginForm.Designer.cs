namespace sp_client
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.laDivider1 = new System.Windows.Forms.Label();
            this.btConnect = new System.Windows.Forms.Button();
            this.cbRememberMe = new System.Windows.Forms.CheckBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.laDivider2 = new System.Windows.Forms.Label();
            this.laDivider3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.laLoading = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.RichTextBox();
            this.tbUsername = new System.Windows.Forms.RichTextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // laDivider1
            // 
            this.laDivider1.BackColor = System.Drawing.SystemColors.Highlight;
            this.laDivider1.Location = new System.Drawing.Point(60, 196);
            this.laDivider1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laDivider1.Name = "laDivider1";
            this.laDivider1.Size = new System.Drawing.Size(569, 2);
            this.laDivider1.TabIndex = 4;
            // 
            // btConnect
            // 
            this.btConnect.BackColor = System.Drawing.SystemColors.Highlight;
            this.btConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConnect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btConnect.ForeColor = System.Drawing.Color.White;
            this.btConnect.Location = new System.Drawing.Point(17, 383);
            this.btConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(612, 38);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = false;
            this.btConnect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // cbRememberMe
            // 
            this.cbRememberMe.AutoSize = true;
            this.cbRememberMe.BackColor = System.Drawing.Color.White;
            this.cbRememberMe.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbRememberMe.ForeColor = System.Drawing.Color.Black;
            this.cbRememberMe.Location = new System.Drawing.Point(30, 329);
            this.cbRememberMe.Name = "cbRememberMe";
            this.cbRememberMe.Size = new System.Drawing.Size(162, 29);
            this.cbRememberMe.TabIndex = 7;
            this.cbRememberMe.Text = "Remember me";
            this.cbRememberMe.UseVisualStyleBackColor = false;
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btCancel.Location = new System.Drawing.Point(18, 430);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(611, 36);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // laDivider2
            // 
            this.laDivider2.BackColor = System.Drawing.SystemColors.Highlight;
            this.laDivider2.Location = new System.Drawing.Point(60, 255);
            this.laDivider2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laDivider2.Name = "laDivider2";
            this.laDivider2.Size = new System.Drawing.Size(569, 2);
            this.laDivider2.TabIndex = 9;
            // 
            // laDivider3
            // 
            this.laDivider3.BackColor = System.Drawing.SystemColors.Highlight;
            this.laDivider3.Location = new System.Drawing.Point(60, 310);
            this.laDivider3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laDivider3.Name = "laDivider3";
            this.laDivider3.Size = new System.Drawing.Size(569, 2);
            this.laDivider3.TabIndex = 10;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::sp_client.Properties.Resources.src_icon;
            this.pictureBox4.Location = new System.Drawing.Point(12, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(618, 127);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::sp_client.Properties.Resources.url_icon;
            this.pictureBox3.Location = new System.Drawing.Point(20, 162);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::sp_client.Properties.Resources.user_icon;
            this.pictureBox2.Location = new System.Drawing.Point(21, 223);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::sp_client.Properties.Resources.password_icon;
            this.pictureBox1.Location = new System.Drawing.Point(21, 276);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // laLoading
            // 
            this.laLoading.BackColor = System.Drawing.Color.White;
            this.laLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laLoading.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.laLoading.ForeColor = System.Drawing.SystemColors.Highlight;
            this.laLoading.Location = new System.Drawing.Point(0, 0);
            this.laLoading.Name = "laLoading";
            this.laLoading.Size = new System.Drawing.Size(642, 489);
            this.laLoading.TabIndex = 15;
            this.laLoading.Text = "Connecting...";
            this.laLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.laLoading.Visible = false;
            // 
            // tbUrl
            // 
            this.tbUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUrl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbUrl.Location = new System.Drawing.Point(64, 170);
            this.tbUrl.Multiline = false;
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(562, 25);
            this.tbUrl.TabIndex = 16;
            this.tbUrl.Text = "";
            // 
            // tbUsername
            // 
            this.tbUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbUsername.Location = new System.Drawing.Point(64, 229);
            this.tbUsername.Multiline = false;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(562, 25);
            this.tbUsername.TabIndex = 17;
            this.tbUsername.Text = "";
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPassword.Location = new System.Drawing.Point(64, 283);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(562, 24);
            this.tbPassword.TabIndex = 18;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(642, 489);
            this.ControlBox = false;
            this.Controls.Add(this.laLoading);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.laDivider3);
            this.Controls.Add(this.laDivider2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.cbRememberMe);
            this.Controls.Add(this.laDivider1);
            this.Controls.Add(this.btConnect);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label laDivider1;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.CheckBox cbRememberMe;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label laDivider2;
        private System.Windows.Forms.Label laDivider3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label laLoading;
        private System.Windows.Forms.RichTextBox tbUrl;
        private System.Windows.Forms.RichTextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
    }
}