using System;
using System.Collections.Generic;
using System.Text;

using CANhandler.Models;

namespace CANhandler.Services
{
    public static class GridProgramConverter
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
                    LineNo = row.Index + 1,
                    Enable = Convert.ToBoolean(row.Cells["col_enable"].Value ?? false),

                    PicType = row.Cells["col_pic_type"].Value?.ToString() ?? "",
                    Action = row.Cells["col_Action"].Value?.ToString() ?? "",
                    Command = row.Cells["col_Command"].Value?.ToString() ?? "",

                    MSB = Convert.ToByte(row.Cells["col_MSB"].Value ?? 0),
                    LSB = Convert.ToByte(row.Cells["col_LSB"].Value ?? 0),

                    Delay = Convert.ToInt32(row.Cells["col_delay"].Value ?? 0),
                    Loop = Convert.ToInt32(row.Cells["col_loop"].Value ?? 1)
                };

                steps.Add(step);
            }

            return steps;
        }

        public static void Write(DataGridView grid, List<ProgramStep> steps)
        {
            grid.Rows.Clear();

            foreach (var step in steps)
            {
                grid.Rows.Add(
                    step.LineNo,
                    step.Enable,
                    step.PicType,
                    step.Action,
                    step.Command,
                    step.MSB,
                    step.LSB,
                    step.Delay,
                    step.Loop
                );
            }
        }

        public static ProgramStep ReadRow(DataGridViewRow row)
        {
            return new ProgramStep
            {
                LineNo = row.Index + 1,
                Enable = Convert.ToBoolean(row.Cells["col_enable"].Value ?? false),

                PicType = row.Cells["col_pic_type"].Value?.ToString() ?? "",
                Action = row.Cells["col_Action"].Value?.ToString() ?? "",
                Command = row.Cells["col_Command"].Value?.ToString() ?? "",

                MSB = Convert.ToByte(row.Cells["col_MSB"].Value ?? 0),
                LSB = Convert.ToByte(row.Cells["col_LSB"].Value ?? 0),

                Delay = Convert.ToInt32(row.Cells["col_delay"].Value ?? 0),
                Loop = Convert.ToInt32(row.Cells["col_loop"].Value ?? 1)
            };
        }
    }
}
