using CANhandler.CANhandler;
using CANhandler.Communication;
using CANhandler.Constants;
using CANhandler.Enums;
using CANhandler.Helpers;
using CANhandler.Models;
using CANhandler.Protocol;
using CANhandler.Services;
using CANhandler.UI;
using System.Data.Common;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using static CANhandler.Constants.ProtocolConstants;
using static CANhandler.Helpers.CommandHelper;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace CANhandler
{
    public partial class frm_main : Form
    {
        #region Initialization
        private SerialPort _serialPort;
        private List<byte> rxBuffer = new List<byte>();
        private int expectedLength = -1;
        private UIConfig config;
        private string? currentFilePath = null;
        private ContextMenuStrip ctxGridMenu;
        private List<object[]> copiedRows = new List<object[]>();
        private ProgramExecutor executor;
        ITransport _transport = null;

        public frm_main()
        {
            InitializeComponent();
            InitializeContextMenu();
            ConfigManager.Load();
            config = ConfigManager.Config.UI;
            LoadRecentFilesMenu();
            dg_prg.CellMouseDown += dg_prg_CellMouseDown;
            dg_prg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_prg.MultiSelect = true;

            commToolStripMenuItem.Click += communicationToolStripMenuItem_Click;
            uSBToolStripMenuItem.Click += communicationToolStripMenuItem_Click;
            aPIToolStripMenuItem.Click += communicationToolStripMenuItem_Click;
            websocketToolStripMenuItem.Click += communicationToolStripMenuItem_Click;
            tcpToolStripMenuItem.Click += communicationToolStripMenuItem_Click;
            udpToolStripMenuItem.Click += communicationToolStripMenuItem_Click;
            iPCToolStripMenuItem.Click += communicationToolStripMenuItem_Click;

            commToolStripMenuItem.MouseDown += MenuItem_MouseDown;
            uSBToolStripMenuItem.MouseDown += MenuItem_MouseDown;
            aPIToolStripMenuItem.MouseDown += MenuItem_MouseDown;
            websocketToolStripMenuItem.MouseDown += MenuItem_MouseDown;
            tcpToolStripMenuItem.MouseDown += MenuItem_MouseDown;
            udpToolStripMenuItem.MouseDown += MenuItem_MouseDown;
            iPCToolStripMenuItem.MouseDown += MenuItem_MouseDown;
            /////////////////////////////
            //kbusToolStripMenuItem.MouseDown += Protocol_Selection_MenuItem_MouseDown;
            rAWBinaryToolStripMenuItem.MouseDown += Protocol_MenuItem_MouseDown;
            aSCIIToolStripMenuItem.MouseDown += Protocol_MenuItem_MouseDown;

        }
        private void InitializeContextMenu()
        {
            ctxGridMenu = new ContextMenuStrip();
            ctxGridMenu.Items.Add("Send", null, SendToDevice_Click);
            ctxGridMenu.Items.Add("Show Packet", null, ShowPacket_Click);
            ctxGridMenu.Items.Add("Insert Above", null, InsertAbove_Click);
            ctxGridMenu.Items.Add("Insert Below", null, InsertBelow_Click);
            ctxGridMenu.Items.Add(new ToolStripSeparator());
            ctxGridMenu.Items.Add("Move Up", null, MoveUp_Click);
            ctxGridMenu.Items.Add("Move Down", null, MoveDown_Click);
            ctxGridMenu.Items.Add(new ToolStripSeparator());
            ctxGridMenu.Items.Add("Copy Row(s)", null, CopyRows_Click);
            ctxGridMenu.Items.Add("Paste Row(s)", null, PasteRows_Click);
            ctxGridMenu.Items.Add(new ToolStripSeparator());
            //ctxGridMenu.Items.Add("Delete Row(s)", null, DeleteRow_Click);

            dg_prg.ContextMenuStrip = ctxGridMenu;
        }
        private void SetupCastColumn()
        {

            var col_Cast = (DataGridViewComboBoxColumn)dg_prg.Columns["col_Cast"];
            col_Cast.DataSource = Enum.GetValues(typeof(Cast));
            col_Cast.ValueType = typeof(Cast);

            var col_pic = (DataGridViewComboBoxColumn)dg_prg.Columns["col_pic_type"];
            col_pic.DataSource = Enum.GetValues(typeof(PIC_Address));
            col_pic.ValueType = typeof(PIC_Address);

            var col_Action = (DataGridViewComboBoxColumn)dg_prg.Columns["col_Operation"];
            col_Action.DataSource = Enum.GetValues(typeof(Operation));
            col_Action.ValueType = typeof(Operation);

            var col_Cmd = (DataGridViewComboBoxColumn)dg_prg.Columns["col_Command"];
            col_Cmd.DataSource = Enum.GetValues(typeof(Command));
            col_Cmd.ValueType = typeof(Command);



            //var col_Cast = (DataGridViewComboBoxColumn)dg_prg.Columns["col_Cast"];
            //col_Cast.DataSource = Enum.GetValues(typeof(Enums.Cast));
            ////col_Cast.DataSource = new[]
            ////{
            ////    new { Text = "Unicast", Value = CastType.Unicast },
            ////    new { Text = "Multicast", Value = CastType.Multicast }
            ////};

            ////col_Cast.DisplayMember = "Text";
            ////col_Cast.ValueMember = "Value";
            //////////////////////////////
            //var pic_type = (DataGridViewComboBoxColumn)dg_prg.Columns["col_pic_type"];
            //pic_type.DataSource = Enum.GetValues(typeof(Enums.PIC_Address));

        }
        #endregion

        #region FormLoad
        private void Form1_Load(object sender, EventArgs e)
        {
            /////////////////////////////////
            dg_prg.DataSource = null;
            dg_prg.Rows.Clear();

            SetupCastColumn();

            switch (config.SelectedInterface)
            {
                case InterfaceType.InbuiltSim:
                    rbtn_InbuiltSim.Checked = true;
                    break;

                case InterfaceType.ExternalSim:
                    rbtn_externalSim.Checked = true;
                    break;

                case InterfaceType.RealHardware:
                    rbtn_real_hardware.Checked = true;
                    //tssl_comport.Text = "Port: " + ConfigManager.Config.Communication.CommPort;
                    //tssl_baudrate.Text = "Speed: " + ConfigManager.Config.Communication.BaudRate.ToString();
                    break;
            }
            ///////////////////////////
            if (config.LoopEnable)
            {
                chk_loop.Checked = true;
            }
            else chk_loop.Checked = false;
            ////////////////////////////
            GridConfigurator.ConfigureProgramGrid(dg_prg);
            dg_prg.RowPostPaint += dg_prg_RowPostPaint;
            chk_auto_connect.Checked = ConfigManager.Config.Communication.AutoConnect;
            chk_loop.Checked = ConfigManager.Config.UI.LoopEnable;
            /////////////////////
            string selected = ConfigManager.Config.Communication.Selected;
            foreach (ToolStripMenuItem item in commToolStripMenuItem.DropDownItems)
            {
                item.Checked = item.Text.Equals(selected, StringComparison.OrdinalIgnoreCase);
            }
            //var steps = AutoSaveService.Load();
            //GridProgramConverter.Write(dg_prg, steps);
        }
        #endregion

        #region Application Related

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                // First time → Save As
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Program Files (*.json)|*.json";

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                currentFilePath = dlg.FileName;
            }

            var steps = GridProgramConverter.Read(dg_prg);

            ProgramFileService.Save(currentFilePath, steps);

            AddToRecentFiles(currentFilePath);
            lbl_message.Text = "Program saved: " + Path.GetFileName(currentFilePath);


        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Program Files (*.json)|*.json";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = dlg.FileName;

                var steps = ProgramFileService.Load(dlg.FileName);
                GridProgramConverter.Write(dg_prg, steps);

                AddToRecentFiles(dlg.FileName);  // 👈 IMPORTANT
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV (*.csv)|*.csv";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var steps = GridProgramConverter.Read(dg_prg);

                ProgramExportService.ExportCSV(dlg.FileName, steps);
            }
        }
        private void dg_prg_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            string rowNumber = (e.RowIndex + 1).ToString();
            using (SolidBrush brush = new SolidBrush(grid.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(
                    rowNumber,
                    grid.DefaultCellStyle.Font,
                    brush,
                    e.RowBounds.Location.X + 15,
                    e.RowBounds.Location.Y + 6);
            }
        }
        private void LoadRecentFilesMenu()
        {
            recentFilesToolStripMenuItem.DropDownItems.Clear();

            var files = ConfigManager.Config.RecentFiles;

            if (files.Count == 0)
            {
                recentFilesToolStripMenuItem.DropDownItems.Add("No recent files");
                return;
            }

            foreach (var file in files)
            {
                var item = new ToolStripMenuItem(file);

                item.Click += (s, e) =>
                {
                    if (File.Exists(file))
                    {
                        var steps = ProgramFileService.Load(file);
                        GridProgramConverter.Write(dg_prg, steps);

                        currentFilePath = file;
                        AddToRecentFiles(file); // move to top
                    }
                    else
                    {
                        MessageBox.Show("File not found!");
                    }
                };

                recentFilesToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var steps = GridProgramConverter.Read(dg_prg);
            //AutoSaveService.Save(steps);
            //base.OnFormClosing(e);
        }
        #endregion

        #region Program Execution
        private async void btn_run_Click(object sender, EventArgs e)
        {
            var steps = GridProgramReader.Read(dg_prg);
            executor = new ProgramExecutor(dg_prg, _transport);
            await executor.RunProgramAsync(steps);
        }

        private async void btn_pause_Click(object sender, EventArgs e)
        {
            executor?.Pause();
        }

        private void btn_new_prg_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void btn_Open_Click(object sender, EventArgs e)
        {

        }

        private void btn_export_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Toolbar Menu Events
        private void rUNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dg_prg.Rows.Clear();
        }



        private void rbtn_InbuiltSim_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_InbuiltSim.Checked)
                config.SelectedInterface = InterfaceType.InbuiltSim;
            else if (rbtn_externalSim.Checked)
                config.SelectedInterface = InterfaceType.ExternalSim;
            else if (rbtn_real_hardware.Checked)
                config.SelectedInterface = InterfaceType.RealHardware;

            ConfigManager.Save();   // 👈 IMPORTANT
        }

        private void rbtn_externalSim_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_InbuiltSim.Checked)
                config.SelectedInterface = InterfaceType.InbuiltSim;
            else if (rbtn_externalSim.Checked)
                config.SelectedInterface = InterfaceType.ExternalSim;
            else if (rbtn_real_hardware.Checked)
                config.SelectedInterface = InterfaceType.RealHardware;

            ConfigManager.Save();   // 👈 IMPORTANT
        }

        private void rbtn_real_hardware_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_InbuiltSim.Checked)
                config.SelectedInterface = InterfaceType.InbuiltSim;
            else if (rbtn_externalSim.Checked)
                config.SelectedInterface = InterfaceType.ExternalSim;
            else if (rbtn_real_hardware.Checked)
                config.SelectedInterface = InterfaceType.RealHardware;

            ConfigManager.Save();   // 👈 IMPORTANT
        }

        #endregion
        #region Recent Files Management
        private void AddToRecentFiles(string filePath)
        {
            var list = ConfigManager.Config.RecentFiles;

            // Remove if already exists
            list.Remove(filePath);

            // Insert at top
            list.Insert(0, filePath);

            // Keep only last 5
            if (list.Count > 5)
                list.RemoveAt(list.Count - 1);

            ConfigManager.Save();

            LoadRecentFilesMenu(); // refresh UI
        }

        #endregion

        #region Datagrid Related

        private void dg_prg_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                if (!dg_prg.Rows[e.RowIndex].Selected)
                {
                    dg_prg.ClearSelection();
                    dg_prg.Rows[e.RowIndex].Selected = true;
                }
                dg_prg.CurrentCell = dg_prg.Rows[e.RowIndex].Cells[0];
            }
        }

        private void dg_prg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //var v = dg_prg.Columns[e.ColumnIndex].Name;

            //if (dg_prg.Columns[e.ColumnIndex].Name == "col_pic_type")
            //{
            //    var selectedPIC = dg_prg.Rows[e.RowIndex].Cells["col_pic_type"].Value?.ToString();

            //    var commandCell = (DataGridViewComboBoxCell)
            //        dg_prg.Rows[e.RowIndex].Cells["col_Command"];

            //    commandCell.DataSource = null;
            //    commandCell.Value = null;

            //    if (selectedPIC != null)
            //    {
            //        //var commands = CommandHelper.GetCommands(selectedPIC);

            //        // Convert enum → string for display
            //        //commandCell.DataSource = commands
            //        //    .Select(c => c.ToString())
            //        //    .ToList();
            //    }
            //}
        }

        private void InsertRow_Click(object sender, EventArgs e)
        {
            int rowIndex = dg_prg.CurrentCell?.RowIndex ?? dg_prg.Rows.Count;
            dg_prg.Rows.Insert(rowIndex, 1);
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Delete selected row(s)?",
                "Confirm",
                MessageBoxButtons.YesNo
            );

            if (result != DialogResult.Yes)
                return;


            if (dg_prg.SelectedRows.Count == 0)
                return;

            foreach (DataGridViewRow row in dg_prg.SelectedRows)
            {
                if (!row.IsNewRow)
                    dg_prg.Rows.Remove(row);
            }
        }


        private void InsertAbove_Click(object sender, EventArgs e)
        {
            int rowIndex = dg_prg.CurrentCell?.RowIndex ?? 0;
            dg_prg.Rows.Insert(rowIndex, 1);
        }

        private void InsertBelow_Click(object sender, EventArgs e)
        {
            int rowIndex = dg_prg.CurrentCell?.RowIndex ?? dg_prg.Rows.Count - 1;
            dg_prg.Rows.Insert(rowIndex + 1, 1);
        }

        private void MoveUp_Click(object sender, EventArgs e)
        {
            //if (dg_prg.SelectedRows.Count == 0)
            //    return;

            //foreach (DataGridViewRow row in dg_prg.SelectedRows)
            //{
            //    int index = row.Index;
            //    if (index > 0)
            //    {
            //        dg_prg.Rows.RemoveAt(index);
            //        dg_prg.Rows.Insert(index - 1, row);
            //        row.Selected = true;
            //    }
            //}
        }

        private void MoveDown_Click(object sender, EventArgs e)
        {
            //if (dg_prg.SelectedRows.Count == 0)
            //    return;

            //for (int i = dg_prg.SelectedRows.Count - 1; i >= 0; i--)
            //{
            //    var row = dg_prg.SelectedRows[i];
            //    int index = row.Index;

            //    if (index < dg_prg.Rows.Count - 1)
            //    {
            //        dg_prg.Rows.RemoveAt(index);
            //        dg_prg.Rows.Insert(index + 1, row);
            //        row.Selected = true;
            //    }
            //}
        }

        private void CopyRows_Click(object sender, EventArgs e)
        {
            copiedRows.Clear();

            foreach (DataGridViewRow row in dg_prg.SelectedRows)
            {
                if (row.IsNewRow) continue;

                object[] values = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    values[i] = row.Cells[i].Value;
                }

                copiedRows.Add(values);
            }
        }


        private void PasteRows_Click(object sender, EventArgs e)
        {
            if (copiedRows.Count == 0)
                return;

            int insertIndex = dg_prg.CurrentCell?.RowIndex ?? dg_prg.Rows.Count;

            foreach (var rowData in copiedRows)
            {
                dg_prg.Rows.Insert(insertIndex, 1);   // insert row

                // Fill values
                for (int i = 0; i < rowData.Length; i++)
                {
                    dg_prg.Rows[insertIndex].Cells[i].Value = rowData[i];
                }

                insertIndex++; // move to next row
            }
        }

        private void dg_prg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopyRows_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                PasteRows_Click(null, null);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteRow_Click(null, null);
            }
        }
        #endregion

        #region Menu Item Events
        private void ShowPacket_Click(object sender, EventArgs e)
        {
            if (dg_prg.SelectedRows.Count == 0)
                return;
            var step = GridProgramConverter.ReadRow(dg_prg.SelectedRows[0]);
            byte[] buffer = KBusBuilder.BuildPacket_From_GridRow(step);
            string debug = CommandHelper.ToDetailedString(buffer);
            MessageBox.Show(debug, "Packet Debug");
        }

        private void commToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {

        }

        private void communicationToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            string selected = ConfigManager.Config.Communication.Selected;

            foreach (ToolStripItem item in communicationToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = false;

                    if (!string.IsNullOrEmpty(selected) &&
                        menuItem.Text.Equals(selected, StringComparison.OrdinalIgnoreCase))
                    {
                        menuItem.Checked = true;
                    }
                }
            }
        }

        private void ToolStripMenuItem_Seria_Click(object sender, EventArgs e)
        {
            UncheckAllInterfaces();

            commToolStripMenuItem.Checked = true;

            using (frm_settings_serial serial = new frm_settings_serial())
            {
                serial.ShowDialog();
            }


        }

        private void UncheckAllInterfaces()
        {
            commToolStripMenuItem.Checked = false;
            tcpToolStripMenuItem.Checked = false;
            udpToolStripMenuItem.Checked = false;
        }

        private void ToolStripMenuItem_TCP_Click(object sender, EventArgs e)
        {
            UncheckAllInterfaces();
            tcpToolStripMenuItem.Checked = true;

        }

        private void ToolStripMenuItem_UDP_Click(object sender, EventArgs e)
        {
            UncheckAllInterfaces();
            udpToolStripMenuItem.Checked = true;
        }

        private void communicationToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {


            }
        }

        private void communicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var clickedItem = sender as ToolStripMenuItem;
            //if (clickedItem == null) return;

            //var parent = clickedItem.GetCurrentParent();

            //// 🔥 Uncheck all siblings
            //foreach (ToolStripItem item in parent.Items)
            //{
            //    if (item is ToolStripMenuItem menuItem)
            //    {
            //        menuItem.Checked = false;
            //    }
            //}

            //// ✔ Check selected
            //clickedItem.Checked = true;

            //int selected = 0;

            //switch (clickedItem.Name)
            //{
            //    case "uSBToolStripMenuItem":
            //        selected = 1;

            //        using (frm_settings_serial frm = new frm_settings_serial())
            //        {
            //            frm.ShowDialog();
            //        }
            //        break;

            //    case "aPIToolStripMenuItem":
            //        selected = 2;
            //        break;

            //    case "websocketToolStripMenuItem":
            //        selected = 3;
            //        break;

            //    case "tcpToolStripMenuItem":
            //        selected = 4;
            //        break;

            //    case "udpToolStripMenuItem":
            //        selected = 5;
            //        break;

            //    case "iPCToolStripMenuItem":
            //        selected = 6;
            //        break;
            //}

            //ConfigManager.Config.UI.SelectedInterface = selected;
            //ConfigManager.Save();

        }

        private void MenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var clickedItem = sender as ToolStripMenuItem;
            if (clickedItem == null) return;

            var parent = clickedItem.GetCurrentParent();

            // 🔥 Uncheck all
            foreach (ToolStripItem item in parent.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = false;
                }
            }

            // ✔ Check selected
            clickedItem.Checked = true;

            // =========================
            // 🔥 SAVE TO CONFIG
            // =========================
            string selected = clickedItem.ToString();
            // Save
            ConfigManager.Config.Communication.Selected = selected;
            ConfigManager.Save();

        }

        private void Protocol_MenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var clickedItem = sender as ToolStripMenuItem;
            if (clickedItem == null) return;

            var parent = clickedItem.GetCurrentParent();

            // 🔥 Uncheck all
            foreach (ToolStripItem item in parent.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = false;
                }
            }

            // ✔ Check selected
            clickedItem.Checked = true;

            // =========================
            // 🔥 SAVE TO CONFIG
            // =========================
            string selected = clickedItem.ToString();
            // Save
            ConfigManager.Config.Communication.CommPort.PacketType = selected;
            ConfigManager.Save();

        }

        #endregion

        #region UI Events

        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void textBoxReceive_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Disp_send_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_disp_weight_TextChanged(object sender, EventArgs e)
        {

        }
        private void SendToDevice_Click(object sender, EventArgs e)
        {
            send();
        }

        private void chk_loop_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_loop.Checked)
                config.LoopEnable = true;
            else config.LoopEnable = false;
            ConfigManager.Save();   // 👈 IMPORTANT
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            executor?.Stop();
        }

        private void btn_resume_Click(object sender, EventArgs e)
        {
            executor?.Resume();
        }

        private void btn_prg_send_Click(object sender, EventArgs e)
        {
            send();
        }

        private void chk_auto_connect_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.Communication.AutoConnect = chk_auto_connect.Checked;
            ConfigManager.Save();
        }


        private void btn_connect_Click_1(object sender, EventArgs e)
        {


        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            InterfaceType channel = config.SelectedInterface;

            if (channel == InterfaceType.RealHardware)
            {
                CommunicationConfig cfg = ConfigManager.Config.Communication;  // then assign
                string port = cfg.CommPort.PortName;
                int baudarate = cfg.CommPort.BaudRate;
                string p = ExtractPortName(port);
                _transport = new SerialTransport(p, baudarate);
                //_kbus = new KBusComm(_transport);
                _transport.Connect();
                try
                {
                    // ✅ Create only once
                    if (_transport == null)
                    {
                        //_transport = new SerialTransport("COM11", 38400);
                        //_transport.Connect();

                        //_kbus = new KBusComm(_transport);
                    }
                    else if (!_transport.IsConnected)
                    {
                        // 🔥 Reconnect if needed
                        _transport.Connect();
                    }

                    pb_connection.BackColor = Color.GreenYellow;

                    // ✅ Send data
                    //RowSendService.SendRow(dg_prg.SelectedRows[0], _kbus);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    pb_connection.BackColor = Color.Red;
                }
            }
        }

        public static string ExtractPortName(string fullText)
        {
            var match = Regex.Match(fullText, @"COM\d+");
            return match.Success ? match.Value : fullText;
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            byte[] b = {
                    0x66, 0x55, 0x15, 0x00, 0x01, 0x00, 0x00, 0x01,
                    0x00, 0x0B, 0x36, 0x32, 0x03, 0x44, 0x03, 0x03,
                    0x1A, 0x8F, 0x70, 0x77, 0x88
            };

            byte[] b1 = {
                                0x66, 0x55, 0x0F, 0x00, 0x00, 0x00, 0x65, 0x02, 0x02, 0x00, 0x64, 0x0D, 0xF5, 0x77, 0x88
                        };

            byte[] b3 = {
    0x66, 0x55,             // Preamble
    0x15,                   // Length = 21 bytes
    0x00,                   // TransType
    0x01,                   // Cast
    0x00, 0x00,             // Address
    0x01,                   // RW
    0x00,                   // Command
    0x0B, 0x36, 0x32, 0x03, // Data
    0x44, 0x03, 0x03, 0x1A, // Data continued
    0x8F, 0x70,             // CRC ✅ (XMODEM verified)
    0x77, 0x88              // Postamble
};


            //byte[] bytes = Encoding.UTF8.GetBytes("fdsdsfsdafsa");
            _transport.Send(b3);
        }
        #endregion



        #region Helpers


        private void send()
        {
            if (dg_prg.SelectedRows.Count == 0) return;
            var step = GridProgramConverter.ReadRow(dg_prg.SelectedRows[0]);
            byte[] buffer = KBusBuilder.BuildPacket_From_GridRow(step);
            _transport.Send(buffer);
        }

        //private ProgramStep GetStep(DataGridViewRow row)
        //{
        //    ProgramStep ps = new ProgramStep();

        //    ps.LineNo = row.Index + 1;
        //    ps.Enable = Convert.ToBoolean(row.Cells["col_enable"].Value);
        //    ps.PicType = (PIC_Address)row.Cells["col_pic_type"].Value;
        //    ps.Operation = (Operation)row.Cells["col_Operation"].Value;
        //    ps.Command = (Command)row.Cells["col_Command"].Value;
        //    ps.Data = row.Cells["col_data"].Value?.ToString();
        //    ps.Delay = Convert.ToInt32(row.Cells["col_delay"].Value);
        //    ps.Loop = Convert.ToInt32(row.Cells["col_loop"].Value);

        //    return ps;
        //}




        #endregion

        #region Inbuilt simulator

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Inbuilt_Simulator sim=new frm_Inbuilt_Simulator();
            sim.Visible = true;
        }
        #endregion
    }
}
