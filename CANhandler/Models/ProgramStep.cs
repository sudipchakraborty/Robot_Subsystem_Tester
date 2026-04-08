using CANhandler.Constants;
using CANhandler.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Models
{
    public class ProgramStep
    {
        public int LineNo { get; set; }
        public bool Enable { get; set; }
        public PIC_Address PicType { get; set; }
        public Cast Cast { get; set; }
        public Operation Operation { get; set; }
        public Command Command { get; set; }
        public string Data { get; set; }
        public int Delay { get; set; }
        public int Loop { get; set; }
    }
}