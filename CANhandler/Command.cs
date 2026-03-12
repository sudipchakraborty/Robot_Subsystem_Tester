using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler
{
    public enum Command : byte
    {
        WHO_ARE_YOU = 0x00,
        LED_TOGGLING_1 = 0x14,
        LED_TOGGLING_2 = 0x15
    }
}