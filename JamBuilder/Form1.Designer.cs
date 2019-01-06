namespace JamBuilder
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stageSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.objTab = new System.Windows.Forms.TabPage();
            this.editObj = new System.Windows.Forms.Button();
            this.delObj = new System.Windows.Forms.Button();
            this.addObj = new System.Windows.Forms.Button();
            this.objList = new System.Windows.Forms.ListBox();
            this.guestStarItemTab = new System.Windows.Forms.TabPage();
            this.editGuestItem = new System.Windows.Forms.Button();
            this.delGuestItem = new System.Windows.Forms.Button();
            this.addGuestItem = new System.Windows.Forms.Button();
            this.guestItemList = new System.Windows.Forms.ListBox();
            this.itemTab = new System.Windows.Forms.TabPage();
            this.editItem = new System.Windows.Forms.Button();
            this.delItem = new System.Windows.Forms.Button();
            this.addItem = new System.Windows.Forms.Button();
            this.itemList = new System.Windows.Forms.ListBox();
            this.bossTab = new System.Windows.Forms.TabPage();
            this.editBoss = new System.Windows.Forms.Button();
            this.delBoss = new System.Windows.Forms.Button();
            this.addBoss = new System.Windows.Forms.Button();
            this.bossList = new System.Windows.Forms.ListBox();
            this.enemyTab = new System.Windows.Forms.TabPage();
            this.editEnemy = new System.Windows.Forms.Button();
            this.delEnemy = new System.Windows.Forms.Button();
            this.addEnemy = new System.Windows.Forms.Button();
            this.enemyList = new System.Windows.Forms.ListBox();
            this.glControl = new OpenTK.GLControl();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.objTab.SuspendLayout();
            this.guestStarItemTab.SuspendLayout();
            this.itemTab.SuspendLayout();
            this.bossTab.SuspendLayout();
            this.enemyTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.stageSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1901, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(317, 34);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(317, 34);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(317, 34);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // stageSettingsToolStripMenuItem
            // 
            this.stageSettingsToolStripMenuItem.Name = "stageSettingsToolStripMenuItem";
            this.stageSettingsToolStripMenuItem.Size = new System.Drawing.Size(156, 34);
            this.stageSettingsToolStripMenuItem.Text = "Stage Settings";
            this.stageSettingsToolStripMenuItem.Click += new System.EventHandler(this.stageSettingsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(22, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(535, 857);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Lists";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.objTab);
            this.tabControl1.Controls.Add(this.guestStarItemTab);
            this.tabControl1.Controls.Add(this.itemTab);
            this.tabControl1.Controls.Add(this.bossTab);
            this.tabControl1.Controls.Add(this.enemyTab);
            this.tabControl1.Location = new System.Drawing.Point(11, 35);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 809);
            this.tabControl1.TabIndex = 0;
            // 
            // objTab
            // 
            this.objTab.Controls.Add(this.editObj);
            this.objTab.Controls.Add(this.delObj);
            this.objTab.Controls.Add(this.addObj);
            this.objTab.Controls.Add(this.objList);
            this.objTab.Location = new System.Drawing.Point(4, 33);
            this.objTab.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.objTab.Name = "objTab";
            this.objTab.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.objTab.Size = new System.Drawing.Size(509, 772);
            this.objTab.TabIndex = 0;
            this.objTab.Text = "Objects";
            this.objTab.UseVisualStyleBackColor = true;
            // 
            // editObj
            // 
            this.editObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editObj.Location = new System.Drawing.Point(328, 711);
            this.editObj.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.editObj.Name = "editObj";
            this.editObj.Size = new System.Drawing.Size(138, 42);
            this.editObj.TabIndex = 3;
            this.editObj.Text = "Edit";
            this.editObj.UseVisualStyleBackColor = true;
            this.editObj.Click += new System.EventHandler(this.editObj_Click);
            // 
            // delObj
            // 
            this.delObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delObj.Location = new System.Drawing.Point(180, 711);
            this.delObj.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.delObj.Name = "delObj";
            this.delObj.Size = new System.Drawing.Size(138, 42);
            this.delObj.TabIndex = 2;
            this.delObj.Text = "-";
            this.delObj.UseVisualStyleBackColor = true;
            this.delObj.Click += new System.EventHandler(this.delObj_Click);
            // 
            // addObj
            // 
            this.addObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addObj.Location = new System.Drawing.Point(31, 711);
            this.addObj.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addObj.Name = "addObj";
            this.addObj.Size = new System.Drawing.Size(138, 42);
            this.addObj.TabIndex = 1;
            this.addObj.Text = "+";
            this.addObj.UseVisualStyleBackColor = true;
            this.addObj.Click += new System.EventHandler(this.addObj_Click);
            // 
            // objList
            // 
            this.objList.FormattingEnabled = true;
            this.objList.ItemHeight = 24;
            this.objList.Location = new System.Drawing.Point(9, 9);
            this.objList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.objList.Name = "objList";
            this.objList.Size = new System.Drawing.Size(483, 676);
            this.objList.TabIndex = 0;
            this.objList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.objList_MouseDoubleClick);
            // 
            // guestStarItemTab
            // 
            this.guestStarItemTab.Controls.Add(this.editGuestItem);
            this.guestStarItemTab.Controls.Add(this.delGuestItem);
            this.guestStarItemTab.Controls.Add(this.addGuestItem);
            this.guestStarItemTab.Controls.Add(this.guestItemList);
            this.guestStarItemTab.Location = new System.Drawing.Point(4, 33);
            this.guestStarItemTab.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.guestStarItemTab.Name = "guestStarItemTab";
            this.guestStarItemTab.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.guestStarItemTab.Size = new System.Drawing.Size(509, 772);
            this.guestStarItemTab.TabIndex = 1;
            this.guestStarItemTab.Text = "Guest Star Items";
            this.guestStarItemTab.UseVisualStyleBackColor = true;
            // 
            // editGuestItem
            // 
            this.editGuestItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editGuestItem.Location = new System.Drawing.Point(328, 711);
            this.editGuestItem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.editGuestItem.Name = "editGuestItem";
            this.editGuestItem.Size = new System.Drawing.Size(138, 42);
            this.editGuestItem.TabIndex = 7;
            this.editGuestItem.Text = "Edit";
            this.editGuestItem.UseVisualStyleBackColor = true;
            this.editGuestItem.Click += new System.EventHandler(this.editGuestItem_Click);
            // 
            // delGuestItem
            // 
            this.delGuestItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delGuestItem.Location = new System.Drawing.Point(180, 711);
            this.delGuestItem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.delGuestItem.Name = "delGuestItem";
            this.delGuestItem.Size = new System.Drawing.Size(138, 42);
            this.delGuestItem.TabIndex = 6;
            this.delGuestItem.Text = "-";
            this.delGuestItem.UseVisualStyleBackColor = true;
            this.delGuestItem.Click += new System.EventHandler(this.delGuestItem_Click);
            // 
            // addGuestItem
            // 
            this.addGuestItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addGuestItem.Location = new System.Drawing.Point(31, 711);
            this.addGuestItem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addGuestItem.Name = "addGuestItem";
            this.addGuestItem.Size = new System.Drawing.Size(138, 42);
            this.addGuestItem.TabIndex = 5;
            this.addGuestItem.Text = "+";
            this.addGuestItem.UseVisualStyleBackColor = true;
            this.addGuestItem.Click += new System.EventHandler(this.addGuestItem_Click);
            // 
            // guestItemList
            // 
            this.guestItemList.FormattingEnabled = true;
            this.guestItemList.ItemHeight = 24;
            this.guestItemList.Location = new System.Drawing.Point(9, 9);
            this.guestItemList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.guestItemList.Name = "guestItemList";
            this.guestItemList.Size = new System.Drawing.Size(483, 676);
            this.guestItemList.TabIndex = 4;
            this.guestItemList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.guestItemList_MouseDoubleClick);
            // 
            // itemTab
            // 
            this.itemTab.Controls.Add(this.editItem);
            this.itemTab.Controls.Add(this.delItem);
            this.itemTab.Controls.Add(this.addItem);
            this.itemTab.Controls.Add(this.itemList);
            this.itemTab.Location = new System.Drawing.Point(4, 33);
            this.itemTab.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.itemTab.Name = "itemTab";
            this.itemTab.Size = new System.Drawing.Size(509, 772);
            this.itemTab.TabIndex = 2;
            this.itemTab.Text = "Items";
            this.itemTab.UseVisualStyleBackColor = true;
            // 
            // editItem
            // 
            this.editItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editItem.Location = new System.Drawing.Point(328, 711);
            this.editItem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.editItem.Name = "editItem";
            this.editItem.Size = new System.Drawing.Size(138, 42);
            this.editItem.TabIndex = 7;
            this.editItem.Text = "Edit";
            this.editItem.UseVisualStyleBackColor = true;
            this.editItem.Click += new System.EventHandler(this.editItem_Click);
            // 
            // delItem
            // 
            this.delItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delItem.Location = new System.Drawing.Point(180, 711);
            this.delItem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.delItem.Name = "delItem";
            this.delItem.Size = new System.Drawing.Size(138, 42);
            this.delItem.TabIndex = 6;
            this.delItem.Text = "-";
            this.delItem.UseVisualStyleBackColor = true;
            this.delItem.Click += new System.EventHandler(this.delItem_Click);
            // 
            // addItem
            // 
            this.addItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItem.Location = new System.Drawing.Point(31, 711);
            this.addItem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(138, 42);
            this.addItem.TabIndex = 5;
            this.addItem.Text = "+";
            this.addItem.UseVisualStyleBackColor = true;
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // itemList
            // 
            this.itemList.FormattingEnabled = true;
            this.itemList.ItemHeight = 24;
            this.itemList.Location = new System.Drawing.Point(9, 9);
            this.itemList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(483, 676);
            this.itemList.TabIndex = 4;
            this.itemList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.itemList_MouseDoubleClick);
            // 
            // bossTab
            // 
            this.bossTab.Controls.Add(this.editBoss);
            this.bossTab.Controls.Add(this.delBoss);
            this.bossTab.Controls.Add(this.addBoss);
            this.bossTab.Controls.Add(this.bossList);
            this.bossTab.Location = new System.Drawing.Point(4, 33);
            this.bossTab.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bossTab.Name = "bossTab";
            this.bossTab.Size = new System.Drawing.Size(509, 772);
            this.bossTab.TabIndex = 3;
            this.bossTab.Text = "Bosses";
            this.bossTab.UseVisualStyleBackColor = true;
            // 
            // editBoss
            // 
            this.editBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBoss.Location = new System.Drawing.Point(328, 711);
            this.editBoss.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.editBoss.Name = "editBoss";
            this.editBoss.Size = new System.Drawing.Size(138, 42);
            this.editBoss.TabIndex = 7;
            this.editBoss.Text = "Edit";
            this.editBoss.UseVisualStyleBackColor = true;
            this.editBoss.Click += new System.EventHandler(this.editBoss_Click);
            // 
            // delBoss
            // 
            this.delBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delBoss.Location = new System.Drawing.Point(180, 711);
            this.delBoss.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.delBoss.Name = "delBoss";
            this.delBoss.Size = new System.Drawing.Size(138, 42);
            this.delBoss.TabIndex = 6;
            this.delBoss.Text = "-";
            this.delBoss.UseVisualStyleBackColor = true;
            this.delBoss.Click += new System.EventHandler(this.delBoss_Click);
            // 
            // addBoss
            // 
            this.addBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBoss.Location = new System.Drawing.Point(31, 711);
            this.addBoss.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addBoss.Name = "addBoss";
            this.addBoss.Size = new System.Drawing.Size(138, 42);
            this.addBoss.TabIndex = 5;
            this.addBoss.Text = "+";
            this.addBoss.UseVisualStyleBackColor = true;
            this.addBoss.Click += new System.EventHandler(this.addBoss_Click);
            // 
            // bossList
            // 
            this.bossList.FormattingEnabled = true;
            this.bossList.ItemHeight = 24;
            this.bossList.Location = new System.Drawing.Point(9, 9);
            this.bossList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bossList.Name = "bossList";
            this.bossList.Size = new System.Drawing.Size(483, 676);
            this.bossList.TabIndex = 4;
            this.bossList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.bossList_MouseDoubleClick);
            // 
            // enemyTab
            // 
            this.enemyTab.Controls.Add(this.editEnemy);
            this.enemyTab.Controls.Add(this.delEnemy);
            this.enemyTab.Controls.Add(this.addEnemy);
            this.enemyTab.Controls.Add(this.enemyList);
            this.enemyTab.Location = new System.Drawing.Point(4, 33);
            this.enemyTab.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.enemyTab.Name = "enemyTab";
            this.enemyTab.Size = new System.Drawing.Size(509, 772);
            this.enemyTab.TabIndex = 4;
            this.enemyTab.Text = "Enemies";
            this.enemyTab.UseVisualStyleBackColor = true;
            // 
            // editEnemy
            // 
            this.editEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editEnemy.Location = new System.Drawing.Point(328, 711);
            this.editEnemy.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.editEnemy.Name = "editEnemy";
            this.editEnemy.Size = new System.Drawing.Size(138, 42);
            this.editEnemy.TabIndex = 7;
            this.editEnemy.Text = "Edit";
            this.editEnemy.UseVisualStyleBackColor = true;
            this.editEnemy.Click += new System.EventHandler(this.editEnemy_Click);
            // 
            // delEnemy
            // 
            this.delEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delEnemy.Location = new System.Drawing.Point(180, 711);
            this.delEnemy.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.delEnemy.Name = "delEnemy";
            this.delEnemy.Size = new System.Drawing.Size(138, 42);
            this.delEnemy.TabIndex = 6;
            this.delEnemy.Text = "-";
            this.delEnemy.UseVisualStyleBackColor = true;
            this.delEnemy.Click += new System.EventHandler(this.delEnemy_Click);
            // 
            // addEnemy
            // 
            this.addEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEnemy.Location = new System.Drawing.Point(31, 711);
            this.addEnemy.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addEnemy.Name = "addEnemy";
            this.addEnemy.Size = new System.Drawing.Size(138, 42);
            this.addEnemy.TabIndex = 5;
            this.addEnemy.Text = "+";
            this.addEnemy.UseVisualStyleBackColor = true;
            this.addEnemy.Click += new System.EventHandler(this.addEnemy_Click);
            // 
            // enemyList
            // 
            this.enemyList.FormattingEnabled = true;
            this.enemyList.ItemHeight = 24;
            this.enemyList.Location = new System.Drawing.Point(9, 9);
            this.enemyList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.enemyList.Name = "enemyList";
            this.enemyList.Size = new System.Drawing.Size(483, 676);
            this.enemyList.TabIndex = 4;
            this.enemyList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.enemyList_MouseDoubleClick);
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(568, 50);
            this.glControl.Margin = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(990, 665);
            this.glControl.TabIndex = 2;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1901, 930);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JamBuilder";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.objTab.ResumeLayout(false);
            this.guestStarItemTab.ResumeLayout(false);
            this.itemTab.ResumeLayout(false);
            this.bossTab.ResumeLayout(false);
            this.enemyTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage objTab;
        private System.Windows.Forms.Button editObj;
        private System.Windows.Forms.Button delObj;
        private System.Windows.Forms.Button addObj;
        private System.Windows.Forms.ListBox objList;
        private System.Windows.Forms.TabPage guestStarItemTab;
        private System.Windows.Forms.Button editGuestItem;
        private System.Windows.Forms.Button delGuestItem;
        private System.Windows.Forms.Button addGuestItem;
        private System.Windows.Forms.ListBox guestItemList;
        private System.Windows.Forms.TabPage itemTab;
        private System.Windows.Forms.Button editItem;
        private System.Windows.Forms.Button delItem;
        private System.Windows.Forms.Button addItem;
        private System.Windows.Forms.ListBox itemList;
        private System.Windows.Forms.TabPage bossTab;
        private System.Windows.Forms.Button editBoss;
        private System.Windows.Forms.Button delBoss;
        private System.Windows.Forms.Button addBoss;
        private System.Windows.Forms.ListBox bossList;
        private System.Windows.Forms.TabPage enemyTab;
        private System.Windows.Forms.Button editEnemy;
        private System.Windows.Forms.Button delEnemy;
        private System.Windows.Forms.Button addEnemy;
        private System.Windows.Forms.ListBox enemyList;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.ToolStripMenuItem stageSettingsToolStripMenuItem;
    }
}

