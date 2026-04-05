using System;
using System.Collections.Generic;
using System.Text;

using CANhandler.Models;

namespace CANhandler.Services
{
    public static class GridProgramReader
    {
        public static List<ProgramStep> Read(DataGridView grid)
        {
            List<ProgramStep> steps = new List<ProgramStep>();

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow)
                    continue;

                ProgramStep step = new ProgramStep
                {
                    LineNo = Convert.ToInt32(row.Cells["col_line_no"].Value),
                    Enable = Convert.ToBoolean(row.Cells["col_enable"].Value),

                    PicType = row.Cells["col_pic_type"].Value?.ToString(),
                    Action = row.Cells["col_Action"].Value?.ToString(),
                    Command = row.Cells["col_Command"].Value?.ToString(),

                    Data = Helpers.CommandHelper.ParseData(row.Cells["col_data"].Value?.ToString()),

                    Delay = Convert.ToInt32(row.Cells["col_delay"].Value),
                    Loop = Convert.ToInt32(row.Cells["col_loop"].Value)
                };

                steps.Add(step);
            }

            return steps;
        }
    }
}