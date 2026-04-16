using CANhandler.Helpers;

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CANhandler.Services
{
    public static class log
    {
        private static readonly ConcurrentQueue<string> _logQueue = new();
        private static readonly AutoResetEvent _signal = new(false);
        private static bool _isRunning = false;

        private static string _logFolder = Path.Combine(CommandHelper.GetProjectRoot(), "logs");
        //private static string _logFolder = Path.Combine(
        //    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")),
        //    "logs"
        //);
        private static DateTime _currentDate = DateTime.Now.Date;
        private static StreamWriter _writer;

        // =========================
        // 🚀 INIT
        // =========================
        public static void Start()
        {
            if (_isRunning) return;

            Directory.CreateDirectory(_logFolder);

            OpenWriter();

            _isRunning = true;

            Task.Run(ProcessQueue);
        }

        // =========================
        // 🛑 STOP
        // =========================
        public static void Stop()
        {
            _isRunning = false;
            _signal.Set();

            _writer?.Flush();
            _writer?.Close();
        }

        // =========================
        // ✍️ PUBLIC LOG METHODS
        // =========================
        public static void Info(string message)
        {
            Enqueue("INFO", message);
        }

        public static void Error(string message)
        {
            Enqueue("ERROR", message);
        }

        public static void Tx(string message)
        {
            Enqueue("TX", message);
        }

        public static void Rx(string message)
        {
            Enqueue("RX", message);
        }

        public static void push(string message)
        {
            Enqueue("LOG:", message);
        }



        // =========================
        // 🔧 INTERNAL
        // =========================
        private static void Enqueue(string type, string message)
        {
            string log = $"[{DateTime.Now:HH:mm:ss.fff}] [{type}] {message}";
            _logQueue.Enqueue(log);
            _signal.Set();
        }

        private static async Task ProcessQueue()
        {
            while (_isRunning)
            {
                _signal.WaitOne();

                while (_logQueue.TryDequeue(out string log))
                {
                    RotateIfNeeded();

                    await _writer.WriteLineAsync(log);
                }

                await _writer.FlushAsync();
            }
        }

        private static void RotateIfNeeded()
        {
            if (DateTime.Now.Date != _currentDate)
            {
                _writer?.Close();
                _currentDate = DateTime.Now.Date;
                OpenWriter();
            }
        }

        private static void OpenWriter()
        {
            string filePath = Path.Combine(
                _logFolder,
                $"log_{_currentDate:yyyy-MM-dd}.txt"
            );

            _writer = new StreamWriter(filePath, true, Encoding.UTF8)
            {
                AutoFlush = false
            };
        }
    }
}