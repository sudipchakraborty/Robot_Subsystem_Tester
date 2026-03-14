using CANhandler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler
{
    namespace CANhandler
    {
        public static class KBusParser
        {
            public static KBusPacket Parse(byte[] buffer)
            {
                if (buffer == null || buffer.Length < 13)
                    return null;

                int index = 0;

                KBusPacket packet = new KBusPacket();

                packet.Preamble = BitConverter.ToUInt16(buffer, index);
                index += 2;

                packet.Length = buffer[index++];

                if (buffer.Length != packet.Length)
                    return null;

                packet.TransType = buffer[index++];
                packet.Multicast = buffer[index++];
                packet.Address = BitConverter.ToUInt16(buffer, index);
                index += 2;

                packet.RWFlag = buffer[index++];
                packet.CmdParameter = buffer[index++];

                int dataLength = packet.Length - 13;

                if (dataLength < 0)
                    return null;

                packet.Data = new byte[dataLength];
                Array.Copy(buffer, index, packet.Data, 0, dataLength);
                index += dataLength;

                packet.CRC = BitConverter.ToUInt16(buffer, index);
                index += 2;

                packet.Postamble = BitConverter.ToUInt16(buffer, index);

                return packet;
            }
        }
    }
}
