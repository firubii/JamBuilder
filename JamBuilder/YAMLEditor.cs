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
using KSALVL.Hel;

namespace JamBuilder
{
    public partial class YAMLEditor : Form
    {
        public Yaml obj;
        public int editorType;

        public ObjectDatabase database;
        bool loading;

        Dictionary<string, ObjectDatabase.ObjectProperty[]> objList;

        public YAMLEditor()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            loading = true;

            yamlDataList.Items.Clear();
            yamlDataList.BeginUpdate();
            for (int i = 0; i < obj.Root.Length; i++)
            {
                string key = obj.Root.Key(i);
                yamlDataList.Items.Add($"{obj.Root[key].Type} {key}");
            }
            yamlDataList.EndUpdate();

            loading = false;
        }

        private void YAMLEditor_Load(object sender, EventArgs e)
        {
            switch (editorType)
            {
                case 0:
                    {
                        objList = database.ObjectList;
                        break;
                    }
                case 1:
                case 2:
                    {
                        objList = database.ItemList;
                        break;
                    }
                case 3:
                    {
                        objList = database.BossList;
                        break;
                    }
                case 4:
                    {
                        objList = database.EnemyList;
                        break;
                    }
            }
            RefreshList();
        }

        private void yamlDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yamlDataList.SelectedItem != null)
            {
                loading = true;
                valueEnum.Items.Clear();

                string key = obj.Root.Key(yamlDataList.SelectedIndex);
                Yaml.Data selectedData = obj.Root[key];
                switch (selectedData.Type)
                {
                    case Yaml.Type.Int:
                        {
                            valueOffset.Visible = false;
                            valueBool.Visible = false;
                            valueString.Visible = false;
                            valueEnum.Visible = false;

                            valueNum.Visible = true;
                            valueNum.Width = 200;
                            valueNum.Value = 0;
                            valueNum.Minimum = int.MinValue;
                            valueNum.Maximum = int.MaxValue;
                            valueNum.DecimalPlaces = 0;

                            valueNum.Value = selectedData.ToInt();
                            if (key == "x" || key == "y")
                            {
                                valueOffset.Visible = true;
                                valueNum.Width = 150;
                                valueNum.Value = selectedData.ToInt() >> 4;
                                valueOffset.Value = selectedData.ToInt() & 0xF;
                            }
                            break;
                        }
                    case Yaml.Type.Float:
                        {
                            valueOffset.Visible = false;
                            valueBool.Visible = false;
                            valueString.Visible = false;
                            valueEnum.Visible = false;

                            valueNum.Visible = true;
                            valueNum.Value = 0;
                            valueNum.Minimum = decimal.MinValue;
                            valueNum.Maximum = decimal.MaxValue;
                            valueNum.DecimalPlaces = 3;

                            valueNum.Value = (decimal)selectedData.ToFloat();
                            break;
                        }
                    case Yaml.Type.Bool:
                        {
                            valueOffset.Visible = false;
                            valueNum.Visible = false;
                            valueString.Visible = false;
                            valueEnum.Visible = false;

                            valueBool.Visible = true;
                            valueBool.Checked = selectedData.ToBool();
                            break;
                        }
                    case Yaml.Type.String:
                        {
                            valueOffset.Visible = false;
                            valueNum.Visible = false;
                            valueBool.Visible = false;
                            valueEnum.Visible = false;

                            valueString.Visible = true;
                            valueString.Text = selectedData.ToString();
                            break;
                        }
                }


                loading = false;
            }
        }

        private void valueString_TextChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            string key = obj.Root.Key(yamlDataList.SelectedIndex);
            obj.Root[key].Set(valueString.Text);
        }

        private void delAttribute_Click(object sender, EventArgs e)
        {
            
        }

        private void valueSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueString.Text = valueEnum.Text;
        }

        private void boolSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            string key = obj.Root.Key(yamlDataList.SelectedIndex);
            obj.Root[key].Set(valueBool.Checked);
        }

        private void valueNum_ValueChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            string key = obj.Root.Key(yamlDataList.SelectedIndex);
            if (key == "x" || key == "y")
            {
                obj.Root[key].Set(((int)valueNum.Value << 4) | ((int)valueOffset.Value));
            }
            else
            {
                obj.Root[key].Set((int)valueNum.Value);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
