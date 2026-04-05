using System;
using System.Collections.Generic;
using System.Text;
using CANhandler.Models;

namespace CANhandler.Services
{
    public static class ProgramExportService
    {
        public static void ExportCSV(string path, List<ProgramStep> steps)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Line,Enable,PIC Type,Action,Command,MSB,LSB,Delay,Loop");

            foreach (var s in steps)
            {
                //sb.AppendLine($"{s.LineNo},{s.Enable},{s.PicType},{s.Action},{s.Command},{s.MSB},{s.LSB},{s.Delay},{s.Loop}");
            }

            File.WriteAllText(path, sb.ToString());
        }
    }
}