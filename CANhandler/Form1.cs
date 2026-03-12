using CANhandler.CANhandler;
using System.IO.Ports;
using System.Text;
using static CANhandler.ProtocolConstants;


namespace CANhandler
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort;
        private List<byte> rxBuffer = new List<byte>();
        private int expectedLength = -1;
        KBusComm _kbus;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pb_connect.BackColor = Color.Gray;
        }


        //private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    try
        //    {
        //        int bytesToRead = _serialPort.BytesToRead;
        //        byte[] buffer = new byte[bytesToRead];
        //        _serialPort.Read(buffer, 0, bytesToRead);

        //        foreach (byte b in buffer)
        //        {
        //            rxBuffer.Add(b);

        //            // Step 1: Check header
        //            if (rxBuffer.Count >= 2)
        //            {
        //                if (rxBuffer[0] != 0x66 || rxBuffer[1] != 0x55)
        //                {
        //                    rxBuffer.RemoveAt(0); // shift until valid header
        //                    continue;
        //                }
        //            }

        //            // Step 2: Get expected length from 3rd byte
        //            if (rxBuffer.Count == 3)
        //            {
        //                expectedLength = rxBuffer[2];
        //            }

        //            // Step 3: Check if full packet received
        //            if (expectedLength > 0 && rxBuffer.Count >= expectedLength)
        //            {
        //                byte[] fullPacket = rxBuffer.GetRange(0, expectedLength).ToArray();

        //                rxBuffer.RemoveRange(0, expectedLength);
        //                expectedLength = -1;

        //                ProcessPacket(fullPacket);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        //private void ProcessPacket(byte[] packet)
        //{
        //    string hex = BitConverter.ToString(packet).Replace("-", " ");

        //    this.Invoke(new MethodInvoker(delegate
        //    {
        //        textBoxReceive.AppendText("RX: " + hex + Environment.NewLine);

        //        KBusPacket pkt = KBusParser.Parse(packet);

        //        if (pkt != null)
        //        {
        //            textBoxReceive.AppendText(
        //                $"Addr: {pkt.Address:X4}  RW:{pkt.RWFlag}  DataLen:{pkt.Data.Length}\r\n");
        //        }
        //    }));
        //}


        //private void ProcessCANFrame(string frame)
        //{
        //    try
        //    {
        //        string id = "";
        //        string dlc = "";
        //        string dataBytes = "";

        //        string[] parts = frame.Split(' ');

        //        foreach (string part in parts)
        //        {
        //            if (part.StartsWith("ID:"))
        //                id = part.Replace("ID:", "");

        //            if (part.StartsWith("DLC:"))
        //                dlc = part.Replace("DLC:", "");

        //            if (part.StartsWith("DATA:"))
        //                dataBytes = frame.Substring(frame.IndexOf("DATA:") + 5);
        //        }

        //        // Display in textbox or DataGridView
        //        textBoxReceive.AppendText(
        //            $"ID: {id}  DLC: {dlc}  DATA: {dataBytes}" + Environment.NewLine
        //        );
        //    }
        //    catch
        //    {
        //        textBoxReceive.AppendText("Invalid Frame" + Environment.NewLine);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            KBusPacket pkt = new KBusPacket();
       
            pkt.Multicast = 0x00;
            pkt.Address = Address.MotorDriver.R5;
            pkt.RWFlag = 1;
            pkt.CmdParameter = Command.LED_TOGGLING_2;
            pkt.Data = new byte[] { 0x01 };

            byte[] sendBuffer = KBusBuilder.BuildPacket(pkt);
            byte[] response = _kbus.SendAndReceive(sendBuffer);

            if (response != null)
            {
                string hex = BitConverter.ToString(response);
                MessageBox.Show("Response: " + hex);
            }
            else
            {
                MessageBox.Show("No response (timeout)");
            }
        }



        //private void SendCANFrame(string id, byte[] data)
        //{
        //    if (_serialPort == null || !_serialPort.IsOpen)
        //    {
        //        MessageBox.Show("Serial Port Not Open");
        //        return;
        //    }

        //    try
        //    {
        //        int dlc = data.Length;

        //        // Convert data bytes to HEX string
        //        StringBuilder sb = new StringBuilder();
        //        foreach (byte b in data)
        //        {
        //            sb.Append(b.ToString("X2") + " ");
        //        }

        //        string frame = $"ID:{id} DLC:{dlc} DATA:{sb.ToString().Trim()}";

        //        _serialPort.WriteLine(frame);

        //        // Optional: show in UI as TX
        //        textBoxReceive.AppendText(
        //            $"TX -> {frame}" + Environment.NewLine
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Send Error: " + ex.Message);
        //    }
        //}

        private void textBoxReceive_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM11";// txt_Port.Text;// "COM11";   // Change to your port
            _serialPort.BaudRate = 38400;// Convert.ToInt16(txt_Port.Text);// 115200;   // Match your MCU baud rate
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            _kbus = new KBusComm(_serialPort);

            //_serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                _serialPort.Open();
                //MessageBox.Show("Serial Port Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
