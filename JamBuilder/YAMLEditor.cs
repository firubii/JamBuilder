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
            ImageList img = new ImageList();
            img.Images.Add(Properties.Resources.yamlInvalid);
            img.Images.Add(Properties.Resources.yamlInt);
            img.Images.Add(Properties.Resources.yamlFloat);
            img.Images.Add(Properties.Resources.yamlBool);
            img.Images.Add(Properties.Resources.yamlString);
            img.Images.Add(Properties.Resources.yamlHash);
            img.Images.Add(Properties.Resources.yamlArray);
            yamlDataList.ImageList = img;
        }

        private void RefreshList()
        {
            loading = true;

            yamlDataList.BeginUpdate();
            yamlDataList.Nodes.Clear();
            for (int i = 0; i < obj.Root.Length; i++)
            {
                string key = obj.Root.Key(i);
                Yaml.Data data = obj.Root[key];
                TreeNode node = new TreeNode(key, (int)data.Type, (int)data.Type);
                if (data.Type == Yaml.Type.Hash)
                {
                    for (int d = 0; d < data.Length; d++)
                    {
                        AddYamlNode(node, data.Key(d), data[data.Key(d)]);
                    }
                }
                else if (data.Type == Yaml.Type.Array)
                {
                    for (int d = 0; d < data.Length; d++)
                    {
                        AddYamlNode(node, d.ToString(), data[d]);
                    }
                }
                yamlDataList.Nodes.Add(node);
            }
            yamlDataList.EndUpdate();

            loading = false;
        }

        private void AddYamlNode(TreeNode node, string name, Yaml.Data data)
        {
            TreeNode n = new TreeNode(name, (int)data.Type, (int)data.Type);
            if (data.Type == Yaml.Type.Hash)
            {
                for (int d = 0; d < data.Length; d++)
                {
                    AddYamlNode(n, data.Key(d), data[data.Key(d)]);
                }
            }
            else if (data.Type == Yaml.Type.Array)
            {
                for (int d = 0; d < data.Length; d++)
                {
                    AddYamlNode(n, d.ToString(), data[d]);
                }
            }
            node.Nodes.Add(n);
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

        private void yamlDataList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (yamlDataList.SelectedNode != null)
            {
                loading = true;
                valueEnum.Items.Clear();

                string[] yamlPath = yamlDataList.SelectedNode.FullPath.Split('/');
                string key = yamlDataList.SelectedNode.Text;

                Yaml.Data selectedData = obj.Root;
                for (int i = 0; i < yamlPath.Length; i++)
                {
                    if (selectedData.Type == Yaml.Type.Hash)
                        selectedData = selectedData[yamlPath[i]];
                    else if (selectedData.Type == Yaml.Type.Array)
                        selectedData = selectedData[int.Parse(yamlPath[i])];
                }

                switch (selectedData.Type)
                {
                    case Yaml.Type.Int:
                        {
                            valueOffset.Visible = false;
                            valueString.Visible = false;
                            valueEnum.Visible = false;
                            valueBool.Visible = false;

                            valueNum.Visible = true;
                            valueNum.Width = 200;
                            valueNum.Value = 0;
                            valueNum.Minimum = int.MinValue;
                            valueNum.Maximum = int.MaxValue;
                            valueNum.DecimalPlaces = 0;

                            valueNum.Value = selectedData.ToInt();
                            if (key == "x" || key == "y" || key == "width" || key == "height")
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
                            valueString.Visible = false;
                            valueEnum.Visible = false;
                            valueBool.Visible = false;

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
                            valueNum.Visible = false;
                            valueOffset.Visible = false;
                            valueString.Visible = false;
                            valueEnum.Visible = false;

                            valueBool.Visible = true;
                            valueBool.Checked = selectedData.ToBool();
                            break;
                        }
                    case Yaml.Type.String:
                        {
                            valueNum.Visible = false;
                            valueOffset.Visible = false;
                            valueEnum.Visible = false;
                            valueBool.Visible = false;

                            valueString.Visible = true;
                            valueString.Text = selectedData.ToString();
                            break;
                        }
                    default:
                        {
                            valueNum.Visible = false;
                            valueOffset.Visible = false;
                            valueString.Visible = false;
                            valueEnum.Visible = false;
                            valueBool.Visible = false;
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

            string[] yamlPath = yamlDataList.SelectedNode.FullPath.Split('/');
            Yaml.Data selectedData = obj.Root;
            for (int i = 0; i < yamlPath.Length; i++)
            {
                if (selectedData.Type == Yaml.Type.Hash)
                    selectedData = selectedData[yamlPath[i]];
                else if (selectedData.Type == Yaml.Type.Array)
                    selectedData = selectedData[int.Parse(yamlPath[i])];
            }

            selectedData.Set(valueString.Text);
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

            string[] yamlPath = yamlDataList.SelectedNode.FullPath.Split('/');
            Yaml.Data selectedData = obj.Root;
            for (int i = 0; i < yamlPath.Length; i++)
            {
                if (selectedData.Type == Yaml.Type.Hash)
                    selectedData = selectedData[yamlPath[i]];
                else if (selectedData.Type == Yaml.Type.Array)
                    selectedData = selectedData[int.Parse(yamlPath[i])];
            }

            selectedData.Set(valueBool.Checked);
        }

        private void valueNum_ValueChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            string[] yamlPath = yamlDataList.SelectedNode.FullPath.Split('/');
            string key = yamlDataList.SelectedNode.Text;
            Yaml.Data selectedData = obj.Root;
            for (int i = 0; i < yamlPath.Length; i++)
            {
                if (selectedData.Type == Yaml.Type.Hash)
                    selectedData = selectedData[yamlPath[i]];
                else if (selectedData.Type == Yaml.Type.Array)
                    selectedData = selectedData[int.Parse(yamlPath[i])];
            }
            if (key == "x" || key == "y" || key == "width" || key == "height")
            {
                selectedData.Set(((int)valueNum.Value << 4) | ((int)valueOffset.Value));
            }
            else
            {
                selectedData.Set((int)valueNum.Value);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
