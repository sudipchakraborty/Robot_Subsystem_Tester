using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Services
{
    using System;
    using System.IO.Ports;
    using System.Text;

    namespace CANhandler.Services
    {
        public class SerialDebugService
        {
            private SerialPort _serialPort;

            public event Action<string> OnDataReceived;

            public bool IsConnected => _serialPort != null && _serialPort.IsOpen;

            public void Connect(string port, int baudrate)
            {
                if (_serialPort != null && _serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort = new SerialPort(port, baudrate);
                _serialPort.Encoding = Encoding.ASCII;
                _serialPort.DataReceived += SerialPort_DataReceived;

                _serialPort.Open();
            }

            public void Disconnect()
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.DataReceived -= SerialPort_DataReceived;
                    _serialPort.Close();
                }
            }

            private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                try
                {
                    string data = _serialPort.ReadExisting();

                    // 🔥 Raise event
                    OnDataReceived?.Invoke(data);
                }
                catch (Exception ex)
                {
                    OnDataReceived?.Invoke($"[ERROR] {ex.Message}");
                }
            }

            public void Send(string data)
            {
                if (IsConnected)
                    _serialPort.Write(data);
            }
        }
    }
}
