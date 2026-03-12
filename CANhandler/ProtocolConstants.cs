using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler
{
    public static class ProtocolConstants
    {
        public const ushort Preamble = 0x6655;
        public const byte TransType = 0x00;
        public const ushort Postamble = 0x7788;
    }
}