using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KSALVL;

namespace JamBuilder
{
    public partial class NewLevel : Form
    {
        public Level level;
        Objects objs = new Objects();

        public NewLevel()
        {
            InitializeComponent();
        }

        private void NewLevel_Load(object sender, EventArgs e)
        {
            
        }

        private void createLevel_Click(object sender, EventArgs e)
        {
            level = new Level();

            level.Height = (uint)sizeH.Value;
            level.Width = (uint)sizeW.Value;

            Collision c = new Collision();
            Block b = new Block();
            Decoration d = new Decoration();
            b.ID = -1;
            d.Tile = 255;
            d.Unk_2 = 255;
            d.Unk_3 = 0;
            d.Group = 254;

            for (int i = 0; i < level.Height * level.Width; i++)
            {
                level.TileCollision.Add(c);
                level.TileBlock.Add(b);
                level.DecorationLayer2.Add(d);
                level.DecorationLayer1.Add(d);
                level.DecorationLayer3.Add(d);
                level.DecorationLayer4.Add(d);
            }

            level.Background = bg.Text;
            level.Tileset = tileset.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
