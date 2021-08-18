using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSALVL.Util;

namespace KSALVL.Hel
{
    public class Yaml
    {
        public XData XData { get; private set; }
        public byte[] Version { get; private set; }

        public Data Root { get; private set; }

        public Yaml(Data root, Endianness endianness)
        {
            XData = new XData(endianness, new byte[] { 4, 0 });
            Version = new byte[] { 2, 0, 0, 0 };
            Root = root;
        }

        public Yaml(string path)
        {
            using (EndianBinaryReader reader = new EndianBinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
            {
                Read(reader);
            }
        }

        public Yaml(byte[] buffer)
        {
            using (EndianBinaryReader reader = new EndianBinaryReader(new MemoryStream(buffer)))
            {
                Read(reader);
            }
        }

        public Yaml(EndianBinaryReader reader)
        {
            Read(reader);
        }

        void Read(EndianBinaryReader reader)
        {
            XData = new XData(reader);

            if (Encoding.UTF8.GetString(reader.ReadBytes(4)) != "YAML")
                throw new InvalidDataException("Invalid Yaml file");

            Version = reader.ReadBytes(4);
            Root = new Data(reader);
        }

        public byte[] Write()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (EndianBinaryWriter writer = new EndianBinaryWriter(stream))
                {
                    Write(writer);
                    return stream.GetBuffer().Take((int)writer.BaseStream.Length).ToArray();
                }
            }
        }

        public void Write(EndianBinaryWriter writer)
        {
            YamlWriter yamlWriter = new YamlWriter(writer);
            yamlWriter.Write(this);
        }

        public enum Type : int
        {
            Invalid,
            Int,
            Float,
            Bool,
            String,
            Hash,
            Array
        }

        public class Data
        {
            public Type Type { get; private set; }

            public byte[] data { get; private set; }
            private Dictionary<string, Data> children;

            public Data(Type type)
            {
                Type = type;
                switch (Type)
                {
                    case Type.Hash:
                    case Type.Array:
                        {
                            children = new Dictionary<string, Data>();
                            break;
                        }
                    default:
                        {
                            data = new byte[4];
                            break;
                        }
                }
            }

            public Data(Type type, object value)
            {
                Type = type;
                Set(value);
            }

            public Data(Data data)
            {
                Type = data.Type;
                switch (Type)
                {
                    case Type.Hash:
                        {
                            for (int i = 0; i < data.Length; i++)
                                children.Add(data.Key(i), data[data.Key(i)]);
                            break;
                        }
                    case Type.Array:
                        {
                            for (int i = 0; i < data.Length; i++)
                                children.Add(i.ToString(), data[i]);
                            break;
                        }
                    default:
                        {
                            this.data = new byte[data.data.Length];
                            data.data.CopyTo(this.data, 0);
                            break;
                        }
                }
            }

