using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Models
{
    public class AppConfig
    {
        public CommunicationConfig Communication { get; set; } = new();
        public ProgramConfig Program { get; set; } = new();
        public UIConfig UI { get; set; } = new();
    }
}
