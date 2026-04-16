using System;
using System.IO.Ports;

namespace CANhandler.Communication
{
    public class SerialTransport : ITransport
    {
        private readonly SerialPort _port;

        public bool IsConnected => _port != null && _port.IsOpen;
        public bool connected { get; set; }

        public event Action<byte[]>? DataReceived;

        public SerialTransport(string port, int baud)
        {
            _port = new SerialPort
            {
                PortName = port,
                BaudRate = baud,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };

            _port.DataReceived += Port_DataReceived;
            connected=false;
        }

        public void Connect()
        {
            try
            {
                if (!_port.IsOpen)
                    _port.Open();
                connected = true;
            }
            catch (Exception ex)
            {
                //throw new Exception($"Serial connect failed: {ex.Message}");
                connected = false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (_port.IsOpen)
                    _port.Close();
                    connected = false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Serial disconnect failed: {ex.Message}");
            }
        }

        public void Send(byte[] data)
        {
            if (!IsConnected)
                throw new Exception("Serial port not connected");

            try
            {
                _port.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                throw new Exception($"Serial send failed: {ex.Message}");
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytes = _port.BytesToRead;
                if (bytes <= 0) return;

                byte[] buffer = new byte[bytes];
                _port.Read(buffer, 0, bytes);

                DataReceived?.Invoke(buffer);
            }
            catch (Exception ex)
            {
                // optional: log instead of throw (important for stability)
                Console.WriteLine($"Serial receive error: {ex.Message}");
            }
        }
    }
}