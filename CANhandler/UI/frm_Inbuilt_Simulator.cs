using CANhandler.Services;

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CANhandler.UI
{
    public partial class frm_Inbuilt_Simulator : Form
    {
        private PacketParserService _parser = new PacketParserService();

        public frm_Inbuilt_Simulator()
        {
            InitializeComponent();
        }

        private void frm_Inbuilt_Simulator_Load(object sender, EventArgs e)
        {
            // UI style (terminal look)
            txt_msg.BackColor = Color.Black;
            txt_msg.ForeColor = Color.LightGreen;
            txt_msg.Font = new Font("Consolas", 10);
        }

        // =========================
        // 🔥 MAIN ENTRY FROM TRANSPORT
        // =========================
        public void HandleReceived(byte[] data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HandleReceived(data)));
                return;
            }

            if (data == null || data.Length == 0)
                return;

            // 🔹 1. RAW HEX LINE
            LogRX(data);

            // 🔹 2. SPACE (important for readability)
            AddLog("");

            // 🔹 3. PARSED BLOCK
            string parsed = _parser.Parse(data);

            AppendMultiline(parsed, Color.LightGreen);

            // 🔹 4. SEPARATOR (REAL TERMINAL FEEL)
            AddLog("====================================", Color.DarkGreen);

            // 🔹 5. SPACE
            AddLog("");
        }

        // =========================
        // 🔹 MULTILINE SAFE APPEND
        // =========================
        private void AppendMultiline(string text, Color color)
        {
            if (string.IsNullOrEmpty(text)) return;

            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach (var line in lines)
            {
                AddRaw(line, color);   // 🔥 NO TIMESTAMP HERE
            }
        }

        // =========================
        // 🔹 BASIC LOG
        // =========================
        public void AddLog(string message)
        {
            AddLog(message, txt_msg.ForeColor);
        }

        private void AddRaw(string message, Color color)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AddRaw(message, color)));
                return;
            }

            txt_msg.SelectionStart = txt_msg.TextLength;
            txt_msg.SelectionColor = color;

            txt_msg.AppendText(message + Environment.NewLine);

            txt_msg.SelectionColor = txt_msg.ForeColor;
            txt_msg.ScrollToCaret();
        }

        public void AddLog(string message, Color color)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AddLog(message, color)));
                return;
            }

            string log = $"[{DateTime.Now:HH:mm:ss}] {message}";

            txt_msg.SelectionStart = txt_msg.TextLength;
            txt_msg.SelectionColor = color;

            txt_msg.AppendText(log + Environment.NewLine);

            txt_msg.SelectionColor = txt_msg.ForeColor;
            txt_msg.ScrollToCaret();
        }

        // =========================
        // 🔹 HELPER METHODS
        // =========================
        public void LogTX(string msg)
        {
            AddLog("TX -> " + msg, Color.Cyan);
        }

        public void LogRX(byte[] data)
        {
            string parsed = _parser.Parse(data);
            //string hex = BitConverter.ToString(data);
            AddLog("RX <- " + parsed, Color.Lime);
        }

        public void LogError(string msg)
        {   
            AddLog("ERROR !! " + msg, Color.Red);
        }

        // =========================
        // 🔹 CLEAR BUTTON
        // =========================
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_msg.Clear();
        }
    }
}