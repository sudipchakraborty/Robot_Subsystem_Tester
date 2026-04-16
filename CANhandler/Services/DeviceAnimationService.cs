using System;
using System.Drawing;
using System.Windows.Forms;

using WinTimer = System.Windows.Forms.Timer;

using CANhandler.Enums;

namespace CANhandler.Services
{
    public enum DeviceType
    {
        NONE,
        GRAIN_DISPENSER,
        LIQUID_DISPENSER,
        MOTOR
    }

    public class DeviceAnimationService
    {
        private PictureBox _pictureBox;
        //private Timer _timer;

        private WinTimer _timer;

        

        private DeviceType _currentDevice = DeviceType.NONE;
        private bool _valveOpen = false;
        private int _dispenseCounter = 0;

        // Images (you can replace with real PNGs)
        private Image imgIdle;
        private Image imgFlow1;
        private Image imgFlow2;

        public DeviceAnimationService(PictureBox pb)
        {
            _pictureBox = pb;

            _timer = new WinTimer();
            _timer.Interval = 200; // animation speed
            _timer.Tick += OnTick;

            LoadDefaultImages();
        }

        private void LoadDefaultImages()
        {
            // 🔥 TEMP: Replace with actual resources later
            imgIdle = CreateImage(Color.Gray, "IDLE");
            imgFlow1 = CreateImage(Color.Yellow, "FLOW 1");
            imgFlow2 = CreateImage(Color.Orange, "FLOW 2");
        }

        // =========================
        // 🔹 SELECT DEVICE
        // =========================
        public void SetDevice(DeviceType type)
        {
            _currentDevice = type;
            _valveOpen = false;
            _timer.Stop();

            UpdateUI(imgIdle);
        }

        // =========================
        // 🔹 COMMAND HANDLER
        // =========================
        public void ExecuteCommand(Command cmd, int value = 0)
        {
            switch (cmd)
            {
                case Command.Open_Valve:
                    _valveOpen = true;
                    _timer.Start();
                    break;

                case Command.Close_Valve:
                    _valveOpen = false;
                    _timer.Stop();
                    UpdateUI(imgIdle);
                    break;

                case Command.Dispense_Timer_Based:
                    StartTimedDispense(value);
                    break;

                case Command.Dispense_Weight_Based:
                    StartWeightDispense(value);
                    break;
            }
        }

        // =========================
        // 🔹 TIMER ANIMATION
        // =========================
        private void OnTick(object sender, EventArgs e)
        {
            if (!_valveOpen) return;

            _dispenseCounter++;

            if (_dispenseCounter % 2 == 0)
                UpdateUI(imgFlow1);
            else
                UpdateUI(imgFlow2);
        }

        // =========================
        // 🔹 DISPENSE LOGIC
        // =========================
        private void StartTimedDispense(int durationMs)
        {
            _valveOpen = true;
            _timer.Start();
            WinTimer t = new WinTimer();
            t.Interval = durationMs;
            t.Tick += (s, e) =>
            {
                t.Stop();
                ExecuteCommand(Command.Close_Valve);
            };
            t.Start();
        }

        private void StartWeightDispense(int weight)
        {
            // 🔥 Simulated logic
            _valveOpen = true;
            _timer.Start();

            int simulatedTime = weight * 10; // adjust

            StartTimedDispense(simulatedTime);
        }

        // =========================
        // 🔹 UI UPDATE (THREAD SAFE)
        // =========================
        private void UpdateUI(Image img)
        {
            if (_pictureBox.InvokeRequired)
            {
                _pictureBox.Invoke(new Action(() => _pictureBox.Image = img));
            }
            else
            {
                _pictureBox.Image = img;
            }
        }

        // =========================
        // 🔹 SIMPLE IMAGE GENERATOR
        // =========================
        private Image CreateImage(Color color, string text)
        {
            Bitmap bmp = new Bitmap(200, 200);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(color);
                g.DrawString(text,
                    new Font("Consolas", 12),
                    Brushes.Black,
                    new PointF(20, 80));
            }

            return bmp;
        }
    }
}