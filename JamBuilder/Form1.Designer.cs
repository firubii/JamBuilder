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
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stageSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderTileModifiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderObjectNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderObjectPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderGuestStarItemPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderItemPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderBossPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderEnemyPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.objectListFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.formatShowIndex = new System.Windows.Forms.ToolStripMenuItem();
			this.formatShowKind = new System.Windows.Forms.ToolStripMenuItem();
			this.formatShowWuid = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.objTab = new System.Windows.Forms.TabPage();
			this.objList = new System.Windows.Forms.ListBox();
			this.guestStarItemTab = new System.Windows.Forms.TabPage();
			this.guestItemList = new System.Windows.Forms.ListBox();
			this.itemTab = new System.Windows.Forms.TabPage();
			this.itemList = new System.Windows.Forms.ListBox();
			this.bossTab = new System.Windows.Forms.TabPage();
			this.bossList = new System.Windows.Forms.ListBox();
			this.enemyTab = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.enemyList = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.addObj = new System.Windows.Forms.Button();
			this.cloneObj = new System.Windows.Forms.Button();
			this.delObj = new System.Windows.Forms.Button();
			this.editObj = new System.Windows.Forms.Button();
			this.glControl = new OpenTK.GLControl();
			this.resetCamera = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.xCoord = new System.Windows.Forms.NumericUpDown();
			this.xOffset = new System.Windows.Forms.NumericUpDown();
			this.yOffset = new System.Windows.Forms.NumericUpDown();
			this.yCoord = new System.Windows.Forms.NumericUpDown();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.editDeco = new System.Windows.Forms.CheckBox();
			this.editBlock = new System.Windows.Forms.CheckBox();
			this.editCol = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.d4_4 = new System.Windows.Forms.NumericUpDown();
			this.label14 = new System.Windows.Forms.Label();
			this.d4_3 = new System.Windows.Forms.NumericUpDown();
			this.d1_1 = new System.Windows.Forms.NumericUpDown();
			this.d4_2 = new System.Windows.Forms.NumericUpDown();
			this.d1_2 = new System.Windows.Forms.NumericUpDown();
			this.d4_1 = new System.Windows.Forms.NumericUpDown();
			this.d1_3 = new System.Windows.Forms.NumericUpDown();
			this.d3_4 = new System.Windows.Forms.NumericUpDown();
			this.d1_4 = new System.Windows.Forms.NumericUpDown();
			this.d3_3 = new System.Windows.Forms.NumericUpDown();
			this.d2_1 = new System.Windows.Forms.NumericUpDown();
			this.d3_2 = new System.Windows.Forms.NumericUpDown();
			this.d2_2 = new System.Windows.Forms.NumericUpDown();
			this.d3_1 = new System.Windows.Forms.NumericUpDown();
			this.d2_3 = new System.Windows.Forms.NumericUpDown();
			this.d2_4 = new System.Windows.Forms.NumericUpDown();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.vblock = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.spike = new System.Windows.Forms.CheckBox();
			this.vshape = new System.Windows.Forms.NumericUpDown();
			this.vmat = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.vunk = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.ladder = new System.Windows.Forms.CheckBox();
			this.water = new System.Windows.Forms.CheckBox();
			this.lava = new System.Windows.Forms.CheckBox();
			this.pick = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.sizeW = new System.Windows.Forms.NumericUpDown();
			this.label16 = new System.Windows.Forms.Label();
			this.sizeH = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.draw = new System.Windows.Forms.Button();
			this.move = new System.Windows.Forms.Button();
			this.select = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.objTab.SuspendLayout();
			this.guestStarItemTab.SuspendLayout();
			this.itemTab.SuspendLayout();
			this.bossTab.SuspendLayout();
			this.enemyTab.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.xCoord)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xOffset)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yOffset)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yCoord)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.d4_4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d4_3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d1_1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d4_2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d1_2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d4_1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d1_3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d3_4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d1_4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d3_3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d2_1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d3_2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d2_2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d3_1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d2_3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.d2_4)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vblock)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vshape)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vmat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vunk)).BeginInit();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sizeW)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sizeH)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.stageSettingsToolStripMenuItem,
            this.renderSettingsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1185, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Enabled = false;
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
			this.saveAsToolStripMenuItem.Text = "Save As...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// stageSettingsToolStripMenuItem
			// 
			this.stageSettingsToolStripMenuItem.Name = "stageSettingsToolStripMenuItem";
			this.stageSettingsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.stageSettingsToolStripMenuItem.Text = "Stage";
			this.stageSettingsToolStripMenuItem.Click += new System.EventHandler(this.stageSettingsToolStripMenuItem_Click);
			// 
			// renderSettingsToolStripMenuItem
			// 
			this.renderSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderTileModifiersToolStripMenuItem,
            this.renderBlocksToolStripMenuItem,
            this.renderObjectNamesToolStripMenuItem,
            this.renderObjectPointsToolStripMenuItem,
            this.renderGuestStarItemPointsToolStripMenuItem,
            this.renderItemPointsToolStripMenuItem,
            this.renderBossPointsToolStripMenuItem,
            this.renderEnemyPointsToolStripMenuItem,
            this.objectListFormatToolStripMenuItem});
			this.renderSettingsToolStripMenuItem.Name = "renderSettingsToolStripMenuItem";
			this.renderSettingsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.renderSettingsToolStripMenuItem.Text = "View";
			// 
			// renderTileModifiersToolStripMenuItem
			// 
			this.renderTileModifiersToolStripMenuItem.Checked = true;
			this.renderTileModifiersToolStripMenuItem.CheckOnClick = true;
			this.renderTileModifiersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.renderTileModifiersToolStripMenuItem.Name = "renderTileModifiersToolStripMenuItem";
			this.renderTileModifiersToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
			this.renderTileModifiersToolStripMenuItem.Text = "Render Tile Modifiers";
			// 
			// renderBlocksToolStripMenuItem
			// 
			this.renderBlocksToolStripMenuItem.Checked = true;
			this.renderBlocksToolStripMenuItem.CheckOnClick = true;
			this.renderBlocksToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.renderBlocksToolStripMenuItem.Name = "renderBlocksToolStripMenuItem";
			this.renderBlocksToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
			this.renderBlocksToolStripMenuItem.Text = "Render Blocks";
			this.renderBlocksToolStripMenuItem.Click += new System.EventHandler(this.renderBlocksToolStripMenuItem_Click);
			// 
			// renderObjectNamesToolStripMenuItem
			// 
			this.renderObjectNamesToolStripMenuItem.Checked = true;
			this.renderObjectNamesToolStripMenuItem.CheckOnClick = true;
			this.renderObjectNamesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.renderObjectNamesToolStripMenuItem.Name = "renderObjectNamesToolStripMenuItem";
			this.renderObjectNamesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
			this.renderObjectNamesToolStripMenuItem.Text = "Render Object Names";
			// 
			// renderObjectPointsToolStripMenuItem
			// 
			this.renderObjectPointsToolStripMenuItem.Checked = true;
			this.renderObjectPointsToolStripMenuItem.CheckOnClick = true;
			this.renderObjectPointsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.renderObjectPointsToolStripMenuItem.Name = "renderObjectPointsToolStripMenuItem";
			this.renderObjectPointsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
			this.renderObjectPointsToolStripMenuItem.Text = "Render Object Points";
			// 
			// renderGuestStarItemPointsToolStripMenuItem
			// 
			this.renderGuestStarItemPointsToolStripMenuItem.Checked = true;
			this.renderGuestStarItemPointsToolStripMenuItem.CheckOnClick = true;
			this.renderGuestStarItemPointsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.renderGuestStarItemPointsToolStripMenuItem.Name = "renderGuestStarItemPointsToolStripMenuItem";
			this.renderGuestStarItemPointsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
			this.renderGuestStarItemPointsToolStripMenuItem.Text = "Render Guest Star Item Points";
			// 
			// renderItemPointsToolStripMenuItem
			// 
			this.renderItemPointsToolStripMenuItem.Checked = true;
			this.renderItemPointsToolStripMenuItem.CheckOnClick = true;
			this.renderItemPointsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.renderItemPointsToolStripMenuItem.Name = "renderItemPointsToolStripMenuItem";
			this.renderItemPointsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
			this.renderItemPointsToolStripMenuItem.Text = "Render Item Points";
			// 
			// renderBossPointsToolStripMenuItem
			// 
			this.renderBossPointsToolStripMenuItem.Checked = true;
			this.renderBossPointsToolStripMenuItem.CheckOnClick = true;
			this.renderBossPointsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.renderBossPointsToolStripMenuItem.Name = "renderBossPointsToolStripMenuItem";
			this.renderBossPointsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
			this.renderBossPointsToolStripMenuItem.Text = "Render Boss Points";
			// 
			// renderEnemyPointsToolStripMenuItem
			// 
			this.renderEnemyPointsToolStripMenuItem.Checked = true;
			this.renderEnemyPointsToolStripMenuItem.CheckOnClick = true;
			this.renderEnemyPointsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.renderEnemyPointsToolStripMenuItem.Name = "renderEnemyPointsToolStripMenuItem";
			this.renderEnemyPointsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
			this.renderEnemyPointsToolStripMenuItem.Text = "Render Enemy Points";
			// 
			// objectListFormatToolStripMenuItem
			// 
			this.objectListFormatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatShowIndex,
            this.formatShowKind,
            this.formatShowWuid});
			this.objectListFormatToolStripMenuItem.Name = "objectListFormatToolStripMenuItem";
			this.objectListFormatToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
			this.objectListFormatToolStripMenuItem.Text = "Object List Format";
			// 
			// formatShowIndex
			// 
			this.formatShowIndex.CheckOnClick = true;
			this.formatShowIndex.Name = "formatShowIndex";
			this.formatShowIndex.Size = new System.Drawing.Size(152, 22);
			this.formatShowIndex.Text = "index";
			this.formatShowIndex.CheckedChanged += new System.EventHandler(this.listFormatChanged);
			// 
			// formatShowKind
			// 
			this.formatShowKind.Checked = true;
			this.formatShowKind.CheckOnClick = true;
			this.formatShowKind.CheckState = System.Windows.Forms.CheckState.Checked;
			this.formatShowKind.Name = "formatShowKind";
			this.formatShowKind.Size = new System.Drawing.Size(152, 22);
			this.formatShowKind.Text = "kind";
			this.formatShowKind.CheckedChanged += new System.EventHandler(this.listFormatChanged);
			// 
			// formatShowWuid
			// 
			this.formatShowWuid.CheckOnClick = true;
			this.formatShowWuid.Name = "formatShowWuid";
			this.formatShowWuid.Size = new System.Drawing.Size(152, 22);
			this.formatShowWuid.Text = "wuid";
			this.formatShowWuid.CheckedChanged += new System.EventHandler(this.listFormatChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox1.Controls.Add(this.tabControl1);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new System.Drawing.Point(0, 59);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(295, 539);
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
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(289, 484);
			this.tabControl1.TabIndex = 0;
			// 
			// objTab
			// 
			this.objTab.Controls.Add(this.objList);
			this.objTab.Location = new System.Drawing.Point(4, 22);
			this.objTab.Name = "objTab";
			this.objTab.Padding = new System.Windows.Forms.Padding(3);
			this.objTab.Size = new System.Drawing.Size(281, 458);
			this.objTab.TabIndex = 0;
			this.objTab.Text = "Objects";
			this.objTab.UseVisualStyleBackColor = true;
			// 
			// objList
			// 
			this.objList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.objList.FormattingEnabled = true;
			this.objList.Location = new System.Drawing.Point(3, 3);
			this.objList.Name = "objList";
			this.objList.Size = new System.Drawing.Size(275, 452);
			this.objList.TabIndex = 0;
			this.objList.SelectedIndexChanged += new System.EventHandler(this.objList_SelectedIndexChanged);
			this.objList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.objList_MouseDoubleClick);
			// 
			// guestStarItemTab
			// 
			this.guestStarItemTab.Controls.Add(this.guestItemList);
			this.guestStarItemTab.Location = new System.Drawing.Point(4, 22);
			this.guestStarItemTab.Name = "guestStarItemTab";
			this.guestStarItemTab.Padding = new System.Windows.Forms.Padding(3);
			this.guestStarItemTab.Size = new System.Drawing.Size(281, 458);
			this.guestStarItemTab.TabIndex = 1;
			this.guestStarItemTab.Text = "Guest Star Items";
			this.guestStarItemTab.UseVisualStyleBackColor = true;
			// 
			// guestItemList
			// 
			this.guestItemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.guestItemList.FormattingEnabled = true;
			this.guestItemList.Location = new System.Drawing.Point(3, 3);
			this.guestItemList.Name = "guestItemList";
			this.guestItemList.Size = new System.Drawing.Size(275, 452);
			this.guestItemList.TabIndex = 4;
			this.guestItemList.SelectedIndexChanged += new System.EventHandler(this.guestItemList_SelectedIndexChanged);
			this.guestItemList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.guestItemList_MouseDoubleClick);
			// 
			// itemTab
			// 
			this.itemTab.Controls.Add(this.itemList);
			this.itemTab.Location = new System.Drawing.Point(4, 22);
			this.itemTab.Name = "itemTab";
			this.itemTab.Size = new System.Drawing.Size(281, 458);
			this.itemTab.TabIndex = 2;
			this.itemTab.Text = "Items";
			this.itemTab.UseVisualStyleBackColor = true;
			// 
			// itemList
			// 
			this.itemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemList.FormattingEnabled = true;
			this.itemList.Location = new System.Drawing.Point(0, 0);
			this.itemList.Name = "itemList";
			this.itemList.Size = new System.Drawing.Size(281, 458);
			this.itemList.TabIndex = 4;
			this.itemList.SelectedIndexChanged += new System.EventHandler(this.itemList_SelectedIndexChanged);
			this.itemList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.itemList_MouseDoubleClick);
			// 
			// bossTab
			// 
			this.bossTab.Controls.Add(this.bossList);
			this.bossTab.Location = new System.Drawing.Point(4, 22);
			this.bossTab.Name = "bossTab";
			this.bossTab.Size = new System.Drawing.Size(281, 458);
			this.bossTab.TabIndex = 3;
			this.bossTab.Text = "Bosses";
			this.bossTab.UseVisualStyleBackColor = true;
			// 
			// bossList
			// 
			this.bossList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bossList.FormattingEnabled = true;
			this.bossList.Location = new System.Drawing.Point(0, 0);
			this.bossList.Name = "bossList";
			this.bossList.Size = new System.Drawing.Size(281, 458);
			this.bossList.TabIndex = 4;
			this.bossList.SelectedIndexChanged += new System.EventHandler(this.bossList_SelectedIndexChanged);
			this.bossList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.bossList_MouseDoubleClick);
			// 
			// enemyTab
			// 
			this.enemyTab.Controls.Add(this.groupBox7);
			this.enemyTab.Controls.Add(this.enemyList);
			this.enemyTab.Location = new System.Drawing.Point(4, 22);
			this.enemyTab.Name = "enemyTab";
			this.enemyTab.Size = new System.Drawing.Size(281, 458);
			this.enemyTab.TabIndex = 4;
			this.enemyTab.Text = "Enemies";
			this.enemyTab.UseVisualStyleBackColor = true;
			// 
			// groupBox7
			// 
			this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox7.Location = new System.Drawing.Point(0, 403);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(281, 55);
			this.groupBox7.TabIndex = 9;
			this.groupBox7.TabStop = false;
			this.groupBox7.Enter += new System.EventHandler(this.groupBox7_Enter);
			// 
			// enemyList
			// 
			this.enemyList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.enemyList.FormattingEnabled = true;
			this.enemyList.Location = new System.Drawing.Point(0, 0);
			this.enemyList.Name = "enemyList";
			this.enemyList.Size = new System.Drawing.Size(281, 458);
			this.enemyList.TabIndex = 4;
			this.enemyList.SelectedIndexChanged += new System.EventHandler(this.enemyList_SelectedIndexChanged);
			this.enemyList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.enemyList_MouseDoubleClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.addObj);
			this.panel1.Controls.Add(this.cloneObj);
			this.panel1.Controls.Add(this.delObj);
			this.panel1.Controls.Add(this.editObj);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 500);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(289, 36);
			this.panel1.TabIndex = 5;
			// 
			// addObj
			// 
			this.addObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addObj.Location = new System.Drawing.Point(3, 6);
			this.addObj.Name = "addObj";
			this.addObj.Size = new System.Drawing.Size(46, 23);
			this.addObj.TabIndex = 1;
			this.addObj.Text = "+";
			this.addObj.UseVisualStyleBackColor = true;
			this.addObj.Click += new System.EventHandler(this.addObj_Click);
			// 
			// cloneObj
			// 
			this.cloneObj.Location = new System.Drawing.Point(173, 6);
			this.cloneObj.Name = "cloneObj";
			this.cloneObj.Size = new System.Drawing.Size(60, 23);
			this.cloneObj.TabIndex = 4;
			this.cloneObj.Text = "Duplicate";
			this.cloneObj.UseVisualStyleBackColor = true;
			this.cloneObj.Click += new System.EventHandler(this.cloneObj_Click);
			// 
			// delObj
			// 
			this.delObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.delObj.Location = new System.Drawing.Point(55, 6);
			this.delObj.Name = "delObj";
			this.delObj.Size = new System.Drawing.Size(46, 23);
			this.delObj.TabIndex = 2;
			this.delObj.Text = "-";
			this.delObj.UseVisualStyleBackColor = true;
			this.delObj.Click += new System.EventHandler(this.delObj_Click);
			// 
			// editObj
			// 
			this.editObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.editObj.Location = new System.Drawing.Point(107, 6);
			this.editObj.Name = "editObj";
			this.editObj.Size = new System.Drawing.Size(60, 23);
			this.editObj.TabIndex = 3;
			this.editObj.Text = "Edit";
			this.editObj.UseVisualStyleBackColor = true;
			this.editObj.Click += new System.EventHandler(this.editObj_Click);
			// 
			// glControl
			// 
			this.glControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.glControl.BackColor = System.Drawing.Color.Black;
			this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.glControl.Location = new System.Drawing.Point(295, 59);
			this.glControl.Name = "glControl";
			this.glControl.Size = new System.Drawing.Size(615, 461);
			this.glControl.TabIndex = 2;
			this.glControl.VSync = false;
			this.glControl.Load += new System.EventHandler(this.glControl_Load);
			this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
			this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
			this.glControl.MouseLeave += new System.EventHandler(this.glControl_MouseLeave);
			this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
			this.glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseUp);
			this.glControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseWheel);
			this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
			// 
			// resetCamera
			// 
			this.resetCamera.Location = new System.Drawing.Point(159, 3);
			this.resetCamera.Name = "resetCamera";
			this.resetCamera.Size = new System.Drawing.Size(82, 32);
			this.resetCamera.TabIndex = 6;
			this.resetCamera.Text = "Reset Camera";
			this.resetCamera.UseVisualStyleBackColor = true;
			this.resetCamera.Click += new System.EventHandler(this.resetCamera_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Coordinate";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(212, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Offset";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(66, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "X";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(66, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(14, 13);
			this.label4.TabIndex = 22;
			this.label4.Text = "Y";
			// 
			// xCoord
			// 
			this.xCoord.Location = new System.Drawing.Point(86, 14);
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
			this.xOffset.Location = new System.Drawing.Point(253, 14);
			this.xOffset.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.xOffset.Name = "xOffset";
			this.xOffset.Size = new System.Drawing.Size(41, 20);
			this.xOffset.TabIndex = 24;
			this.xOffset.ValueChanged += new System.EventHandler(this.xOffset_ValueChanged);
			// 
			// yOffset
			// 
			this.yOffset.Location = new System.Drawing.Point(253, 42);
			this.yOffset.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.yOffset.Name = "yOffset";
			this.yOffset.Size = new System.Drawing.Size(41, 20);
			this.yOffset.TabIndex = 26;
			this.yOffset.ValueChanged += new System.EventHandler(this.yOffset_ValueChanged);
			// 
			// yCoord
			// 
			this.yCoord.Location = new System.Drawing.Point(86, 42);
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
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Collision",
            "Decoration"});
			this.comboBox1.Location = new System.Drawing.Point(247, 3);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 27;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.editDeco);
			this.groupBox2.Controls.Add(this.editBlock);
			this.groupBox2.Controls.Add(this.editCol);
			this.groupBox2.Controls.Add(this.groupBox5);
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(270, 434);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tile Data Editor";
			// 
			// editDeco
			// 
			this.editDeco.AutoSize = true;
			this.editDeco.Checked = true;
			this.editDeco.CheckState = System.Windows.Forms.CheckState.Checked;
			this.editDeco.Location = new System.Drawing.Point(7, 412);
			this.editDeco.Name = "editDeco";
			this.editDeco.Size = new System.Drawing.Size(104, 17);
			this.editDeco.TabIndex = 61;
			this.editDeco.Text = "Edit Decorations";
			this.editDeco.UseVisualStyleBackColor = true;
			// 
			// editBlock
			// 
			this.editBlock.AutoSize = true;
			this.editBlock.Location = new System.Drawing.Point(7, 389);
			this.editBlock.Name = "editBlock";
			this.editBlock.Size = new System.Drawing.Size(79, 17);
			this.editBlock.TabIndex = 60;
			this.editBlock.Text = "Edit Blocks";
			this.editBlock.UseVisualStyleBackColor = true;
			// 
			// editCol
			// 
			this.editCol.AutoSize = true;
			this.editCol.Checked = true;
			this.editCol.CheckState = System.Windows.Forms.CheckState.Checked;
			this.editCol.Location = new System.Drawing.Point(7, 366);
			this.editCol.Name = "editCol";
			this.editCol.Size = new System.Drawing.Size(90, 17);
			this.editCol.TabIndex = 59;
			this.editCol.Text = "Edit Collisions";
			this.editCol.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.label13);
			this.groupBox5.Controls.Add(this.d4_4);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.d4_3);
			this.groupBox5.Controls.Add(this.d1_1);
			this.groupBox5.Controls.Add(this.d4_2);
			this.groupBox5.Controls.Add(this.d1_2);
			this.groupBox5.Controls.Add(this.d4_1);
			this.groupBox5.Controls.Add(this.d1_3);
			this.groupBox5.Controls.Add(this.d3_4);
			this.groupBox5.Controls.Add(this.d1_4);
			this.groupBox5.Controls.Add(this.d3_3);
			this.groupBox5.Controls.Add(this.d2_1);
			this.groupBox5.Controls.Add(this.d3_2);
			this.groupBox5.Controls.Add(this.d2_2);
			this.groupBox5.Controls.Add(this.d3_1);
			this.groupBox5.Controls.Add(this.d2_3);
			this.groupBox5.Controls.Add(this.d2_4);
			this.groupBox5.Location = new System.Drawing.Point(6, 242);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(258, 118);
			this.groupBox5.TabIndex = 58;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Decoration Data";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(40, 13);
			this.label11.TabIndex = 21;
			this.label11.Text = "MLand";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 42);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(39, 13);
			this.label12.TabIndex = 26;
			this.label12.Text = "Deco2";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 68);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(39, 13);
			this.label13.TabIndex = 31;
			this.label13.Text = "Deco3";
			// 
			// d4_4
			// 
			this.d4_4.Location = new System.Drawing.Point(187, 92);
			this.d4_4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d4_4.Name = "d4_4";
			this.d4_4.Size = new System.Drawing.Size(39, 20);
			this.d4_4.TabIndex = 52;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(6, 94);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(39, 13);
			this.label14.TabIndex = 36;
			this.label14.Text = "Deco4";
			// 
			// d4_3
			// 
			this.d4_3.Location = new System.Drawing.Point(142, 92);
			this.d4_3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d4_3.Name = "d4_3";
			this.d4_3.Size = new System.Drawing.Size(39, 20);
			this.d4_3.TabIndex = 51;
			// 
			// d1_1
			// 
			this.d1_1.Location = new System.Drawing.Point(52, 14);
			this.d1_1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d1_1.Name = "d1_1";
			this.d1_1.Size = new System.Drawing.Size(39, 20);
			this.d1_1.TabIndex = 37;
			// 
			// d4_2
			// 
			this.d4_2.Location = new System.Drawing.Point(97, 92);
			this.d4_2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d4_2.Name = "d4_2";
			this.d4_2.Size = new System.Drawing.Size(39, 20);
			this.d4_2.TabIndex = 50;
			// 
			// d1_2
			// 
			this.d1_2.Location = new System.Drawing.Point(97, 14);
			this.d1_2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d1_2.Name = "d1_2";
			this.d1_2.Size = new System.Drawing.Size(39, 20);
			this.d1_2.TabIndex = 38;
			// 
			// d4_1
			// 
			this.d4_1.Location = new System.Drawing.Point(52, 92);
			this.d4_1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d4_1.Name = "d4_1";
			this.d4_1.Size = new System.Drawing.Size(39, 20);
			this.d4_1.TabIndex = 49;
			// 
			// d1_3
			// 
			this.d1_3.Location = new System.Drawing.Point(142, 14);
			this.d1_3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d1_3.Name = "d1_3";
			this.d1_3.Size = new System.Drawing.Size(39, 20);
			this.d1_3.TabIndex = 39;
			// 
			// d3_4
			// 
			this.d3_4.Location = new System.Drawing.Point(187, 66);
			this.d3_4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d3_4.Name = "d3_4";
			this.d3_4.Size = new System.Drawing.Size(39, 20);
			this.d3_4.TabIndex = 48;
			// 
			// d1_4
			// 
			this.d1_4.Location = new System.Drawing.Point(187, 14);
			this.d1_4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d1_4.Name = "d1_4";
			this.d1_4.Size = new System.Drawing.Size(39, 20);
			this.d1_4.TabIndex = 40;
			// 
			// d3_3
			// 
			this.d3_3.Location = new System.Drawing.Point(142, 66);
			this.d3_3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d3_3.Name = "d3_3";
			this.d3_3.Size = new System.Drawing.Size(39, 20);
			this.d3_3.TabIndex = 47;
			// 
			// d2_1
			// 
			this.d2_1.Location = new System.Drawing.Point(52, 40);
			this.d2_1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d2_1.Name = "d2_1";
			this.d2_1.Size = new System.Drawing.Size(39, 20);
			this.d2_1.TabIndex = 41;
			// 
			// d3_2
			// 
			this.d3_2.Location = new System.Drawing.Point(97, 66);
			this.d3_2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d3_2.Name = "d3_2";
			this.d3_2.Size = new System.Drawing.Size(39, 20);
			this.d3_2.TabIndex = 46;
			// 
			// d2_2
			// 
			this.d2_2.Location = new System.Drawing.Point(97, 40);
			this.d2_2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d2_2.Name = "d2_2";
			this.d2_2.Size = new System.Drawing.Size(39, 20);
			this.d2_2.TabIndex = 42;
			// 
			// d3_1
			// 
			this.d3_1.Location = new System.Drawing.Point(52, 66);
			this.d3_1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d3_1.Name = "d3_1";
			this.d3_1.Size = new System.Drawing.Size(39, 20);
			this.d3_1.TabIndex = 45;
			// 
			// d2_3
			// 
			this.d2_3.Location = new System.Drawing.Point(142, 40);
			this.d2_3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d2_3.Name = "d2_3";
			this.d2_3.Size = new System.Drawing.Size(39, 20);
			this.d2_3.TabIndex = 43;
			// 
			// d2_4
			// 
			this.d2_4.Location = new System.Drawing.Point(187, 40);
			this.d2_4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.d2_4.Name = "d2_4";
			this.d2_4.Size = new System.Drawing.Size(39, 20);
			this.d2_4.TabIndex = 44;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.vblock);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Location = new System.Drawing.Point(6, 193);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(258, 43);
			this.groupBox4.TabIndex = 57;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Block Data";
			// 
			// vblock
			// 
			this.vblock.Location = new System.Drawing.Point(8, 16);
			this.vblock.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
			this.vblock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.vblock.Name = "vblock";
			this.vblock.Size = new System.Drawing.Size(51, 20);
			this.vblock.TabIndex = 53;
			this.vblock.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(65, 18);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 13);
			this.label10.TabIndex = 18;
			this.label10.Text = "Block";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.spike);
			this.groupBox3.Controls.Add(this.vshape);
			this.groupBox3.Controls.Add(this.vmat);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.vunk);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.ladder);
			this.groupBox3.Controls.Add(this.water);
			this.groupBox3.Controls.Add(this.lava);
			this.groupBox3.Location = new System.Drawing.Point(6, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(258, 168);
			this.groupBox3.TabIndex = 56;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Collision Data";
			// 
			// spike
			// 
			this.spike.AutoSize = true;
			this.spike.Image = global::JamBuilder.Properties.Resources.spike;
			this.spike.Location = new System.Drawing.Point(85, 89);
			this.spike.Name = "spike";
			this.spike.Size = new System.Drawing.Size(70, 17);
			this.spike.TabIndex = 56;
			this.spike.Text = "Spike";
			this.spike.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.spike.UseVisualStyleBackColor = true;
			// 
			// vshape
			// 
			this.vshape.Location = new System.Drawing.Point(7, 17);
			this.vshape.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
			this.vshape.Name = "vshape";
			this.vshape.Size = new System.Drawing.Size(69, 20);
			this.vshape.TabIndex = 8;
			// 
			// vmat
			// 
			this.vmat.Location = new System.Drawing.Point(7, 112);
			this.vmat.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.vmat.Name = "vmat";
			this.vmat.Size = new System.Drawing.Size(69, 20);
			this.vmat.TabIndex = 55;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(82, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "Collision Shape";
			// 
			// vunk
			// 
			this.vunk.Location = new System.Drawing.Point(7, 138);
			this.vunk.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.vunk.Name = "vunk";
			this.vunk.Size = new System.Drawing.Size(70, 20);
			this.vunk.TabIndex = 54;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(82, 114);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Collision Material";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(82, 140);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(83, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Unknown Value";
			// 
			// ladder
			// 
			this.ladder.AutoSize = true;
			this.ladder.Image = global::JamBuilder.Properties.Resources.ladder;
			this.ladder.Location = new System.Drawing.Point(7, 43);
			this.ladder.Name = "ladder";
			this.ladder.Size = new System.Drawing.Size(76, 17);
			this.ladder.TabIndex = 9;
			this.ladder.Text = "Ladder";
			this.ladder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.ladder.UseVisualStyleBackColor = true;
			// 
			// water
			// 
			this.water.AutoSize = true;
			this.water.Image = global::JamBuilder.Properties.Resources.water;
			this.water.Location = new System.Drawing.Point(7, 66);
			this.water.Name = "water";
			this.water.Size = new System.Drawing.Size(72, 17);
			this.water.TabIndex = 10;
			this.water.Text = "Water";
			this.water.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.water.UseVisualStyleBackColor = true;
			// 
			// lava
			// 
			this.lava.AutoSize = true;
			this.lava.Image = global::JamBuilder.Properties.Resources.damage;
			this.lava.Location = new System.Drawing.Point(7, 89);
			this.lava.Name = "lava";
			this.lava.Size = new System.Drawing.Size(67, 17);
			this.lava.TabIndex = 11;
			this.lava.Text = "Lava";
			this.lava.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.lava.UseVisualStyleBackColor = true;
			// 
			// pick
			// 
			this.pick.BackgroundImage = global::JamBuilder.Properties.Resources.pick;
			this.pick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pick.Location = new System.Drawing.Point(120, 3);
			this.pick.Name = "pick";
			this.pick.Size = new System.Drawing.Size(33, 33);
			this.pick.TabIndex = 29;
			this.pick.UseVisualStyleBackColor = true;
			this.pick.Click += new System.EventHandler(this.pick_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.sizeW);
			this.groupBox6.Controls.Add(this.label16);
			this.groupBox6.Controls.Add(this.sizeH);
			this.groupBox6.Controls.Add(this.label15);
			this.groupBox6.Location = new System.Drawing.Point(309, 9);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(270, 66);
			this.groupBox6.TabIndex = 30;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Level Size";
			// 
			// sizeW
			// 
			this.sizeW.Location = new System.Drawing.Point(175, 17);
			this.sizeW.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
			this.sizeW.Name = "sizeW";
			this.sizeW.Size = new System.Drawing.Size(78, 20);
			this.sizeW.TabIndex = 3;
			this.sizeW.ValueChanged += new System.EventHandler(this.UpdateLevelSize);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(134, 20);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(35, 13);
			this.label16.TabIndex = 2;
			this.label16.Text = "Width";
			// 
			// sizeH
			// 
			this.sizeH.Location = new System.Drawing.Point(50, 17);
			this.sizeH.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
			this.sizeH.Name = "sizeH";
			this.sizeH.Size = new System.Drawing.Size(78, 20);
			this.sizeH.TabIndex = 1;
			this.sizeH.ValueChanged += new System.EventHandler(this.UpdateLevelSize);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(6, 19);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(38, 13);
			this.label15.TabIndex = 0;
			this.label15.Text = "Height";
			// 
			// draw
			// 
			this.draw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.draw.Image = global::JamBuilder.Properties.Resources.draw;
			this.draw.Location = new System.Drawing.Point(81, 3);
			this.draw.Name = "draw";
			this.draw.Size = new System.Drawing.Size(33, 33);
			this.draw.TabIndex = 5;
			this.draw.UseVisualStyleBackColor = true;
			this.draw.Click += new System.EventHandler(this.draw_Click);
			// 
			// move
			// 
			this.move.BackgroundImage = global::JamBuilder.Properties.Resources.move;
			this.move.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.move.Location = new System.Drawing.Point(42, 3);
			this.move.Name = "move";
			this.move.Size = new System.Drawing.Size(33, 33);
			this.move.TabIndex = 4;
			this.move.UseVisualStyleBackColor = true;
			this.move.Click += new System.EventHandler(this.move_Click);
			// 
			// select
			// 
			this.select.BackgroundImage = global::JamBuilder.Properties.Resources.select;
			this.select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.select.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.select.Location = new System.Drawing.Point(3, 3);
			this.select.Name = "select";
			this.select.Size = new System.Drawing.Size(33, 33);
			this.select.TabIndex = 3;
			this.select.UseVisualStyleBackColor = true;
			this.select.Click += new System.EventHandler(this.select_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.select);
			this.flowLayoutPanel1.Controls.Add(this.move);
			this.flowLayoutPanel1.Controls.Add(this.draw);
			this.flowLayoutPanel1.Controls.Add(this.pick);
			this.flowLayoutPanel1.Controls.Add(this.resetCamera);
			this.flowLayoutPanel1.Controls.Add(this.comboBox1);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1185, 35);
			this.flowLayoutPanel1.TabIndex = 31;
			// 
			// panel2
			// 
			this.panel2.AutoScroll = true;
			this.panel2.Controls.Add(this.groupBox2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(910, 59);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(275, 539);
			this.panel2.TabIndex = 33;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.groupBox8);
			this.panel3.Controls.Add(this.groupBox6);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(295, 520);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(615, 78);
			this.panel3.TabIndex = 34;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.label1);
			this.groupBox8.Controls.Add(this.yCoord);
			this.groupBox8.Controls.Add(this.label2);
			this.groupBox8.Controls.Add(this.yOffset);
			this.groupBox8.Controls.Add(this.label3);
			this.groupBox8.Controls.Add(this.xOffset);
			this.groupBox8.Controls.Add(this.label4);
			this.groupBox8.Controls.Add(this.xCoord);
			this.groupBox8.Location = new System.Drawing.Point(3, 3);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(300, 72);
			this.groupBox8.TabIndex = 31;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "groupBox8";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1185, 598);
			this.Controls.Add(this.glControl);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.menuStrip1);
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
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.xCoord)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xOffset)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yOffset)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yCoord)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.d4_4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d4_3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d1_1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d4_2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d1_2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d4_1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d1_3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d3_4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d1_4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d3_3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d2_1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d3_2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d2_2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d3_1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d2_3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.d2_4)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.vblock)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.vshape)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vmat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vunk)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.sizeW)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sizeH)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
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
        private System.Windows.Forms.ListBox guestItemList;
        private System.Windows.Forms.TabPage itemTab;
        private System.Windows.Forms.ListBox itemList;
        private System.Windows.Forms.TabPage bossTab;
        private System.Windows.Forms.ListBox bossList;
        private System.Windows.Forms.TabPage enemyTab;
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cloneObj;
        private System.Windows.Forms.ToolStripMenuItem renderSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderTileModifiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderBlocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderObjectPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderGuestStarItemPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderItemPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderBossPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderEnemyPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderObjectNamesToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox lava;
        private System.Windows.Forms.CheckBox water;
        private System.Windows.Forms.CheckBox ladder;
        private System.Windows.Forms.NumericUpDown vshape;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown d4_4;
        private System.Windows.Forms.NumericUpDown d4_3;
        private System.Windows.Forms.NumericUpDown d4_2;
        private System.Windows.Forms.NumericUpDown d4_1;
        private System.Windows.Forms.NumericUpDown d3_4;
        private System.Windows.Forms.NumericUpDown d3_3;
        private System.Windows.Forms.NumericUpDown d3_2;
        private System.Windows.Forms.NumericUpDown d3_1;
        private System.Windows.Forms.NumericUpDown d2_4;
        private System.Windows.Forms.NumericUpDown d2_3;
        private System.Windows.Forms.NumericUpDown d2_2;
        private System.Windows.Forms.NumericUpDown d2_1;
        private System.Windows.Forms.NumericUpDown d1_4;
        private System.Windows.Forms.NumericUpDown d1_3;
        private System.Windows.Forms.NumericUpDown d1_2;
        private System.Windows.Forms.NumericUpDown d1_1;
        private System.Windows.Forms.NumericUpDown vmat;
        private System.Windows.Forms.NumericUpDown vunk;
        private System.Windows.Forms.NumericUpDown vblock;
        private System.Windows.Forms.CheckBox editDeco;
        private System.Windows.Forms.CheckBox editBlock;
        private System.Windows.Forms.CheckBox editCol;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button pick;
        private System.Windows.Forms.CheckBox spike;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown sizeH;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown sizeW;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TabPage guestStarItemTab;
		private System.Windows.Forms.ToolStripMenuItem objectListFormatToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatShowIndex;
		private System.Windows.Forms.ToolStripMenuItem formatShowKind;
		private System.Windows.Forms.ToolStripMenuItem formatShowWuid;
	}
}

