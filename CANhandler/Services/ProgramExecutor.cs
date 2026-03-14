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

        public ProgramExecutor(KBusComm kbus)
        {
            _kbus = kbus;
        }

        public async Task RunProgramAsync(List<ProgramStep> steps)
        {
            foreach (var step in steps)
            {
                if (!step.Enable)
                    continue;

                for (int i = 0; i < step.Loop; i++)
                {
                    DispenseRequest req = new DispenseRequest
                    {
                        DispenserType = step.PicType,
                        Action = step.Action,
                        Command = step.Command,
                        MSB =Convert.ToString(step.MSB),
                        LSB = Convert.ToString(step.LSB)
                    };

                    KBusPacket pkt = DispenserCommandService.CreatePacket(req);

                    byte[] buffer = KBusBuilder.BuildPacket(pkt);

                    //_kbus.SendAndReceive(buffer);
                    _kbus.SendOnly(buffer);

                    await Task.Delay(step.Delay);
                }
            }
        }
    }
}