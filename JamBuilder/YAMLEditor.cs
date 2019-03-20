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
    public partial class YAMLEditor : Form
    {
        public Dictionary<string, string> obj;
        public int editorType;

        public ObjectDatabase database;

        Dictionary<string, ObjectDatabase.ObjectProperty[]> objList;

        public YAMLEditor()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            yamlDataList.Items.Clear();
            yamlDataList.BeginUpdate();
            foreach(KeyValuePair<string, string> pair in obj)
            {
                yamlDataList.Items.Add(pair.Key);
            }
            yamlDataList.EndUpdate();
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
            foreach (KeyValuePair<string, string> pair in obj)
            {
                yamlDataList.Items.Add(pair.Key);
            }
        }

        private void yamlDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yamlDataList.SelectedItem != null)
            {
                valueSelect.Items.Clear();
                valueSelect.Enabled = false;
                boolSelect.Checked = false;
                boolSelect.Enabled = false;
                value.Text = obj[yamlDataList.SelectedItem.ToString()];
                value.Enabled = true;
                if (yamlDataList.SelectedItem.ToString() == "string kind")
                {
                    valueSelect.Enabled = false;
                    value.Enabled = false;
                    boolSelect.Enabled = false;
                }
                if (objList.ContainsKey(obj["string kind"]))
                {
                    for (int i = 0; i < objList[obj["string kind"]].Length; i++)
                    {
                        if (yamlDataList.SelectedItem.ToString().Split(' ')[1] == objList[obj["string kind"]][i].Name)
                        {
                            if (objList[obj["string kind"]][i].Type == ObjectDatabase.PropertyType.Bool)
                            {
                                boolSelect.Checked = Convert.ToBoolean(obj[yamlDataList.SelectedItem.ToString()].ToLower());
                                boolSelect.Enabled = true;
                                value.Enabled = false;
                            }
                            else if (objList[obj["string kind"]][i].Options.Length > 0)
                            {
                                valueSelect.Items.AddRange(objList[obj["string kind"]][i].Options);
                                valueSelect.Enabled = true;
                                valueSelect.Text = value.Text;
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void value_TextChanged(object sender, EventArgs e)
        {
            obj[yamlDataList.SelectedItem.ToString()] = value.Text;
        }

        private void save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void delAttribute_Click(object sender, EventArgs e)
        {
            if (yamlDataList.SelectedItem != null)
            {
                obj.Remove(yamlDataList.SelectedItem.ToString());
                RefreshList();
            }
        }

        private void valueSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            value.Text = valueSelect.Text;
        }

        private void boolSelect_CheckedChanged(object sender, EventArgs e)
        {
            obj[yamlDataList.SelectedItem.ToString()] = boolSelect.Checked.ToString();
        }
    }
}
