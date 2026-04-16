using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Models
{
    public class UIConfig
    {
        public int WindowWidth { get; set; } = 1200;
        public int WindowHeight { get; set; } = 800;

        // Only this is needed for radio button selection
        public InterfaceType SelectedInterface { get; set; }

        public bool LoopEnable { get; set; } = true;
    }
}
