﻿namespace JamBuilder
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.objTab = new System.Windows.Forms.TabPage();
            this.cloneObj = new System.Windows.Forms.Button();
            this.editObj = new System.Windows.Forms.Button();
            this.delObj = new System.Windows.Forms.Button();
            this.addObj = new System.Windows.Forms.Button();
            this.objList = new System.Windows.Forms.ListBox();
            this.guestStarItemTab = new System.Windows.Forms.TabPage();
            this.cloneGuestItem = new System.Windows.Forms.Button();
            this.editGuestItem = new System.Windows.Forms.Button();
            this.delGuestItem = new System.Windows.Forms.Button();
            this.addGuestItem = new System.Windows.Forms.Button();
            this.guestItemList = new System.Windows.Forms.ListBox();
            this.itemTab = new System.Windows.Forms.TabPage();
            this.cloneItem = new System.Windows.Forms.Button();
            this.editItem = new System.Windows.Forms.Button();
            this.delItem = new System.Windows.Forms.Button();
            this.addItem = new System.Windows.Forms.Button();
            this.itemList = new System.Windows.Forms.ListBox();
            this.bossTab = new System.Windows.Forms.TabPage();
            this.cloneBoss = new System.Windows.Forms.Button();
            this.editBoss = new System.Windows.Forms.Button();
            this.delBoss = new System.Windows.Forms.Button();
            this.addBoss = new System.Windows.Forms.Button();
            this.bossList = new System.Windows.Forms.ListBox();
            this.enemyTab = new System.Windows.Forms.TabPage();
            this.cloneEnemy = new System.Windows.Forms.Button();
            this.editEnemy = new System.Windows.Forms.Button();
            this.delEnemy = new System.Windows.Forms.Button();
            this.addEnemy = new System.Windows.Forms.Button();
            this.enemyList = new System.Windows.Forms.ListBox();
            this.glControl = new OpenTK.GLControl(new OpenTK.Graphics.GraphicsMode(),3,3,OpenTK.Graphics.GraphicsContextFlags.Default);
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
            this.vshape = new System.Windows.Forms.NumericUpDown();
            this.vmat = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.vunk = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pick = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.sizeW = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.sizeH = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.spike = new System.Windows.Forms.CheckBox();
            this.ladder = new System.Windows.Forms.CheckBox();
            this.water = new System.Windows.Forms.CheckBox();
            this.lava = new System.Windows.Forms.CheckBox();
            this.draw = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(1138, 24);
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
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
            this.renderEnemyPointsToolStripMenuItem});
            this.renderSettingsToolStripMenuItem.Name = "renderSettingsToolStripMenuItem";
            this.renderSettingsToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.renderSettingsToolStripMenuItem.Text = "Render Settings";
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
            this.objTab.Controls.Add(this.cloneObj);
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
            // cloneObj
            // 
            this.cloneObj.Location = new System.Drawing.Point(187, 385);
            this.cloneObj.Name = "cloneObj";
            this.cloneObj.Size = new System.Drawing.Size(60, 23);
            this.cloneObj.TabIndex = 4;
            this.cloneObj.Text = "Duplicate";
            this.cloneObj.UseVisualStyleBackColor = true;
            this.cloneObj.Click += new System.EventHandler(this.cloneObj_Click);
            // 
            // editObj
            // 
            this.editObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editObj.Location = new System.Drawing.Point(121, 385);
            this.editObj.Name = "editObj";
            this.editObj.Size = new System.Drawing.Size(60, 23);
            this.editObj.TabIndex = 3;
            this.editObj.Text = "Edit";
            this.editObj.UseVisualStyleBackColor = true;
            this.editObj.Click += new System.EventHandler(this.editObj_Click);
            // 
            // delObj
            // 
            this.delObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delObj.Location = new System.Drawing.Point(69, 385);
            this.delObj.Name = "delObj";
            this.delObj.Size = new System.Drawing.Size(46, 23);
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
            this.addObj.Size = new System.Drawing.Size(46, 23);
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
            this.guestStarItemTab.Controls.Add(this.cloneGuestItem);
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
            // cloneGuestItem
            // 
            this.cloneGuestItem.Location = new System.Drawing.Point(187, 385);
            this.cloneGuestItem.Name = "cloneGuestItem";
            this.cloneGuestItem.Size = new System.Drawing.Size(60, 23);
            this.cloneGuestItem.TabIndex = 8;
            this.cloneGuestItem.Text = "Duplicate";
            this.cloneGuestItem.UseVisualStyleBackColor = true;
            this.cloneGuestItem.Click += new System.EventHandler(this.cloneGuestItem_Click);
            // 
            // editGuestItem
            // 
            this.editGuestItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editGuestItem.Location = new System.Drawing.Point(121, 385);
            this.editGuestItem.Name = "editGuestItem";
            this.editGuestItem.Size = new System.Drawing.Size(60, 23);
            this.editGuestItem.TabIndex = 7;
            this.editGuestItem.Text = "Edit";
            this.editGuestItem.UseVisualStyleBackColor = true;
            this.editGuestItem.Click += new System.EventHandler(this.editGuestItem_Click);
            // 
            // delGuestItem
            // 
            this.delGuestItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delGuestItem.Location = new System.Drawing.Point(69, 385);
            this.delGuestItem.Name = "delGuestItem";
            this.delGuestItem.Size = new System.Drawing.Size(46, 23);
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
            this.addGuestItem.Size = new System.Drawing.Size(46, 23);
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
            this.itemTab.Controls.Add(this.cloneItem);
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
            // cloneItem
            // 
            this.cloneItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cloneItem.Location = new System.Drawing.Point(187, 385);
            this.cloneItem.Name = "cloneItem";
            this.cloneItem.Size = new System.Drawing.Size(60, 23);
            this.cloneItem.TabIndex = 8;
            this.cloneItem.Text = "Duplicate";
            this.cloneItem.UseVisualStyleBackColor = true;
            this.cloneItem.Click += new System.EventHandler(this.cloneItem_Click);
            // 
            // editItem
            // 
            this.editItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editItem.Location = new System.Drawing.Point(121, 385);
            this.editItem.Name = "editItem";
            this.editItem.Size = new System.Drawing.Size(60, 23);
            this.editItem.TabIndex = 7;
            this.editItem.Text = "Edit";
            this.editItem.UseVisualStyleBackColor = true;
            this.editItem.Click += new System.EventHandler(this.editItem_Click);
            // 
            // delItem
            // 
            this.delItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delItem.Location = new System.Drawing.Point(69, 385);
            this.delItem.Name = "delItem";
            this.delItem.Size = new System.Drawing.Size(46, 23);
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
            this.addItem.Size = new System.Drawing.Size(46, 23);
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
            this.bossTab.Controls.Add(this.cloneBoss);
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
            // cloneBoss
            // 
            this.cloneBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cloneBoss.Location = new System.Drawing.Point(187, 385);
            this.cloneBoss.Name = "cloneBoss";
            this.cloneBoss.Size = new System.Drawing.Size(60, 23);
            this.cloneBoss.TabIndex = 8;
            this.cloneBoss.Text = "Duplicate";
            this.cloneBoss.UseVisualStyleBackColor = true;
            this.cloneBoss.Click += new System.EventHandler(this.cloneBoss_Click);
            // 
            // editBoss
            // 
            this.editBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBoss.Location = new System.Drawing.Point(121, 385);
            this.editBoss.Name = "editBoss";
            this.editBoss.Size = new System.Drawing.Size(60, 23);
            this.editBoss.TabIndex = 7;
            this.editBoss.Text = "Edit";
            this.editBoss.UseVisualStyleBackColor = true;
            this.editBoss.Click += new System.EventHandler(this.editBoss_Click);
            // 
            // delBoss
            // 
            this.delBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delBoss.Location = new System.Drawing.Point(69, 385);
            this.delBoss.Name = "delBoss";
            this.delBoss.Size = new System.Drawing.Size(46, 23);
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
            this.addBoss.Size = new System.Drawing.Size(46, 23);
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
            this.enemyTab.Controls.Add(this.cloneEnemy);
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
            // cloneEnemy
            // 
            this.cloneEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cloneEnemy.Location = new System.Drawing.Point(187, 385);
            this.cloneEnemy.Name = "cloneEnemy";
            this.cloneEnemy.Size = new System.Drawing.Size(60, 23);
            this.cloneEnemy.TabIndex = 8;
            this.cloneEnemy.Text = "Duplicate";
            this.cloneEnemy.UseVisualStyleBackColor = true;
            this.cloneEnemy.Click += new System.EventHandler(this.cloneEnemy_Click);
            // 
            // editEnemy
            // 
            this.editEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editEnemy.Location = new System.Drawing.Point(121, 385);
            this.editEnemy.Name = "editEnemy";
            this.editEnemy.Size = new System.Drawing.Size(60, 23);
            this.editEnemy.TabIndex = 7;
            this.editEnemy.Text = "Edit";
            this.editEnemy.UseVisualStyleBackColor = true;
            this.editEnemy.Click += new System.EventHandler(this.editEnemy_Click);
            // 
            // delEnemy
            // 
            this.delEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delEnemy.Location = new System.Drawing.Point(69, 385);
            this.delEnemy.Name = "delEnemy";
            this.delEnemy.Size = new System.Drawing.Size(46, 23);
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
            this.addEnemy.Size = new System.Drawing.Size(46, 23);
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
            // resetCamera
            // 
            this.resetCamera.Location = new System.Drawing.Point(458, 33);
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
            this.label1.Location = new System.Drawing.Point(321, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Coordinate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Offset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 473);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Y";
            // 
            // xCoord
            // 
            this.xCoord.Location = new System.Drawing.Point(401, 443);
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
            this.xOffset.Location = new System.Drawing.Point(568, 443);
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
            this.yOffset.Location = new System.Drawing.Point(568, 471);
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
            this.yCoord.Location = new System.Drawing.Point(401, 471);
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
            this.comboBox1.Location = new System.Drawing.Point(546, 44);
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
            this.groupBox2.Location = new System.Drawing.Point(856, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 414);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tile Data Editor";
            // 
            // editDeco
            // 
            this.editDeco.AutoSize = true;
            this.editDeco.Checked = true;
            this.editDeco.CheckState = System.Windows.Forms.CheckState.Checked;
            this.editDeco.Location = new System.Drawing.Point(6, 392);
            this.editDeco.Name = "editDeco";
            this.editDeco.Size = new System.Drawing.Size(104, 17);
            this.editDeco.TabIndex = 61;
            this.editDeco.Text = "Edit Decorations";
            this.editDeco.UseVisualStyleBackColor = true;
            // 
            // editBlock
            // 
            this.editBlock.AutoSize = true;
            this.editBlock.Location = new System.Drawing.Point(6, 369);
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
            this.editCol.Location = new System.Drawing.Point(6, 346);
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
            this.groupBox5.Location = new System.Drawing.Point(6, 227);
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
            this.groupBox4.Location = new System.Drawing.Point(6, 184);
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
            this.groupBox3.Size = new System.Drawing.Size(258, 165);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Collision Data";
            // 
            // vshape
            // 
            this.vshape.Location = new System.Drawing.Point(6, 19);
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
            this.vmat.Location = new System.Drawing.Point(6, 114);
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
            this.label5.Location = new System.Drawing.Point(81, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Collision Shape";
            // 
            // vunk
            // 
            this.vunk.Location = new System.Drawing.Point(6, 140);
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
            this.label7.Location = new System.Drawing.Point(81, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Collision Material";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Unknown Value";
            // 
            // pick
            // 
            this.pick.BackgroundImage = global::JamBuilder.Properties.Resources.pick;
            this.pick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pick.Location = new System.Drawing.Point(421, 32);
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
            this.groupBox6.Location = new System.Drawing.Point(856, 447);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(270, 45);
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
            // spike
            // 
            this.spike.AutoSize = true;
            this.spike.Image = global::JamBuilder.Properties.Resources.spike;
            this.spike.Location = new System.Drawing.Point(84, 91);
            this.spike.Name = "spike";
            this.spike.Size = new System.Drawing.Size(70, 17);
            this.spike.TabIndex = 56;
            this.spike.Text = "Spike";
            this.spike.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.spike.UseVisualStyleBackColor = true;
            // 
            // ladder
            // 
            this.ladder.AutoSize = true;
            this.ladder.Image = global::JamBuilder.Properties.Resources.ladder;
            this.ladder.Location = new System.Drawing.Point(6, 45);
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
            this.water.Location = new System.Drawing.Point(6, 68);
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
            this.lava.Location = new System.Drawing.Point(6, 91);
            this.lava.Name = "lava";
            this.lava.Size = new System.Drawing.Size(67, 17);
            this.lava.TabIndex = 11;
            this.lava.Text = "Lava";
            this.lava.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.lava.UseVisualStyleBackColor = true;
            // 
            // draw
            // 
            this.draw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.draw.Image = global::JamBuilder.Properties.Resources.draw;
            this.draw.Location = new System.Drawing.Point(384, 32);
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
            this.move.Location = new System.Drawing.Point(347, 32);
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
            this.select.Location = new System.Drawing.Point(310, 32);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(33, 33);
            this.select.TabIndex = 3;
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 504);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.pick);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBox1);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cloneObj;
        private System.Windows.Forms.Button cloneGuestItem;
        private System.Windows.Forms.Button cloneItem;
        private System.Windows.Forms.Button cloneBoss;
        private System.Windows.Forms.Button cloneEnemy;
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
    }
}

