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
            obj.Add("int wuid", "0");
            obj.Add("int x", "0 | 0");
            obj.Add("int y", "0 | 0");
            obj.Add("string kind", objectDropDown.Text);
            if (editorType == 0)
            {
                for (int i = 0; i < database.ObjectList[objectDropDown.Text].Length; i++)
                {
                    string pname = "";
                    switch (database.ObjectList[objectDropDown.Text][i].Type)
                    {
                        case ObjectDatabase.PropertyType.Int:
                            {
                                pname = $"int {database.ObjectList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.Float:
                            {
                                pname = $"float {database.ObjectList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.Bool:
                            {
                                pname = $"bool {database.ObjectList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.String:
                            {
                                pname = $"string {database.ObjectList[objectDropDown.Text][i].Name}";
                                break;
                            }
                    }
                    obj.Add(pname, (string)database.ObjectList[objectDropDown.Text][i].Default);
                }
            }
            if (editorType == 1 || editorType == 2)
            {
                for (int i = 0; i < database.ItemList[objectDropDown.Text].Length; i++)
                {
                    string pname = "";
                    switch (database.ItemList[objectDropDown.Text][i].Type)
                    {
                        case ObjectDatabase.PropertyType.Int:
                            {
                                pname = $"int {database.ItemList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.Float:
                            {
                                pname = $"float {database.ItemList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.Bool:
                            {
                                pname = $"bool {database.ItemList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.String:
                            {
                                pname = $"string {database.ItemList[objectDropDown.Text][i].Name}";
                                break;
                            }
                    }
                    obj.Add(pname, (string)database.ItemList[objectDropDown.Text][i].Default);
                }
            }
            else if (editorType == 3)
            {
                for (int i = 0; i < database.BossList[objectDropDown.Text].Length; i++)
                {
                    string pname = "";
                    switch (database.BossList[objectDropDown.Text][i].Type)
                    {
                        case ObjectDatabase.PropertyType.Int:
                            {
                                pname = $"int {database.BossList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.Float:
                            {
                                pname = $"float {database.BossList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.Bool:
                            {
                                pname = $"bool {database.BossList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.String:
                            {
                                pname = $"string {database.BossList[objectDropDown.Text][i].Name}";
                                break;
                            }
                    }
                    obj.Add(pname, (string)database.BossList[objectDropDown.Text][i].Default);
                }
            }
            else if (editorType == 4)
            {
                for (int i = 0; i < database.EnemyList[objectDropDown.Text].Length; i++)
                {
                    string pname = "";
                    switch (database.EnemyList[objectDropDown.Text][i].Type)
                    {
                        case ObjectDatabase.PropertyType.Int:
                            {
                                pname = $"int {database.EnemyList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.Float:
                            {
                                pname = $"float {database.EnemyList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.Bool:
                            {
                                pname = $"bool {database.EnemyList[objectDropDown.Text][i].Name}";
                                break;
                            }
                        case ObjectDatabase.PropertyType.String:
                            {
                                pname = $"string {database.EnemyList[objectDropDown.Text][i].Name}";
                                break;
                            }
                    }
                    obj.Add(pname, (string)database.EnemyList[objectDropDown.Text][i].Default);
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void objectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
