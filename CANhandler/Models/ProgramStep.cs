using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Models
{
    public class ProgramStep
    {
        public int LineNo { get; set; }
        public bool Enable { get; set; }

        public string PicType { get; set; }
        public string Action { get; set; }
        public string Command { get; set; }

        public byte MSB { get; set; }
        public byte LSB { get; set; }

        public int Delay { get; set; }
        public int Loop { get; set; }
    }
}