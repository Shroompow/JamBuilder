﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using JamBuilder.Rendering;
using KSALVL;

namespace JamBuilder
{
    public partial class Form1 : Form
    {
        public Level level;
        public string filePath;

        List<int> texIds = new List<int>();
        List<int> modTexIds = new List<int>();
        List<int> objTexIds = new List<int>();
        Dictionary<short, int> blockTexIds = new Dictionary<short, int>();
		
        Camera camera;

        BmFont font;

		RenderManager renderManager;

		private System.Timers.Timer t;

        bool moveCam = false;
        int mouseX = 0;
        int mouseY = 0;

        int moveObj;

        int tool = -1;

        uint tileX;
        uint tileY;
        uint selTileX1;
        uint selTileY1;
        uint selTileX2;
        uint selTileY2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        public void RefreshObjectLists()
        {
            int selIndex = 0;

            if (tabControl1.SelectedTab == objTab) selIndex = objList.SelectedIndex;
            if (tabControl1.SelectedTab == guestStarItemTab) selIndex = guestItemList.SelectedIndex;
            if (tabControl1.SelectedTab == itemTab) selIndex = itemList.SelectedIndex;
            if (tabControl1.SelectedTab == bossTab) selIndex = bossList.SelectedIndex;
            if (tabControl1.SelectedTab == enemyTab) selIndex = enemyList.SelectedIndex;

            objList.Items.Clear();
            guestItemList.Items.Clear();
            itemList.Items.Clear();
            bossList.Items.Clear();
            enemyList.Items.Clear();

            objList.BeginUpdate();
            guestItemList.BeginUpdate();
            itemList.BeginUpdate();
            bossList.BeginUpdate();
            enemyList.BeginUpdate();

            for (int i = 0; i < level.Objects.Count; i++)
            {
                objList.Items.Add(level.Objects[i]["string kind"]);
            }
            for (int i = 0; i < level.GuestStarItems.Count; i++)
            {
                guestItemList.Items.Add(level.GuestStarItems[i]["string kind"]);
            }
            for (int i = 0; i < level.Items.Count; i++)
            {
                itemList.Items.Add(level.Items[i]["string kind"]);
            }
            for (int i = 0; i < level.Bosses.Count; i++)
            {
                bossList.Items.Add(level.Bosses[i]["string kind"]);
            }
            for (int i = 0; i < level.Enemies.Count; i++)
            {
                enemyList.Items.Add(level.Enemies[i]["string kind"]);
            }

            if (tabControl1.SelectedTab == objTab && objList.Items.Count >= selIndex + 1) objList.SelectedIndex = selIndex;
            if (tabControl1.SelectedTab == guestStarItemTab && guestItemList.Items.Count >= selIndex + 1) guestItemList.SelectedIndex = selIndex;
            if (tabControl1.SelectedTab == itemTab && itemList.Items.Count >= selIndex + 1) itemList.SelectedIndex = selIndex;
            if (tabControl1.SelectedTab == bossTab && bossList.Items.Count >= selIndex + 1) bossList.SelectedIndex = selIndex;
            if (tabControl1.SelectedTab == enemyTab && enemyList.Items.Count >= selIndex + 1) enemyList.SelectedIndex = selIndex;

            objList.EndUpdate();
            guestItemList.EndUpdate();
            itemList.EndUpdate();
            bossList.EndUpdate();
            enemyList.EndUpdate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Kirby Star Allies Level Files|*.dat";
            open.DefaultExt = ".dat";
            open.CheckFileExists = true;
            open.Title = "Open Level File";
            if (open.ShowDialog() == DialogResult.OK)
            {
                a = true;

                filePath = open.FileName;
                objList.Items.Clear();
                guestItemList.Items.Clear();
                itemList.Items.Clear();
                bossList.Items.Clear();
                enemyList.Items.Clear();

                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                this.Text = $"JamBuilder - Opening {filePath}...";
                level = new Level(open.FileName);

                sizeW.Value = level.Width;
                sizeH.Value = level.Height;

                camera.pos = Vector2.Zero;
                camera.zoom = 1.1;
                RefreshObjectLists();

                this.Text = $"JamBuilder - {filePath}";
                this.Cursor = Cursors.Arrow;
                this.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;

                a = false;
            }
        }
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLevel newlvl = new NewLevel();
            if (newlvl.ShowDialog() == DialogResult.OK)
            {
                a = true;

                objList.Items.Clear();
                guestItemList.Items.Clear();
                itemList.Items.Clear();
                bossList.Items.Clear();
                enemyList.Items.Clear();

                level = newlvl.level;

                camera.pos = Vector2.Zero;
                camera.zoom = 1.1;
                RefreshObjectLists();

                sizeH.Value = level.Height;
                sizeW.Value = level.Width;

                this.Text = $"JamBuilder - New Level";

                saveAsToolStripMenuItem.Enabled = true;

                a = false;
            }
        }

