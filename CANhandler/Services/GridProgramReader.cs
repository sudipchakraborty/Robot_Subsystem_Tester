using CANhandler.Enums;
using CANhandler.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

                    PicType = (PIC_Address)row.Cells["col_pic_type"].Value,
                    Operation =(Constants.Operation)row.Cells["col_Operation"].Value,
                    Command = (Command)row.Cells["col_Command"].Value,

                    Data = row.Cells["col_data"].Value?.ToString(),

                    Delay = Convert.ToInt32(row.Cells["col_delay"].Value),
                    Loop = Convert.ToInt32(row.Cells["col_loop"].Value)
                };

                steps.Add(step);
            }

            return steps;
        }
    }
}