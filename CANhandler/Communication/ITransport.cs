using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Communication
{
    public interface ITransport
    {
        bool IsConnected { get; }

        void Connect();
        void Disconnect();

        void Send(byte[] data);

        event Action<byte[]> DataReceived;
    }
}