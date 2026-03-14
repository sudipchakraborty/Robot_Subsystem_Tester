using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Models
{
    public class CommunicationConfig
    {
        public string CommPort { get; set; } = "COM3";
        public int BaudRate { get; set; } = 115200;
    }
}