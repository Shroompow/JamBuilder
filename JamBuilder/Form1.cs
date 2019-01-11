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

        Renderer renderer;
        Texturing texturing;
        Camera camera;

        private System.Timers.Timer t;

        bool moveCam = false;
        int mouseX = 0;
        int mouseY = 0;

        int moveObj;

        int tool;

        int tile;

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

            if (tabControl1.SelectedTab == objTab) objList.SelectedIndex = selIndex;
            if (tabControl1.SelectedTab == guestStarItemTab) guestItemList.SelectedIndex = selIndex;
            if (tabControl1.SelectedTab == itemTab) itemList.SelectedIndex = selIndex;
            if (tabControl1.SelectedTab == bossTab) bossList.SelectedIndex = selIndex;
            if (tabControl1.SelectedTab == enemyTab) enemyList.SelectedIndex = selIndex;

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

                camera.pos = Vector2.Zero;
                camera.zoom = 1.1;
                RefreshObjectLists();

                this.Text = $"JamBuilder - {filePath}";
                this.Cursor = Cursors.Arrow;
                this.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
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
            glControl.MakeCurrent();
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.ClearColor(Color.FromArgb(200, 200, 200));

            renderer = new Renderer();
            texturing = new Texturing();
            camera = new Camera(new Vector2(0, 0), 1.1);

            for (int i = 0; i < 52; i++)
            {
                texIds.Add(texturing.LoadTexture("Resources/tiles/" + i + ".png"));
            }

            modTexIds.Add(texturing.LoadTexture("Resources/modifiers/ladder.png"));
            modTexIds.Add(texturing.LoadTexture("Resources/modifiers/water.png"));
            modTexIds.Add(texturing.LoadTexture("Resources/modifiers/damage.png"));
            objTexIds.Add(texturing.LoadTexture("Resources/obj/object.png"));
            objTexIds.Add(texturing.LoadTexture("Resources/obj/guestItem.png"));

            objTexIds.Add(texturing.LoadTexture("Resources/obj/item.png"));
            objTexIds.Add(texturing.LoadTexture("Resources/obj/boss.png"));
            objTexIds.Add(texturing.LoadTexture("Resources/obj/enemy.png"));
            objTexIds.Add(texturing.LoadTexture("Resources/obj/select.png"));

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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.FromArgb(200, 200, 200));

            renderer.Begin(glControl.Width, glControl.Height);
            camera.Transform();

            if (level != null)
            {
                int y = 0;
                int x = 0;
                for (int i = 0; i < level.TileCollision.Count; i++)
                {
                    if (x >= level.Width)
                    {
                        y++;
                        x = 0;
                    }
                    renderer.Draw(texIds[level.TileCollision[i].Shape], new Vector2(x*15f, -y*15f), new Vector2(1f, 1f), 17, 17);
                    if (level.TileCollision[i].Modifier != 0)
                    {
                        if ((level.TileCollision[i].Modifier & (1 << 1)) != 0)
                        {
                            renderer.Draw(modTexIds[0], new Vector2(x * 15f, -y * 15f), new Vector2(1f, 1f), 17, 17);
                        }
                        if ((level.TileCollision[i].Modifier & (1 << 3)) != 0)
                        {
                            renderer.Draw(modTexIds[1], new Vector2(x * 15f, -y * 15f), new Vector2(1f, 1f), 17, 17);
                        }
                        if ((level.TileCollision[i].Modifier & (1 << 6)) != 0)
                        {
                            renderer.Draw(modTexIds[2], new Vector2(x * 15f, -y * 15f), new Vector2(1f, 1f), 17, 17);
                        }
                    }
                    x++;
                }

                for (int i = 0; i < level.Objects.Count; i++)
                {
                    try
                    {
                        int oX = int.Parse(level.Objects[i]["int x"].Replace(" ", "").Split('|')[0]);
                        int oY = int.Parse(level.Objects[i]["int y"].Replace(" ", "").Split('|')[0]);
                        int offX = int.Parse(level.Objects[i]["int x"].Replace(" ", "").Split('|')[1]);
                        int offY = int.Parse(level.Objects[i]["int y"].Replace(" ", "").Split('|')[1]);
                        renderer.Draw(objTexIds[0], new Vector2(((oX * 15f) - 3f) + offX, ((-oY * 15f) + 13f) - offY), new Vector2(1f, 1f), 7, 7);
                        if (i == objList.SelectedIndex)
                        {
                            renderer.Draw(objTexIds[5], new Vector2(((oX * 15f) - 3f) + offX, ((-oY * 15f) + 13f) - offY), new Vector2(1f, 1f), 7, 7);
                        }
                    } catch { }
                }

                for (int i = 0; i < level.GuestStarItems.Count; i++)
                {
                    try
                    {
                        int oX = int.Parse(level.GuestStarItems[i]["int x"].Replace(" ", "").Split('|')[0]);
                        int oY = int.Parse(level.GuestStarItems[i]["int y"].Replace(" ", "").Split('|')[0]);
                        int offX = int.Parse(level.GuestStarItems[i]["int x"].Replace(" ", "").Split('|')[1]);
                        int offY = int.Parse(level.GuestStarItems[i]["int y"].Replace(" ", "").Split('|')[1]);
                        renderer.Draw(objTexIds[1], new Vector2(((oX * 15f) - 3f) + offX, ((-oY * 15f) + 13f) - offY), new Vector2(1f, 1f), 7, 7);
                        if (i == guestItemList.SelectedIndex)
                        {
                            renderer.Draw(objTexIds[5], new Vector2(((oX * 15f) - 3f) + offX, ((-oY * 15f) + 13f) - offY), new Vector2(1f, 1f), 7, 7);
                        }
                    }
                    catch { }
                }

                for (int i = 0; i < level.Items.Count; i++)
                {
                    try
                    {
                        int oX = int.Parse(level.Items[i]["int x"].Replace(" ", "").Split('|')[0]);
                        int oY = int.Parse(level.Items[i]["int y"].Replace(" ", "").Split('|')[0]);
                        int offX = int.Parse(level.Items[i]["int x"].Replace(" ", "").Split('|')[1]);
                        int offY = int.Parse(level.Items[i]["int y"].Replace(" ", "").Split('|')[1]);
                        renderer.Draw(objTexIds[2], new Vector2(((oX * 15f) - 3f) + offX, ((-oY * 15f) + 13f) - offY), new Vector2(1f, 1f), 7, 7);
                        if (i == itemList.SelectedIndex)
                        {
                            renderer.Draw(objTexIds[5], new Vector2(((oX * 15f) - 3f) + offX, ((-oY * 15f) + 13f) - offY), new Vector2(1f, 1f), 7, 7);
                        }
                    }
                    catch { }
                }

                for (int i = 0; i < level.Bosses.Count; i++)
                {
                    try
                    {
                        int oX = int.Parse(level.Bosses[i]["int x"].Replace(" ", "").Split('|')[0]);
                        int oY = int.Parse(level.Bosses[i]["int y"].Replace(" ", "").Split('|')[0]);
                        int offX = int.Parse(level.Bosses[i]["int x"].Replace(" ", "").Split('|')[1]);
                        int offY = int.Parse(level.Bosses[i]["int y"].Replace(" ", "").Split('|')[1]);
                        renderer.Draw(objTexIds[3], new Vector2(((oX * 15f) - 3f) + offX, ((-oY * 15f) + 13f) - offY), new Vector2(1f, 1f), 7, 7);
                        if (i == bossList.SelectedIndex)
                        {
                            renderer.Draw(objTexIds[5], new Vector2(((oX * 15f) - 3f) + offX, ((-oY * 15f) + 13f) - offY), new Vector2(1f, 1f), 7, 7);
                        }
                    }
                    catch { }
                }

                for (int i = 0; i < level.Enemies.Count; i++)
                {
                    try
                    {
                        int oX = int.Parse(level.Enemies[i]["int x"].Replace(" ", "").Split('|')[0]);
                        int oY = int.Parse(level.Enemies[i]["int y"].Replace(" ", "").Split('|')[0]);
                        int offX = int.Parse(level.Enemies[i]["int x"].Replace(" ", "").Split('|')[1]);
                        int offY = int.Parse(level.Enemies[i]["int y"].Replace(" ", "").Split('|')[1]);
                        renderer.Draw(objTexIds[4], new Vector2(((oX * 15f) - 3f) + offX, ((-oY * 15f) + 13f) - offY), new Vector2(1f, 1f), 7, 7);
                        if (i == enemyList.SelectedIndex)
                        {
                            renderer.Draw(objTexIds[5], new Vector2(((oX * 15f) - 3f) + offX, ((-oY * 15f) + 13f) - offY), new Vector2(1f, 1f), 7, 7);
                        }
                    }
                    catch { }
                }
            }

            glControl.SwapBuffers();
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
                if (tool == 2)
                {
                    
                }
            }
        }

        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveCam)
            {
                camera.pos.X += mouseX - e.X;
                camera.pos.Y += mouseY - e.Y;
                mouseX = e.X;
                mouseY = e.Y;
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
                camera.zoom += 0.2;
                if (camera.zoom > 2.9)
                {
                    camera.zoom = 2.9;
                }
            }
            else if (e.Delta < 0)
            {
                camera.zoom -= 0.2;
                if (camera.zoom < 0.5)
                {
                    camera.zoom = 0.5;
                }
            }
        }

        private void resetCamera_Click(object sender, EventArgs e)
        {
            camera.zoom = 1.1;
        }

        bool a;

        private void objList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!a)
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
                a = true;
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
                moveObj = 1;
                int oX = int.Parse(level.GuestStarItems[guestItemList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[0]);
                int oY = int.Parse(level.GuestStarItems[guestItemList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[0]);
                int offX = int.Parse(level.GuestStarItems[guestItemList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[1]);
                int offY = int.Parse(level.GuestStarItems[guestItemList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[1]);
                xCoord.Value = oX;
                xOffset.Value = offX;
                yCoord.Value = oY;
                yOffset.Value = offY;
                a = true;
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
                moveObj = 2;
                int oX = int.Parse(level.Items[itemList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[0]);
                int oY = int.Parse(level.Items[itemList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[0]);
                int offX = int.Parse(level.Items[itemList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[1]);
                int offY = int.Parse(level.Items[itemList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[1]);
                xCoord.Value = oX;
                xOffset.Value = offX;
                yCoord.Value = oY;
                yOffset.Value = offY;
                a = true;
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
                moveObj = 3;
                int oX = int.Parse(level.Bosses[bossList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[0]);
                int oY = int.Parse(level.Bosses[bossList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[0]);
                int offX = int.Parse(level.Bosses[bossList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[1]);
                int offY = int.Parse(level.Bosses[bossList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[1]);
                xCoord.Value = oX;
                xOffset.Value = offX;
                yCoord.Value = oY;
                yOffset.Value = offY;
                a = true;
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
                moveObj = 4;
                int oX = int.Parse(level.Enemies[enemyList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[0]);
                int oY = int.Parse(level.Enemies[enemyList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[0]);
                int offX = int.Parse(level.Enemies[enemyList.SelectedIndex]["int x"].Replace(" ", "").Split('|')[1]);
                int offY = int.Parse(level.Enemies[enemyList.SelectedIndex]["int y"].Replace(" ", "").Split('|')[1]);
                xCoord.Value = oX;
                xOffset.Value = offX;
                yCoord.Value = oY;
                yOffset.Value = offY;
                a = true;
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
            tool = 0;
            select.Enabled = false;
            move.Enabled = true;
            draw.Enabled = true;
        }

        private void move_Click(object sender, EventArgs e)
        {
            tool = 1;
            select.Enabled = true;
            move.Enabled = false;
            draw.Enabled = true;
        }

        private void draw_Click(object sender, EventArgs e)
        {
            tool = 2;
            select.Enabled = true;
            move.Enabled = true;
            draw.Enabled = false;
        }

        private void t0_Click(object sender, EventArgs e)
        {
            tile = 0;
        }

        private void t1_Click(object sender, EventArgs e)
        {
            tile = 1;
        }

        private void t2_Click(object sender, EventArgs e)
        {
            tile = 2;
        }

        private void t3_Click(object sender, EventArgs e)
        {
            tile = 3;
        }

        private void t4_Click(object sender, EventArgs e)
        {
            tile = 4;
        }

        private void t5_Click(object sender, EventArgs e)
        {
            tile = 5;
        }

        private void t6_Click(object sender, EventArgs e)
        {
            tile = 6;
        }

        private void t7_Click(object sender, EventArgs e)
        {
            tile = 7;
        }

        private void t8_Click(object sender, EventArgs e)
        {
            tile = 8;
        }

        private void t9_Click(object sender, EventArgs e)
        {
            tile = 9;
        }

        private void t10_Click(object sender, EventArgs e)
        {
            tile = 10;
        }

        private void t11_Click(object sender, EventArgs e)
        {
            tile = 11;
        }

        private void t12_Click(object sender, EventArgs e)
        {
            tile = 12;
        }

        private void t13_Click(object sender, EventArgs e)
        {
            tile = 13;
        }

        private void t14_Click(object sender, EventArgs e)
        {
            tile = 14;
        }

        private void t15_Click(object sender, EventArgs e)
        {
            tile = 15;
        }

        private void t16_Click(object sender, EventArgs e)
        {
            tile = 16;
        }

        private void t17_Click(object sender, EventArgs e)
        {
            tile = 17;
        }

        private void t18_Click(object sender, EventArgs e)
        {
            tile = 18;
        }

        private void t19_Click(object sender, EventArgs e)
        {
            tile = 19;
        }

        private void t20_Click(object sender, EventArgs e)
        {
            tile = 20;
        }

        private void t21_Click(object sender, EventArgs e)
        {
            tile = 21;
        }

        private void t22_Click(object sender, EventArgs e)
        {
            tile = 22;
        }

        private void t23_Click(object sender, EventArgs e)
        {
            tile = 23;
        }

        private void t24_Click(object sender, EventArgs e)
        {
            tile = 24;
        }

        private void t25_Click(object sender, EventArgs e)
        {
            tile = 25;
        }

        private void t26_Click(object sender, EventArgs e)
        {
            tile = 26;
        }

        private void t27_Click(object sender, EventArgs e)
        {
            tile = 27;
        }

        private void t28_Click(object sender, EventArgs e)
        {
            tile = 28;
        }

        private void t29_Click(object sender, EventArgs e)
        {
            tile = 29;
        }

        private void t30_Click(object sender, EventArgs e)
        {
            tile = 30;
        }

        private void t31_Click(object sender, EventArgs e)
        {
            tile = 31;
        }

        private void t32_Click(object sender, EventArgs e)
        {
            tile = 32;
        }

        private void t33_Click(object sender, EventArgs e)
        {
            tile = 33;
        }

        private void t34_Click(object sender, EventArgs e)
        {
            tile = 34;
        }

        private void t35_Click(object sender, EventArgs e)
        {
            tile = 35;
        }

        private void t36_Click(object sender, EventArgs e)
        {
            tile = 36;
        }

        private void t37_Click(object sender, EventArgs e)
        {
            tile = 37;
        }

        private void t38_Click(object sender, EventArgs e)
        {
            tile = 38;
        }

        private void t39_Click(object sender, EventArgs e)
        {
            tile = 39;
        }

        private void t40_Click(object sender, EventArgs e)
        {
            tile = 40;
        }

        private void t41_Click(object sender, EventArgs e)
        {
            tile = 41;
        }

        private void t42_Click(object sender, EventArgs e)
        {
            tile = 42;
        }

        private void t43_Click(object sender, EventArgs e)
        {
            tile = 43;
        }

        private void t44_Click(object sender, EventArgs e)
        {
            tile = 44;
        }

        private void t45_Click(object sender, EventArgs e)
        {
            tile = 45;
        }

        private void t46_Click(object sender, EventArgs e)
        {
            tile = 46;
        }

        private void t47_Click(object sender, EventArgs e)
        {
            tile = 47;
        }

        private void t48_Click(object sender, EventArgs e)
        {
            tile = 48;
        }

        private void t49_Click(object sender, EventArgs e)
        {
            tile = 49;
        }

        private void t50_Click(object sender, EventArgs e)
        {
            tile = 50;
        }

        private void t51_Click(object sender, EventArgs e)
        {
            tile = 51;
        }

        private void m2_Click(object sender, EventArgs e)
        {
            tile = 52;
        }

        private void m8_Click(object sender, EventArgs e)
        {
            tile = 53;
        }

        private void m64_Click(object sender, EventArgs e)
        {
            tile = 54;
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
