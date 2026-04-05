using System;
using System.Collections.Generic;
using System.Linq;
using CANhandler.Enums;

namespace CANhandler.Helpers
{
    public static class CommandHelper
    {
        // PIC group
        public static readonly HashSet<string> DispensePICs = new HashSet<string>()
        {
            "PIC_DISP_3X3_GRAINS",
            "PIC_DISP_3X3_LIQUID",
            "PIC_DISP_3X3_PUREE",
            "PIC_DISP_6X6_GRAINS",
            "PIC_DISP_6X6_LIQUID"
        };

        // Commands for those PICs
        public static readonly List<Command> DispenseCommands = new List<Command>()
        {
            Command.Who_Are_You,
            Command.Dispense_Timer_Based,
            Command.Dispense_Weight_Based,
            Command.LED_TOGGLING_1,
            Command.LED_TOGGLING_2
        };

        // Main function
        public static List<Command> GetCommands(string picType)
        {
            if (DispensePICs.Contains(picType))
                return DispenseCommands;

            return new List<Command>() { Command.Who_Are_You };
        }

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

    }
}