using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Models
{
    public class DispenseRequest
    {
        public string DispenserType { get; set; }
        public string Action { get; set; }
        public string Command { get; set; }

        public string MSB { get; set; }
        public string LSB { get; set; }
    }
}