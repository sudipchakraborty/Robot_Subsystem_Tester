using System;
using System.Collections.Generic;
using System.Text;
using static CANhandler.ProtocolConstants;

namespace CANhandler
{
    namespace CANhandler
    {
        public static class KBusBuilder
        {
            public static byte[] BuildPacket(KBusPacket packet)
            {
                if (packet == null)
                    return null;

                packet.Preamble = Preamble;
                packet.TransType = TransType;
                packet.Postamble = Postamble;


                int dataLength = packet.Data != null ? packet.Data.Length : 0;

                packet.Length = (byte)(13 + dataLength);

                byte[] buffer = new byte[packet.Length];

                int index = 0;

                //// Preamble (Little Endian)
                //buffer[index++] = (byte)(packet.Preamble & 0xFF);
                //buffer[index++] = (byte)((packet.Preamble >> 8) & 0xFF);

                // Preamble (Big Endian)
                buffer[index++] = (byte)((packet.Preamble >> 8) & 0xFF);
                buffer[index++] = (byte)(packet.Preamble & 0xFF);

                // Length
                buffer[index++] = packet.Length;

                // TransType
                buffer[index++] = packet.TransType;

                // Multicast
                buffer[index++] = packet.Multicast;

                // Address (Little Endian)
                buffer[index++] = (byte)((packet.Address >> 8) & 0xFF);
                buffer[index++] = (byte)(packet.Address & 0xFF);           

                // RW
                buffer[index++] = packet.RWFlag;

                // CmdParameter
                buffer[index++] =(byte) packet.CmdParameter;

                // Data
                if (dataLength > 0)
                {
                    Array.Copy(packet.Data, 0, buffer, index, dataLength);
                    index += dataLength;
                }

                //// CRC (placeholder for now = 0)
                //ushort crc = 0; // You can replace with real CRC16
                //buffer[index++] = (byte)(crc & 0xFF);
                //buffer[index++] = (byte)((crc >> 8) & 0xFF);

                // Calculate CRC
                ushort crc = CRC16_XMODEM(buffer, index);

                // CRC Low Byte
                buffer[index++] = (byte)(crc & 0xFF);

                // CRC High Byte
                buffer[index++] = (byte)((crc >> 8) & 0xFF);

                // Postamble (Little Endian)
                buffer[index++] = (byte)((packet.Postamble >> 8) & 0xFF);
                buffer[index++] = (byte)(packet.Postamble & 0xFF);
                
                return buffer;
            }

            public static ushort CRC16_XMODEM(byte[] data, int length)
            {
                ushort crc = 0x0000;

                for (int i = 0; i < length; i++)
                {
                    crc ^= (ushort)(data[i] << 8);

                    for (int j = 0; j < 8; j++)
                    {
                        if ((crc & 0x8000) != 0)
                            crc = (ushort)((crc << 1) ^ 0x1021);
                        else
                            crc <<= 1;
                    }
                }

                return crc;
            }
        }
    }
}
