using CANhandler.Communication;
using CANhandler.Models;
using CANhandler.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Services
{
    public class ProgramExecutor
    {
        private readonly KBusComm _kbus;
        private readonly DataGridView _grid;
        private bool _isPaused = false;
        private bool _isStopped = false;

        public ProgramExecutor(KBusComm kbus, DataGridView grid)
        {
            _kbus = kbus;
            _grid = grid;
        }

        public async Task RunProgramAsync(List<ProgramStep> steps)
        {
            _isStopped = false;

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

                        // 🔥 Pause handling
                        while (_isPaused)
                        {
                            await Task.Delay(100);
                        }

                        DispenseRequest req = new DispenseRequest
                        {
                            DispenserType = step.PicType,
                            Action = step.Action,
                            Command = step.Command,
                            MSB = Convert.ToString(step.MSB),
                            LSB = Convert.ToString(step.LSB)
                        };

                        KBusPacket pkt = DispenserCommandService.CreatePacket(req);
                        byte[] buffer = KBusBuilder.BuildPacket(pkt);

                        UIConfig config = ConfigManager.Config.UI;

                        if (config.SelectedInterface == InterfaceType.RealHardware)
                            _kbus?.SendOnly(buffer);

                        await Task.Delay(step.Delay);
                    }
                }

            } while (!_isStopped && ConfigManager.Config.UI.LoopEnable);
        }


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