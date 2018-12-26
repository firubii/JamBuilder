using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KSALVL;

namespace KSALVL
{
    public class Level
    {
        public uint Height;
        public uint Width;
        public string Background;
        public string Tileset;
        public string Unk_String;
        public byte[] Unk_Bytes;
        public List<Block> TileBlock = new List<Block>();
        public List<Collision> TileCollision = new List<Collision>();
        public List<Decoration> BLandDecoration = new List<Decoration>();
        public List<Decoration> MLandDecoration = new List<Decoration>();
        public List<Decoration> FLandDecoration = new List<Decoration>();
        public List<Decoration> Unk_Decoration = new List<Decoration>();
        public List<Dictionary<string, string>> Objects = new List<Dictionary<string, string>>();
        public List<Dictionary<string, string>> GuestStarItems = new List<Dictionary<string, string>>();
        public List<Dictionary<string, string>> Items = new List<Dictionary<string, string>>();
        public List<Dictionary<string, string>> Bosses = new List<Dictionary<string, string>>();
        public List<Dictionary<string, string>> Enemies = new List<Dictionary<string, string>>();

        public Level(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
            {
                Read(reader);
            }
        }

        public void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(0x18, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            Height = reader.ReadUInt32();
            Width = reader.ReadUInt32();
            for (int i = 0; i < Width*Height; i++)
            {
                Block block = new Block();
                block.ID = reader.ReadInt16();
                TileBlock.Add(block);
            }

            reader.BaseStream.Seek(0x20, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            reader.BaseStream.Seek(0x8, SeekOrigin.Current);
            for (int i = 0; i < Width * Height; i++)
            {
                Collision collision = new Collision();
                collision.Modifier = reader.ReadByte();
                collision.Unk_1 = reader.ReadByte();
                collision.Shape = reader.ReadByte();
                collision.Unk_2 = reader.ReadByte();
                TileCollision.Add(collision);
            }

            reader.BaseStream.Seek(0x28, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            long decoAddress = reader.BaseStream.Position;

            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            Background = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));

            reader.BaseStream.Seek(decoAddress + 0x4, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            Tileset = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));

            reader.BaseStream.Seek(decoAddress + 0x8, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32() + 0x8, SeekOrigin.Begin);
            for (int i = 0; i < Width * Height; i++)
            {
                Decoration decoration = new Decoration();
                decoration.Unk_1 = reader.ReadByte();
                decoration.Unk_2 = reader.ReadByte();
                decoration.Unk_3 = reader.ReadByte();
                decoration.Unk_4 = reader.ReadByte();
                BLandDecoration.Add(decoration);
            }

            reader.BaseStream.Seek(decoAddress + 0xC, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32() + 0x8, SeekOrigin.Begin);
            for (int i = 0; i < Width * Height; i++)
            {
                Decoration decoration = new Decoration();
                decoration.Unk_1 = reader.ReadByte();
                decoration.Unk_2 = reader.ReadByte();
                decoration.Unk_3 = reader.ReadByte();
                decoration.Unk_4 = reader.ReadByte();
                MLandDecoration.Add(decoration);
            }

            reader.BaseStream.Seek(decoAddress + 0x10, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32() + 0x8, SeekOrigin.Begin);
            for (int i = 0; i < Width * Height; i++)
            {
                Decoration decoration = new Decoration();
                decoration.Unk_1 = reader.ReadByte();
                decoration.Unk_2 = reader.ReadByte();
                decoration.Unk_3 = reader.ReadByte();
                decoration.Unk_4 = reader.ReadByte();
                FLandDecoration.Add(decoration);
            }

            reader.BaseStream.Seek(decoAddress + 0x14, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32() + 0x8, SeekOrigin.Begin);
            for (int i = 0; i < Width * Height; i++)
            {
                Decoration decoration = new Decoration();
                decoration.Unk_1 = reader.ReadByte();
                decoration.Unk_2 = reader.ReadByte();
                decoration.Unk_3 = reader.ReadByte();
                decoration.Unk_4 = reader.ReadByte();
                Unk_Decoration.Add(decoration);
            }

