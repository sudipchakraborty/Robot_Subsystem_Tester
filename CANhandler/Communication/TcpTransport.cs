using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Sockets;

namespace CANhandler.Communication
{
    public class TcpTransport : ITransport
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public bool IsConnected => _client?.Connected ?? false;

        public event Action<byte[]>? DataReceived;

        public TcpTransport(string ip, int port)
        {
            _client = new TcpClient();
            _client.Connect(ip, port);

            _stream = _client.GetStream();
        }

        public void Connect() { }

        public void Disconnect()
        {
            _client.Close();
        }

        public void Send(byte[] data)
        {
            _stream.Write(data, 0, data.Length);
        }
    }
}
