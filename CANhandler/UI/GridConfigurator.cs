using System.Drawing;
using System.Windows.Forms;

namespace CANhandler.UI
{
    public static class GridConfigurator
    {
        public static void ConfigureProgramGrid(DataGridView grid)
        {
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;

            grid.AllowUserToAddRows = true;
            grid.AllowUserToDeleteRows = true;
            grid.AllowUserToResizeRows = false;

            grid.RowHeadersVisible = false;

            grid.EditMode = DataGridViewEditMode.EditOnEnter;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.LightGray;

            // Header style
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeight = 32;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cell style
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 229, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Alternating rows
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            // Row height
            grid.RowTemplate.Height = 28;

            // Numeric columns right alignment
            SetNumericAlignment(grid, "MSB");
            SetNumericAlignment(grid, "LSB");
            SetNumericAlignment(grid, "Delay");
            SetNumericAlignment(grid, "Loop");

            ConfigureColumnSizes(grid);
        }

        private static void SetNumericAlignment(DataGridView grid, string columnName)
        {
            if (grid.Columns.Contains(columnName))
            {
                grid.Columns[columnName].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
        }

        private static void ConfigureColumnSizes(DataGridView grid)
        {
            if (grid.Columns.Contains("col_pic_type"))
            {
                grid.Columns["col_pic_type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grid.Columns["col_pic_type"].Width = 250;
            }
        }

    }
}