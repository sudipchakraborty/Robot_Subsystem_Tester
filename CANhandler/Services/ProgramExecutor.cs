using CANhandler.Communication;
using CANhandler.Models;
using CANhandler.Protocol;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CANhandler.Services
{
    public class ProgramExecutor
    {
        private ITransport _transport = null;
        private readonly DataGridView _grid;

        private volatile bool _isPaused = false;
        private volatile bool _isStopped = false;

        // 🔥 Improve Windows timer resolution (~1ms)
        [DllImport("winmm.dll")]
        public static extern uint timeBeginPeriod(uint uMilliseconds);

        [DllImport("winmm.dll")]
        public static extern uint timeEndPeriod(uint uMilliseconds);

        public ProgramExecutor(DataGridView grid, ITransport transport)
        {
            _transport = transport;
            _grid = grid;
        }

        // =========================
        // 🚀 MAIN EXECUTION
        // =========================
        public async Task RunProgramAsync(List<ProgramStep> steps)
        {
            // ✅ Validate before execution
            if (!ValidateSteps(steps))
                return;

            _isStopped = false;

            timeBeginPeriod(1); // improve timing

            try
            {
                do
                {
                    for (int rowIndex = 0; rowIndex < steps.Count; rowIndex++)
                    {
                        if (_isStopped)
                            return;

                        var step = steps[rowIndex];

                        if (!step.Enable)
                            continue;

                        // Highlight row
                        _grid.Invoke(() =>
                        {
                            GridExecutionService.HighlightExecutingRow(_grid, rowIndex);
                        });

                        for (int i = 0; i < step.Loop; i++)
                        {
                            if (_isStopped)
                                return;

                            await WaitIfPaused();

                            var st = GridProgramConverter.ReadRow(_grid.Rows[rowIndex]);
                            byte[] buffer = KBusBuilder.BuildPacket_From_GridRow(st);

                            _transport.Send(buffer);

                            // ✅ Interruptible delay
                            await InterruptibleDelay(step.Delay);
                        }
                    }

                } while (!_isStopped && ConfigManager.Config.UI.LoopEnable);
            }
            finally
            {
                timeEndPeriod(1); // restore system timer
            }
        }

        // =========================
        // 🔍 VALIDATION
        // =========================
        private bool ValidateSteps(List<ProgramStep> steps)
        {
            for (int i = 0; i < steps.Count; i++)
            {
                var step = steps[i];

                if (!step.Enable)
                    continue;

                if (step.Loop <= 0)
                {
                    _grid.Invoke(() =>
                    {
                        _grid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    });

                    MessageBox.Show(
                        $"Row {i + 1}: Loop must be at least 1.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }
            }

            return true;
        }

        // =========================
        // ⏸ PAUSE HANDLER
        // =========================
        private async Task WaitIfPaused()
        {
            while (_isPaused)
            {
                await Task.Delay(50);

                if (_isStopped)
                    return;
            }
        }

        // =========================
        // ⏱ INTERRUPTIBLE DELAY
        // =========================
        private async Task InterruptibleDelay(int totalMs)
        {
            if (totalMs <= 0)
                return;

            int chunk = 5; // responsiveness
            int elapsed = 0;

            while (elapsed < totalMs)
            {
                if (_isStopped)
                    return;

                await WaitIfPaused();

                int delay = Math.Min(chunk, totalMs - elapsed);
                await Task.Delay(delay);

                elapsed += delay;
            }
        }

        // =========================
        // 🎮 CONTROL METHODS
        // =========================
        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }

        public void Stop()
        {
            _isStopped = true;
        }

        public void Reset()
        {
            _isStopped = true;
            _isPaused = false;

            _grid.Invoke(() =>
            {
                GridExecutionService.HighlightExecutingRow(_grid, 0);
            });
        }
    }
}