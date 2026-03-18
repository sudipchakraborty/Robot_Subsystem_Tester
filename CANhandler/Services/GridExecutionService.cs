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

            // Reset all rows
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.SelectionBackColor = grid.DefaultCellStyle.SelectionBackColor;
            }

            // Highlight current row
            var currentRow = grid.Rows[rowIndex];
            currentRow.DefaultCellStyle.BackColor = Color.LightGreen;
            currentRow.DefaultCellStyle.SelectionBackColor = Color.LightGreen;

            grid.ClearSelection();
            currentRow.Selected = true;

            ScrollToRow(grid, rowIndex);

            grid.Refresh();
        }

        public static void ScrollToRow(DataGridView grid, int rowIndex)
        {
            int visibleRows = grid.DisplayedRowCount(false);

            int targetRow = Math.Max(0, rowIndex - visibleRows / 2);

            grid.FirstDisplayedScrollingRowIndex = targetRow;
        }
    }
}