            reader.BaseStream.Seek(0x2C, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32() + 0x8, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            Unk_String = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));
            reader.BaseStream.Seek(0x2C, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32() + 0xC, SeekOrigin.Begin);
            Unk_Bytes = reader.ReadBytes(0x38);

            reader.BaseStream.Seek(0x30, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            uint count = reader.ReadUInt32();
            List<uint> offsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                offsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(offsets[i] + 0x8, SeekOrigin.Begin);
                int length = reader.ReadInt32() + 0xC;
                reader.BaseStream.Seek(offsets[i], SeekOrigin.Begin);
                Objects.Add(ReadYAML(reader.ReadBytes(length)));
            }
            offsets.Clear();

            reader.BaseStream.Seek(0x34, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            count = reader.ReadUInt32();
            offsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                offsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(offsets[i] + 0x8, SeekOrigin.Begin);
                int length = reader.ReadInt32() + 0xC;
                reader.BaseStream.Seek(offsets[i], SeekOrigin.Begin);
                GuestStarItems.Add(ReadYAML(reader.ReadBytes(length)));
            }
            offsets.Clear();

            reader.BaseStream.Seek(0x38, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            count = reader.ReadUInt32();
            offsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                offsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(offsets[i] + 0x8, SeekOrigin.Begin);
                int length = reader.ReadInt32() + 0xC;
                reader.BaseStream.Seek(offsets[i], SeekOrigin.Begin);
                Items.Add(ReadYAML(reader.ReadBytes(length)));
            }
            offsets.Clear();

            reader.BaseStream.Seek(0x3C, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            count = reader.ReadUInt32();
            offsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                offsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(offsets[i] + 0x8, SeekOrigin.Begin);
                int length = reader.ReadInt32() + 0xC;
                reader.BaseStream.Seek(offsets[i], SeekOrigin.Begin);
                Bosses.Add(ReadYAML(reader.ReadBytes(length)));
            }
            offsets.Clear();

