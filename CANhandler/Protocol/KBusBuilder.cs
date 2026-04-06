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

            packet.AddRange(Helpers.CommandHelper.GetBytesBE(Preamble));
            packet.Add(0);
            packet.Add(TransType);
            packet.Add((byte)step.Cast);       
            PIC_Address pic = step.PicType;
            ushort address = (ushort)pic;
            packet.AddRange(Helpers.CommandHelper.GetBytesBE(address));
            packet.Add((byte)step.Operation);
            packet.Add((byte)step.Command);

            packet.AddRange(Helpers.CommandHelper.ParseUInt16Array(step.Data));
            packet[2]=(byte)packet.Count;

            byte[] packetArray = packet.ToArray();
            ushort crc = CRC16_XMODEM(packetArray, packetArray.Length);

            packet.Add((byte)(crc & 0xFF));
            packet.Add((byte)((crc >> 8) & 0xFF));

            packet.Add((byte)((ProtocolConstants.Postamble >> 8) & 0xFF));
            packet.Add((byte)(ProtocolConstants.Postamble & 0xFF));

            byte[] buffer = packet.ToArray();
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
