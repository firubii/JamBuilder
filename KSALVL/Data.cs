using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSALVL
{
    public struct Block
    {
        public short ID;
    }

    public struct Collision
    {
        public byte Modifier;
        public byte Unk_1;
        public byte Shape;
        public byte Unk_2;
    }

    public struct Decoration
    {
        public byte Unk_1;
        public byte Unk_2;
        public byte Unk_3;
        public byte Unk_4;
    }

    public struct Stage
    {
        public uint Unk_1;
        public uint Unk_2;
        public string Unk_String;
        public float Unk_3;
        public float Unk_4;
        public float Unk_5;
        public float Unk_6;
        public float Unk_7;
        public float Unk_8;
        public float Unk_9;
        public float Unk_10;
        public float Unk_11;
    }
}
