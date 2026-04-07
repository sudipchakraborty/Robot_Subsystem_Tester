using CANhandler.Constants;
using CANhandler.Enums;
using CANhandler.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static CANhandler.Constants.ProtocolConstants;

namespace CANhandler.Protocol
    {
        public static class KBusBuilder
        {


        public static byte[] BuildPacket_From_GridRow(ProgramStep step)
        {
            if (step == null) return null;

            List<byte> packet = new List<byte>();

            // Preamble
            packet.AddRange(Helpers.CommandHelper.GetBytesBE(Preamble));

            // Length placeholder
            packet.Add(0);

            // Header
            packet.Add(TransType);
            packet.Add((byte)step.Cast);

            ushort address = (ushort)step.PicType;
            packet.AddRange(Helpers.CommandHelper.GetBytesBE(address));

            packet.Add((byte)step.Operation);
            packet.Add((byte)step.Command);

            // 🔥 IMPORTANT: ensure BIG-ENDIAN data
            var dataBytes = Helpers.CommandHelper.ParseUInt16Array(step.Data);
            packet.AddRange(dataBytes);

            packet[2] = (byte)(packet.Count+4);

            // ✅ CRC (correct range)
            byte[] crcData = packet.ToArray();

            ushort crc = CRC16_XMODEM(crcData, crcData.Length);

            // MSB first
            packet.Add((byte)(crc >> 8));
            packet.Add((byte)(crc & 0xFF));

            // Postamble
            packet.Add((byte)(ProtocolConstants.Postamble >> 8));
            packet.Add((byte)(ProtocolConstants.Postamble & 0xFF));

            // ✅ Final length
           

            return packet.ToArray();
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
