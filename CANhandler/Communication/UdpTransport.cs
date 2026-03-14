using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace CANhandler.Communication
{
    public class UdpTransport : ITransport
    {
        private UdpClient _udp;
        private IPEndPoint _endpoint;

        public bool IsConnected => true;

        public event Action<byte[]>? DataReceived;

        public UdpTransport(string ip, int port)
        {
            _udp = new UdpClient();
            _endpoint = new IPEndPoint(IPAddress.Parse(ip), port);
        }

        public void Connect() { }

        public void Disconnect()
        {
            _udp.Close();
        }

        public void Send(byte[] data)
        {
            _udp.Send(data, data.Length, _endpoint);
        }
    }
}