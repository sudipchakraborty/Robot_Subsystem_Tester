using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Models
{
        public class SerialPortInfo
        {
            public string PortName { get; set; }      // COM3
            public string Description { get; set; }   // USB Serial Device
            public string DisplayName => $"{PortName} - {Description}";
        }
}
