using System;
using System.Collections.Generic;
using System.Text;

using System.Net.WebSockets;

namespace CANhandler.Communication
{
    public class WebSocketTransport : ITransport
    {
        private ClientWebSocket _socket = new();

        public bool IsConnected => _socket.State == WebSocketState.Open;

        public event Action<byte[]>? DataReceived;

        public async void Connect()
        {
            await _socket.ConnectAsync(
                new Uri("ws://localhost:8080"),
                CancellationToken.None);
        }

        public async void Send(byte[] data)
        {
            await _socket.SendAsync(
                data,
                WebSocketMessageType.Binary,
                true,
                CancellationToken.None);
        }

        public void Disconnect()
        {
            _socket.Dispose();
        }
    }
}