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
            List<string> list = new List<string>();
            if (editorType == 0)
            {
                list = objs.ObjectList.Keys.ToList();
                list.Sort();
                objectDropDown.Items.AddRange(list.ToArray());
            }
            else if (editorType == 1 || editorType == 2)
            {
                list = objs.ItemList.Keys.ToList();
                list.Sort();
                objectDropDown.Items.AddRange(list.ToArray());
            }
            else if (editorType == 3)
            {
                list = objs.BossList.Keys.ToList();
                list.Sort();
                objectDropDown.Items.AddRange(list.ToArray());
            }
            else if (editorType == 4)
            {
                objectDropDown.Items.AddRange(new string[] { "Enemy", "MBoss" });
                enemyDropDown.Visible = true;
            }
            objectDropDown.SelectedIndex = 0;
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
                                if (objs.ObjectList[objectDropDown.Text][i] == "int x" || objs.ObjectList[objectDropDown.Text][i] == "int y")
                                {
                                    value = "0 | 0";
                                }
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
                                if (objs.ItemList[objectDropDown.Text][i] == "int x" || objs.ItemList[objectDropDown.Text][i] == "int y")
                                {
                                    value = "0 | 0";
                                }
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
                                if (objs.BossList[objectDropDown.Text][i] == "int x" || objs.BossList[objectDropDown.Text][i] == "int y")
                                {
                                    value = "0 | 0";
                                }
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
                                else if (objs.BossList[objectDropDown.Text][i] == "string kind")
                                {
                                    value = objectDropDown.Text;
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
                    for (int i = 0; i < objs.EnemyList[enemyDropDown.Text].Length; i++)
                    {
                        string value = "";
                        string valType = objs.EnemyList[enemyDropDown.Text][i].Split(' ')[0];
                        switch (valType)
                        {
                            case "int":
                            case "float":
                                {
                                    value = "0";
                                    if (objs.EnemyList[enemyDropDown.Text][i] == "int x" || objs.EnemyList[enemyDropDown.Text][i] == "int y")
                                    {
                                        value = "0 | 0";
                                    }
                                    break;
                                }
                            case "bool":
                                {
                                    value = "False";
                                    break;
                                }
                            case "string":
                                {
                                    if (objs.EnemyList[enemyDropDown.Text][i] == "string constraintMoveGroup")
                                    {
                                        value = "-1";
                                    }
                                    else if (objs.EnemyList[enemyDropDown.Text][i] == "string dirType")
                                    {
                                        value = "Normal";
                                    }
                                    else if (objs.EnemyList[enemyDropDown.Text][i] == "string enemyCategory")
                                    {
                                        value = "Enemy";
                                    }
                                    else if (objs.EnemyList[enemyDropDown.Text][i] == "string kind")
                                    {
                                        value = enemyDropDown.Text;
                                    }
                                    else if (objs.EnemyList[enemyDropDown.Text][i] == "string level")
                                    {
                                        value = "Lvl1";
                                    }
                                    else if (objs.EnemyList[enemyDropDown.Text][i] == "string size")
                                    {
                                        value = "Normal";
                                    }
                                    else if (objs.EnemyList[enemyDropDown.Text][i] == "string variation")
                                    {
                                        value = "Normal";
                                    }
                                    break;
                                }
                        }
                        obj.Add(objs.EnemyList[enemyDropDown.Text][i], value);
                    }
                }
                else if (objectDropDown.Text == "MBoss")
                {
                    for (int i = 0; i < objs.MBossList[enemyDropDown.Text].Length; i++)
                    {
                        string value = "";
                        string valType = objs.MBossList[enemyDropDown.Text][i].Split(' ')[0];
                        switch (valType)
                        {
                            case "int":
                            case "float":
                                {
                                    value = "0";
                                    if (objs.MBossList[enemyDropDown.Text][i] == "int x" || objs.MBossList[enemyDropDown.Text][i] == "int y")
                                    {
                                        value = "0 | 0";
                                    }
                                    break;
                                }
                            case "bool":
                                {
                                    value = "False";
                                    break;
                                }
                            case "string":
                                {
                                    if (objs.MBossList[enemyDropDown.Text][i] == "string constraintMoveGroup")
                                    {
                                        value = "-1";
                                    }
                                    else if (objs.MBossList[enemyDropDown.Text][i] == "string dirType")
                                    {
                                        value = "Normal";
                                    }
                                    else if (objs.MBossList[enemyDropDown.Text][i] == "string enemyCategory")
                                    {
                                        value = "MBoss";
                                    }
                                    else if (objs.MBossList[enemyDropDown.Text][i] == "string kind")
                                    {
                                        value = enemyDropDown.Text;
                                    }
                                    else if (objs.MBossList[enemyDropDown.Text][i] == "string level")
                                    {
                                        value = "Lvl1";
                                    }
                                    else if (objs.MBossList[enemyDropDown.Text][i] == "string mapDBKind")
                                    {
                                        value = enemyDropDown.Text;
                                    }
                                    else if (objs.MBossList[enemyDropDown.Text][i] == "string modelKind")
                                    {
                                        value = "Normal";
                                    }
                                    else if (objs.MBossList[enemyDropDown.Text][i] == "string size")
                                    {
                                        value = "Normal";
                                    }
                                    else if (objs.MBossList[enemyDropDown.Text][i] == "string variation")
                                    {
                                        value = "Normal";
                                    }
                                    break;
                                }
                        }
                        obj.Add(objs.MBossList[enemyDropDown.Text][i], value);
                    }
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void objectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editorType == 4)
            {
                enemyDropDown.Items.Clear();
                if (objectDropDown.Text == "Enemy")
                {
                    List<string> list = objs.EnemyList.Keys.ToList();
                    list.Sort();
                    enemyDropDown.Items.AddRange(list.ToArray());
                }
                else if (objectDropDown.Text == "MBoss")
                {
                    List<string> list = objs.MBossList.Keys.ToList();
                    list.Sort();
                    enemyDropDown.Items.AddRange(list.ToArray());
                }
            }
        }
    }
}
