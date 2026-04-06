using CANhandler.Models;
using CANhandler.Protocol;
using System;
using System.Collections.Generic;
using System.Text;
using CANhandler.Communication;

namespace CANhandler.Services
{
    public static class RowSendService
    {

        public static byte[] Get_Row(DataGridViewRow row)
        {
            if (row == null || row.IsNewRow)
                return Array.Empty<byte>();   // safer than null

            var step = GridProgramConverter.ReadRow(row);

            DispenseRequest req = new DispenseRequest
            {
                //DispenserType = step.PicType,
                //Action = step.Action,
                //Command = step.Command,
                //MSB = Convert.ToString(step.MSB),
                //LSB = Convert.ToString(step.LSB)
            };

            KBusPacket pkt = DispenserCommandService.CreatePacket(req);

            //byte[] buffer = KBusBuilder.BuildPacket(pkt);

            //return buffer;
            return null; // Placeholder for actual byte array to be returned
        }
    }
}