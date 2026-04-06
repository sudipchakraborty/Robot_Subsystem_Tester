using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Constants
{
    public static class ProtocolConstants
    {
        public const ushort Preamble = 0x6655;
        public const byte TransType = 0x00;
        public const ushort Postamble = 0x7788;

        //public const byte Unicast=0;
        //public const byte Multicast = 1;

        
    }

    //public enum CastType : byte
    //{
    //    Unicast = 0,
    //    Multicast = 1
    //}

    public enum Operation : byte
    {
        Read = 0,
        Write = 1,
        Execute = 2

    }


}