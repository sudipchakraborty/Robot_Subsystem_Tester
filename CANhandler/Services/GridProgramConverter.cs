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
                    Cast= (Cast)row.Cells["col_cast"].Value,
                    Operation = (Constants.Operation)row.Cells["col_Operation"].Value,   
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
                int rowIndex = grid.Rows.Add();
                var row = grid.Rows[rowIndex];

                row.Cells["col_line_no"].Value = step.LineNo;
                row.Cells["col_enable"].Value = step.Enable;

                // 🔴 IMPORTANT: Assign EXACT enum type expected by ComboBox
                row.Cells["col_pic_type"].Value = (PIC_Address)step.PicType;
                row.Cells["col_cast"].Value = (Cast)step.Cast;
                row.Cells["col_Operation"].Value = (Operation)step.Operation;
                row.Cells["col_command"].Value = (Command)step.Command;

                row.Cells["col_data"].Value = step.Data;
                row.Cells["col_delay"].Value = step.Delay;
                row.Cells["col_loop"].Value = step.Loop;
            }
        }

        public static ProgramStep ReadRow(DataGridViewRow row)
        {
            ProgramStep ps= new ProgramStep();

            ps. LineNo = row.Index + 1;
            ps.Enable = Convert.ToBoolean(row.Cells["col_enable"].Value);
            ps.PicType = (PIC_Address)row.Cells["col_pic_type"].Value;
            ps.Cast = (Cast)row.Cells["col_cast"].Value;
            ps.Operation = (Operation)row.Cells["col_Operation"].Value;
            ps.Command = (Command)row.Cells["col_Command"].Value;
            ps.Data = row.Cells["col_data"].Value?.ToString();
            ps.Delay = Convert.ToInt32(row.Cells["col_delay"].Value);
            ps.Loop = Convert.ToInt32(row.Cells["col_loop"].Value);

            return ps;
        }
    }
}
