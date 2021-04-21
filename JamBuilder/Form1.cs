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
        List<int> modTexIds = new List<int>();
        List<int> objTexIds = new List<int>();
        Dictionary<short, int> blockTexIds = new Dictionary<short, int>();
        Dictionary<byte, int> tileTexIds = new Dictionary<byte, int>();
        int unkTileTex;

        ObjectDatabase objectDB;

        Renderer renderer;
        Texturing texturing;
        Camera camera;

        BmFont font;

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
            objectDB = new ObjectDatabase(File.ReadAllLines(Directory.GetCurrentDirectory() + @"\object.json"));
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

		public void listFormatChanged(object sender, EventArgs e)
		{
			RefreshObjectLists();
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

			if (this.level == null)
			{
				return;
			}

            objList.BeginUpdate();
            guestItemList.BeginUpdate();
            itemList.BeginUpdate();
            bossList.BeginUpdate();
            enemyList.BeginUpdate();

			string formatting = "";
			string spacer = "";
			if (formatShowIndex.Checked)
			{
				formatting += spacer+"[{0}]";
				spacer = " ";
			}
			if (formatShowKind.Checked)
			{
				formatting += spacer+"{1}";
				spacer = " ";
			}
			if (formatShowWuid.Checked)
			{
				formatting += spacer+"({2})";
				spacer = " ";
			}

			if (formatting.Length == 0)
			{
				//When no formatting option is checked.
				formatting = "View > Object List Format     OwO";
				//Uuuhm. Consider it an easteregg.
			}

			for (int i = 0; i < level.Objects.Count; i++)
            {
				objList.Items.Add(String.Format(formatting, i , level.Objects[i]["string kind"], level.Objects[i]["int wuid"]));
			}
            for (int i = 0; i < level.GuestStarItems.Count; i++)
            {
                guestItemList.Items.Add(String.Format(formatting, i, level.GuestStarItems[i]["string kind"], level.GuestStarItems[i]["int wuid"]));
			}
            for (int i = 0; i < level.Items.Count; i++)
            {
				itemList.Items.Add(String.Format(formatting, i, level.Items[i]["string kind"], level.Items[i]["int wuid"]));
			}
            for (int i = 0; i < level.Bosses.Count; i++)
            {
				bossList.Items.Add(String.Format(formatting, i, level.Bosses[i]["string kind"], level.Bosses[i]["int wuid"]));
            }
            for (int i = 0; i < level.Enemies.Count; i++)
            {
				enemyList.Items.Add(String.Format(formatting, i, level.Enemies[i]["string kind"], level.Enemies[i]["int wuid"]));
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
                camera.zoom = 1.0;
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
                camera.zoom = 1.0;
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
			int index = tabControl1.SelectedIndex;

			switch (index)
			{
				default:
				case 0:
					editObject(); break;
				case 1:
					editGuestItem(); break;
				case 2:
					editItem(); break;
				case 3:
					editBoss(); break;
				case 4:
					editEnemy(); break;
			}
		}

		private void editObject()
        {
            if (objList.SelectedItem != null && level != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.database = objectDB;
                editor.obj = level.Objects[objList.SelectedIndex];
                editor.editorType = 0;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.Objects[objList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void editGuestItem()
        {
            if (guestItemList.SelectedItem != null && level != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.database = objectDB;
                editor.obj = level.GuestStarItems[guestItemList.SelectedIndex];
                editor.editorType = 1;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.GuestStarItems[guestItemList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void editItem()
        {
            if (itemList.SelectedItem != null && level != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.database = objectDB;
                editor.obj = level.Items[itemList.SelectedIndex];
                editor.editorType = 2;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.Items[itemList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void editBoss()
        {
            if (bossList.SelectedItem != null && level != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.database = objectDB;
                editor.obj = level.Bosses[bossList.SelectedIndex];
                editor.editorType = 3;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    level.Bosses[bossList.SelectedIndex] = editor.obj;
                    RefreshObjectLists();
                }
            }
        }

        private void editEnemy()
        {
            if (enemyList.SelectedItem != null && level != null)
            {
                YAMLEditor editor = new YAMLEditor();
                editor.database = objectDB;
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
            camera = new Camera(new Vector2(0, 0), 1.0);

            for (int i = 0; i < 52; i++)
            {
                texIds.Add(texturing.LoadTexture("Resources/tiles/" + i + ".png"));
            }
            texIds.Add(texturing.LoadTexture("Resources/tiles/hover.png"));

            modTexIds.Add(texturing.LoadTexture("Resources/modifiers/ladder.png"));
            modTexIds.Add(texturing.LoadTexture("Resources/modifiers/water.png"));
            modTexIds.Add(texturing.LoadTexture("Resources/modifiers/spike.png"));
            modTexIds.Add(texturing.LoadTexture("Resources/modifiers/damage.png"));

            blockTexIds.Add(0xFF, texturing.LoadTexture("Resources/blocks/unknown.png"));
            blockTexIds.Add(0, texturing.LoadTexture("Resources/blocks/star.png"));
            blockTexIds.Add(1, texturing.LoadTexture("Resources/blocks/unbreakable.png"));
            blockTexIds.Add(2, texturing.LoadTexture("Resources/blocks/unbreakable.png"));
            blockTexIds.Add(3, texturing.LoadTexture("Resources/blocks/unbreakable.png"));
            blockTexIds.Add(4, texturing.LoadTexture("Resources/blocks/bomb.png"));
            blockTexIds.Add(5, texturing.LoadTexture("Resources/blocks/bomb_chain_metal.png"));
            blockTexIds.Add(6, texturing.LoadTexture("Resources/blocks/bomb_chain_stone.png"));
            blockTexIds.Add(7, texturing.LoadTexture("Resources/blocks/bomb_chain_invisible.png"));
            blockTexIds.Add(8, texturing.LoadTexture("Resources/blocks/breakable.png"));
            blockTexIds.Add(9, texturing.LoadTexture("Resources/blocks/box.png"));
            blockTexIds.Add(10, texturing.LoadTexture("Resources/blocks/falling.png"));
            blockTexIds.Add(11, texturing.LoadTexture("Resources/blocks/ice.png"));
            blockTexIds.Add(12, texturing.LoadTexture("Resources/blocks/ice.png"));
            blockTexIds.Add(13, texturing.LoadTexture("Resources/blocks/ice.png"));
            blockTexIds.Add(14, texturing.LoadTexture("Resources/blocks/barrel.png"));
            blockTexIds.Add(18, texturing.LoadTexture("Resources/blocks/metal.png"));
            blockTexIds.Add(19, texturing.LoadTexture("Resources/blocks/metal.png"));
            blockTexIds.Add(20, texturing.LoadTexture("Resources/blocks/metal.png"));
            blockTexIds.Add(27, texturing.LoadTexture("Resources/blocks/bomb_chain_create.png"));

            objTexIds.Add(texturing.LoadTexture("Resources/obj/object.png"));
            objTexIds.Add(texturing.LoadTexture("Resources/obj/guestItem.png"));
            objTexIds.Add(texturing.LoadTexture("Resources/obj/item.png"));
            objTexIds.Add(texturing.LoadTexture("Resources/obj/boss.png"));
            objTexIds.Add(texturing.LoadTexture("Resources/obj/enemy.png"));
            objTexIds.Add(texturing.LoadTexture("Resources/obj/select.png"));

            string[] tileset = Directory.GetFiles("Resources/tileset", "*.png");
            for (int i = 0; i < tileset.Length; i++)
            {
                if (byte.TryParse(Path.GetFileNameWithoutExtension(tileset[i]), out byte b))
                {
                    tileTexIds.Add(b, texturing.LoadTexture(tileset[i]));
                }
            }
            unkTileTex = texturing.LoadTexture("Resources/tileset/unknown.png");

            font = new BmFont(texturing, "a");

            t = new System.Timers.Timer(1000.0 / 60.0);
            t.Elapsed += t_Elapsed;
            t.Start();
        }

        private void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            glControl.Invalidate();
            t.Start();
        }

		private void glControl_Resize(object sender, EventArgs e)
		{
			glControl.ClientSize = new Size(Math.Max(glControl.Width, 1), Math.Max(glControl.Height, 1));
			GL.Viewport(0, 0, Math.Max(glControl.Width, 1), Math.Max(glControl.Height, 1));
		}

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.FromArgb(200, 200, 200));

            renderer.Init(glControl.Width, glControl.Height);
            camera.Transform();

            if (level != null)
            {

                //Crop Tiles outside camera view.
                int tileStartX = (int)Math.Max(0,Math.Floor(
                        (camera.pos.X - glControl.Width/camera.zoom*0.5f)/16.0f
                    ));
                int tileEndX = (int)Math.Min(level.Width, Math.Ceiling(
                        (camera.pos.X + glControl.Width / camera.zoom*0.5f) / 16.0f
                    ));
                int tileStartY = (int)Math.Max(0, 1+Math.Floor(
                        -(camera.pos.Y + glControl.Height / camera.zoom*0.5f) / 16.0f
                    ));
                int tileEndY = (int)Math.Min(level.Height,1+ Math.Ceiling(
                        -(camera.pos.Y - glControl.Height / camera.zoom*0.5f) / 16.0f
                    ));

                Vector2 vec_scale = new Vector2(1.0f, 1.0f);

                //Collisions
                if (comboBox1.SelectedIndex == 0)
                {
                    for (int ty = tileStartY; ty < tileEndY; ty++)
                    {
                        for (int tx = tileStartX; tx < tileEndX; tx++)
                        {
                            int ix = ty * (int)level.Width + tx;
                            Collision c = level.TileCollision[ix];
                            Vector2 v = new Vector2(tx * 16f, -ty * 16f);
                            renderer.Draw(texIds[c.Shape], v, vec_scale, 17, 17);
                        }
                    }
                }
                //Deco Layers
                if (comboBox1.SelectedIndex >= 1)
                {
                    //Invisible tiles
                    for (int ty = tileStartY; ty < tileEndY; ty++)
                    {
                        for (int tx = tileStartX; tx < tileEndX; tx++)
                        {
                            Vector2 v = new Vector2(tx * 16f, -ty * 16f);
                            renderer.Draw(tileTexIds[0xFF], v, vec_scale, 16, 16);
                        }
                    }

                    //Deco Layer 1
                    if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)
                    {
                        for (int ty = tileStartY; ty < tileEndY; ty++)
                        {
                            for (int tx = tileStartX; tx < tileEndX; tx++)
                            {
                                int ix = ty * (int)level.Width + tx;
                                Decoration d = level.DecorationLayer1[ix];
                                if (d.Tile == 0xFF) continue;

                                Vector2 v = new Vector2(tx * 16f, -ty * 16f);
                                if (tileTexIds.ContainsKey(d.Tile))
                                    renderer.Draw(tileTexIds[d.Tile], v, vec_scale, 16, 16);
                                else
                                    renderer.Draw(unkTileTex, v, vec_scale, 16, 16);
                            }
                        }
                    }
                    //Deco Layer 2
                    if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 3)
                    {
                        for (int ty = tileStartY; ty < tileEndY; ty++)
                        {
                            for (int tx = tileStartX; tx < tileEndX; tx++)
                            {
                                int ix = ty * (int)level.Width + tx;
                                Decoration d = level.DecorationLayer2[ix];
                                if (d.Tile == 0xFF) continue;

                                Vector2 v = new Vector2(tx * 16f, -ty * 16f);
                                if (tileTexIds.ContainsKey(d.Tile))
                                    renderer.Draw(tileTexIds[d.Tile], v, vec_scale, 16, 16);
                                else
                                    renderer.Draw(unkTileTex, v, vec_scale, 16, 16);
                            }
                        }
                    }
                    //Deco Layer 3
                    if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 4)
                    {
                        for (int ty = tileStartY; ty < tileEndY; ty++)
                        {
                            for (int tx = tileStartX; tx < tileEndX; tx++)
                            {
                                int ix = ty * (int)level.Width + tx;
                                Decoration d = level.DecorationLayer3[ix];
                                if (d.Tile == 0xFF) continue;

                                Vector2 v = new Vector2(tx * 16f, -ty * 16f);
                                if (tileTexIds.ContainsKey(d.Tile))
                                    renderer.Draw(tileTexIds[d.Tile], v, vec_scale, 16, 16);
                                else
                                    renderer.Draw(unkTileTex, v, vec_scale, 16, 16);
                            }
                        }
                    }
                    //Deco Layer 4
                    if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 5)
                    {
                        for (int ty = tileStartY; ty < tileEndY; ty++)
                        {
                            for (int tx = tileStartX; tx < tileEndX; tx++)
                            {
                                int ix = ty * (int)level.Width + tx;
                                Decoration d = level.DecorationLayer4[ix];
                                if (d.Tile == 0xFF) continue;

                                Vector2 v = new Vector2(tx * 16f, -ty * 16f);
                                if (tileTexIds.ContainsKey(d.Tile))
                                    renderer.Draw(tileTexIds[d.Tile], v, vec_scale, 16, 16);
                                else
                                    renderer.Draw(unkTileTex, v, vec_scale, 16, 16);
                            }
                        }
                    }
                }

                //Blocks
                if (renderBlocksToolStripMenuItem.Checked)
                {
                    for (int ty = tileStartY; ty < tileEndY; ty++)
                    {
                        for (int tx = tileStartX; tx < tileEndX; tx++)
                        {
                            int ix = ty * (int)level.Width + tx;
                            Block b = level.TileBlock[ix];
                            Vector2 v = new Vector2(tx * 16f, -ty * 16f);

                            if (b.ID != -1)
                            {
                                if (b.ID == 2 || b.ID == 9 || b.ID == 12 || b.ID == 14 || b.ID == 19) //2x2
                                {
                                    renderer.Draw(blockTexIds[b.ID], v - new Vector2(0, 16f), vec_scale, 33, 33);
                                }
                                else if (b.ID == 3 || b.ID == 13 || b.ID == 20) //3x3
                                {
                                    renderer.Draw(blockTexIds[b.ID], v - new Vector2(0, 32f), vec_scale, 49, 49);
                                }
                                else if (blockTexIds.ContainsKey(b.ID))
                                {
                                    renderer.Draw(blockTexIds[b.ID], v, vec_scale, 17, 17);
                                }
                                else
                                {
                                    renderer.Draw(blockTexIds[0xFF], v, vec_scale, 17, 17);
                                }
                            }
                        }
                    }
                }

                //Modifiers
                if (renderTileModifiersToolStripMenuItem.Checked)
                {
                    for (int ty = tileStartY; ty < tileEndY; ty++)
                    {
                        for (int tx = tileStartX; tx < tileEndX; tx++)
                        {
                            int ix = ty * (int)level.Width + tx;
                            Collision c = level.TileCollision[ix];
                            Vector2 v = new Vector2(tx * 16f, -ty * 16f);
                            if ((c.Modifier & (1 << 1)) != 0)
                            {
                                renderer.Draw(modTexIds[0], v, vec_scale, 17, 17);
                            }
                            if ((c.Modifier & (1 << 3)) != 0)
                            {
                                renderer.Draw(modTexIds[1], v, vec_scale, 17, 17);
                            }
                            if ((c.Modifier & (1 << 4)) != 0)
                            {
                                renderer.Draw(modTexIds[2], v, vec_scale, 17, 17);
                            }
                            if ((c.Modifier & (1 << 6)) != 0)
                            {
                                renderer.Draw(modTexIds[3], v, vec_scale, 17, 17);
                            }
                        }
                    }
                }

                if (true)
                {
                    Vector2 v = new Vector2(tileX * 16f, -tileY * 16f);
                    renderer.Draw(texIds[52], v, vec_scale, 17, 17);
                }

                if (selTileX1 != selTileX2 && selTileY1 != selTileY2)
                {
                    uint x1 = selTileX1;
                    uint x2 = selTileX2;
                    uint y1 = selTileY1;
                    uint y2 = selTileY2;
                    if (x2 > x1)
                    {
                        x2++;
                    }
                    else if (x2 < x1)
                    {
                        x1++;
                    }
                    if (y2 < y1 && y2 != 0)
                    {
                        y2--;
                    }
                    if (y2 > y1 && y1 != 0)
                    {
                        y1--;
                    }
                    GL.Begin(PrimitiveType.Quads);
                    GL.Color4(Color.FromArgb(50, 200, 255, 255));
                    GL.Vertex2(x1 * 16, -y1 * 16);
                    GL.Vertex2(x2 * 16, -y1 * 16);
                    GL.Vertex2(x2 * 16, -y2 * 16);
                    GL.Vertex2(x1 * 16, -y2 * 16);
                    GL.End();

                    GL.Begin(PrimitiveType.Lines);
                    GL.Color4(Color.FromArgb(255, 0, 0, 255));

                    GL.Vertex2(x1 * 16, -y1 * 16);
                    GL.Vertex2(x2 * 16, -y1 * 16);
                    
                    GL.Vertex2(x2 * 16, -y2 * 16);
                    GL.Vertex2(x2 * 16, -y1 * 16);
                    
                    GL.Vertex2(x2 * 16, -y2 * 16);
                    GL.Vertex2(x1 * 16, -y2 * 16);
                    
                    GL.Vertex2(x1 * 16, -y2 * 16);
                    GL.Vertex2(x1 * 16, -y1 * 16);
                    GL.End();
                }

                if (renderObjectPointsToolStripMenuItem.Checked)
                {
                    for (int i = 0; i < level.Objects.Count; i++)
                    {
                        try
                        {
                            int oX = int.Parse(level.Objects[i]["int x"].Replace(" ", "").Split('|')[0]);
                            int oY = int.Parse(level.Objects[i]["int y"].Replace(" ", "").Split('|')[0]);
                            int offX = int.Parse(level.Objects[i]["int x"].Replace(" ", "").Split('|')[1]);
                            int offY = int.Parse(level.Objects[i]["int y"].Replace(" ", "").Split('|')[1]);
                            renderer.Draw(objTexIds[0], new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f, 1f), 7, 7);
                            if (i == objList.SelectedIndex)
                            {
                                renderer.Draw(objTexIds[5], new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f, 1f), 7, 7);
                            }
                            if (renderObjectNamesToolStripMenuItem.Checked) renderer.DrawString(level.Objects[i]["string kind"], font, new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f / (float)camera.zoom, 1f / (float)camera.zoom), new Vector4(0.2f,0.6f,0.2f,1f));
                        }
                        catch { }
                    }
                }

                if (renderGuestStarItemPointsToolStripMenuItem.Checked)
                {
                    for (int i = 0; i < level.GuestStarItems.Count; i++)
                    {
                        try
                        {
                            int oX = int.Parse(level.GuestStarItems[i]["int x"].Replace(" ", "").Split('|')[0]);
                            int oY = int.Parse(level.GuestStarItems[i]["int y"].Replace(" ", "").Split('|')[0]);
                            int offX = int.Parse(level.GuestStarItems[i]["int x"].Replace(" ", "").Split('|')[1]);
                            int offY = int.Parse(level.GuestStarItems[i]["int y"].Replace(" ", "").Split('|')[1]);
                            renderer.Draw(objTexIds[1], new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f, 1f), 7, 7);
                            if (i == guestItemList.SelectedIndex)
                            {
                                renderer.Draw(objTexIds[5], new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f, 1f), 7, 7);
                            }
                            if (renderObjectNamesToolStripMenuItem.Checked) renderer.DrawString(level.GuestStarItems[i]["string kind"], font, new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f / (float)camera.zoom, 1f / (float)camera.zoom), new Vector4(0.2f, 0.3f, 0.6f, 1f));
                        }
                        catch { }
                    }
                }

                if (renderItemPointsToolStripMenuItem.Checked)
                {
                    for (int i = 0; i < level.Items.Count; i++)
                    {
                        try
                        {
                            int oX = int.Parse(level.Items[i]["int x"].Replace(" ", "").Split('|')[0]);
                            int oY = int.Parse(level.Items[i]["int y"].Replace(" ", "").Split('|')[0]);
                            int offX = int.Parse(level.Items[i]["int x"].Replace(" ", "").Split('|')[1]);
                            int offY = int.Parse(level.Items[i]["int y"].Replace(" ", "").Split('|')[1]);
                            renderer.Draw(objTexIds[2], new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f, 1f), 7, 7);
                            if (i == itemList.SelectedIndex)
                            {
                                renderer.Draw(objTexIds[5], new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f, 1f), 7, 7);
                            }
                            if (renderObjectNamesToolStripMenuItem.Checked) renderer.DrawString(level.Items[i]["string kind"], font, new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f / (float)camera.zoom, 1f / (float)camera.zoom), new Vector4(0.6f, 0.6f, 0.2f, 1f));
                        }
                        catch { }
                    }
                }

                if (renderBossPointsToolStripMenuItem.Checked)
                {
                    for (int i = 0; i < level.Bosses.Count; i++)
                    {
                        try
                        {
                            int oX = int.Parse(level.Bosses[i]["int x"].Replace(" ", "").Split('|')[0]);
                            int oY = int.Parse(level.Bosses[i]["int y"].Replace(" ", "").Split('|')[0]);
                            int offX = int.Parse(level.Bosses[i]["int x"].Replace(" ", "").Split('|')[1]);
                            int offY = int.Parse(level.Bosses[i]["int y"].Replace(" ", "").Split('|')[1]);
                            renderer.Draw(objTexIds[3], new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f, 1f), 7, 7);
                            if (i == bossList.SelectedIndex)
                            {
                                renderer.Draw(objTexIds[5], new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f, 1f), 7, 7);
                            }
                            if (renderObjectNamesToolStripMenuItem.Checked) renderer.DrawString(level.Bosses[i]["string kind"], font, new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f / (float)camera.zoom, 1f / (float)camera.zoom), new Vector4(0.9f, 0.1f, 0.1f, 1f));
                        }
                        catch { }
                    }
                }

                if (renderEnemyPointsToolStripMenuItem.Checked)
                {
                    for (int i = 0; i < level.Enemies.Count; i++)
                    {
                        try
                        {
                            int oX = int.Parse(level.Enemies[i]["int x"].Replace(" ", "").Split('|')[0]);
                            int oY = int.Parse(level.Enemies[i]["int y"].Replace(" ", "").Split('|')[0]);
                            int offX = int.Parse(level.Enemies[i]["int x"].Replace(" ", "").Split('|')[1]);
                            int offY = int.Parse(level.Enemies[i]["int y"].Replace(" ", "").Split('|')[1]);
                            renderer.Draw(objTexIds[4], new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f, 1f), 7, 7);
                            if (i == enemyList.SelectedIndex)
                            {
                                renderer.Draw(objTexIds[5], new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f, 1f), 7, 7);
                            }
                            if (renderObjectNamesToolStripMenuItem.Checked) renderer.DrawString(level.Enemies[i]["string kind"], font, new Vector2(((oX * 16f) - 3f) + (offX * 0.95f), ((-oY * 16f) + 13f) - (offY * 0.95f)), new Vector2(1f / (float)camera.zoom, 1f / (float)camera.zoom), new Vector4(0.8f, 0.2f, 0.2f, 1f));
                        }
                        catch { }
                    }
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
			int index = tabControl1.SelectedIndex;

			switch (index)
			{
				default:
				case 0:
					addObject();break;
				case 1:
					addGuestItem(); break;
				case 2:
					addItem(); break;
				case 3:
					addBoss(); break;
				case 4:
					addEnemy(); break;
			}
		}


		private void addObject()
        {
            if (level != null)
            {
                AddObj addObj = new AddObj();
                addObj.database = objectDB;
                addObj.editorType = 0;
                if (addObj.ShowDialog() == DialogResult.OK)
                {
                    addObj.obj["int wuid"] = GetUniqueWUID().ToString();
                    level.Objects.Add(addObj.obj);
                    RefreshObjectLists();
                }
            }
        }

        private void addGuestItem()
        {
            if (level != null)
            {
                AddObj addObj = new AddObj();
                addObj.database = objectDB;
                addObj.editorType = 1;
                if (addObj.ShowDialog() == DialogResult.OK)
                {
                    addObj.obj["int wuid"] = GetUniqueWUID().ToString();
                    level.GuestStarItems.Add(addObj.obj);
                    RefreshObjectLists();
                }
            }
        }

        private void addItem()
        {
            if (level != null)
            {
                AddObj addObj = new AddObj();
                addObj.database = objectDB;
                addObj.editorType = 2;
                if (addObj.ShowDialog() == DialogResult.OK)
                {
                    addObj.obj["int wuid"] = GetUniqueWUID().ToString();
                    level.Items.Add(addObj.obj);
                    RefreshObjectLists();
                }
            }
        }

        private void addBoss()
        {
            if (level != null)
            {
                AddObj addObj = new AddObj();
                addObj.database = objectDB;
                addObj.editorType = 3;
                if (addObj.ShowDialog() == DialogResult.OK)
                {
                    addObj.obj["int wuid"] = GetUniqueWUID().ToString();
                    level.Bosses.Add(addObj.obj);
                    RefreshObjectLists();
                }
            }
        }

        private void addEnemy()
        {
            if (level != null)
            {
                AddObj addObj = new AddObj();
                addObj.database = objectDB;
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
			int index = tabControl1.SelectedIndex;

			switch (index)
			{
				default:
				case 0:
					delObject(); break;
				case 1:
					delGuestItem(); break;
				case 2:
					delItem(); break;
				case 3:
					delBoss(); break;
				case 4:
					delEnemy(); break;
			}
		}

		private void delObject()
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

        private void delGuestItem()
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

        private void delItem()
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

        private void delBoss()
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

        private void delEnemy()
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
                    editObject();
                }
            }
        }

        private void guestItemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (level != null)
            {
                if (guestItemList.SelectedItem != null)
                {
                    editGuestItem();
                }
            }
        }

        private void itemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (level != null)
            {
                if (itemList.SelectedItem != null)
                {
                    editItem();
                }
            }
        }

        private void bossList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (level != null)
            {
                if (bossList.SelectedItem != null)
                {
                    editBoss();
                }
            }
        }

        private void enemyList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (level != null)
            {
                if (enemyList.SelectedItem != null)
                {
                    editEnemy();
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
                        Decoration ml = level.DecorationLayer1[ix];
                        Decoration bl = level.DecorationLayer2[ix];
                        Decoration fl = level.DecorationLayer3[ix];
                        Decoration ul = level.DecorationLayer4[ix];

                        bl.Tile = (byte)d1_1.Value;
                        bl.Unk_2 = (byte)d1_2.Value;
                        bl.Unk_3 = (byte)d1_3.Value;
                        bl.Group = (byte)d1_4.Value;

                        ml.Tile = (byte)d2_1.Value;
                        ml.Unk_2 = (byte)d2_2.Value;
                        ml.Unk_3 = (byte)d2_3.Value;
                        ml.Group = (byte)d2_4.Value;

                        fl.Tile = (byte)d3_1.Value;
                        fl.Unk_2 = (byte)d3_2.Value;
                        fl.Unk_3 = (byte)d3_3.Value;
                        fl.Group = (byte)d3_4.Value;

                        ul.Tile = (byte)d4_1.Value;
                        ul.Unk_2 = (byte)d4_2.Value;
                        ul.Unk_3 = (byte)d4_3.Value;
                        ul.Group = (byte)d4_4.Value;

                        level.DecorationLayer1[ix] = bl;
                        level.DecorationLayer2[ix] = ml;
                        level.DecorationLayer3[ix] = fl;
                        level.DecorationLayer4[ix] = ul;
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

                    d1_1.Value = level.DecorationLayer1[ix].Tile;
                    d1_2.Value = level.DecorationLayer1[ix].Unk_2;
                    d1_3.Value = level.DecorationLayer1[ix].Unk_3;
                    d1_4.Value = level.DecorationLayer1[ix].Group;

                    d2_1.Value = level.DecorationLayer2[ix].Tile;
                    d2_2.Value = level.DecorationLayer2[ix].Unk_2;
                    d2_3.Value = level.DecorationLayer2[ix].Unk_3;
                    d2_4.Value = level.DecorationLayer2[ix].Group;

                    d3_1.Value = level.DecorationLayer3[ix].Tile;
                    d3_2.Value = level.DecorationLayer3[ix].Unk_2;
                    d3_3.Value = level.DecorationLayer3[ix].Unk_3;
                    d3_4.Value = level.DecorationLayer3[ix].Group;

                    d4_1.Value = level.DecorationLayer4[ix].Tile;
                    d4_2.Value = level.DecorationLayer4[ix].Unk_2;
                    d4_3.Value = level.DecorationLayer4[ix].Unk_3;
                    d4_4.Value = level.DecorationLayer4[ix].Group;
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
                        Decoration ml = level.DecorationLayer1[ix];
                        Decoration bl = level.DecorationLayer2[ix];
                        Decoration fl = level.DecorationLayer3[ix];
                        Decoration ul = level.DecorationLayer4[ix];

                        bl.Tile = (byte)d1_1.Value;
                        bl.Unk_2 = (byte)d1_2.Value;
                        bl.Unk_3 = (byte)d1_3.Value;
                        bl.Group = (byte)d1_4.Value;

                        ml.Tile = (byte)d2_1.Value;
                        ml.Unk_2 = (byte)d2_2.Value;
                        ml.Unk_3 = (byte)d2_3.Value;
                        ml.Group = (byte)d2_4.Value;

                        fl.Tile = (byte)d3_1.Value;
                        fl.Unk_2 = (byte)d3_2.Value;
                        fl.Unk_3 = (byte)d3_3.Value;
                        fl.Group = (byte)d3_4.Value;

                        ul.Tile = (byte)d4_1.Value;
                        ul.Unk_2 = (byte)d4_2.Value;
                        ul.Unk_3 = (byte)d4_3.Value;
                        ul.Group = (byte)d4_4.Value;

                        level.DecorationLayer1[ix] = bl;
                        level.DecorationLayer2[ix] = ml;
                        level.DecorationLayer3[ix] = fl;
                        level.DecorationLayer4[ix] = ul;
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
            camera.zoom = 1.0;
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
                d.Tile = 255;
                d.Unk_2 = 255;
                d.Unk_3 = 0;
                d.Group = 255;

                if (sizeW.Value > level.Width)
                {
                    for (int h = 0; h < sizeH.Value; h++)
                    {
                        level.TileCollision.Insert(((h * (int)level.Width) + (int)level.Width) + h, c);
                        level.TileBlock.Insert(((h * (int)level.Width) + (int)level.Width) + h, b);
                        level.DecorationLayer2.Insert(((h * (int)level.Width) + (int)level.Width) + h, d);
                        level.DecorationLayer1.Insert(((h * (int)level.Width) + (int)level.Width) + h, d);
                        level.DecorationLayer3.Insert(((h * (int)level.Width) + (int)level.Width) + h, d);
                        level.DecorationLayer4.Insert(((h * (int)level.Width) + (int)level.Width) + h, d);
                    }
                    level.Width = (uint)sizeW.Value;
                }
                else if (sizeW.Value < level.Width)
                {
                    for (int h = 0; h < sizeH.Value - 1; h++)
                    {
                        level.TileCollision.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                        level.TileBlock.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                        level.DecorationLayer2.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                        level.DecorationLayer1.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                        level.DecorationLayer3.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                        level.DecorationLayer4.RemoveAt(((h * (int)level.Width) + (int)level.Width) - h);
                    }
                    level.Width = (uint)sizeW.Value;
                }
                else if (sizeH.Value > level.Height)
                {
                    for (int w = 0; w < level.Width; w++)
                    {
                        level.TileCollision.Add(c);
                        level.TileBlock.Add(b);
                        level.DecorationLayer2.Add(d);
                        level.DecorationLayer1.Add(d);
                        level.DecorationLayer3.Add(d);
                        level.DecorationLayer4.Add(d);
                    }
                    level.Height = (uint)sizeH.Value;
                }
                else if (sizeH.Value < level.Height)
                {
                    level.TileCollision.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.TileBlock.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.DecorationLayer2.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.DecorationLayer1.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.DecorationLayer3.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
                    level.DecorationLayer4.RemoveRange((int)((level.Height - 1) * (int)level.Width), (int)level.Width);
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
                                Decoration ml = level.DecorationLayer1[ix];
                                Decoration bl = level.DecorationLayer2[ix];
                                Decoration fl = level.DecorationLayer3[ix];
                                Decoration ul = level.DecorationLayer4[ix];

                                bl.Tile = (byte)d1_1.Value;
                                bl.Unk_2 = (byte)d1_2.Value;
                                bl.Unk_3 = (byte)d1_3.Value;
                                bl.Group = (byte)d1_4.Value;

                                ml.Tile = (byte)d2_1.Value;
                                ml.Unk_2 = (byte)d2_2.Value;
                                ml.Unk_3 = (byte)d2_3.Value;
                                ml.Group = (byte)d2_4.Value;

                                fl.Tile = (byte)d3_1.Value;
                                fl.Unk_2 = (byte)d3_2.Value;
                                fl.Unk_3 = (byte)d3_3.Value;
                                fl.Group = (byte)d3_4.Value;

                                ul.Tile = (byte)d4_1.Value;
                                ul.Unk_2 = (byte)d4_2.Value;
                                ul.Unk_3 = (byte)d4_3.Value;
                                ul.Group = (byte)d4_4.Value;

                                level.DecorationLayer1[ix] = bl;
                                level.DecorationLayer2[ix] = ml;
                                level.DecorationLayer3[ix] = fl;
                                level.DecorationLayer4[ix] = ul;
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
			int index = tabControl1.SelectedIndex;

			switch (index)
			{
				default:
				case 0:
					cloneObject(); break;
				case 1:
					cloneGuestItem(); break;
				case 2:
					cloneItem(); break;
				case 3:
					cloneBoss(); break;
				case 4:
					cloneEnemy(); break;
			}
		}

		private void cloneObject()
        {
            if (level != null)
            {
                if (objList.SelectedItem != null)
                {
                    level.Objects.Add(level.Objects[objList.SelectedIndex]);
					RefreshObjectLists();
                }
            }
        }

        private void cloneGuestItem()
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

        private void cloneItem()
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

        private void cloneBoss()
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

        private void cloneEnemy()
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

		private void groupBox7_Enter(object sender, EventArgs e)
		{

		}

		private void toolStripComboBox1_Click(object sender, EventArgs e)
		{

		}

		private void renderBlocksToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

        private void reloadObjectDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objectDB = new ObjectDatabase(File.ReadAllLines(Directory.GetCurrentDirectory() + @"\object.json"));
        }
    }
}
