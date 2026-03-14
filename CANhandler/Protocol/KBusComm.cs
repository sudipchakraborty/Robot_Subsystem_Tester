using System;
using System.Collections.Generic;
using System.Text;

using CANhandler.Communication;

public class KBusComm
{
    private ITransport _transport;

    public KBusComm(ITransport transport)
    {
        _transport = transport;

        _transport.DataReceived += OnDataReceived;
    }

    public void SendOnly(byte[] data)
    {
        _transport.Send(data);
    }

    private void OnDataReceived(byte[] data)
    {
        // protocol parser here
    }
}