using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Enums
{
    public enum Command : byte
    {
        Who_Are_You = 0,
        Dispense = 0,
        PB6_LED = 20,
        PB5_LED = 21,
        Erase_Log = 100,

        Read_Log_Count = 101,
        Read_Logs = 102,
    }
}