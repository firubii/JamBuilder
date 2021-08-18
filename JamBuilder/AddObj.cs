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
    public partial class AddObj : Form
    {
        public int editorType;
        public Yaml obj;

        public ObjectDatabase database;

        public AddObj()
        {
            InitializeComponent();
        }

        private void AddObj_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            if (editorType == 0)
            {
                list = database.ObjectList.Keys.ToList();
                objectDropDown.Items.AddRange(list.ToArray());
            }
            else if (editorType == 1 || editorType == 2)
            {
                list = database.ItemList.Keys.ToList();
                objectDropDown.Items.AddRange(list.ToArray());
            }
            else if (editorType == 3)
            {
                list = database.BossList.Keys.ToList();
                objectDropDown.Items.AddRange(list.ToArray());
            }
            else if (editorType == 4)
            {
                list = database.EnemyList.Keys.ToList();
                objectDropDown.Items.AddRange(list.ToArray());
            }
            objectDropDown.SelectedIndex = 0;
        }

        private void save_Click(object sender, EventArgs e)
        {
            obj.Root.Add("wuid", new Yaml.Data(Yaml.Type.Int, 0));
            obj.Root.Add("x", new Yaml.Data(Yaml.Type.Int, 0));
            obj.Root.Add("y", new Yaml.Data(Yaml.Type.Int, 0));
            obj.Root.Add("kind", new Yaml.Data(Yaml.Type.String, objectDropDown.Text));
            if (editorType == 0)
            {
                for (int i = 0; i < database.ObjectList[objectDropDown.Text].Length; i++)
                {
                    Yaml.Type pType = Yaml.Type.Int;
                    string pname = database.ObjectList[objectDropDown.Text][i].Name;
                    switch (database.ObjectList[objectDropDown.Text][i].Type)
                    {
                        case ObjectDatabase.PropertyType.Int:
                            {
                                pType = Yaml.Type.Int;
                                break;
                            }
                        case ObjectDatabase.PropertyType.Float:
                            {
                                pType = Yaml.Type.Float;
                                break;
                            }
                        case ObjectDatabase.PropertyType.Bool:
                            {
                                pType = Yaml.Type.Bool;
                                break;
                            }
                        case ObjectDatabase.PropertyType.String:
                            {
                                pType = Yaml.Type.String;
                                break;
                            }
                    }
                    obj.Root.Add(pname, new Yaml.Data(pType, database.ObjectList[objectDropDown.Text][i].Default));
                }
            }
            if (editorType == 1 || editorType == 2)
            {
                for (int i = 0; i < database.ItemList[objectDropDown.Text].Length; i++)
                {
                    Yaml.Type pType = Yaml.Type.Int;
                    string pname = database.ItemList[objectDropDown.Text][i].Name;
                    switch (database.ItemList[objectDropDown.Text][i].Type)
                    {
                        case ObjectDatabase.PropertyType.Int:
                            {
                                pType = Yaml.Type.Int;
                                break;
                            }
                        case ObjectDatabase.PropertyType.Float:
                            {
                                pType = Yaml.Type.Float;
                                break;
                            }
                        case ObjectDatabase.PropertyType.Bool:
                            {
                                pType = Yaml.Type.Bool;
                                break;
                            }
                        case ObjectDatabase.PropertyType.String:
                            {
                                pType = Yaml.Type.String;
                                break;
                            }
                    }
                    obj.Root.Add(pname, new Yaml.Data(pType, database.ItemList[objectDropDown.Text][i].Default));
                }
            }
            else if (editorType == 3)
            {
                for (int i = 0; i < database.BossList[objectDropDown.Text].Length; i++)
                {
                    Yaml.Type pType = Yaml.Type.Int;
                    string pname = database.BossList[objectDropDown.Text][i].Name;
                    switch (database.BossList[objectDropDown.Text][i].Type)
                    {
                        case ObjectDatabase.PropertyType.Int:
                            {
                                pType = Yaml.Type.Int;
                                break;
                            }
                        case ObjectDatabase.PropertyType.Float:
                            {
                                pType = Yaml.Type.Float;
                                break;
                            }
                        case ObjectDatabase.PropertyType.Bool:
                            {
                                pType = Yaml.Type.Bool;
                                break;
                            }
                        case ObjectDatabase.PropertyType.String:
                            {
                                pType = Yaml.Type.String;
                                break;
                            }
                    }
                    obj.Root.Add(pname, new Yaml.Data(pType, database.BossList[objectDropDown.Text][i].Default));
                }
            }
            else if (editorType == 4)
            {
                for (int i = 0; i < database.EnemyList[objectDropDown.Text].Length; i++)
                {
                    Yaml.Type pType = Yaml.Type.Int;
                    string pname = database.EnemyList[objectDropDown.Text][i].Name;
                    switch (database.EnemyList[objectDropDown.Text][i].Type)
                    {
                        case ObjectDatabase.PropertyType.Int:
                            {
                                pType = Yaml.Type.Int;
                                break;
                            }
                        case ObjectDatabase.PropertyType.Float:
                            {
                                pType = Yaml.Type.Float;
                                break;
                            }
                        case ObjectDatabase.PropertyType.Bool:
                            {
                                pType = Yaml.Type.Bool;
                                break;
                            }
                        case ObjectDatabase.PropertyType.String:
                            {
                                pType = Yaml.Type.String;
                                break;
                            }
                    }
                    obj.Root.Add(pname, new Yaml.Data(pType, database.EnemyList[objectDropDown.Text][i].Default));
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void objectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
