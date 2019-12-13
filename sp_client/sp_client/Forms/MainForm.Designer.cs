namespace sp_client
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listRefreshRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerOff = new System.Windows.Forms.ToolStripMenuItem();
            this.timer10Seconds = new System.Windows.Forms.ToolStripMenuItem();
            this.timer30Seconds = new System.Windows.Forms.ToolStripMenuItem();
            this.timer60Seconds = new System.Windows.Forms.ToolStripMenuItem();
            this.timer2Minutes = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgTemplate = new System.Windows.Forms.TableLayoutPanel();
            this.panelFunctions = new System.Windows.Forms.Panel();
            this.laDivider4 = new System.Windows.Forms.Label();
            this.laDivider3 = new System.Windows.Forms.Label();
            this.laDivider2 = new System.Windows.Forms.Label();
            this.laDivider = new System.Windows.Forms.Label();
            this.btRefreshList = new System.Windows.Forms.Button();
            this.btFilterForSelectedItem = new System.Windows.Forms.Button();
            this.btEditSelectedRow = new System.Windows.Forms.Button();
            this.btRemoveItemFromList = new System.Windows.Forms.Button();
            this.btAddItemToList = new System.Windows.Forms.Button();
            this.panelView = new System.Windows.Forms.Panel();
            this.laCurrentList = new System.Windows.Forms.Label();
            this.lbLists = new System.Windows.Forms.ListBox();
            this.dgvDataTable = new System.Windows.Forms.DataGridView();
            this.timerRefreshList = new System.Windows.Forms.Timer(this.components);
            this.laGetStarted = new System.Windows.Forms.Label();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.laLoading = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.bgTemplate.SuspendLayout();
            this.panelFunctions.SuspendLayout();
            this.panelView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.userToolStripMenuItem,
            this.siteToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(1924, 31);
            this.menuStrip.TabIndex = 0;
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(62, 27);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Image = global::sp_client.Properties.Resources.connect_to_site_icon;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(210, 28);
            this.connectToolStripMenuItem.Text = "Connect to site";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Enabled = false;
            this.disconnectToolStripMenuItem.Image = global::sp_client.Properties.Resources.disconnect_icon;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(210, 28);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listRefreshRateToolStripMenuItem});
            this.settingsToolStripMenuItem.Enabled = false;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(85, 27);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // listRefreshRateToolStripMenuItem
            // 
            this.listRefreshRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerOff,
            this.timer10Seconds,
            this.timer30Seconds,
            this.timer60Seconds,
            this.timer2Minutes});
            this.listRefreshRateToolStripMenuItem.Image = global::sp_client.Properties.Resources.refresh_rate_icon;
            this.listRefreshRateToolStripMenuItem.Name = "listRefreshRateToolStripMenuItem";
            this.listRefreshRateToolStripMenuItem.Size = new System.Drawing.Size(211, 28);
            this.listRefreshRateToolStripMenuItem.Text = "List refresh rate";
            // 
            // timerOff
            // 
            this.timerOff.Checked = true;
            this.timerOff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.timerOff.Name = "timerOff";
            this.timerOff.Size = new System.Drawing.Size(178, 28);
            this.timerOff.Text = "Off";
            this.timerOff.Click += new System.EventHandler(this.offToolStripMenuItem_Click);
            // 
            // timer10Seconds
            // 
            this.timer10Seconds.Name = "timer10Seconds";
            this.timer10Seconds.Size = new System.Drawing.Size(178, 28);
            this.timer10Seconds.Text = "10 seconds";
            this.timer10Seconds.Click += new System.EventHandler(this.tenSecondsToolStripMenuItem_Click);
            // 
            // timer30Seconds
            // 
            this.timer30Seconds.Name = "timer30Seconds";
            this.timer30Seconds.Size = new System.Drawing.Size(178, 28);
            this.timer30Seconds.Text = "30 seconds";
            this.timer30Seconds.Click += new System.EventHandler(this.thirtySecondsToolStripMenuItem_Click);
            // 
            // timer60Seconds
            // 
            this.timer60Seconds.Name = "timer60Seconds";
            this.timer60Seconds.Size = new System.Drawing.Size(178, 28);
            this.timer60Seconds.Text = "60 seconds";
            this.timer60Seconds.Click += new System.EventHandler(this.sixtySecondsToolStripMenuItem_Click);
            // 
            // timer2Minutes
            // 
            this.timer2Minutes.Name = "timer2Minutes";
            this.timer2Minutes.Size = new System.Drawing.Size(178, 28);
            this.timer2Minutes.Text = "2 minutes";
            this.timer2Minutes.Click += new System.EventHandler(this.twoMinutesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(71, 27);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(150, 28);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(14, 27);
            // 
            // siteToolStripMenuItem
            // 
            this.siteToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.siteToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.siteToolStripMenuItem.Name = "siteToolStripMenuItem";
            this.siteToolStripMenuItem.Size = new System.Drawing.Size(14, 27);
            this.siteToolStripMenuItem.Click += new System.EventHandler(this.siteToolStripMenuItem_Click);
            // 
            // bgTemplate
            // 
            this.bgTemplate.BackColor = System.Drawing.Color.White;
            this.bgTemplate.ColumnCount = 2;
            this.bgTemplate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bgTemplate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1789F));
            this.bgTemplate.Controls.Add(this.panelFunctions, 0, 0);
            this.bgTemplate.Controls.Add(this.panelView, 1, 0);
            this.bgTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgTemplate.Location = new System.Drawing.Point(0, 31);
            this.bgTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.bgTemplate.Name = "bgTemplate";
            this.bgTemplate.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bgTemplate.RowCount = 1;
            this.bgTemplate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 817F));
            this.bgTemplate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 817F));
            this.bgTemplate.Size = new System.Drawing.Size(1924, 821);
            this.bgTemplate.TabIndex = 3;
            this.bgTemplate.Visible = false;
            // 
            // panelFunctions
            // 
            this.panelFunctions.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelFunctions.Controls.Add(this.laDivider4);
            this.panelFunctions.Controls.Add(this.laDivider3);
            this.panelFunctions.Controls.Add(this.laDivider2);
            this.panelFunctions.Controls.Add(this.laDivider);
            this.panelFunctions.Controls.Add(this.btRefreshList);
            this.panelFunctions.Controls.Add(this.btFilterForSelectedItem);
            this.panelFunctions.Controls.Add(this.btEditSelectedRow);
            this.panelFunctions.Controls.Add(this.btRemoveItemFromList);
            this.panelFunctions.Controls.Add(this.btAddItemToList);
            this.panelFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFunctions.Location = new System.Drawing.Point(7, 6);
            this.panelFunctions.Margin = new System.Windows.Forms.Padding(4);
            this.panelFunctions.Name = "panelFunctions";
            this.panelFunctions.Size = new System.Drawing.Size(275, 809);
            this.panelFunctions.TabIndex = 6;
            // 
            // laDivider4
            // 
            this.laDivider4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.laDivider4.Location = new System.Drawing.Point(-1, 650);
            this.laDivider4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.laDivider4.Name = "laDivider4";
            this.laDivider4.Size = new System.Drawing.Size(279, 2);
            this.laDivider4.TabIndex = 34;
            // 
            // laDivider3
            // 
            this.laDivider3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.laDivider3.Location = new System.Drawing.Point(-1, 487);
            this.laDivider3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.laDivider3.Name = "laDivider3";
            this.laDivider3.Size = new System.Drawing.Size(279, 2);
            this.laDivider3.TabIndex = 33;
            // 
            // laDivider2
            // 
            this.laDivider2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.laDivider2.Location = new System.Drawing.Point(-1, 325);
            this.laDivider2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.laDivider2.Name = "laDivider2";
            this.laDivider2.Size = new System.Drawing.Size(279, 2);
            this.laDivider2.TabIndex = 32;
            // 
            // laDivider
            // 
            this.laDivider.BackColor = System.Drawing.SystemColors.HotTrack;
            this.laDivider.Location = new System.Drawing.Point(-4, 162);
            this.laDivider.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.laDivider.Name = "laDivider";
            this.laDivider.Size = new System.Drawing.Size(279, 2);
            this.laDivider.TabIndex = 31;
            // 
            // btRefreshList
            // 
            this.btRefreshList.BackColor = System.Drawing.SystemColors.Highlight;
            this.btRefreshList.BackgroundImage = global::sp_client.Properties.Resources.refresh_button_icon;
            this.btRefreshList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRefreshList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btRefreshList.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btRefreshList.Location = new System.Drawing.Point(0, 0);
            this.btRefreshList.Margin = new System.Windows.Forms.Padding(4);
            this.btRefreshList.Name = "btRefreshList";
            this.btRefreshList.Size = new System.Drawing.Size(275, 165);
            this.btRefreshList.TabIndex = 9;
            this.btRefreshList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTipMain.SetToolTip(this.btRefreshList, "Refresh list");
            this.btRefreshList.UseVisualStyleBackColor = false;
            this.btRefreshList.Click += new System.EventHandler(this.btRefreshList_Click);
            // 
            // btFilterForSelectedItem
            // 
            this.btFilterForSelectedItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.btFilterForSelectedItem.BackgroundImage = global::sp_client.Properties.Resources.filter_button_icon;
            this.btFilterForSelectedItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btFilterForSelectedItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFilterForSelectedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btFilterForSelectedItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btFilterForSelectedItem.Location = new System.Drawing.Point(0, 650);
            this.btFilterForSelectedItem.Margin = new System.Windows.Forms.Padding(4);
            this.btFilterForSelectedItem.Name = "btFilterForSelectedItem";
            this.btFilterForSelectedItem.Size = new System.Drawing.Size(275, 160);
            this.btFilterForSelectedItem.TabIndex = 8;
            this.toolTipMain.SetToolTip(this.btFilterForSelectedItem, "Filter list item");
            this.btFilterForSelectedItem.UseVisualStyleBackColor = false;
            this.btFilterForSelectedItem.Click += new System.EventHandler(this.btFilterForSelectedItem_Click);
            // 
            // btEditSelectedRow
            // 
            this.btEditSelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.btEditSelectedRow.BackgroundImage = global::sp_client.Properties.Resources.edit_button_icon;
            this.btEditSelectedRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btEditSelectedRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEditSelectedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btEditSelectedRow.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btEditSelectedRow.Location = new System.Drawing.Point(0, 325);
            this.btEditSelectedRow.Margin = new System.Windows.Forms.Padding(4);
            this.btEditSelectedRow.Name = "btEditSelectedRow";
            this.btEditSelectedRow.Size = new System.Drawing.Size(275, 165);
            this.btEditSelectedRow.TabIndex = 7;
            this.toolTipMain.SetToolTip(this.btEditSelectedRow, "Edit list item");
            this.btEditSelectedRow.UseVisualStyleBackColor = false;
            this.btEditSelectedRow.Click += new System.EventHandler(this.btEditSelectedRow_Click);
            // 
            // btRemoveItemFromList
            // 
            this.btRemoveItemFromList.BackColor = System.Drawing.SystemColors.Highlight;
            this.btRemoveItemFromList.BackgroundImage = global::sp_client.Properties.Resources.delete_button_icon2;
            this.btRemoveItemFromList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btRemoveItemFromList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRemoveItemFromList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btRemoveItemFromList.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btRemoveItemFromList.Location = new System.Drawing.Point(0, 487);
            this.btRemoveItemFromList.Margin = new System.Windows.Forms.Padding(4);
            this.btRemoveItemFromList.Name = "btRemoveItemFromList";
            this.btRemoveItemFromList.Size = new System.Drawing.Size(275, 165);
            this.btRemoveItemFromList.TabIndex = 6;
            this.toolTipMain.SetToolTip(this.btRemoveItemFromList, "Delete list item(s)");
            this.btRemoveItemFromList.UseVisualStyleBackColor = false;
            this.btRemoveItemFromList.Click += new System.EventHandler(this.btRemoveItemFromList_Click);
            // 
            // btAddItemToList
            // 
            this.btAddItemToList.BackColor = System.Drawing.SystemColors.Highlight;
            this.btAddItemToList.BackgroundImage = global::sp_client.Properties.Resources.add_button_icon;
            this.btAddItemToList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAddItemToList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddItemToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btAddItemToList.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btAddItemToList.Location = new System.Drawing.Point(0, 162);
            this.btAddItemToList.Margin = new System.Windows.Forms.Padding(4);
            this.btAddItemToList.Name = "btAddItemToList";
            this.btAddItemToList.Size = new System.Drawing.Size(275, 165);
            this.btAddItemToList.TabIndex = 5;
            this.toolTipMain.SetToolTip(this.btAddItemToList, "Add list item");
            this.btAddItemToList.UseVisualStyleBackColor = false;
            this.btAddItemToList.Click += new System.EventHandler(this.btAddItemToList_Click);
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.laCurrentList);
            this.panelView.Controls.Add(this.lbLists);
            this.panelView.Controls.Add(this.dgvDataTable);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(290, 6);
            this.panelView.Margin = new System.Windows.Forms.Padding(4);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(1781, 809);
            this.panelView.TabIndex = 7;
            // 
            // laCurrentList
            // 
            this.laCurrentList.BackColor = System.Drawing.SystemColors.Highlight;
            this.laCurrentList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.laCurrentList.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laCurrentList.ForeColor = System.Drawing.Color.White;
            this.laCurrentList.Location = new System.Drawing.Point(4, 0);
            this.laCurrentList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laCurrentList.Name = "laCurrentList";
            this.laCurrentList.Size = new System.Drawing.Size(215, 52);
            this.laCurrentList.TabIndex = 7;
            this.laCurrentList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLists
            // 
            this.lbLists.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbLists.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLists.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbLists.FormattingEnabled = true;
            this.lbLists.ItemHeight = 28;
            this.lbLists.Location = new System.Drawing.Point(4, 55);
            this.lbLists.Margin = new System.Windows.Forms.Padding(4);
            this.lbLists.Name = "lbLists";
            this.lbLists.Size = new System.Drawing.Size(214, 730);
            this.lbLists.TabIndex = 6;
            this.lbLists.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbLists_MouseDoubleClick);
            // 
            // dgvDataTable
            // 
            this.dgvDataTable.AllowUserToAddRows = false;
            this.dgvDataTable.AllowUserToDeleteRows = false;
            this.dgvDataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDataTable.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDataTable.Location = new System.Drawing.Point(227, 4);
            this.dgvDataTable.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDataTable.Name = "dgvDataTable";
            this.dgvDataTable.RowHeadersVisible = false;
            this.dgvDataTable.RowHeadersWidth = 51;
            this.dgvDataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTable.Size = new System.Drawing.Size(1551, 802);
            this.dgvDataTable.TabIndex = 5;
            this.dgvDataTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataTable_CellClick);
            // 
            // timerRefreshList
            // 
            this.timerRefreshList.Interval = 10000;
            this.timerRefreshList.Tick += new System.EventHandler(this.timerRefreshList_Tick);
            // 
            // laGetStarted
            // 
            this.laGetStarted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laGetStarted.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.laGetStarted.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.laGetStarted.Location = new System.Drawing.Point(0, 31);
            this.laGetStarted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laGetStarted.Name = "laGetStarted";
            this.laGetStarted.Size = new System.Drawing.Size(1924, 821);
            this.laGetStarted.TabIndex = 4;
            this.laGetStarted.Text = "Connect to a site";
            this.laGetStarted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laLoading
            // 
            this.laLoading.AutoSize = true;
            this.laLoading.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.laLoading.ForeColor = System.Drawing.SystemColors.Highlight;
            this.laLoading.Location = new System.Drawing.Point(621, 6);
            this.laLoading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laLoading.Name = "laLoading";
            this.laLoading.Size = new System.Drawing.Size(83, 23);
            this.laLoading.TabIndex = 5;
            this.laLoading.Text = "Loading...";
            this.laLoading.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1924, 852);
            this.Controls.Add(this.laLoading);
            this.Controls.Add(this.bgTemplate);
            this.Controls.Add(this.laGetStarted);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sharepoint Remote Client";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.bgTemplate.ResumeLayout(false);
            this.panelFunctions.ResumeLayout(false);
            this.panelView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel bgTemplate;
        private System.Windows.Forms.Button btAddItemToList;
        private System.Windows.Forms.Panel panelFunctions;
        private System.Windows.Forms.Button btRemoveItemFromList;
        private System.Windows.Forms.Button btEditSelectedRow;
        private System.Windows.Forms.Timer timerRefreshList;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listRefreshRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timerOff;
        private System.Windows.Forms.ToolStripMenuItem timer10Seconds;
        private System.Windows.Forms.ToolStripMenuItem timer30Seconds;
        private System.Windows.Forms.ToolStripMenuItem timer60Seconds;
        private System.Windows.Forms.ToolStripMenuItem timer2Minutes;
        private System.Windows.Forms.Button btFilterForSelectedItem;
        private System.Windows.Forms.Label laGetStarted;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.Button btRefreshList;
        private System.Windows.Forms.Label laDivider4;
        private System.Windows.Forms.Label laDivider3;
        private System.Windows.Forms.Label laDivider2;
        private System.Windows.Forms.Label laDivider;
        private System.Windows.Forms.Label laLoading;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siteToolStripMenuItem;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.ListBox lbLists;
        private System.Windows.Forms.DataGridView dgvDataTable;
        private System.Windows.Forms.Label laCurrentList;
    }
}

