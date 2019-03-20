using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KSALVL
{
    public class ObjectDatabase
    {
        public enum PropertyType
        {
            Int,
            Float,
            Bool,
            String
        }
        public struct ObjectProperty
        {
            public string Name;
            public PropertyType Type;
            public object Default;
            public object[] Options;
        }

        public Dictionary<string, ObjectProperty[]> ObjectList;
        public Dictionary<string, ObjectProperty[]> ItemList;
        public Dictionary<string, ObjectProperty[]> BossList;
        public Dictionary<string, ObjectProperty[]> EnemyList;

        public ObjectDatabase()
        {
            ObjectList = new Dictionary<string, ObjectProperty[]>();
            ItemList = new Dictionary<string, ObjectProperty[]>();
            BossList = new Dictionary<string, ObjectProperty[]>();
            EnemyList = new Dictionary<string, ObjectProperty[]>();
        }
        public ObjectDatabase(string[] file)
        {
            ObjectList = new Dictionary<string, ObjectProperty[]>();
            ItemList = new Dictionary<string, ObjectProperty[]>();
            BossList = new Dictionary<string, ObjectProperty[]>();
            EnemyList = new Dictionary<string, ObjectProperty[]>();
            ReadDatabase(file);
        }

        public void ReadDatabase(string[] db)
        {
            string[] listTypes = new string[] { "object", "item", "boss", "enemy" };
            JObject json = JObject.Parse(string.Join("\n", db));
            for (int t = 0; t < 4; t++)
            {
                JArray objArray = (JArray)json[listTypes[t]];
                for (int i = 0; i < objArray.Count; i++)
                {
                    JArray propArray = (JArray)objArray[i]["properties"];
                    List<ObjectProperty> properties = new List<ObjectProperty>();
                    for (int p = 0; p < propArray.Count; p++)
                    {
                        ObjectProperty prop = new ObjectProperty();
                        JObject propObj = (JObject)propArray[p];
                        prop.Name = (string)propObj["name"];
                        prop.Default = (string)propObj["default"];
                        switch ((string)propObj["type"])
                        {
                            case "int":
                                {
                                    prop.Type = PropertyType.Int;
                                    break;
                                }
                            case "float":
                                {
                                    prop.Type = PropertyType.Float;
                                    break;
                                }
                            case "bool":
                                {
                                    prop.Type = PropertyType.Bool;
                                    break;
                                }
                            case "string":
                                {
                                    prop.Type = PropertyType.String;
                                    break;
                                }
                        }
                        prop.Options = new object[] { };
                        if (propObj.ContainsKey("options"))
                        {
                            List<object> optionList = new List<object>();
                            JArray optionArray = (JArray)propObj["options"];
                            for (int o = 0; o < optionArray.Count; o++)
                            {
                                optionList.Add((string)optionArray[o]);
                            }
                            prop.Options = optionList.ToArray();
                        }
                        properties.Add(prop);
                    }
                    switch (t)
                    {
                        case 0:
                            {
                                ObjectList.Add((string)((JObject)objArray[i])["name"], properties.ToArray());
                                break;
                            }
                        case 1:
                            {
                                ItemList.Add((string)((JObject)objArray[i])["name"], properties.ToArray());
                                break;
                            }
                        case 2:
                            {
                                BossList.Add((string)((JObject)objArray[i])["name"], properties.ToArray());
                                break;
                            }
                        case 3:
                            {
                                EnemyList.Add((string)((JObject)objArray[i])["name"], properties.ToArray());
                                break;
                            }

                    }
                    ObjectList.Add((string)((JObject)objArray[i])["name"], properties.ToArray());
                }
            }
        }
    }
}
