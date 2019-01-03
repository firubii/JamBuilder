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

        Objects objs = new Objects();

        public AddObj()
        {
            InitializeComponent();
        }

        private void AddObj_Load(object sender, EventArgs e)
        {
            if (editorType == 0)
            {
                objectDropDown.Items.AddRange(objs.ObjectList.Keys.ToArray());
            }
            else if (editorType == 1 || editorType == 2)
            {
                objectDropDown.Items.AddRange(objs.ItemList.Keys.ToArray());
            }
            else if (editorType == 3)
            {
                objectDropDown.Items.AddRange(objs.BossList.Keys.ToArray());
            }
            else if (editorType == 4)
            {
                objectDropDown.Items.AddRange(new string[] { "Enemy", "MBoss" });
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (editorType == 0)
            {
                for (int i = 0; i < objs.ObjectList[objectDropDown.Text].Length; i++)
                {
                    string value = "";
                    string valType = objs.ObjectList[objectDropDown.Text][i].Split(' ')[0];
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
                        case "string":
                            {
                                if (objs.ObjectList[objectDropDown.Text][i] == "string constraintMoveGroup")
                                {
                                    value = "-1";
                                }
                                else if (objs.ObjectList[objectDropDown.Text][i] == "string kind")
                                {
                                    value = objectDropDown.Text;
                                }
                                break;
                            }
                    }
                    obj.Add(objs.ObjectList[objectDropDown.Text][i], value);
                }
            }
            if (editorType == 1 || editorType == 2)
            {
                for (int i = 0; i < objs.ItemList[objectDropDown.Text].Length; i++)
                {
                    string value = "";
                    string valType = objs.ItemList[objectDropDown.Text][i].Split(' ')[0];
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
                        case "string":
                            {
                                if (objs.ItemList[objectDropDown.Text][i] == "string constraintMoveGroup")
                                {
                                    value = "-1";
                                }
                                else if (objs.ItemList[objectDropDown.Text][i] == "string itemCategory")
                                {
                                    if (editorType == 1)
                                    {
                                        value = "HelperGoItem";
                                    }
                                    else if (editorType == 1)
                                    {
                                        value = "Item";
                                    }
                                }
                                else if (objs.ItemList[objectDropDown.Text][i] == "string kind")
                                {
                                    value = objectDropDown.Text;
                                }
                                else if (objs.ItemList[objectDropDown.Text][i] == "string subKind")
                                {
                                    value = "FruitWatermelon";
                                }
                                else if (objs.ItemList[objectDropDown.Text][i] == "string variation")
                                {
                                    value = "Fixed";
                                }
                                break;
                            }
                    }
                    obj.Add(objs.ItemList[objectDropDown.Text][i], value);
                }
            }
            else if (editorType == 3)
            {
                for (int i = 0; i < objs.BossList[objectDropDown.Text].Length; i++)
                {
                    string value = "";
                    string valType = objs.BossList[objectDropDown.Text][i].Split(' ')[0];
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
                        case "string":
                            {
                                if (objs.BossList[objectDropDown.Text][i] == "string constraintMoveGroup")
                                {
                                    value = "-1";
                                }
                                else if (objs.BossList[objectDropDown.Text][i] == "string dirType")
                                {
                                    value = "Normal";
                                }
                                else if (objs.BossList[objectDropDown.Text][i] == "string enemyCategory")
                                {
                                    value = "Boss";
                                }
                                else if (objs.BossList[objectDropDown.Text][i] == "string level")
                                {
                                    value = "Lvl1";
                                }
                                else if (objs.BossList[objectDropDown.Text][i] == "string modelKind")
                                {
                                    value = "Normal";
                                }
                                else if (objs.BossList[objectDropDown.Text][i] == "string size")
                                {
                                    value = "Normal";
                                }
                                else if (objs.BossList[objectDropDown.Text][i] == "string variation")
                                {
                                    value = "Normal";
                                }
                                break;
                            }
                    }
                    obj.Add(objs.BossList[objectDropDown.Text][i], value);
                }
            }
            else if (editorType == 4)
            {
                if (objectDropDown.Text == "Enemy")
                {
                    for (int i = 0; i < objs.EnemyList[objectDropDown.Text].Length; i++)
                    {
                        string value = "";
                        string valType = objs.EnemyList[objectDropDown.Text][i].Split(' ')[0];
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
                            case "string":
                                {
                                    if (objs.EnemyList[objectDropDown.Text][i] == "string constraintMoveGroup")
                                    {
                                        value = "-1";
                                    }
                                    else if (objs.EnemyList[objectDropDown.Text][i] == "string dirType")
                                    {
                                        value = "Normal";
                                    }
                                    else if (objs.EnemyList[objectDropDown.Text][i] == "string enemyCategory")
                                    {
                                        value = "Enemy";
                                    }
                                    else if (objs.EnemyList[objectDropDown.Text][i] == "string level")
                                    {
                                        value = "Lvl1";
                                    }
                                    else if (objs.EnemyList[objectDropDown.Text][i] == "string size")
                                    {
                                        value = "Normal";
                                    }
                                    else if (objs.EnemyList[objectDropDown.Text][i] == "string variation")
                                    {
                                        value = "Normal";
                                    }
                                    break;
                                }
                        }
                        obj.Add(objs.EnemyList[objectDropDown.Text][i], value);
                    }
                }
                else if (objectDropDown.Text == "MBoss")
                {
                    for (int i = 0; i < objs.MBossList[objectDropDown.Text].Length; i++)
                    {
                        string value = "";
                        string valType = objs.MBossList[objectDropDown.Text][i].Split(' ')[0];
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
                            case "string":
                                {
                                    if (objs.MBossList[objectDropDown.Text][i] == "string constraintMoveGroup")
                                    {
                                        value = "-1";
                                    }
                                    else if (objs.MBossList[objectDropDown.Text][i] == "string dirType")
                                    {
                                        value = "Normal";
                                    }
                                    else if (objs.MBossList[objectDropDown.Text][i] == "string enemyCategory")
                                    {
                                        value = "MBoss";
                                    }
                                    else if (objs.MBossList[objectDropDown.Text][i] == "string kind")
                                    {
                                        value = "Bonkers";
                                    }
                                    else if (objs.MBossList[objectDropDown.Text][i] == "string level")
                                    {
                                        value = "Lvl1";
                                    }
                                    else if (objs.MBossList[objectDropDown.Text][i] == "string mapDBKind")
                                    {
                                        value = "Bonkers";
                                    }
                                    else if (objs.MBossList[objectDropDown.Text][i] == "string modelKind")
                                    {
                                        value = "Normal";
                                    }
                                    else if (objs.MBossList[objectDropDown.Text][i] == "string size")
                                    {
                                        value = "Normal";
                                    }
                                    else if (objs.MBossList[objectDropDown.Text][i] == "string variation")
                                    {
                                        value = "Normal";
                                    }
                                    break;
                                }
                        }
                        obj.Add(objs.MBossList[objectDropDown.Text][i], value);
                    }
                }
            }
            DialogResult = DialogResult.OK;
        }
    }
}
