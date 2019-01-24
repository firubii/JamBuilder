using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamBuilder.Rendering;
using System.Text.RegularExpressions;
using OpenTK;

namespace JamBuilder
{

    class BmChar
    {
        public int x, y, width, height, xoffset, yoffset, xadvance;
        //<Last Character, xoffset>
        public Dictionary<int, int> kerning = new Dictionary<int, int>();
    }

    public class BmFont
    {
        private int texId;
        private int lineHeight, lineBase, tabLength;
        private float scaleW, scaleH;
        private const string fontDir = "Resources/bmfonts/";
        private Dictionary<int, BmChar> bmChars = new Dictionary<int, BmChar>();

        private static void parseKeyValue(string arg, out string k, out string v)
        {
            int s = arg.IndexOf("=");
            if (s == -1)
            {
                //No '=' found
                k = arg;
                v = "";
            }
            else
            {
                k = arg.Substring(0, s);
                v = arg.Substring(s + 1);
            }
        }

        public BmFont(Texturing texturingManager, string name)
        {
            System.Console.WriteLine("Loading BmFont \"" + name + "\"");

            texId = texturingManager.LoadTexture(fontDir + name + ".png");
            string[] lines = System.IO.File.ReadAllLines(fontDir + name + ".fnt");

            for (int i = 0;i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                //Comments
                if (line.StartsWith("#")) { continue; }

                string[] args = line.Split(' ');

                if (args[0].Equals("common"))
                {
                    parseCommon(args);
                }
                else if (args[0].Equals("char"))
                {
                    parseCharacter(args);
                }
                else if (args[0].Equals("kerning"))
                {
                    parseKerning(args);
                }
            }
        }

        private void parseCommon(string[] args)
        {
            for (int j = 1; j < args.Length; j++)
            {
                string arg = args[j];

                string aKey, aValue;

                parseKeyValue(arg, out aKey, out aValue);

                switch (aKey)
                {
                    case "lineHeight":
                        lineHeight = Int32.Parse(aValue);
                        break;
                    case "base":
                        lineBase = Int32.Parse(aValue);
                        break;
                    case "scaleW":
                        scaleW = (float)Int32.Parse(aValue);
                        break;
                    case "scaleH":
                        scaleH = (float)Int32.Parse(aValue);
                        break;
                    case "tabLength":
                        tabLength = Int32.Parse(aValue);
                        break;
                    default:
                        break;
                }
            }
        }

        private void parseCharacter(string[] args)
        {
            int id = -1;
            BmChar c = new BmChar();
            for (int j = 1; j < args.Length; j++)
            {
                string arg = args[j];

                string aKey, aValue;

                parseKeyValue(arg, out aKey, out aValue);

                switch (aKey)
                {
                    case "id":
                        id = Int32.Parse(aValue);
                        break;
                    case "x":
                        c.x = Int32.Parse(aValue);
                        break;
                    case "y":
                        c.y = Int32.Parse(aValue);
                        break;
                    case "width":
                        c.width = Int32.Parse(aValue);
                        break;
                    case "height":
                        c.height = Int32.Parse(aValue);
                        break;
                    case "xoffset":
                        c.xoffset = Int32.Parse(aValue);
                        break;
                    case "yoffset":
                        c.yoffset = Int32.Parse(aValue);
                        break;
                    case "xadvance":
                        c.xadvance = Int32.Parse(aValue);
                        break;
                    default:
                        break;
                }
            }

            bmChars.Add(id, c);
        }

        private void parseKerning(string[] args)
        {
            int first = -1;
            int second = -1;
            int amount = 0;
            for (int j = 1; j < args.Length; j++)
            {
                string arg = args[j];

                string aKey, aValue;

                parseKeyValue(arg, out aKey, out aValue);

                switch (aKey)
                {
                    case "first":
                        first = Int32.Parse(aValue);
                        break;
                    case "second":
                        second = Int32.Parse(aValue);
                        break;
                    case "amount":
                        amount = Int32.Parse(aValue);
                        break;
                    default:
                        break;
                }
            }

            BmChar c;
            if (bmChars.TryGetValue(second, out c))
            {
                c.kerning.Add(first, amount);
            }

        }

        public int getTextureId()
        {
            return texId;
        }
        
        public List<Vector2> buildString(string s)
        {
            List<Vector2> v = new List<Vector2>();

            int posX=0, line=0;
            int lastC=-1;

            for(int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                
                if (c == '\n')
                {
                    posX = 0;
                    line++;
                    continue;
                }
                else if (c == '\t')
                {
                    int tabPosX = (int)(Math.Ceiling((double)posX / (double)tabLength) * tabLength);
                    posX = tabPosX > posX ? tabPosX : posX + tabLength;
                    continue;
                }

                BmChar bc;
                if (bmChars.TryGetValue((int)c, out bc))
                {
                    int kerning = 0;
                    if (lastC != -1)
                    {
                        if(!bc.kerning.TryGetValue(lastC, out kerning))
                        {
                            kerning = 0;
                        }
                    }

                    Vector2 v1 = new Vector2(
                        posX + bc.xoffset,
                        line * -lineHeight - lineBase + bc.yoffset
                        );
                    Vector2 v2 = new Vector2(
                        v1.X + bc.width,
                        v1.Y
                        );
                    Vector2 v3 = new Vector2(
                        v2.X,
                        v2.Y + bc.height
                        );
                    Vector2 v4 = new Vector2(
                        v1.X,
                        v3.Y
                        );

                    Vector2 t1 = new Vector2(
                        bc.x/scaleW,
                        bc.y/scaleH
                        );
                    Vector2 t2 = new Vector2(
                        t1.X + bc.width / scaleW,
                        t1.Y
                        );
                    Vector2 t3 = new Vector2(
                        t2.X,
                        t2.Y + bc.height / scaleH
                        );
                    Vector2 t4 = new Vector2(
                        t1.X,
                        t3.Y
                        );

                    v.Add(v1);
                    v.Add(t1);

                    v.Add(v2);
                    v.Add(t2);

                    v.Add(v3);
                    v.Add(t3);

                    v.Add(v4);
                    v.Add(t4);

                    /*v.Add(v1);
                    v.Add(t1);

                    v.Add(v2);
                    v.Add(t2);

                    v.Add(v3);
                    v.Add(t3);

                    v.Add(v4);
                    v.Add(t4);*/

                    posX += bc.xadvance;
                }
            }

            return v;
        }

    }
}
