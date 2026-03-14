using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

namespace CANhandler.Communication
{
    public class KBusComm
    {
        private SerialPort _serialPort;
        private List<byte> _rxBuffer = new List<byte>();

        private byte[] _responsePacket = null;
        private AutoResetEvent _packetEvent = new AutoResetEvent(false);

        public KBusComm(SerialPort port)
        {
            _serialPort = port;
            _serialPort.DataReceived += SerialPort_DataReceived;
        }

        public byte[] SendAndReceive(byte[] txBuffer, int timeout = 1000)
        {
            _responsePacket = null;
            _packetEvent.Reset();

            lock (_rxBuffer)
            {
                _rxBuffer.Clear();
            }

            _serialPort.Write(txBuffer, 0, txBuffer.Length);

            if (_packetEvent.WaitOne(timeout))
                return _responsePacket;

            return null;
        }

        public void SendOnly(byte[] txBuffer)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
                throw new InvalidOperationException("Serial port is not open.");

            if (txBuffer == null || txBuffer.Length == 0)
                throw new ArgumentException("TX buffer empty");

            _serialPort.Write(txBuffer, 0, txBuffer.Length);
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = _serialPort.BytesToRead;
            byte[] data = new byte[bytes];

            _serialPort.Read(data, 0, bytes);

            lock (_rxBuffer)
            {
                _rxBuffer.AddRange(data);
                ProcessBuffer();
            }
        }

        private void ProcessBuffer()
        {
            while (_rxBuffer.Count >= 3)
            {
                // Check preamble 0x6655
                if (!(_rxBuffer[0] == 0x66 && _rxBuffer[1] == 0x55))
                {
                    _rxBuffer.RemoveAt(0);
                    continue;
                }

                int packetLength = _rxBuffer[2];

                if (_rxBuffer.Count < packetLength)
                    return;

                byte[] packet = _rxBuffer.GetRange(0, packetLength).ToArray();
                _rxBuffer.RemoveRange(0, packetLength);

                _responsePacket = packet;
                _packetEvent.Set();
            }
        }
    }
}