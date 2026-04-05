using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Models
{
    public class CommunicationConfig
    {
        public CommPortConfig CommPort { get; set; } = new CommPortConfig();
        public string USB { get; set; } = "";
        public string API { get; set; } = "";
        public string Websocket { get; set; } = "";
        public string TCP { get; set; } = "";
        public string UDP { get; set; } = "";
        public string IPC { get; set; } = "";
        public bool AutoConnect { get; set; } = true;
        public string Selected { get; set; } = "IPC";
    }

    public class CommPortConfig
    {
        public string PortName { get; set; } = "";
        public int BaudRate { get; set; } = 115200;
        public string PacketType { get; set; } = "ASCII";
    }
}