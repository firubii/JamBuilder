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
}
