using CANhandler.CANhandler;
using System.Data.Common;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Xml;
using static CANhandler.Enums.Address;
using static CANhandler.Constants.ProtocolConstants;

using CANhandler.Models;
using CANhandler.Services;
using CANhandler.UI;
using CANhandler.Protocol;
using CANhandler.Constants;
using CANhandler.Communication;

namespace CANhandler
{
    public partial class frm_main : Form
    {
        private SerialPort _serialPort;
        private List<byte> rxBuffer = new List<byte>();
        private int expectedLength = -1;
        KBusComm _kbus;
        private UIConfig config;   // 👈 THIS WAS MISSING
        private string? currentFilePath = null;   // allow null
        private ContextMenuStrip ctxGridMenu;
        private List<object[]> copiedRows = new List<object[]>();
        private ProgramExecutor executor;

        public frm_main()
        {
            InitializeComponent();
            InitializeContextMenu();
            // Load config (from your ConfigService)
            ConfigManager.Load();              // load first
            config = ConfigManager.Config.UI;  // then assign
            LoadRecentFilesMenu();   // 👈 add this
            dg_prg.CellMouseDown += dg_prg_CellMouseDown;
            dg_prg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_prg.MultiSelect = true;
        }
        //________________________________________________________________________
        private void Form1_Load(object sender, EventArgs e)
        {

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
                    break;
            }
            ///////////////////////////
            if (config.LoopEnable)
            {
                chk_loop.Checked = true;
            }
            else chk_loop.Checked = false;
            ////////////////////////////


            //comboComPort.Text = ConfigManager.Config.Communication.CommPort;
            //comboBaud.Text = ConfigManager.Config.Communication.BaudRate.ToString();



            //pb_connect.BackColor = Color.Gray;
            GridConfigurator.ConfigureProgramGrid(dg_prg);
            dg_prg.RowPostPaint += dg_prg_RowPostPaint;

            //var steps = AutoSaveService.Load();
            //GridProgramConverter.Write(dg_prg, steps);
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


        //private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    try
        //    {
        //        int bytesToRead = _serialPort.BytesToRead;
        //        byte[] buffer = new byte[bytesToRead];
        //        _serialPort.Read(buffer, 0, bytesToRead);

        //        foreach (byte b in buffer)
        //        {
        //            rxBuffer.Add(b);

        //            // Step 1: Check header
        //            if (rxBuffer.Count >= 2)
        //            {
        //                if (rxBuffer[0] != 0x66 || rxBuffer[1] != 0x55)
        //                {
        //                    rxBuffer.RemoveAt(0); // shift until valid header
        //                    continue;
        //                }
        //            }

        //            // Step 2: Get expected length from 3rd byte
        //            if (rxBuffer.Count == 3)
        //            {
        //                expectedLength = rxBuffer[2];
        //            }

        //            // Step 3: Check if full packet received
        //            if (expectedLength > 0 && rxBuffer.Count >= expectedLength)
        //            {
        //                byte[] fullPacket = rxBuffer.GetRange(0, expectedLength).ToArray();

        //                rxBuffer.RemoveRange(0, expectedLength);
        //                expectedLength = -1;

        //                ProcessPacket(fullPacket);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        //private void ProcessPacket(byte[] packet)
        //{
        //    string hex = BitConverter.ToString(packet).Replace("-", " ");

        //    this.Invoke(new MethodInvoker(delegate
        //    {
        //        textBoxReceive.AppendText("RX: " + hex + Environment.NewLine);

        //        KBusPacket pkt = KBusParser.Parse(packet);

        //        if (pkt != null)
        //        {
        //            textBoxReceive.AppendText(
        //                $"Addr: {pkt.Address:X4}  RW:{pkt.RWFlag}  DataLen:{pkt.Data.Length}\r\n");
        //        }
        //    }));
        //}


        //private void ProcessCANFrame(string frame)
        //{
        //    try
        //    {
        //        string id = "";
        //        string dlc = "";
        //        string dataBytes = "";

        //        string[] parts = frame.Split(' ');

        //        foreach (string part in parts)
        //        {
        //            if (part.StartsWith("ID:"))
        //                id = part.Replace("ID:", "");

