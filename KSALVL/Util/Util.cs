using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSALVL.Util
{
    public enum Endianness
    {
        Big,
        Little
    }

    public static class IOUtil
    {
        public static string ReadString(EndianBinaryReader reader)
        {
            uint offset = reader.ReadUInt32();
            long pos = reader.BaseStream.Position;

            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            string str = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));
            reader.BaseStream.Seek(pos, SeekOrigin.Begin);

            return str;
        }

        public static void WriteString(EndianBinaryWriter writer, string str)
        {
            writer.Write(str.Length);
            writer.Write(Encoding.UTF8.GetBytes(str));
            writer.Write(0);
            while ((writer.BaseStream.Length & 0xF) != 0x0
                && (writer.BaseStream.Length & 0xF) != 0x4
                && (writer.BaseStream.Length & 0xF) != 0x8
                && (writer.BaseStream.Length & 0xF) != 0xC)
                writer.Write((byte)0);
        }
    }
}
