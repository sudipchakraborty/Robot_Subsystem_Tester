using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.Windows.Forms;

namespace CANhandler.Services
{
    public static class GridExecutionService
    {
        public static void HighlightExecutingRow(DataGridView grid, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= grid.Rows.Count)
                return;

            // reset previous highlight
            foreach (DataGridViewRow row in grid.Rows)
                row.DefaultCellStyle.BackColor = Color.White;

            // highlight executing row
            grid.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;

            grid.ClearSelection();
            grid.Rows[rowIndex].Selected = true;

            ScrollToRow(grid, rowIndex);
        }

        public static void ScrollToRow(DataGridView grid, int rowIndex)
        {
            int visibleRows = grid.DisplayedRowCount(false);

            int targetRow = Math.Max(0, rowIndex - visibleRows / 2);

            grid.FirstDisplayedScrollingRowIndex = targetRow;
        }
    }
}
