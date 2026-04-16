using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Services
{
    public class InBuiltSimService
    {
        private readonly RichTextBox _rtb;
        private readonly PacketParserService _parser;

        public InBuiltSimService(RichTextBox rtb) 
        {
            _rtb = rtb;
            _parser = new PacketParserService();

            SetupUI();
        }

        private void SetupUI()
        {
            _rtb.BackColor = Color.Black;
            _rtb.ForeColor = Color.LightGreen;
            _rtb.Font = new Font("Consolas", 10);
        }

        // =========================
        // 🔥 MAIN ENTRY (same as simulator)
        // =========================
        public void HandleReceived(byte[] data)
        {
            if (data == null || data.Length == 0)
                return;

            LogRX(data);
            AddLog("");

            string parsed = _parser.Parse(data);
            AppendMultiline(parsed, Color.LightGreen);

            AddLog("====================================", Color.DarkGreen);
            AddLog("");
        }

        // =========================
        // 🔹 MULTILINE
        // =========================
        private void AppendMultiline(string text, Color color)
        {
            if (string.IsNullOrEmpty(text)) return;

            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach (var line in lines)
            {
                AddRaw(line, color);
            }
        }

        // =========================
        // 🔹 BASIC LOG
        // =========================
        public void AddLog(string message)
        {
            AddLog(message, _rtb.ForeColor);
        }

        public void AddLog(string message, Color color)
        {
            SafeUI(() =>
            {
                string log = $"[{DateTime.Now:HH:mm:ss}] {message}";

                _rtb.SelectionStart = _rtb.TextLength;
                _rtb.SelectionColor = color;
                _rtb.AppendText(log + Environment.NewLine);
                _rtb.SelectionColor = _rtb.ForeColor;
                _rtb.ScrollToCaret();
            });
        }

        private void AddRaw(string message, Color color)
        {
            SafeUI(() =>
            {
                _rtb.SelectionStart = _rtb.TextLength;
                _rtb.SelectionColor = color;
                _rtb.AppendText(message + Environment.NewLine);
                _rtb.SelectionColor = _rtb.ForeColor;
                _rtb.ScrollToCaret();
            });
        }

        // =========================
        // 🔹 HELPERS
        // =========================
        public void LogTX(string msg)
        {
            AddLog("TX -> " + msg, Color.Cyan);
        }

        public void LogRX(byte[] data)
        {
            string parsed = _parser.Parse(data);
            AddLog("RX <- " + parsed, Color.Lime);
        }

        public void LogError(string msg)
        {
            AddLog("ERROR !! " + msg, Color.Red);
        }

        public void Clear()
        {
            SafeUI(() => _rtb.Clear());
        }

        // =========================
        // 🔥 THREAD SAFE WRAPPER
        // =========================
        private void SafeUI(Action action)
        {
            if (_rtb.InvokeRequired)
                _rtb.Invoke(action);
            else
                action();
        }
    }
}