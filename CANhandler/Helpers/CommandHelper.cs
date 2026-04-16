using CANhandler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CANhandler.Helpers
{
    public static class CommandHelper
    {
        // PIC group
        //public static readonly HashSet<string> DispensePICs = new HashSet<string>()
        //{
        //    "PIC_DISP_3X3_GRAINS",
        //    "PIC_DISP_3X3_LIQUID",
        //    "PIC_DISP_3X3_PUREE",
        //    "PIC_DISP_6X6_GRAINS",
        //    "PIC_DISP_6X6_LIQUID"
        //};

        // Commands for those PICs
        //public static readonly List<PIC_Addr> DispenseCommands = new List<PIC_Addr>()
        //{
        //    PIC_Addr.Who_Are_You,
        //    PIC_Addr.Dispense_Timer_Based,
        //    PIC_Addr.Dispense_Weight_Based,
        //    PIC_Addr.LED_TOGGLING_1,
        //    PIC_Addr.LED_TOGGLING_2
        //};

        // Main function
        //public static List<PIC_Addr> GetCommands(string picType)
        //{
        //    if (DispensePICs.Contains(picType))
        //        return DispenseCommands;

        //    return new List<PIC_Addr>() { PIC_Addr.Who_Are_You };
        //}

        public static byte[] ParseData(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Array.Empty<byte>();

            return input
                .Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x =>
                {
                    // Support hex (0x..) and decimal
                    if (x.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                        return Convert.ToByte(x, 16);

                    return Convert.ToByte(x);
                })
                .ToArray();
        }

        // Big Endian (MSB first)
        public static byte[] GetBytesBE(ushort value)
        {
            return new byte[]
            {
            (byte)(value >> 8),       // MSB
            (byte)(value & 0xFF)      // LSB
            };
        }

        // Little Endian (LSB first)
        public static byte[] GetBytesLE(ushort value)
        {
            return new byte[]
            {
            (byte)(value & 0xFF),     // LSB
            (byte)(value >> 8)        // MSB
            };
        }

        public static byte[] ParseUInt16Array(string input, bool bigEndian = true)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Array.Empty<byte>();

            List<byte> result = new List<byte>();

            // Split by comma OR space
            var tokens = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (!ushort.TryParse(token.Trim(), out ushort value))
                    throw new Exception($"Invalid data value: {token}");

                if (bigEndian)
                {
                    result.Add((byte)(value >> 8));     // MSB
                    result.Add((byte)(value & 0xFF));   // LSB
                }
                else
                {
                    result.Add((byte)(value & 0xFF));   // LSB
                    result.Add((byte)(value >> 8));     // MSB
                }
            }

            return result.ToArray();
        }



        public static int AddUInt16Data(
        List<byte> packet,
        string input,
        bool bigEndian = true)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            int byteCount = 0;

            var tokens = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (!ushort.TryParse(token.Trim(), out ushort value))
                    throw new Exception($"Invalid data value: {token}");

                if (bigEndian)
                {
                    packet.Add((byte)(value >> 8));     // MSB
                    packet.Add((byte)(value & 0xFF));   // LSB
                }
                else
                {
                    packet.Add((byte)(value & 0xFF));   // LSB
                    packet.Add((byte)(value >> 8));     // MSB
                }

                byteCount += 2; // each ushort = 2 bytes
            }

            return byteCount;
        }



        public static string ToHexString(byte[] data, bool withSpace = true)
        {
            if (data == null || data.Length == 0)
                return string.Empty;

            return withSpace
                ? BitConverter.ToString(data).Replace("-", " ")
                : BitConverter.ToString(data).Replace("-", "");
        }


        public static string ToDetailedString(byte[] packet)
        {
            if (packet == null || packet.Length < 10)
                return "Invalid Packet";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"RAW: {PacketFormatter.ToHexString(packet)}");
            sb.AppendLine("------ Parsed ------");

            sb.AppendLine($"Preamble : {packet[0]:X2} {packet[1]:X2}");
            sb.AppendLine($"Length   : {packet[2]}");
            sb.AppendLine($"Type     : {packet[3]}");
            sb.AppendLine($"Cast     : {packet[4]}");

            ushort address = (ushort)((packet[5] << 8) | packet[6]);
            sb.AppendLine($"Address  : {address}");

            sb.AppendLine($"Operation: {packet[7]}");
            sb.AppendLine($"Command  : {packet[8]}");

            sb.AppendLine($"Data     : {PacketFormatter.ToHexString(packet.Skip(9).Take(packet.Length - 13).ToArray())}");

            sb.AppendLine($"CRC      : {packet[packet.Length - 4]:X2} {packet[packet.Length - 3]:X2}");
            sb.AppendLine($"Postamble: {packet[packet.Length - 2]:X2} {packet[packet.Length - 1]:X2}");

            return sb.ToString();
        }

        public static class PacketFormatter
        {
            public static string ToHexString(byte[] data, bool withSpace = true)
            {
                if (data == null || data.Length == 0)
                    return string.Empty;

                return withSpace
                    ? BitConverter.ToString(data).Replace("-", " ")
                    : BitConverter.ToString(data).Replace("-", "");
            }
        }


        public static string GetProjectRoot()
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            // Move up until we exit "bin"
            while (dir != null && dir.Name.ToLower() != "bin")
            {
                dir = dir.Parent;
            }

            // Go one level above "bin"
            return dir?.Parent?.FullName ?? AppDomain.CurrentDomain.BaseDirectory;
        }


    }
}