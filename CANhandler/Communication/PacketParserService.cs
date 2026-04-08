using System;
using System.Text;

namespace CANhandler.Services
{
    public class PacketParserService
    {
        public string Parse(byte[] buf)
        {
            if (buf == null || buf.Length == 0)
                return "Empty packet";

            try
            {
                return ParseInternal(buf);
            }
            catch (Exception ex)
            {
                return $"Parser Error: {ex.Message}";
            }
        }

        private string ParseInternal(byte[] buf)
        {
            StringBuilder sb = new StringBuilder();

            if (buf.Length < 13)
                return "❌ Packet too small";

            // 🔹 Preamble
            if (buf[0] != 0x66 || buf[1] != 0x55)
                return "❌ Invalid Preamble";

            byte length = buf[2];

            if (buf.Length != length)
                return $"❌ Length mismatch RX={buf.Length} LEN={length}";

            byte transtype = buf[3];
            byte packetType = buf[4];
            ushort address = (ushort)((buf[5] << 8) | buf[6]);
            byte rw = buf[7];
            byte command = buf[8];

            int dataLen = length - (2 + 1 + 6 + 2 + 2);

            byte[] data = new byte[dataLen];
            if (dataLen > 0)
                Array.Copy(buf, 9, data, 0, dataLen);

            int crcIndex = 9 + dataLen;
            ushort crc = (ushort)((buf[crcIndex] << 8) | buf[crcIndex + 1]);

            byte post1 = buf[crcIndex + 2];
            byte post2 = buf[crcIndex + 3];

            if (post1 != 0x77 || post2 != 0x88)
                return "❌ Invalid Postamble";

            ushort calcCRC = CalculateCRC(buf, crcIndex);

            if (calcCRC != crc)
                return $"❌ CRC Mismatch RX={crc:X4} CALC={calcCRC:X4}";

            // ✅ BUILD OUTPUT STRING (like ESP print)
            sb.AppendLine("========== PACKET ==========");
            sb.AppendLine($"Preamble     : {buf[0]:X2} {buf[1]:X2}");
            sb.AppendLine($"Length       : {length:X2}");
            sb.AppendLine($"TransType    : {transtype:X2}");
            sb.AppendLine($"PacketType   : {packetType:X2}");
            sb.AppendLine($"Address      : {address:X4}");
            sb.AppendLine($"RW           : {rw:X2}");
            sb.AppendLine($"Command      : {command:X2}");
            sb.AppendLine($"DataLen      : {dataLen}");

            string dataStr = "";
            for (int i = 0; i < dataLen; i++)
                dataStr += data[i].ToString("X2") + " ";

            sb.AppendLine($"Data         : {dataStr}");
            sb.AppendLine($"CRC          : {crc:X4}");
            sb.AppendLine($"Postamble    : {post1:X2} {post2:X2}");
            sb.AppendLine("============================");

            return sb.ToString();
        }

        private ushort CalculateCRC(byte[] data, int len)
        {
            ushort crc = 0x0000;

            for (int i = 0; i < len; i++)
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