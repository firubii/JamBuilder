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
    public partial class StageSettings : Form
    {
        public Stage stage;
        public string bg;
        public string tileset;

        public StageSettings()
        {
            InitializeComponent();
        }

        private void StageSettings_Load(object sender, EventArgs e)
        {
            unk1.Text = stage.Unk_1.ToString();
            unk2.Text = stage.Unk_2.ToString();
            unk3.Text = stage.Unk_3.ToString();
            unk4.Text = stage.Unk_4.ToString();
            unk5.Text = stage.Unk_5.ToString();
            unk6.Text = stage.Unk_6.ToString();
            unk7.Text = stage.Unk_7.ToString();
            unk8.Text = stage.Unk_8.ToString();
            unk9.Text = stage.Unk_9.ToString();
            unk10.Text = stage.Unk_10.ToString();
            unk11.Text = stage.Unk_11.ToString();
            unkString.Text = stage.Unk_String;
            bgText.Text = bg;
            tileText.Text = tileset;
        }

        private void save_Click(object sender, EventArgs e)
        {
            stage.Unk_1 = uint.Parse(unk1.Text);
            stage.Unk_2 = uint.Parse(unk2.Text);
            stage.Unk_3 = float.Parse(unk3.Text);
            stage.Unk_4 = float.Parse(unk4.Text);
            stage.Unk_5 = float.Parse(unk5.Text);
            stage.Unk_6 = float.Parse(unk6.Text);
            stage.Unk_7 = float.Parse(unk7.Text);
            stage.Unk_8 = float.Parse(unk8.Text);
            stage.Unk_9 = float.Parse(unk9.Text);
            stage.Unk_10 = float.Parse(unk10.Text);
            stage.Unk_11 = float.Parse(unk11.Text);
            stage.Unk_String = unkString.Text;
            bg = bgText.Text;
            tileset = tileText.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
