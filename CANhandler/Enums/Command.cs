using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Enums
{
    public enum Command : byte
    {
        Who_Are_You = 0,
        Dispense_Timer_Based = 1,
        Dispense_Weight_Based = 2,
        LED_TOGGLING_1 = 20,
        LED_TOGGLING_2 = 21,
        Erase_Log = 100,
        Read_Log_Count = 101,
        Read_Logs = 102,
    }

    public class command
    {
        List<string> dispenseCommands = new List<string>()
        {
            "WHO_ARE_YOU",
            "Dispense_Timer_Based",
            "Dispense_Weight_Based",
            "LED_TOGGLING_1",
            "LED_TOGGLING_2"
        };

        HashSet<string> dispensePICs = new HashSet<string>()
        {
            "PIC_DISP_3X3_GRAINS",
            "PIC_DISP_3X3_LIQUID",
            "PIC_DISP_3X3_PUREE",
            "PIC_DISP_6X6_GRAINS",
            "PIC_DISP_6X6_LIQUID"
        };
    }
}