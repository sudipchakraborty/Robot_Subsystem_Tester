using System;
using System.Collections.Generic;
using System.Text;

using System.IO.Ports;

namespace CANhandler.Communication
{
    public class SerialTransport : ITransport
    {
        private SerialPort _port;

        public bool IsConnected => _port.IsOpen;

        public event Action<byte[]>? DataReceived;

        public SerialTransport(string port, int baud)
        {
            _port = new SerialPort(port, baud);
            _port.DataReceived += Port_DataReceived;
        }

        public void Connect()
        {
            if (!_port.IsOpen)
                _port.Open();
        }

        public void Disconnect()
        {
            if (_port.IsOpen)
                _port.Close();
        }

        public void Send(byte[] data)
        {
            _port.Write(data, 0, data.Length);
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = _port.BytesToRead;

            byte[] buffer = new byte[bytes];

            _port.Read(buffer, 0, bytes);

            DataReceived?.Invoke(buffer);
        }
    }
}