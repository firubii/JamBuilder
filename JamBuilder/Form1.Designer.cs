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
            this.draw = new System.Windows.Forms.Button();
            this.resetCamera = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.xCoord = new System.Windows.Forms.NumericUpDown();
            this.xOffset = new System.Windows.Forms.NumericUpDown();
            this.yOffset = new System.Windows.Forms.NumericUpDown();
            this.yCoord = new System.Windows.Forms.NumericUpDown();
            this.move = new System.Windows.Forms.Button();
            this.select = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.objTab.SuspendLayout();
            this.guestStarItemTab.SuspendLayout();
            this.itemTab.SuspendLayout();
            this.bossTab.SuspendLayout();
            this.enemyTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCoord)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.stageSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1037, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // stageSettingsToolStripMenuItem
            // 
            this.stageSettingsToolStripMenuItem.Name = "stageSettingsToolStripMenuItem";
            this.stageSettingsToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.stageSettingsToolStripMenuItem.Text = "Stage Settings";
            this.stageSettingsToolStripMenuItem.Click += new System.EventHandler(this.stageSettingsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 464);
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
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(282, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // objTab
            // 
            this.objTab.Controls.Add(this.editObj);
            this.objTab.Controls.Add(this.delObj);
            this.objTab.Controls.Add(this.addObj);
            this.objTab.Controls.Add(this.objList);
            this.objTab.Location = new System.Drawing.Point(4, 22);
            this.objTab.Name = "objTab";
            this.objTab.Padding = new System.Windows.Forms.Padding(3);
            this.objTab.Size = new System.Drawing.Size(274, 412);
            this.objTab.TabIndex = 0;
            this.objTab.Text = "Objects";
            this.objTab.UseVisualStyleBackColor = true;
            // 
            // editObj
            // 
            this.editObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editObj.Location = new System.Drawing.Point(179, 385);
            this.editObj.Name = "editObj";
            this.editObj.Size = new System.Drawing.Size(75, 23);
            this.editObj.TabIndex = 3;
            this.editObj.Text = "Edit";
            this.editObj.UseVisualStyleBackColor = true;
            this.editObj.Click += new System.EventHandler(this.editObj_Click);
            // 
            // delObj
            // 
            this.delObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delObj.Location = new System.Drawing.Point(98, 385);
            this.delObj.Name = "delObj";
            this.delObj.Size = new System.Drawing.Size(75, 23);
            this.delObj.TabIndex = 2;
            this.delObj.Text = "-";
            this.delObj.UseVisualStyleBackColor = true;
            this.delObj.Click += new System.EventHandler(this.delObj_Click);
            // 
            // addObj
            // 
            this.addObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addObj.Location = new System.Drawing.Point(17, 385);
            this.addObj.Name = "addObj";
            this.addObj.Size = new System.Drawing.Size(75, 23);
            this.addObj.TabIndex = 1;
            this.addObj.Text = "+";
            this.addObj.UseVisualStyleBackColor = true;
            this.addObj.Click += new System.EventHandler(this.addObj_Click);
            // 
            // objList
            // 
            this.objList.FormattingEnabled = true;
            this.objList.Location = new System.Drawing.Point(5, 5);
            this.objList.Name = "objList";
            this.objList.Size = new System.Drawing.Size(265, 368);
            this.objList.TabIndex = 0;
            this.objList.SelectedIndexChanged += new System.EventHandler(this.objList_SelectedIndexChanged);
            this.objList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.objList_MouseDoubleClick);
            // 
            // guestStarItemTab
            // 
            this.guestStarItemTab.Controls.Add(this.editGuestItem);
            this.guestStarItemTab.Controls.Add(this.delGuestItem);
            this.guestStarItemTab.Controls.Add(this.addGuestItem);
            this.guestStarItemTab.Controls.Add(this.guestItemList);
            this.guestStarItemTab.Location = new System.Drawing.Point(4, 22);
            this.guestStarItemTab.Name = "guestStarItemTab";
            this.guestStarItemTab.Padding = new System.Windows.Forms.Padding(3);
            this.guestStarItemTab.Size = new System.Drawing.Size(274, 412);
            this.guestStarItemTab.TabIndex = 1;
            this.guestStarItemTab.Text = "Guest Star Items";
            this.guestStarItemTab.UseVisualStyleBackColor = true;
            // 
            // editGuestItem
            // 
            this.editGuestItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editGuestItem.Location = new System.Drawing.Point(179, 385);
            this.editGuestItem.Name = "editGuestItem";
            this.editGuestItem.Size = new System.Drawing.Size(75, 23);
            this.editGuestItem.TabIndex = 7;
            this.editGuestItem.Text = "Edit";
            this.editGuestItem.UseVisualStyleBackColor = true;
            this.editGuestItem.Click += new System.EventHandler(this.editGuestItem_Click);
            // 
            // delGuestItem
            // 
            this.delGuestItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delGuestItem.Location = new System.Drawing.Point(98, 385);
            this.delGuestItem.Name = "delGuestItem";
            this.delGuestItem.Size = new System.Drawing.Size(75, 23);
            this.delGuestItem.TabIndex = 6;
            this.delGuestItem.Text = "-";
            this.delGuestItem.UseVisualStyleBackColor = true;
            this.delGuestItem.Click += new System.EventHandler(this.delGuestItem_Click);
            // 
            // addGuestItem
            // 
            this.addGuestItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addGuestItem.Location = new System.Drawing.Point(17, 385);
            this.addGuestItem.Name = "addGuestItem";
            this.addGuestItem.Size = new System.Drawing.Size(75, 23);
            this.addGuestItem.TabIndex = 5;
            this.addGuestItem.Text = "+";
            this.addGuestItem.UseVisualStyleBackColor = true;
            this.addGuestItem.Click += new System.EventHandler(this.addGuestItem_Click);
            // 
            // guestItemList
            // 
            this.guestItemList.FormattingEnabled = true;
            this.guestItemList.Location = new System.Drawing.Point(5, 5);
            this.guestItemList.Name = "guestItemList";
            this.guestItemList.Size = new System.Drawing.Size(265, 368);
            this.guestItemList.TabIndex = 4;
            this.guestItemList.SelectedIndexChanged += new System.EventHandler(this.guestItemList_SelectedIndexChanged);
            this.guestItemList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.guestItemList_MouseDoubleClick);
            // 
            // itemTab
            // 
            this.itemTab.Controls.Add(this.editItem);
            this.itemTab.Controls.Add(this.delItem);
            this.itemTab.Controls.Add(this.addItem);
            this.itemTab.Controls.Add(this.itemList);
            this.itemTab.Location = new System.Drawing.Point(4, 22);
            this.itemTab.Name = "itemTab";
            this.itemTab.Size = new System.Drawing.Size(274, 412);
            this.itemTab.TabIndex = 2;
            this.itemTab.Text = "Items";
            this.itemTab.UseVisualStyleBackColor = true;
            // 
            // editItem
            // 
            this.editItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editItem.Location = new System.Drawing.Point(179, 385);
            this.editItem.Name = "editItem";
            this.editItem.Size = new System.Drawing.Size(75, 23);
            this.editItem.TabIndex = 7;
            this.editItem.Text = "Edit";
            this.editItem.UseVisualStyleBackColor = true;
            this.editItem.Click += new System.EventHandler(this.editItem_Click);
            // 
            // delItem
            // 
            this.delItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delItem.Location = new System.Drawing.Point(98, 385);
            this.delItem.Name = "delItem";
            this.delItem.Size = new System.Drawing.Size(75, 23);
            this.delItem.TabIndex = 6;
            this.delItem.Text = "-";
            this.delItem.UseVisualStyleBackColor = true;
            this.delItem.Click += new System.EventHandler(this.delItem_Click);
            // 
            // addItem
            // 
            this.addItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItem.Location = new System.Drawing.Point(17, 385);
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(75, 23);
            this.addItem.TabIndex = 5;
            this.addItem.Text = "+";
            this.addItem.UseVisualStyleBackColor = true;
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // itemList
            // 
            this.itemList.FormattingEnabled = true;
            this.itemList.Location = new System.Drawing.Point(5, 5);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(265, 368);
            this.itemList.TabIndex = 4;
            this.itemList.SelectedIndexChanged += new System.EventHandler(this.itemList_SelectedIndexChanged);
            this.itemList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.itemList_MouseDoubleClick);
            // 
            // bossTab
            // 
            this.bossTab.Controls.Add(this.editBoss);
            this.bossTab.Controls.Add(this.delBoss);
            this.bossTab.Controls.Add(this.addBoss);
            this.bossTab.Controls.Add(this.bossList);
            this.bossTab.Location = new System.Drawing.Point(4, 22);
            this.bossTab.Name = "bossTab";
            this.bossTab.Size = new System.Drawing.Size(274, 412);
            this.bossTab.TabIndex = 3;
            this.bossTab.Text = "Bosses";
            this.bossTab.UseVisualStyleBackColor = true;
            // 
            // editBoss
            // 
            this.editBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBoss.Location = new System.Drawing.Point(179, 385);
            this.editBoss.Name = "editBoss";
            this.editBoss.Size = new System.Drawing.Size(75, 23);
            this.editBoss.TabIndex = 7;
            this.editBoss.Text = "Edit";
            this.editBoss.UseVisualStyleBackColor = true;
            this.editBoss.Click += new System.EventHandler(this.editBoss_Click);
            // 
            // delBoss
            // 
            this.delBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delBoss.Location = new System.Drawing.Point(98, 385);
            this.delBoss.Name = "delBoss";
            this.delBoss.Size = new System.Drawing.Size(75, 23);
            this.delBoss.TabIndex = 6;
            this.delBoss.Text = "-";
            this.delBoss.UseVisualStyleBackColor = true;
            this.delBoss.Click += new System.EventHandler(this.delBoss_Click);
            // 
            // addBoss
            // 
            this.addBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBoss.Location = new System.Drawing.Point(17, 385);
            this.addBoss.Name = "addBoss";
            this.addBoss.Size = new System.Drawing.Size(75, 23);
            this.addBoss.TabIndex = 5;
            this.addBoss.Text = "+";
            this.addBoss.UseVisualStyleBackColor = true;
            this.addBoss.Click += new System.EventHandler(this.addBoss_Click);
            // 
            // bossList
            // 
            this.bossList.FormattingEnabled = true;
            this.bossList.Location = new System.Drawing.Point(5, 5);
            this.bossList.Name = "bossList";
            this.bossList.Size = new System.Drawing.Size(265, 368);
            this.bossList.TabIndex = 4;
            this.bossList.SelectedIndexChanged += new System.EventHandler(this.bossList_SelectedIndexChanged);
            this.bossList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.bossList_MouseDoubleClick);
            // 
            // enemyTab
            // 
            this.enemyTab.Controls.Add(this.editEnemy);
            this.enemyTab.Controls.Add(this.delEnemy);
            this.enemyTab.Controls.Add(this.addEnemy);
            this.enemyTab.Controls.Add(this.enemyList);
            this.enemyTab.Location = new System.Drawing.Point(4, 22);
            this.enemyTab.Name = "enemyTab";
            this.enemyTab.Size = new System.Drawing.Size(274, 412);
            this.enemyTab.TabIndex = 4;
            this.enemyTab.Text = "Enemies";
            this.enemyTab.UseVisualStyleBackColor = true;
            // 
            // editEnemy
            // 
            this.editEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editEnemy.Location = new System.Drawing.Point(179, 385);
            this.editEnemy.Name = "editEnemy";
            this.editEnemy.Size = new System.Drawing.Size(75, 23);
            this.editEnemy.TabIndex = 7;
            this.editEnemy.Text = "Edit";
            this.editEnemy.UseVisualStyleBackColor = true;
            this.editEnemy.Click += new System.EventHandler(this.editEnemy_Click);
            // 
            // delEnemy
            // 
            this.delEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delEnemy.Location = new System.Drawing.Point(98, 385);
            this.delEnemy.Name = "delEnemy";
            this.delEnemy.Size = new System.Drawing.Size(75, 23);
            this.delEnemy.TabIndex = 6;
            this.delEnemy.Text = "-";
            this.delEnemy.UseVisualStyleBackColor = true;
            this.delEnemy.Click += new System.EventHandler(this.delEnemy_Click);
            // 
            // addEnemy
            // 
            this.addEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEnemy.Location = new System.Drawing.Point(17, 385);
            this.addEnemy.Name = "addEnemy";
            this.addEnemy.Size = new System.Drawing.Size(75, 23);
            this.addEnemy.TabIndex = 5;
            this.addEnemy.Text = "+";
            this.addEnemy.UseVisualStyleBackColor = true;
            this.addEnemy.Click += new System.EventHandler(this.addEnemy_Click);
            // 
            // enemyList
            // 
            this.enemyList.FormattingEnabled = true;
            this.enemyList.Location = new System.Drawing.Point(5, 5);
            this.enemyList.Name = "enemyList";
            this.enemyList.Size = new System.Drawing.Size(265, 368);
            this.enemyList.TabIndex = 4;
            this.enemyList.SelectedIndexChanged += new System.EventHandler(this.enemyList_SelectedIndexChanged);
            this.enemyList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.enemyList_MouseDoubleClick);
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(310, 68);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(540, 365);
            this.glControl.TabIndex = 2;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            this.glControl.MouseLeave += new System.EventHandler(this.glControl_MouseLeave);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseUp);
            this.glControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseWheel);
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(384, 32);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(31, 31);
            this.draw.TabIndex = 5;
            this.draw.UseVisualStyleBackColor = true;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // resetCamera
            // 
            this.resetCamera.Location = new System.Drawing.Point(421, 32);
            this.resetCamera.Name = "resetCamera";
            this.resetCamera.Size = new System.Drawing.Size(82, 31);
            this.resetCamera.TabIndex = 6;
            this.resetCamera.Text = "Reset Camera";
            this.resetCamera.UseVisualStyleBackColor = true;
            this.resetCamera.Click += new System.EventHandler(this.resetCamera_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Coordinate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Offset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Y";
            // 
            // xCoord
            // 
            this.xCoord.Location = new System.Drawing.Point(390, 443);
            this.xCoord.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.xCoord.Name = "xCoord";
            this.xCoord.Size = new System.Drawing.Size(120, 20);
            this.xCoord.TabIndex = 23;
            this.xCoord.ValueChanged += new System.EventHandler(this.xCoord_ValueChanged);
            // 
            // xOffset
            // 
            this.xOffset.Location = new System.Drawing.Point(390, 471);
            this.xOffset.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.xOffset.Name = "xOffset";
            this.xOffset.Size = new System.Drawing.Size(120, 20);
            this.xOffset.TabIndex = 24;
            this.xOffset.ValueChanged += new System.EventHandler(this.xOffset_ValueChanged);
            // 
            // yOffset
            // 
            this.yOffset.Location = new System.Drawing.Point(536, 471);
            this.yOffset.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.yOffset.Name = "yOffset";
            this.yOffset.Size = new System.Drawing.Size(120, 20);
            this.yOffset.TabIndex = 26;
            this.yOffset.ValueChanged += new System.EventHandler(this.yOffset_ValueChanged);
            // 
            // yCoord
            // 
            this.yCoord.Location = new System.Drawing.Point(536, 443);
            this.yCoord.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.yCoord.Name = "yCoord";
            this.yCoord.Size = new System.Drawing.Size(120, 20);
            this.yCoord.TabIndex = 25;
            this.yCoord.ValueChanged += new System.EventHandler(this.yCoord_ValueChanged);
            // 
            // move
            // 
            this.move.BackgroundImage = global::JamBuilder.Properties.Resources.move;
            this.move.Location = new System.Drawing.Point(347, 32);
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(31, 31);
            this.move.TabIndex = 4;
            this.move.UseVisualStyleBackColor = true;
            this.move.Click += new System.EventHandler(this.move_Click);
            // 
            // select
            // 
            this.select.BackgroundImage = global::JamBuilder.Properties.Resources.select;
            this.select.Location = new System.Drawing.Point(310, 32);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(31, 31);
            this.select.TabIndex = 3;
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 504);
            this.Controls.Add(this.yOffset);
            this.Controls.Add(this.yCoord);
            this.Controls.Add(this.xOffset);
            this.Controls.Add(this.xCoord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetCamera);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.move);
            this.Controls.Add(this.select);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JamBuilder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.objTab.ResumeLayout(false);
            this.guestStarItemTab.ResumeLayout(false);
            this.itemTab.ResumeLayout(false);
            this.bossTab.ResumeLayout(false);
            this.enemyTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCoord)).EndInit();
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
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.Button move;
        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.Button resetCamera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown xCoord;
        private System.Windows.Forms.NumericUpDown xOffset;
        private System.Windows.Forms.NumericUpDown yOffset;
        private System.Windows.Forms.NumericUpDown yCoord;
    }
}

