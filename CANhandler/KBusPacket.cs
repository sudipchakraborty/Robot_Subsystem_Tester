using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler
{
    public class KBusPacket
    {
        public ushort Preamble { get; set; }
        public byte Length { get; set; }
        public byte TransType { get; set; }
        public byte Multicast { get; set; }
        public ushort Address { get; set; }
        public byte RWFlag { get; set; }
        public Command CmdParameter { get; set; }
        public byte[] Data { get; set; }
        public ushort CRC { get; set; }
        public ushort Postamble { get; set; }
    }
}
