using System;
using System.Threading.Tasks;

namespace CANhandler.Communication
{
    public class SimulatorTransport : ITransport
    {
        public bool IsConnected { get; private set; }
        public bool connected { get; set; }

        public event Action<byte[]>? DataReceived;

        public SimulatorTransport()
        {
            connected = false;
        }

        public void Connect()
        {
            try
            {
                // No real connection needed
                IsConnected = true;
                connected = true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Simulator connect failed: {ex.Message}");
            }
        }

        public void Disconnect()
        {
            try
            {
                IsConnected = false;
                connected = false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Simulator disconnect failed: {ex.Message}");
            }
        }

        public async void Send(byte[] data)
        {
            if (!IsConnected)
                throw new Exception("Simulator not connected");

            try
            {
                // 🔹 Simulate processing delay (like real device)
                await Task.Delay(100);

                // 🔹 Generate response
                //byte[] response = ProcessPacket(data);

                // 🔹 Raise DataReceived event (same as Serial)
                DataReceived?.Invoke(data);

                // 🔥 Optional: continuous streaming (like weight feedback)
                //_ = SimulateStreaming();
            }
            catch (Exception ex)
            {
                throw new Exception($"Simulator send failed: {ex.Message}");
            }
        }

        // 🔥 Core simulation logic
        private byte[] ProcessPacket(byte[] request)
        {
            // 👉 TODO: Replace with your real protocol logic

            // Example: simple ACK packet
            return new byte[] { 0xAA, 0x55 };
        }

        // 🔥 Continuous fake device feedback
        private async Task SimulateStreaming()
        {
            for (int i = 0; i <= 100; i += 10)
            {
                await Task.Delay(200);

                // Example: weight data packet
                byte[] stream = new byte[]
                {
                    0x01,       // type
                    (byte)i     // value
                };

                DataReceived?.Invoke(stream);
            }

            // Simulate error packet
            byte[] error = new byte[] { 0xFF, 0x00 };
            DataReceived?.Invoke(error);
        }
    }
}