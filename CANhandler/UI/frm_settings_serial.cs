using CANhandler.Communication;
using CANhandler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CANhandler.UI
{
    public partial class frm_settings_serial : Form
    {
        private bool portListLoaded = false;
        private bool baudListLoaded = false;

        public frm_settings_serial()
        {
            InitializeComponent();
            cbo_port_list.DropDown += cbo_port_list_DropDown;
            cbo_baudrate.DropDown += cbo_baudrate_DropDown;
        }

        private void frm_settings_serial_Load(object sender, EventArgs e)
        {
            LoadConfigToUI();   // ✅ Only load saved values (no list yet)
        }

        // ================================
        // ✅ LOAD CONFIG INTO UI
        // ================================
        private void LoadConfigToUI()
        {
            var config = ConfigManager.Config;

            // Show saved COM port (even if not connected)
            cbo_port_list.Text = config.Communication.CommPort.PortName;

            // Show saved baud rate
            cbo_baudrate.Text = config.Communication.CommPort.BaudRate.ToString();
        }

        // ================================
        // ✅ LOAD PORTS (ON DEMAND)
        // ================================
        private void LoadPorts()
        {
            var service = new SerialPortSearchService();
            var ports = service.GetAvailablePorts();

            cbo_port_list.DataSource = ports;
            cbo_port_list.DisplayMember = "DisplayName";
            cbo_port_list.ValueMember = "PortName";

            portListLoaded = true;
        }

        // ================================
        // ✅ LOAD BAUD RATES (ON DEMAND)
        // ================================
        private void LoadBaudRates()
        {
            cbo_baudrate.Items.Clear();

            cbo_baudrate.Items.AddRange(new object[]
            {
                "9600", "19200", "38400", "57600", "115200"
            });

            baudListLoaded = true;
        }

        // ================================
        // ✅ DROPDOWN EVENTS (IMPORTANT)
        // ================================
        private void cbo_port_list_DropDown(object sender, EventArgs e)
        {
            if (!portListLoaded)
            {
                LoadPorts();

                // restore selection after binding
                var savedPort = ConfigManager.Config.Communication.CommPort.PortName;
                if (!string.IsNullOrEmpty(savedPort))
                {
                    cbo_port_list.SelectedValue = savedPort;
                }
            }
        }

        private void cbo_baudrate_DropDown(object sender, EventArgs e)
        {
            if (!baudListLoaded)
            {
                LoadBaudRates();

                // restore selection
                //cbo_baudrate.Text =
                //    ConfigManager.Config.Communication.BaudRate.ToString();
            }
        }

        // ================================
        // ✅ SAVE
        // ================================
        private void brn_ok_Click(object sender, EventArgs e)
        {
            SaveUIToConfig();
            ConfigManager.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveUIToConfig()
        {
            var config = ConfigManager.Config;

            // COM Port
            if (!string.IsNullOrWhiteSpace(cbo_port_list.Text))
            {
                config.Communication.CommPort.PortName = cbo_port_list.Text;
            }

            // Baud Rate
            if (int.TryParse(cbo_baudrate.Text, out int baud))
            {
                config.Communication.CommPort.BaudRate = baud;
            }
        }
    }
}