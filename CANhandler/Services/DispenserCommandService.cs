using CANhandler.Constants;
using CANhandler.Enums;
using CANhandler.Models;
using System;
using System;
using System.Collections.Generic;
using System.Text;
using static CANhandler.Enums.Address;

namespace CANhandler.Services
{
    public class DispenserCommandService
    {
        public static KBusPacket CreatePacket(DispenseRequest request)
        {
            KBusPacket pkt = new KBusPacket();

            pkt.Multicast = ProtocolConstants.Multicast;

            // Address
            var field = typeof(Dispenser).GetField(request.DispenserType);
            pkt.Address = (byte)(int)field.GetValue(null);

            // RW Flag
            field = typeof(ProtocolConstants).GetField(request.Action);
            pkt.RWFlag = (byte)field.GetValue(null);

            // Command
            Command cmd = (Command)Enum.Parse(typeof(Command), request.Command);
            pkt.CmdParameter = (byte)cmd;

            // Data generation
            switch (cmd)
            {
                case Command.Dispense:
                    pkt.Data = new byte[]
                    {
                        (byte)( Convert.ToByte(request.MSB) / 100),
                        Convert.ToByte(request.LSB)
                    };
                    break;

                case Command.PB6_LED:
                case Command.PB5_LED:
                    pkt.Data = new byte[]
                    {
                        0,
                       Convert.ToByte(request.LSB)
                    };
                    break;

                default:
                    pkt.Data = new byte[] { 0, 0 };
                    break;
            }

            return pkt;
        }
    }
}