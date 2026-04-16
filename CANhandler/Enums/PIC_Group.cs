using System;
using System.Collections.Generic;
using System.Text;

namespace CANhandler.Enums
{
    public static class PICHelper
    {
        public static class CommandHelper
        {
            public static List<Command> GetCommands(PIC_Group group)
            {
                switch (group)
                {
                    case PIC_Group.DISPENSER:
                        return new List<Command>
                {
                    Command.Who_Are_You,
                    Command.Dispense_Timer_Based,
                    Command.Dispense_Weight_Based,
                    Command.Open_Valve,
                    Command.Close_Valve
                };

                    case PIC_Group.MOTOR:
                        return new List<Command>
                {
                    Command.Who_Are_You,
                    Command.LED_TOGGLING_1,
                    Command.LED_TOGGLING_2
                };

                    case PIC_Group.WTS:
                        return new List<Command>
                {
                    Command.Who_Are_You,
                    Command.Dispense_Weight_Based
                };

                    default:
                        return new List<Command>
                {
                    Command.Who_Are_You
                };
                }
            }
        }


        public static PIC_Group GetGroup(PIC_Address pic)
        {
            switch (pic)
            {
                // ===== Grains =====
                case PIC_Address.PIC_DISP_3X3_GRAINS:
                case PIC_Address.PIC_DISP_6X6_GRAINS:
                    return PIC_Group.DISPENSER;

                // ===== Liquid =====
                case PIC_Address.PIC_DISP_3X3_LIQUID:
                case PIC_Address.PIC_DISP_6X6_LIQUID:
                    return PIC_Group.DISPENSER;

                // ===== Puree =====
                case PIC_Address.PIC_DISP_3X3_PUREE:
                case PIC_Address.PIC_DISP_6X6_PUREE:
                    return PIC_Group.DISPENSER;

                // ===== Motors =====
                case PIC_Address.PIC_MOTOR_X:
                case PIC_Address.PIC_MOTOR_Y:
                case PIC_Address.PIC_MOTOR_R1:
                case PIC_Address.PIC_MOTOR_R2:
                case PIC_Address.PIC_MOTOR_R3:
                case PIC_Address.PIC_MOTOR_R4:
                case PIC_Address.PIC_MOTOR_R5:
                case PIC_Address.PIC_MOTOR_L1:
                case PIC_Address.PIC_MOTOR_L2:
                case PIC_Address.PIC_MOTOR_L3:
                case PIC_Address.PIC_MOTOR_L4:
                    return PIC_Group.MOTOR;

                // ===== WTS =====
                case PIC_Address.PIC_WTS:
                    return PIC_Group.WTS;

                default:
                    return PIC_Group.GENERIC;
            }
        }
    }

    public enum PIC_Group
    {
        DISPENSER,
        MOTOR,
        WTS,
        GENERIC
    }


}