            reader.BaseStream.Seek(0x40, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            count = reader.ReadUInt32();
            offsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                offsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(offsets[i] + 0x8, SeekOrigin.Begin);
                int length = reader.ReadInt32() + 0xC;
                reader.BaseStream.Seek(offsets[i], SeekOrigin.Begin);
                Enemies.Add(ReadYAML(reader.ReadBytes(length)));
            }
        }

        public void Write(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write));
            writer.Write(Encoding.UTF8.GetBytes("XBIN"));
            writer.Write(new byte[] {   0x34, 0x12, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE9, 0xFD, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x78, 0x56, 0x34, 0x12, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            });
            writer.Write(Height);
            writer.Write(Width);
            for (int i = 0; i < TileBlock.Count; i++)
            {
                writer.Write(TileBlock[i].ID);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }

            uint pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x1C, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(0);
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x20, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);

            pos = (uint)writer.BaseStream.Position;
            writer.Write(pos + 0x4);
            writer.Write(Height);
            writer.Write(Width);
            for (int i = 0; i < TileCollision.Count; i++)
            {
                writer.Write(TileCollision[i].Modifier);
                writer.Write(TileCollision[i].Unk_1);
                writer.Write(TileCollision[i].Shape);
                writer.Write(TileCollision[i].Unk_2);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x24, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(0);
            pos = (uint)writer.BaseStream.Position;
            for (int i = 0; i < 16; i++)
            {
                writer.Write(pos + 64);
            }
            writer.Write(0);
            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x28, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            uint bgOffset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            uint tilesetOffset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            uint deco1Offset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            uint deco2Offset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            uint deco3Offset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            uint deco4Offset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(deco1Offset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Height);
            writer.Write(Width);
            for (int i = 0; i < BLandDecoration.Count; i++)
            {
                writer.Write(BLandDecoration[i].Unk_1);
                writer.Write(BLandDecoration[i].Unk_2);
                writer.Write(BLandDecoration[i].Unk_3);
                writer.Write(BLandDecoration[i].Unk_4);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(deco2Offset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Height);
            writer.Write(Width);
            for (int i = 0; i < MLandDecoration.Count; i++)
            {
                writer.Write(MLandDecoration[i].Unk_1);
                writer.Write(MLandDecoration[i].Unk_2);
                writer.Write(MLandDecoration[i].Unk_3);
                writer.Write(MLandDecoration[i].Unk_4);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(deco3Offset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Height);
            writer.Write(Width);
            for (int i = 0; i < FLandDecoration.Count; i++)
            {
                writer.Write(FLandDecoration[i].Unk_1);
                writer.Write(FLandDecoration[i].Unk_2);
                writer.Write(FLandDecoration[i].Unk_3);
                writer.Write(FLandDecoration[i].Unk_4);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(deco4Offset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Height);
            writer.Write(Width);
            for (int i = 0; i < Unk_Decoration.Count; i++)
            {
                writer.Write(Unk_Decoration[i].Unk_1);
                writer.Write(Unk_Decoration[i].Unk_2);
                writer.Write(Unk_Decoration[i].Unk_3);
                writer.Write(Unk_Decoration[i].Unk_4);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x2C, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(0);
            writer.Write(1);
            uint unkStringOffset = (uint)writer.BaseStream.Position;
            writer.Write(Unk_Bytes);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x30, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            List<uint> yamlOffsets = new List<uint>();
            writer.Write(Objects.Count);
            for (int i = 0; i < Objects.Count; i++)
            {
                yamlOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            for (int i = 0; i < Objects.Count; i++)
            {
                pos = (uint)writer.BaseStream.Position;
                writer.BaseStream.Seek(yamlOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.Write(WriteYAML(Objects[i]));
            }
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x34, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            yamlOffsets = new List<uint>();
            writer.Write(GuestStarItems.Count);
            for (int i = 0; i < GuestStarItems.Count; i++)
            {
                yamlOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            for (int i = 0; i < GuestStarItems.Count; i++)
            {
                pos = (uint)writer.BaseStream.Position;
                writer.BaseStream.Seek(yamlOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.Write(WriteYAML(GuestStarItems[i]));
            }
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x38, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            yamlOffsets = new List<uint>();
            writer.Write(Items.Count);
            for (int i = 0; i < Items.Count; i++)
            {
                yamlOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            for (int i = 0; i < Items.Count; i++)
            {
                pos = (uint)writer.BaseStream.Position;
                writer.BaseStream.Seek(yamlOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.Write(WriteYAML(Items[i]));
            }
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x3C, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            yamlOffsets = new List<uint>();
            writer.Write(Bosses.Count);
            for (int i = 0; i < Bosses.Count; i++)
            {
                yamlOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            for (int i = 0; i < Bosses.Count; i++)
            {
                pos = (uint)writer.BaseStream.Position;
                writer.BaseStream.Seek(yamlOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.Write(WriteYAML(Bosses[i]));
            }
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x40, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            yamlOffsets = new List<uint>();
            writer.Write(Enemies.Count);
            for (int i = 0; i < Enemies.Count; i++)
            {
                yamlOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            for (int i = 0; i < Enemies.Count; i++)
            {
                pos = (uint)writer.BaseStream.Position;
                writer.BaseStream.Seek(yamlOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.Write(WriteYAML(Enemies[i]));
            }
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(bgOffset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Background.Length);
            writer.Write(Encoding.UTF8.GetBytes(Background));
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(tilesetOffset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Tileset.Length);
            writer.Write(Encoding.UTF8.GetBytes(Tileset));
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(unkStringOffset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Unk_String.Length);
            writer.Write(Encoding.UTF8.GetBytes(Unk_String));
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x8, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0x10, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Encoding.UTF8.GetBytes("RLOC"));
            writer.Write(0);
            writer.Write(0);

            writer.Flush();
            writer.Dispose();
            writer.Close();
        }

        private Dictionary<string, string> ReadYAML(byte[] yamlFile)
        {
            Dictionary<string, string> yaml = new Dictionary<string, string>();
            BinaryReader reader = new BinaryReader(new MemoryStream(yamlFile));
            reader.BaseStream.Seek(0x20, SeekOrigin.Begin);
            uint count = reader.ReadUInt32();
            List<uint> nameOffsets = new List<uint>();
            List<uint> valOffsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                nameOffsets.Add(reader.ReadUInt32());
                valOffsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(nameOffsets[i], SeekOrigin.Begin);
                string name = string.Join("", reader.ReadChars(reader.ReadInt32()));
                reader.BaseStream.Seek(valOffsets[i], SeekOrigin.Begin);
                uint valtype = reader.ReadUInt32();
                switch (valtype)
                {
                    case 1:
                        {
                            yaml.Add(valtype + name, reader.ReadUInt32().ToString());
                            break;
                        }
                    case 2:
                        {
                            yaml.Add(valtype + name, reader.ReadSingle().ToString());
                            break;
                        }
                    case 3:
                        {
                            yaml.Add(valtype + name, reader.ReadUInt32().ToString());
                            break;
                        }
                    case 4:
                        {
                            uint stringoffset = reader.ReadUInt32();
                            reader.BaseStream.Seek(stringoffset, SeekOrigin.Begin);
                            string stringval = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));
                            yaml.Add(valtype + name, stringval);
                            break;
                        }
                }
            }
            return yaml;
        }

        private byte[] WriteYAML(Dictionary<string, string> yaml)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            List<uint> stringOffsets = new List<uint>();
            List<string> strings = new List<string>();
            List<uint> valuePointers = new List<uint>();
            List<uint> valueOffsets = new List<uint>();

            uint pos = 0;

            writer.Write(new byte[] {
                0x58, 0x42, 0x49, 0x4E, 0x34, 0x12, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE9, 0xFD, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x59, 0x41, 0x4D, 0x4C, 0x02, 0x00, 0x00, 0x00
            });
            writer.Write(5);
            writer.Write((uint)yaml.Count);

            foreach (KeyValuePair<string, string> pair in yaml)
            {
                strings.Add(string.Join("", pair.Key.Skip(1)));
                stringOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
                valuePointers.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            foreach (KeyValuePair<string, string> pair in yaml)
            {
                uint valType = uint.Parse($"{pair.Key.ToCharArray()[0]}");
                valueOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(valType);
                switch (valType)
                {
                    case 1:
                        {
                            writer.Write(uint.Parse(pair.Value));
                            break;
                        }
                    case 2:
                        {
                            writer.Write(float.Parse(pair.Value));
                            break;
                        }
                    case 3:
                        {
                            writer.Write(uint.Parse(pair.Value));
                            break;
                        }
                    case 4:
                        {
                            strings.Add(pair.Value);
                            stringOffsets.Add((uint)writer.BaseStream.Position);
                            writer.Write(0);
                            break;
                        }
                }
            }

            for (int i = 0; i < strings.Count; i++)
            {
                writer.BaseStream.Seek(0, SeekOrigin.End);
                pos = (uint)writer.BaseStream.Position;
                writer.Write(strings[i].Length);
                writer.Write(Encoding.UTF8.GetBytes(strings[i]));
                writer.Write(0);
                while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
                {
                    writer.Write((byte)0);
                }
                writer.BaseStream.Seek(stringOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
            }

            for (int i = 0; i < valueOffsets.Count; i++)
            {
                writer.BaseStream.Seek(valuePointers[i], SeekOrigin.Begin);
                writer.Write(valueOffsets[i]);
            }

            writer.BaseStream.Seek(0, SeekOrigin.End);
            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x8, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0x10, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Encoding.UTF8.GetBytes("RLOC"));
            writer.Write(0);
            writer.Write(0);
            pos = (uint)writer.BaseStream.Position;

            return stream.GetBuffer().Take((int)pos).ToArray();
        }
    }
}
