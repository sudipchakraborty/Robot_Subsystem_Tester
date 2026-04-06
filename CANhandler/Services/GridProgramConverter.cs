using CANhandler.Constants;
using CANhandler.Enums;
using CANhandler.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
                     
                    Enable = Convert.ToBoolean(row.Cells["col_enable"].Value),

                    PicType = (PIC_Address)row.Cells["col_pic_type"].Value,
                    Operation = (Constants.Operation)row.Cells["col_Action"].Value,
                   
                    
                    Command = (Command)row.Cells["col_Command"].Value,

                    Data = row.Cells["col_data"].Value?.ToString(),

                    Delay = Convert.ToInt32(row.Cells["col_delay"].Value),
                    Loop = Convert.ToInt32(row.Cells["col_loop"].Value)

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
                    step.Operation,
                    step.Command,
                    //step.MSB,
                    //step.LSB,
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
                Enable = Convert.ToBoolean(row.Cells["col_enable"].Value),

                PicType = (PIC_Address)row.Cells["col_pic_type"].Value,

                //Cast = ()row.Cells["col_Cast"].Value,

                Operation = (Operation)row.Cells["col_Action"].Value,

                //Operation = (Constants.Operation)row.Cells["col_Action"].Value,

                Command = (Command)row.Cells["col_Command"].Value,

                Data = row.Cells["col_data"].Value?.ToString(),

                Delay = Convert.ToInt32(row.Cells["col_delay"].Value),
                Loop = Convert.ToInt32(row.Cells["col_loop"].Value)
            };
        }
    }
}