        //            if (part.StartsWith("DLC:"))
        //                dlc = part.Replace("DLC:", "");

        //            if (part.StartsWith("DATA:"))
        //                dataBytes = frame.Substring(frame.IndexOf("DATA:") + 5);
        //        }

        //        // Display in textbox or DataGridView
        //        textBoxReceive.AppendText(
        //            $"ID: {id}  DLC: {dlc}  DATA: {dataBytes}" + Environment.NewLine
        //        );
        //    }
        //    catch
        //    {
        //        textBoxReceive.AppendText("Invalid Frame" + Environment.NewLine);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //KBusPacket pkt = new KBusPacket();

            //pkt.Multicast = ProtocolConstants.Multicast;
            ////////////
            //string selected = cbo_disp_pic_type.SelectedItem.ToString();
            //var field = typeof(Dispenser).GetField(selected);
            //int value = (int)field.GetValue(null);
            //pkt.Address = (byte)value;
            /////////////
            //pkt.RWFlag = ProtocolConstants.Execute;
            ////pkt.CmdParameter = Command.LED_TOGGLING_2;
            //pkt.Data = new byte[] { 0x01 };

            //byte[] sendBuffer = KBusBuilder.BuildPacket(pkt);
            //byte[] response = _kbus.SendAndReceive(sendBuffer);

            //if (response != null)
            //{
            //    string hex = BitConverter.ToString(response);
            //    MessageBox.Show("Response: " + hex);
            //}
            //else
            //{
            //    MessageBox.Show("No response (timeout)");
            //}
        }



        //private void SendCANFrame(string id, byte[] data)
        //{
        //    if (_serialPort == null || !_serialPort.IsOpen)
        //    {
        //        MessageBox.Show("Serial Port Not Open");
        //        return;
        //    }

        //    try
        //    {
        //        int dlc = data.Length;

        //        // Convert data bytes to HEX string
        //        StringBuilder sb = new StringBuilder();
        //        foreach (byte b in data)
        //        {
        //            sb.Append(b.ToString("X2") + " ");
        //        }

        //        string frame = $"ID:{id} DLC:{dlc} DATA:{sb.ToString().Trim()}";

        //        _serialPort.WriteLine(frame);

        //        // Optional: show in UI as TX
        //        textBoxReceive.AppendText(
        //            $"TX -> {frame}" + Environment.NewLine
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Send Error: " + ex.Message);
        //    }
        //}

        private void textBoxReceive_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM11";// txt_Port.Text;// "COM11";   // Change to your port
            _serialPort.BaudRate = 38400;// Convert.ToInt16(txt_Port.Text);// 115200;   // Match your MCU baud rate
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            //_kbus = new KBusComm(_serialPort);