        private void editObj_Click(object sender, EventArgs e)
        {
            if (objList.SelectedItem != null && level != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.obj = level.Objects[objList.SelectedIndex];
                editor.editorType = 0;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.Objects[objList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void editGuestItem_Click(object sender, EventArgs e)
        {
            if (guestItemList.SelectedItem != null && level != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.obj = level.GuestStarItems[guestItemList.SelectedIndex];
                editor.editorType = 1;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.GuestStarItems[guestItemList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void editItem_Click(object sender, EventArgs e)
        {
            if (itemList.SelectedItem != null && level != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.obj = level.Items[itemList.SelectedIndex];
                editor.editorType = 2;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.Items[itemList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void editBoss_Click(object sender, EventArgs e)
        {
            if (bossList.SelectedItem != null && level != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.obj = level.Bosses[bossList.SelectedIndex];
                editor.editorType = 3;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.Bosses[bossList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void editEnemy_Click(object sender, EventArgs e)
        {
            if (enemyList.SelectedItem != null && level != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.obj = level.Enemies[enemyList.SelectedIndex];
                editor.editorType = 4;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.Enemies[enemyList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void glControl_Load(object sender, EventArgs e)
        {
			camera = new Camera(Vector2.Zero,1.0);
			renderManager = new RenderManager(this.glControl);
			t = new System.Timers.Timer(1000.0 / 60.0);
            t.Elapsed += t_Elapsed;
            t.Start();
        }

        private void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            glControl.Invalidate();
            t.Start();
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
			renderManager.render();
        }

        public int GetUniqueWUID()
        {
            int wuid = 0;
            Random random = new Random();
            wuid = random.Next();

            for (int i = 0; i < level.Objects.Count; i++)
            {
                if (int.Parse(level.Objects[i]["int wuid"]) == wuid)
                {
                    random = new Random();
                    wuid = random.Next();
                    i = -1;
                }
            }

            for (int i = 0; i < level.GuestStarItems.Count; i++)
            {
                if (int.Parse(level.GuestStarItems[i]["int wuid"]) == wuid)
                {
                    random = new Random();
                    wuid = random.Next();
                    i = -1;
                }
            }

            for (int i = 0; i < level.Items.Count; i++)
            {
                if (int.Parse(level.Items[i]["int wuid"]) == wuid)
                {
                    random = new Random();
                    wuid = random.Next();
                    i = -1;
                }
            }

            for (int i = 0; i < level.Bosses.Count; i++)
            {
                if (int.Parse(level.Bosses[i]["int wuid"]) == wuid)
                {
                    random = new Random();
                    wuid = random.Next();
                    i = -1;
                }
            }

            for (int i = 0; i < level.Enemies.Count; i++)
            {
                if (int.Parse(level.Enemies[i]["int wuid"]) == wuid)
                {
                    random = new Random();
                    wuid = random.Next();
                    i = -1;
                }
            }

            return wuid;
        }

        private void addObj_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                AddObj addObj = new AddObj();
                addObj.editorType = 0;
                if (addObj.ShowDialog() == DialogResult.OK)
                {
                    addObj.obj["int wuid"] = GetUniqueWUID().ToString();
                    level.Objects.Add(addObj.obj);
                    RefreshObjectLists();
                }
            }
        }

        private void addGuestItem_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                AddObj addObj = new AddObj();
                addObj.editorType = 1;
                if (addObj.ShowDialog() == DialogResult.OK)
                {
                    addObj.obj["int wuid"] = GetUniqueWUID().ToString();
                    level.GuestStarItems.Add(addObj.obj);
                    RefreshObjectLists();
                }
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                AddObj addObj = new AddObj();
                addObj.editorType = 2;
                if (addObj.ShowDialog() == DialogResult.OK)
                {
                    addObj.obj["int wuid"] = GetUniqueWUID().ToString();
                    level.Items.Add(addObj.obj);
                    RefreshObjectLists();
                }
            }
        }

        private void addBoss_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                AddObj addObj = new AddObj();
                addObj.editorType = 3;
                if (addObj.ShowDialog() == DialogResult.OK)
                {
                    addObj.obj["int wuid"] = GetUniqueWUID().ToString();
                    level.Bosses.Add(addObj.obj);
                    RefreshObjectLists();
                }
            }
        }

        private void addEnemy_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                AddObj addObj = new AddObj();
                addObj.editorType = 4;
                if (addObj.ShowDialog() == DialogResult.OK)
                {
                    addObj.obj["int wuid"] = GetUniqueWUID().ToString();
                    level.Enemies.Add(addObj.obj);
                    RefreshObjectLists();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                Save();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Kirby Star Allies Level Files|*.dat";
                save.DefaultExt = ".dat";
                save.Title = "Save Level File";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    filePath = save.FileName;
                    Save();
                }
            }
        }

        public void Save()
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            this.Text = $"JamBuilder - Saving {filePath}...";
            level.Write(filePath);
            this.Text = $"JamBuilder - {filePath}";
            this.Cursor = Cursors.Arrow;
            this.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void delObj_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                if (objList.SelectedItem != null)
                {
                    level.Objects.RemoveAt(objList.SelectedIndex);
                    RefreshObjectLists();
                }
            }
        }

        private void delGuestItem_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                if (guestItemList.SelectedItem != null)
                {
                    level.GuestStarItems.RemoveAt(guestItemList.SelectedIndex);
                    RefreshObjectLists();
                }
            }
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                if (itemList.SelectedItem != null)
                {
                    level.Items.RemoveAt(itemList.SelectedIndex);
                    RefreshObjectLists();
                }
            }
        }

        private void delBoss_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                if (bossList.SelectedItem != null)
                {
                    level.Bosses.RemoveAt(bossList.SelectedIndex);
                    RefreshObjectLists();
                }
            }
        }

        private void delEnemy_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                if (enemyList.SelectedItem != null)
                {
                    level.Enemies.RemoveAt(enemyList.SelectedIndex);
                    RefreshObjectLists();
                }
            }
        }

        private void stageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                StageSettings settings = new StageSettings();
                settings.stage = level.StageData;
                settings.bg = level.Background;
                settings.tileset = level.Tileset;
                if (settings.ShowDialog() == DialogResult.OK)
                {
                    level.StageData = settings.stage;
                    level.Background = settings.bg;
                    level.Tileset = settings.tileset;
                }
            }
        }

        private void objList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (level != null)
            {
                if (objList.SelectedItem != null)
                {
                    editObj_Click(this, new EventArgs());
                }
            }
        }

        private void guestItemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (level != null)
            {
                if (guestItemList.SelectedItem != null)
                {
                    editGuestItem_Click(this, new EventArgs());
                }
            }
        }

        private void itemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (level != null)
            {
                if (itemList.SelectedItem != null)
                {
                    editItem_Click(this, new EventArgs());
                }
            }
        }

        private void bossList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (level != null)
            {
                if (bossList.SelectedItem != null)
                {
                    editBoss_Click(this, new EventArgs());
                }
            }
        }

        private void enemyList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (level != null)
            {
                if (enemyList.SelectedItem != null)
                {
                    editEnemy_Click(this, new EventArgs());
                }
            }
        }

        private void glControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                moveCam = true;
                mouseX = e.X;
                mouseY = e.Y;
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (tool == 0)
                {
                    selTileX1 = tileX;
                    selTileY1 = tileY;
                    selTileX2 = tileX;
                    selTileY2 = tileY;
                }
                else if (tool == 1)
                {

                }
                else if (tool == 2)
                {
                    int ix = (int)((tileY * level.Width) + tileX);

                    if (editCol.Checked)
                    {
                        Collision c = level.TileCollision[ix];
                        c.Shape = (byte)vshape.Value;
                        c.Modifier = 0;
                        if (ladder.Checked) c.Modifier += 2;
                        if (water.Checked) c.Modifier += 8;
                        if (spike.Checked) c.Modifier += 16;
                        if (lava.Checked) c.Modifier += 64;
                        c.Material = (byte)vmat.Value;
                        c.Unk = (byte)vunk.Value;
                        level.TileCollision[ix] = c;
                    }
                    if (editBlock.Checked)
                    {
                        Block b = level.TileBlock[ix];
                        b.ID = (short)vblock.Value;
                        level.TileBlock[ix] = b;
                    }
                    if (editDeco.Checked)
                    {
                        Decoration ml = level.MLandDecoration[ix];
                        Decoration bl = level.BLandDecoration[ix];
                        Decoration fl = level.FLandDecoration[ix];
                        Decoration ul = level.Unk_Decoration[ix];

                        bl.Unk_1 = (byte)d1_1.Value;
                        bl.Unk_2 = (byte)d1_2.Value;
                        bl.Unk_3 = (byte)d1_3.Value;
                        bl.Unk_4 = (byte)d1_4.Value;

                        ml.Unk_1 = (byte)d2_1.Value;
                        ml.Unk_2 = (byte)d2_2.Value;
                        ml.Unk_3 = (byte)d2_3.Value;
                        ml.Unk_4 = (byte)d2_4.Value;

                        fl.Unk_1 = (byte)d3_1.Value;
                        fl.Unk_2 = (byte)d3_2.Value;
                        fl.Unk_3 = (byte)d3_3.Value;
                        fl.Unk_4 = (byte)d3_4.Value;

                        ul.Unk_1 = (byte)d4_1.Value;
                        ul.Unk_2 = (byte)d4_2.Value;
                        ul.Unk_3 = (byte)d4_3.Value;
                        ul.Unk_4 = (byte)d4_4.Value;

                        level.MLandDecoration[ix] = bl;
                        level.BLandDecoration[ix] = ml;
                        level.FLandDecoration[ix] = fl;
                        level.Unk_Decoration[ix] = ul;
                    }
                }
                else if (tool == 3)
                {
                    int ix = (int)((tileY * level.Width) + tileX);
                    
                    vshape.Value = level.TileCollision[ix].Shape;

                    if ((level.TileCollision[ix].Modifier & (1 << 1)) != 0)
                    {
                        ladder.Checked = true;
                    }
                    else { ladder.Checked = false; }

                    if ((level.TileCollision[ix].Modifier & (1 << 3)) != 0)
                    {
                        water.Checked = true;
                    }
                    else { water.Checked = false; }

                    if ((level.TileCollision[ix].Modifier & (1 << 4)) != 0)
                    {
                        spike.Checked = true;
                    }
                    else { spike.Checked = false; }

                    if ((level.TileCollision[ix].Modifier & (1 << 6)) != 0)
                    {
                        lava.Checked = true;
                    }
                    else { lava.Checked = false; }

                    vmat.Value = level.TileCollision[ix].Material;

                    vunk.Value = level.TileCollision[ix].Unk;

                    vblock.Value = level.TileBlock[ix].ID;

                    d1_1.Value = level.MLandDecoration[ix].Unk_1;
                    d1_2.Value = level.MLandDecoration[ix].Unk_2;
                    d1_3.Value = level.MLandDecoration[ix].Unk_3;
                    d1_4.Value = level.MLandDecoration[ix].Unk_4;

                    d2_1.Value = level.BLandDecoration[ix].Unk_1;
                    d2_2.Value = level.BLandDecoration[ix].Unk_2;
                    d2_3.Value = level.BLandDecoration[ix].Unk_3;
                    d2_4.Value = level.BLandDecoration[ix].Unk_4;

                    d3_1.Value = level.FLandDecoration[ix].Unk_1;
                    d3_2.Value = level.FLandDecoration[ix].Unk_2;
                    d3_3.Value = level.FLandDecoration[ix].Unk_3;
                    d3_4.Value = level.FLandDecoration[ix].Unk_4;

                    d4_1.Value = level.Unk_Decoration[ix].Unk_1;
                    d4_2.Value = level.Unk_Decoration[ix].Unk_2;
                    d4_3.Value = level.Unk_Decoration[ix].Unk_3;
                    d4_4.Value = level.Unk_Decoration[ix].Unk_4;
                }
            }
        }

        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (level != null)
            {
                Vector2 p = ConvertMouseCoords(new Vector2(e.X, e.Y));
                if (p.X > level.Width - 1)
                {
                    tileX = level.Width - 1;
                }
                else if (p.X > 0)
                {
                    tileX = (uint)p.X;
                }
                else { tileX = 0; }
                if (p.Y < -(level.Height - 1))
                {
                    tileY = level.Height - 1;
                }
                else if (p.Y < 0)
                {
                    tileY = (uint)-p.Y + 1;
                }
                else { tileY = 0; }
            }
            if (e.Button == MouseButtons.Right)
            {
                float moveSpeed = 1.0f/(float)camera.zoom;
                camera.pos.X += (mouseX - e.X) * moveSpeed;
                camera.pos.Y += (mouseY - e.Y) * moveSpeed;
                mouseX = e.X;
                mouseY = e.Y;
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (tool == 0)
                {
                    selTileX2 = tileX;
                    selTileY2 = tileY;
                }
                else if (tool == 2)
                {
                    int ix = (int)((tileY * level.Width) + tileX);

                    if (editCol.Checked)
                    {
                        Collision c = level.TileCollision[ix];
                        c.Shape = (byte)vshape.Value;
                        c.Modifier = 0;
                        if (ladder.Checked) c.Modifier += 2;
                        if (water.Checked) c.Modifier += 8;
                        if (spike.Checked) c.Modifier += 16;
                        if (lava.Checked) c.Modifier += 64;
                        c.Material = (byte)vmat.Value;
                        c.Unk = (byte)vunk.Value;
                        level.TileCollision[ix] = c;
                    }
                    if (editBlock.Checked)
                    {
                        Block b = level.TileBlock[ix];
                        b.ID = (short)vblock.Value;
                        level.TileBlock[ix] = b;
                    }
                    if (editDeco.Checked)
                    {
                        Decoration ml = level.MLandDecoration[ix];
                        Decoration bl = level.BLandDecoration[ix];
                        Decoration fl = level.FLandDecoration[ix];
                        Decoration ul = level.Unk_Decoration[ix];

                        bl.Unk_1 = (byte)d1_1.Value;
                        bl.Unk_2 = (byte)d1_2.Value;
                        bl.Unk_3 = (byte)d1_3.Value;
                        bl.Unk_4 = (byte)d1_4.Value;

                        ml.Unk_1 = (byte)d2_1.Value;
                        ml.Unk_2 = (byte)d2_2.Value;
                        ml.Unk_3 = (byte)d2_3.Value;
                        ml.Unk_4 = (byte)d2_4.Value;

                        fl.Unk_1 = (byte)d3_1.Value;
                        fl.Unk_2 = (byte)d3_2.Value;
                        fl.Unk_3 = (byte)d3_3.Value;
                        fl.Unk_4 = (byte)d3_4.Value;

                        ul.Unk_1 = (byte)d4_1.Value;
                        ul.Unk_2 = (byte)d4_2.Value;
                        ul.Unk_3 = (byte)d4_3.Value;
                        ul.Unk_4 = (byte)d4_4.Value;

                        level.MLandDecoration[ix] = bl;
                        level.BLandDecoration[ix] = ml;
                        level.FLandDecoration[ix] = fl;
                        level.Unk_Decoration[ix] = ul;
                    }
                }
            }
        }

        private void glControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                moveCam = false;
                mouseX = 0;
                mouseY = 0;
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (tool == 0)
                {
                    
                }
            }
        }

        private void glControl_MouseLeave(object sender, EventArgs e)
        {
            moveCam = false;
            mouseX = 0;
            mouseY = 0;
        }

        private void glControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                camera.zoom += 0.1 * camera.zoom;
                if (camera.zoom > 4)
                {
                    camera.zoom = 4;
                }
            }
            else if (e.Delta < 0)
            {
                camera.zoom -= 0.1 * camera.zoom;
                if (camera.zoom < 0.25)
                {
                    camera.zoom = 0.25;
                }
            }
        }

        private void resetCamera_Click(object sender, EventArgs e)
        {
            camera.zoom = 1.1;
            //Move Camera into Level Bounds
            camera.pos.X = Math.Max(0, Math.Min(level.Width*16 , camera.pos.X));
            camera.pos.Y = Math.Max(-level.Height*16, Math.Min(0, camera.pos.Y));
        }

        private void UpdateLevelSize(object sender, EventArgs e)
        {
            if (!a)
            {
                Collision c = new Collision();
                Block b = new Block();
                Decoration d = new Decoration();
                b.ID = -1;
                d.Unk_1 = 255;
                d.Unk_2 = 255;
                d.Unk_3 = 0;
                d.Unk_4 = 255;

                if (sizeW.Value > level.Width)
                {
                    for (int h = 0; h < sizeH.Value; h++)
                    {
                        level.TileCollision.Insert(((h * (int)level.Width) + (int)level.Width) + h, c);
                        level.TileBlock.Insert(((h * (int)level.Width) + (int)level.Width) + h, b);
                        level.BLandDecoration.Insert(((h * (int)level.Width) + (int)level.Width) + h, d);
                        level.MLandDecoration.Insert(((h * (int)level.Width) + (int)level.Width) + h, d);
                        level.FLandDecoration.Insert(((h * (int)level.Width) + (int)level.Width) + h, d);
                        level.Unk_Decoration.Insert(((h * (int)level.Width) + (int)level.Width) + h, d);
                    }
                    level.Width = (uint)sizeW.Value;
                }
                else if (sizeW.Value < level.Width)
                {
                    for (int h = 0; h < sizeH.Value - 1; h++)
                    {
                        level.TileCollision.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                        level.TileBlock.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                        level.BLandDecoration.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                        level.MLandDecoration.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                        level.FLandDecoration.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                        level.Unk_Decoration.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                    }
                    level.Width = (uint)sizeW.Value;
                }
                else if (sizeH.Value > level.Height)
                {
                    for (int w = 0; w < level.Width; w++)
                    {
                        level.TileCollision.Add(c);
                        level.TileBlock.Add(b);
                        level.BLandDecoration.Add(d);
                        level.MLandDecoration.Add(d);
                        level.FLandDecoration.Add(d);
                        level.Unk_Decoration.Add(d);
                    }
                    level.Height = (uint)sizeH.Value;
                }
                else if (sizeH.Value < level.Height)
                {
                    level.TileCollision.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.TileBlock.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.BLandDecoration.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.MLandDecoration.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.FLandDecoration.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.Unk_Decoration.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.Height = (uint)sizeH.Value;
                }
            }
        }

        private Vector2 ConvertMouseCoords(Vector2 i)
        {
            i -= new Vector2(glControl.Width, glControl.Height) / 2f;
            i /= (float)camera.zoom;
            return (camera.pos + i) / 16f;
        }

        bool a;

        private void objList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!a)
            {
                a = true;
                try
                {
                    moveObj = 0;
                    int oX = int.Parse(level.Objects[objList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[0]);
                    int oY = int.Parse(level.Objects[objList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[0]);
                    int offX = int.Parse(level.Objects[objList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[1]);
                    int offY = int.Parse(level.Objects[objList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[1]);
                    xCoord.Value = oX;
                    xOffset.Value = offX;
                    yCoord.Value = oY;
                    yOffset.Value = offY;
                } catch { }
                guestItemList.ClearSelected();
                itemList.ClearSelected();
                bossList.ClearSelected();
                enemyList.ClearSelected();
                a = false;
            }
        }

        private void guestItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!a)
            {
                a = true;
                try
                {
                    moveObj = 1;
                    int oX = int.Parse(level.GuestStarItems[guestItemList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[0]);
                    int oY = int.Parse(level.GuestStarItems[guestItemList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[0]);
                    int offX = int.Parse(level.GuestStarItems[guestItemList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[1]);
                    int offY = int.Parse(level.GuestStarItems[guestItemList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[1]);
                    xCoord.Value = oX;
                    xOffset.Value = offX;
                    yCoord.Value = oY;
                    yOffset.Value = offY;
                } catch { }
                objList.ClearSelected();
                itemList.ClearSelected();
                bossList.ClearSelected();
                enemyList.ClearSelected();
                a = false;
            }
        }

        private void itemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!a)
            {
                a = true;
                try
                {
                    moveObj = 2;
                    int oX = int.Parse(level.Items[itemList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[0]);
                    int oY = int.Parse(level.Items[itemList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[0]);
                    int offX = int.Parse(level.Items[itemList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[1]);
                    int offY = int.Parse(level.Items[itemList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[1]);
                    xCoord.Value = oX;
                    xOffset.Value = offX;
                    yCoord.Value = oY;
                    yOffset.Value = offY;
                } catch { }
                objList.ClearSelected();
                guestItemList.ClearSelected();
                bossList.ClearSelected();
                enemyList.ClearSelected();
                a = false;
            }
            
        }

        private void bossList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!a)
            {
                a = true;
                try
                {
                    moveObj = 3;
                    int oX = int.Parse(level.Bosses[bossList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[0]);
                    int oY = int.Parse(level.Bosses[bossList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[0]);
                    int offX = int.Parse(level.Bosses[bossList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[1]);
                    int offY = int.Parse(level.Bosses[bossList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[1]);
                    xCoord.Value = oX;
                    xOffset.Value = offX;
                    yCoord.Value = oY;
                    yOffset.Value = offY;
                } catch { }
                objList.ClearSelected();
                guestItemList.ClearSelected();
                itemList.ClearSelected();
                enemyList.ClearSelected();
                a = false;
            }
        }

        private void enemyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!a)
            {
                a = true;
                try
                {
                    moveObj = 4;
                    int oX = int.Parse(level.Enemies[enemyList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[0]);
                    int oY = int.Parse(level.Enemies[enemyList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[0]);
                    int offX = int.Parse(level.Enemies[enemyList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[1]);
                    int offY = int.Parse(level.Enemies[enemyList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[1]);
                    xCoord.Value = oX;
                    xOffset.Value = offX;
                    yCoord.Value = oY;
                    yOffset.Value = offY;
                } catch { }
                objList.ClearSelected();
                guestItemList.ClearSelected();
                itemList.ClearSelected();
                bossList.ClearSelected();
                a = false;
            }
        }

        void UpdateCoords()
        {
            switch (moveObj)
            {
                case 0:
                    {
                        level.Objects[objList.SelectedIndex]["int x"] = $"{xCoord.Value} | {xOffset.Value}";
                        level.Objects[objList.SelectedIndex]["int y"] = $"{yCoord.Value} | {yOffset.Value}";
                        break;
                    }
                case 1:
                    {
                        level.GuestStarItems[guestItemList.SelectedIndex]["int x"] = $"{xCoord.Value} | {xOffset.Value}";
                        level.GuestStarItems[guestItemList.SelectedIndex]["int y"] = $"{yCoord.Value} | {yOffset.Value}";
                        break;
                    }
                case 2:
                    {
                        level.Items[itemList.SelectedIndex]["int x"] = $"{xCoord.Value} | {xOffset.Value}";
                        level.Items[itemList.SelectedIndex]["int y"] = $"{yCoord.Value} | {yOffset.Value}";
                        break;
                    }
                case 3:
                    {
                        level.Bosses[bossList.SelectedIndex]["int x"] = $"{xCoord.Value} | {xOffset.Value}";
                        level.Bosses[bossList.SelectedIndex]["int y"] = $"{yCoord.Value} | {yOffset.Value}";
                        break;
                    }
                case 4:
                    {
                        level.Enemies[enemyList.SelectedIndex]["int x"] = $"{xCoord.Value} | {xOffset.Value}";
                        level.Enemies[enemyList.SelectedIndex]["int y"] = $"{yCoord.Value} | {yOffset.Value}";
                        break;
                    }
            }
        }

        private void xCoord_ValueChanged(object sender, EventArgs e)
        {
            if (level != null && moveObj != null)
            {
                UpdateCoords();
            }
        }

        private void xOffset_ValueChanged(object sender, EventArgs e)
        {
            if (level != null && moveObj != null)
            {
                UpdateCoords();
            }
        }

        private void yCoord_ValueChanged(object sender, EventArgs e)
        {
            if (level != null && moveObj != null)
            {
                UpdateCoords();
            }
        }

        private void yOffset_ValueChanged(object sender, EventArgs e)
        {
            if (level != null && moveObj != null)
            {
                UpdateCoords();
            }
        }

        private void select_Click(object sender, EventArgs e)
        {
            if (tool != 0 && tool != 3)
            {
                tool = 0;
                move.Enabled = true;
                draw.Enabled = true;
                pick.Enabled = true;
                select.BackgroundImage = null;
                select.Text = "FILL";
            }
            else
            {
                uint x1 = selTileX1;
                uint x2 = selTileX2;
                uint y1 = selTileY1;
                uint y2 = selTileY2;
                if (x2 < x1)
                {
                    x1 = selTileX2;
                    x2 = selTileX1;
                }
                if (y2 < y1)
                {
                    y2 = selTileY1;
                    y1 = selTileY2;
                }
                for (int y = 0; y < level.Height; y++)
                {
                    for (int x = 0; x < level.Width; x++)
                    {
                        if (x >= x1 && x <= x2 && y >= y1 && y <= y2)
                        {
                            int ix = (int)((y * level.Width) + x);

                            if (editCol.Checked)
                            {
                                Collision c = level.TileCollision[ix];
                                c.Shape = (byte)vshape.Value;
                                c.Modifier = 0;
                                if (ladder.Checked) c.Modifier += 2;
                                if (water.Checked) c.Modifier += 8;
                                if (spike.Checked) c.Modifier += 16;
                                if (lava.Checked) c.Modifier += 64;
                                c.Material = (byte)vmat.Value;
                                c.Unk = (byte)vunk.Value;
                                level.TileCollision[ix] = c;
                            }
                            if (editBlock.Checked)
                            {
                                Block b = level.TileBlock[ix];
                                b.ID = (short)vblock.Value;
                                level.TileBlock[ix] = b;
                            }
                            if (editDeco.Checked)
                            {
                                Decoration ml = level.MLandDecoration[ix];
                                Decoration bl = level.BLandDecoration[ix];
                                Decoration fl = level.FLandDecoration[ix];
                                Decoration ul = level.Unk_Decoration[ix];

                                bl.Unk_1 = (byte)d1_1.Value;
                                bl.Unk_2 = (byte)d1_2.Value;
                                bl.Unk_3 = (byte)d1_3.Value;
                                bl.Unk_4 = (byte)d1_4.Value;

                                ml.Unk_1 = (byte)d2_1.Value;
                                ml.Unk_2 = (byte)d2_2.Value;
                                ml.Unk_3 = (byte)d2_3.Value;
                                ml.Unk_4 = (byte)d2_4.Value;

                                fl.Unk_1 = (byte)d3_1.Value;
                                fl.Unk_2 = (byte)d3_2.Value;
                                fl.Unk_3 = (byte)d3_3.Value;
                                fl.Unk_4 = (byte)d3_4.Value;

                                ul.Unk_1 = (byte)d4_1.Value;
                                ul.Unk_2 = (byte)d4_2.Value;
                                ul.Unk_3 = (byte)d4_3.Value;
                                ul.Unk_4 = (byte)d4_4.Value;

                                level.MLandDecoration[ix] = bl;
                                level.BLandDecoration[ix] = ml;
                                level.FLandDecoration[ix] = fl;
                                level.Unk_Decoration[ix] = ul;
                            }
                        }
                    }
                }
                selTileX1 = 0;
                selTileY1 = 0;
                selTileX2 = 0;
                selTileY2 = 0;
                move.Enabled = true;
                draw.Enabled = true;
                pick.Enabled = true;
                select.BackgroundImage = global::JamBuilder.Properties.Resources.select;
                select.Text = "";
                tool = -1;
            }
        }

        private void move_Click(object sender, EventArgs e)
        {
            tool = 1;
            select.Enabled = true;
            move.Enabled = false;
            draw.Enabled = true;
            pick.Enabled = true;
            selTileX1 = 0;
            selTileY1 = 0;
            selTileX2 = 0;
            selTileY2 = 0;
            select.BackgroundImage = global::JamBuilder.Properties.Resources.select;
            select.Text = "";
        }

        private void draw_Click(object sender, EventArgs e)
        {
            tool = 2;
            select.Enabled = true;
            move.Enabled = true;
            draw.Enabled = false;
            pick.Enabled = true;
            selTileX1 = 0;
            selTileY1 = 0;
            selTileX2 = 0;
            selTileY2 = 0;
            select.BackgroundImage = global::JamBuilder.Properties.Resources.select;
            select.Text = "";
        }

        private void pick_Click(object sender, EventArgs e)
        {
            tool = 3;
            select.Enabled = true;
            move.Enabled = true;
            draw.Enabled = true;
            pick.Enabled = false;
        }

        private void cloneObj_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                if (objList.SelectedItem != null)
                {
                    level.Objects.Add(level.Objects[objList.SelectedIndex]);
                }
            }
        }

        private void cloneGuestItem_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                if (guestItemList.SelectedItem != null)
                {
                    level.GuestStarItems.Add(level.GuestStarItems[guestItemList.SelectedIndex]);
                    RefreshObjectLists();
                }
            }
        }

        private void cloneItem_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                if (itemList.SelectedItem != null)
                {
                    level.Items.Add(level.Items[itemList.SelectedIndex]);
                    RefreshObjectLists();
                }
            }
        }

        private void cloneBoss_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                if (bossList.SelectedItem != null)
                {
                    level.Bosses.Add(level.Bosses[bossList.SelectedIndex]);
                    RefreshObjectLists();
                }
            }
        }

        private void cloneEnemy_Click(object sender, EventArgs e)
        {
            if (level != null)
            {
                if (enemyList.SelectedItem != null)
                {
                    level.Enemies.Add(level.Enemies[enemyList.SelectedIndex]);
                    RefreshObjectLists();
                }
            }
        }
    }
}