            public Data(EndianBinaryReader reader)
            {
                Type = (Type)reader.ReadInt32();
                switch (Type)
                {
                    default:
                    case Type.Invalid:
                        break;
                    case Type.Int:
                    case Type.Float:
                    case Type.Bool:
                        {
                            data = reader.ReadBytes(4);
                            break;
                        }
                    case Type.String:
                        {
                            uint offs = reader.ReadUInt32();
                            long pos = reader.BaseStream.Position;
                            reader.BaseStream.Seek(offs, SeekOrigin.Begin);
                            data = reader.ReadBytes(reader.ReadInt32());
                            reader.BaseStream.Seek(pos, SeekOrigin.Begin);
                            break;
                        }
                    case Type.Hash:
                        {
                            children = new Dictionary<string, Data>();
                            int count = reader.ReadInt32();
                            long pos = reader.BaseStream.Position;
                            for (int i = 0; i < count; i++)
                            {
                                reader.BaseStream.Seek(pos + i * 8, SeekOrigin.Begin);
                                string key = IOUtil.ReadString(reader);
                                reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);

                                children.Add(key, new Data(reader));
                            }
                            break;
                        }
                    case Type.Array:
                        {
                            children = new Dictionary<string, Data>();
                            int count = reader.ReadInt32();
                            long pos = reader.BaseStream.Position;
                            for (int i = 0; i < count; i++)
                            {
                                reader.BaseStream.Seek(pos + i * 4, SeekOrigin.Begin);
                                reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);

                                children.Add(i.ToString(), new Data(reader));
                            }
                            break;
                        }
                }
            }

            public void Set(object value)
            {
                children = null;
                switch (Type)
                {
                    case Type.Invalid:
                        {
                            data = new byte[] { };
                            break;
                        }
                    case Type.Int:
                        {
                            data = BitConverter.GetBytes((int)value);
                            break;
                        }
                    case Type.Float:
                        {
                            data = BitConverter.GetBytes((float)value);
                            break;
                        }
                    case Type.Bool:
                        {
                            data = BitConverter.GetBytes(Convert.ToInt32((bool)value));
                            break;
                        }
                    case Type.String:
                        {
                            data = Encoding.UTF8.GetBytes((string)value);
                            break;
                        }
                    case Type.Hash:
                        {
                            children = new Dictionary<string, Data>();
                            Dictionary<string, Data> newChildren = (Dictionary<string, Data>)value;
                            foreach (KeyValuePair<string, Data> pair in newChildren)
                                children.Add(pair.Key, pair.Value);
                            break;
                        }
                    case Type.Array:
                        {
                            children = new Dictionary<string, Data>();
                            Dictionary<string, Data> newChildren = (Dictionary<string, Data>)value;
                            for (int i = 0; i < newChildren.Count; i++)
                                children.Add(i.ToString(), newChildren.Values.ElementAt(i));
                            break;
                        }
                }
            }

            public int ToInt()
            {
                if (Type == Type.Int)
                    return BitConverter.ToInt32(data, 0);
                return 0;
            }

            public float ToFloat()
            {
                if (Type == Type.Float)
                    return BitConverter.ToSingle(data, 0);
                return 0;
            }

            public bool ToBool()
            {
                if (Type == Type.Bool)
                    return BitConverter.ToBoolean(data, 0);
                return false;
            }

            public override string ToString()
            {
                if (Type == Type.String)
                    return Encoding.UTF8.GetString(data);
                return string.Empty;
            }

            public object ToGeneric()
            {
                switch (Type)
                {
                    case Type.Int:    return ToInt();
                    case Type.Float:  return ToFloat();
                    case Type.Bool:   return ToBool();
                    case Type.String: return ToString();
                    default:          return 0;
                }
            }

            public int Length
            {
                get
                {
                    if (Type == Type.Hash || Type == Type.Array)
                        return children.Count;
                    return 0;
                }
            }

            public string Key(int index)
            {
                if (index >= 0 && Type == Type.Hash && index < Length)
                    return children.Keys.ElementAt(index);
                return string.Empty;
            }

            public bool HasKey(string key)
            {
                if (Type == Type.Hash && Length > 0)
                    return children.Keys.Contains(key);
                return false;
            }

            public void Add(string key, Data value)
            {
                if (Type != Type.Hash)
                    return;

                children.Add(key, value);
            }

            public void Add(Data value)
            {
                if (Type != Type.Array)
                    return;

                children.Add(Length.ToString(), value);
            }

            public Data this[int i]
            {
                get
                {
                    if (Type == Type.Array && i > -1 && i < Length)
                        return children[i.ToString()];
                    return null;
                }
                set
                {
                    if (Type == Type.Array && i > -1 && i < Length)
                        children[i.ToString()] = value;
                }
            }

            public Data this[string i]
            {
                get
                {
                    if (Type == Type.Hash && HasKey(i))
                        return children[i];
                    return null;
                }
                set
                {
                    if (Type == Type.Hash && HasKey(i))
                        children[i.ToString()] = value;
                }
            }
        }
    }

    public class YamlWriter
    {
        EndianBinaryWriter writer;
        Dictionary<long, string> stringList;

        public YamlWriter(EndianBinaryWriter writer)
        {
            stringList = new Dictionary<long, string>();
            this.writer = writer;
        }

        public void Write(Yaml yaml)
        {
            yaml.XData.Write(writer);

            writer.Write("YAML".ToCharArray());
            writer.Write(yaml.Version);

            WriteData(yaml.Root);

            foreach (KeyValuePair<long,string> pair in stringList)
            {
                writer.BaseStream.Seek(pair.Key, SeekOrigin.Begin);
                writer.Write((uint)writer.BaseStream.Length);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                IOUtil.WriteString(writer, pair.Value);
            }

            yaml.XData.UpdateFilesize(writer);
            yaml.XData.WriteFooter(writer);
        }

        void WriteData(Yaml.Data data)
        {
            writer.Write((int)data.Type);
            switch (data.Type)
            {
                case Yaml.Type.Int:
                    {
                        writer.Write(data.ToInt());
                        break;
                    }
                case Yaml.Type.Float:
                    {
                        writer.Write(data.ToFloat());
                        break;
                    }
                case Yaml.Type.Bool:
                    {
                        writer.Write(Convert.ToInt32(data.ToBool()));
                        break;
                    }
                case Yaml.Type.String:
                    {
                        stringList.Add(writer.BaseStream.Position, data.ToString());
                        writer.Write(-1);
                        break;
                    }
                case Yaml.Type.Hash:
                    {
                        writer.Write(data.Length);
                        long pos = writer.BaseStream.Position;
                        for (int i = 0; i < data.Length; i++)
                        {
                            writer.BaseStream.Seek(pos + i * 8, SeekOrigin.Begin);
                            stringList.Add(writer.BaseStream.Position, data.Key(i));
                            writer.Write(-1);
                            writer.Write(-1);
                        }
                        for (int i = 0; i < data.Length; i++)
                        {
                            writer.BaseStream.Seek(pos + i * 8 + 4, SeekOrigin.Begin);
                            writer.Write((uint)writer.BaseStream.Length);
                            writer.BaseStream.Seek(0, SeekOrigin.End);
                            WriteData(data[data.Key(i)]);
                        }
                        break;
                    }
                case Yaml.Type.Array:
                    {
                        writer.Write(data.Length);
                        long pos = writer.BaseStream.Position;
                        for (int i = 0; i < data.Length; i++)
                        {
                            writer.BaseStream.Seek(pos + i * 4, SeekOrigin.Begin);
                            writer.Write(-1);
                        }
                        for (int i = 0; i < data.Length; i++)
                        {
                            writer.BaseStream.Seek(pos + i * 4, SeekOrigin.Begin);
                            writer.Write((uint)writer.BaseStream.Length);
                            writer.BaseStream.Seek(writer.BaseStream.Length, SeekOrigin.Begin);
                            WriteData(data[data.Key(i)]);
                        }
                        break;
                    }
            }
        }
    }
}
