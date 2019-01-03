using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using KSALVL;

namespace JamBuilder
{
    public partial class Form1 : Form
    {
        public Level level;
        public string filePath;

        public Form1()
        {
            InitializeComponent();
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

        private void editItem_Click(object sender, EventArgs e)
        {
            if (guestItemList.SelectedItem != null)
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

        private void editSpecItem_Click(object sender, EventArgs e)
        {
            if (itemList.SelectedItem != null)
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
            GL.ClearColor(Color.FromArgb(200, 200, 200));
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            

            glControl.SwapBuffers();
        }

        private void addObj_Click(object sender, EventArgs e)
        {
            AddObj addObj = new AddObj();
            addObj.editorType = 0;
            if (addObj.ShowDialog() == DialogResult.OK)
            {
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
    }
}
