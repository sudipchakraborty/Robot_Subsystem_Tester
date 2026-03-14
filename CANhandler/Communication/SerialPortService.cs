using System;
using System.Collections.Generic;
using System.Text;

using System.IO.Ports;

namespace CANhandler.Communication
{
    public class SerialPortService
    {
        private SerialPort? _serialPort;

        public bool IsConnected => _serialPort != null && _serialPort.IsOpen;

        public event Action<byte[]>? DataReceived;

        public void Create(string portName, int baudRate)
        {
            _serialPort = new SerialPort(portName, baudRate);

            _serialPort.DataReceived += SerialPort_DataReceived;
        }

        public void Open()
        {
            if (_serialPort == null)
                throw new Exception("Serial port not created");

            if (!_serialPort.IsOpen)
                _serialPort.Open();
        }

        public void Close()
        {
            if (_serialPort == null)
                return;

            if (_serialPort.IsOpen)
                _serialPort.Close();
        }

        public void Disconnect()
        {
            if (_serialPort == null)
                return;

            try
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
            }
            finally
            {
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        public void Send(byte[] buffer)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
                throw new Exception("Serial port not open");

            _serialPort.Write(buffer, 0, buffer.Length);
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort == null)
                return;

            int bytes = _serialPort.BytesToRead;

            byte[] buffer = new byte[bytes];

            _serialPort.Read(buffer, 0, bytes);

            DataReceived?.Invoke(buffer);
        }
    }
}