            //_serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                _serialPort.Open();
                //MessageBox.Show("Serial Port Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_Disp_send_Click(object sender, EventArgs e)
        {
            //DispenseRequest req = new DispenseRequest
            //{
            //    DispenserType = cbo_disp_pic_type.Text,
            //    Action = cbo_disp_action.Text,
            //    Command = cbo_disp_cmd.Text,
            //    MSB = txt_disp_MSB.Text,
            //    LSB = txt_disp_LSB.Text
            //};

            //KBusPacket pkt = DispenserCommandService.CreatePacket(req);

            //byte[] sendBuffer = KBusBuilder.BuildPacket(pkt);
            //byte[] response = _kbus.SendAndReceive(sendBuffer);

            //if (response != null)
            //{
            //    string hex = BitConverter.ToString(response);
            //    MessageBox.Show("Response: " + hex);
            //}
            //else
            //{
            //    MessageBox.Show("No response (timeout)");
            //}





            //[
            //  0x66, 0x55,
            //        0x0f,
            //        0x00,
            //        0x01,
            //  0x00, 0x65,
            //        0x02,
            //        0x00,
            //  0x00, 0x64,
            //  0xe0, 0x53,
            //  0x77, 0x88
            //]

            // 0x66, 0x55, preamble auto set by builder
            //       0x0f, byte count (15 bytes total) auto set by builder
            //       0x00, transmit type: defult static value
            //       0x01, multicast
            // 0x00, 0x65, address
            //       0x02, RWFlag: execute
            //       0x00, command:  
            //       0x00, 0x64, Data:  
            //       0xe0, 0x53, crc auto calculated by builder
            // 0x77, 0x88 postamble auto set by builder


            //KBusPacket pkt = new KBusPacket();

            //pkt.Multicast = ProtocolConstants.Multicast;
            ////////////
            //string selected = cbo_disp_pic_type.SelectedItem.ToString();
            //var field = typeof(Dispenser).GetField(selected);
            //int value = (int)field.GetValue(null);
            //pkt.Address = (byte)value;
            /////////////
            //string action = cbo_disp_action.SelectedItem.ToString();
            //field = typeof(ProtocolConstants).GetField(action);
            //value = (byte)field.GetValue(null);
            //pkt.RWFlag = (byte)value;
            ////////////
            //Command cmd = (Command)Enum.Parse(typeof(Command), cbo_disp_cmd.Text);
            //value = (byte)cmd;
            //pkt.CmdParameter = (byte)value;
            ////////////
            //byte msb=Convert.ToByte(txt_disp_MSB.Text);
            //byte lsb = Convert.ToByte(txt_disp_LSB.Text);

            //switch (cmd)
            //{
            //    case Command.Dispense:
            //        pkt.Data = new byte[] {(byte)(msb / 100), lsb};  // Example: 150 pills -> MSB=1, LSB=
            //        break;
            //    case Command.PB6_LED:
            //    case Command.PB5_LED:
            //        pkt.Data = new byte[]{0,lsb};
            //        break;
            //    default:
            //        pkt.Data = new byte[] { 0, 0 };
            //        break;
            //}
            ////////////////////////////
            //byte[] sendBuffer = KBusBuilder.BuildPacket(pkt);
            //byte[] response = _kbus.SendAndReceive(sendBuffer);

            //if (response != null)
            //{
            //    string hex = BitConverter.ToString(response);
            //    MessageBox.Show("Response: " + hex);
            //}
            //else
            //{
            //    MessageBox.Show("No response (timeout)");
            //}
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_disp_weight_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btn_run_Click(object sender, EventArgs e)
        {
            var steps = GridProgramReader.Read(dg_prg);
            executor = new ProgramExecutor(_kbus, dg_prg);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var steps = GridProgramConverter.Read(dg_prg);
            //AutoSaveService.Save(steps);
            //base.OnFormClosing(e);
        }

        private void btn_prg_send_Click(object sender, EventArgs e)
        {
            if (dg_prg.SelectedRows.Count == 0)
                return;

            RowSendService.SendRow(dg_prg.SelectedRows[0], _kbus);
        }

        private void rUNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dg_prg.Rows.Clear();
        }

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



        private void InitializeContextMenu()
        {
            ctxGridMenu = new ContextMenuStrip();

            var insertItem = new ToolStripMenuItem("Insert Row");
            var deleteItem = new ToolStripMenuItem("Delete Row(s)");

            insertItem.Click += InsertRow_Click;
            deleteItem.Click += DeleteRow_Click;

            ctxGridMenu.Items.Add(insertItem);
            ctxGridMenu.Items.Add(deleteItem);

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
            if (dg_prg.SelectedRows.Count == 0)
                return;

            foreach (DataGridViewRow row in dg_prg.SelectedRows)
            {
                int index = row.Index;
                if (index > 0)
                {
                    dg_prg.Rows.RemoveAt(index);
                    dg_prg.Rows.Insert(index - 1, row);
                    row.Selected = true;
                }
            }
        }

        private void MoveDown_Click(object sender, EventArgs e)
        {
            if (dg_prg.SelectedRows.Count == 0)
                return;

            for (int i = dg_prg.SelectedRows.Count - 1; i >= 0; i--)
            {
                var row = dg_prg.SelectedRows[i];
                int index = row.Index;

                if (index < dg_prg.Rows.Count - 1)
                {
                    dg_prg.Rows.RemoveAt(index);
                    dg_prg.Rows.Insert(index + 1, row);
                    row.Selected = true;
                }
            }
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
    }
}
