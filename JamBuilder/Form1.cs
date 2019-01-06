using System;
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

        Renderer renderer;
        Texturing texturing;
        Camera camera;

        private System.Timers.Timer t;

        bool moveCam = false;
        int mouseX = 0;
        int mouseY = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void RefreshObjectLists()
        {
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
            if (objList.SelectedItem != null)
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
            if (guestItemList.SelectedItem != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.obj = level.Items[guestItemList.SelectedIndex];
                editor.editorType = 1;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.Items[guestItemList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void editItem_Click(object sender, EventArgs e)
        {
            if (guestItemList.SelectedItem != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.obj = level.GuestStarItems[guestItemList.SelectedIndex];
                editor.editorType = 2;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.GuestStarItems[itemList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void editBoss_Click(object sender, EventArgs e)
        {
            if (bossList.SelectedItem != null)
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
            if (enemyList.SelectedItem != null)
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
            GL.ClearColor(Color.FromArgb(200, 200, 200));
            renderer = new Renderer();
            texturing = new Texturing();
            camera = new Camera(new Vector2(0, 0), 1.0);
            for (int i = 0; i < 52; i++)
            {
                texIds.Add(texturing.LoadTexture("Resources/tiles/" + i + ".png"));
            }
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
                    renderer.Draw(texIds[level.TileCollision[i].Shape], new Vector2(x*15f, -y*15f), new Vector2(1f, 1f));
                    x++;
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
            AddObj addObj = new AddObj();
            addObj.editorType = 0;
            if (addObj.ShowDialog() == DialogResult.OK)
            {
                addObj.obj["int wuid"] = GetUniqueWUID().ToString();
                level.Objects.Add(addObj.obj);
                RefreshObjectLists();
            }
        }

        private void addGuestItem_Click(object sender, EventArgs e)
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

        private void addItem_Click(object sender, EventArgs e)
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

        private void addBoss_Click(object sender, EventArgs e)
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

        private void addEnemy_Click(object sender, EventArgs e)
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
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
            if (objList.SelectedItem != null)
            {
                level.Objects.RemoveAt(objList.SelectedIndex);
                RefreshObjectLists();
            }
        }

        private void delGuestItem_Click(object sender, EventArgs e)
        {
            if (guestItemList.SelectedItem != null)
            {
                level.GuestStarItems.RemoveAt(guestItemList.SelectedIndex);
                RefreshObjectLists();
            }
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            if (itemList.SelectedItem != null)
            {
                level.Items.RemoveAt(itemList.SelectedIndex);
                RefreshObjectLists();
            }
        }

        private void delBoss_Click(object sender, EventArgs e)
        {
            if (bossList.SelectedItem != null)
            {
                level.Bosses.RemoveAt(bossList.SelectedIndex);
                RefreshObjectLists();
            }
        }

        private void delEnemy_Click(object sender, EventArgs e)
        {
            if (enemyList.SelectedItem != null)
            {
                level.Enemies.RemoveAt(enemyList.SelectedIndex);
                RefreshObjectLists();
            }
        }

        private void stageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void objList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (objList.SelectedItem != null)
            {
                editObj_Click(this, new EventArgs());
            }
        }

        private void guestItemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (guestItemList.SelectedItem != null)
            {
                editGuestItem_Click(this, new EventArgs());
            }
        }

        private void itemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (itemList.SelectedItem != null)
            {
                editItem_Click(this, new EventArgs());
            }
        }

        private void bossList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (bossList.SelectedItem != null)
            {
                editBoss_Click(this, new EventArgs());
            }
        }

        private void enemyList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (enemyList.SelectedItem != null)
            {
                editEnemy_Click(this, new EventArgs());
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
                camera.zoom += SystemInformation.MouseWheelScrollLines / 2;
                if (camera.zoom < 2.0)
                {
                    camera.zoom = 2.0;
                }
            }
            else if (e.Delta < 0)
            {
                camera.zoom -= SystemInformation.MouseWheelScrollLines / 2;
                if (camera.zoom < 0.5)
                {
                    camera.zoom = 0.5;
                }
            }
            Console.WriteLine(camera.zoom);
        }
    }
}
