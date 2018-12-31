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
    public partial class AddObj : Form
    {
        public int editorType;
        public Dictionary<string, string> obj = new Dictionary<string, string>();

        public AddObj()
        {
            InitializeComponent();
        }

        private void AddObj_Load(object sender, EventArgs e)
        {
            if (editorType == 0)
            {
                foreach (KeyValuePair<string, string[]> pair in new Objects().ObjectList)
                {
                    objectDropDown.Items.Add(pair.Key);
                }
            }
            else if (editorType == 3)
            {

            }
            else if (editorType == 4)
            {
                objectDropDown.Items.AddRange(new Objects().EnemyList.ToArray());
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (editorType == 0)
            {
                for (int i = 0; i < new Objects().ObjectList[objectDropDown.Text].Length; i++)
                {
                    string value = "";
                    string valType = new Objects().ObjectList[objectDropDown.Text][i].Split(' ')[0];
                    switch (valType)
                    {
                        case "int":
                        case "float":
                            {
                                value = "0";
                                break;
                            }
                        case "bool":
                            {
                                value = "False";
                                break;
                            }
                    }
                    if (new Objects().ObjectList[objectDropDown.Text][i] == "string kind")
                    {
                        value = objectDropDown.Text;
                    }
                    obj.Add(new Objects().ObjectList[objectDropDown.Text][i], value);
                }
            }
            else if (editorType == 4)
            {
                for (int i = 0; i < new Objects().EnemyData.Length; i++)
                {
                    switch (new Objects().EnemyData[i])
                    {
                        case "int wuid":
                        case "int x":
                        case "int y":
                        case "int group":
                            {
                                obj.Add(new Objects().EnemyData[i], "0");
                                break;
                            }
                        case "string constraintMoveGroup":
                            {
                                obj.Add(new Objects().EnemyData[i], "0");
                                break;
                            }
                        case "string dirType":
                            {
                                obj.Add(new Objects().EnemyData[i], "L");
                                break;
                            }
                        case "string enemyCategory":
                            {
                                obj.Add(new Objects().EnemyData[i], "Enemy");
                                break;
                            }
                        case "string kind":
                            {
                                obj.Add(new Objects().EnemyData[i], objectDropDown.Text);
                                break;
                            }
                        case "string level":
                            {
                                obj.Add(new Objects().EnemyData[i], "Lvl1");
                                break;
                            }
                        case "string size":
                        case "string variation":
                            {
                                obj.Add(new Objects().EnemyData[i], "Normal");
                                break;
                            }
                    }
                }
            }
            DialogResult = DialogResult.OK;
        }
    }
}
