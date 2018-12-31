using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSALVL
{
    public class Objects
    {
        public Dictionary<string, string[]> ObjectList = new Dictionary<string, string[]>()
        {
            {"AbilitySeat", new string[] { "int wuid", "int x", "int y", "string abilityKind", "bool isSaveBetweenStep", "string kind", "int signalNo", "string variation" } },
        };
        public Dictionary<string, string[]> ItemList = new Dictionary<string, string[]>()
        {

        };
        public Dictionary<string, string[]> BossList = new Dictionary<string, string[]>()
        {

        };
        public List<string> EnemyList = new List<string>()
        {
            "Marx"
        };
        public string[] EnemyData = new string[] { "int wuid", "int x", "int y", "string constraintMoveGroup", "string dirType", "string enemyCategory", "int group", "string kind", "string level", "string size", "string variation" };
    }
}
