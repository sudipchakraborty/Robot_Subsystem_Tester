namespace CANhandler.Enums
{
    public enum PIC_Address : ushort
    {
        // ===== Dispenser 3x3 =====
        PIC_DISP_3X3_GRAINS = 101,
        PIC_DISP_3X3_LIQUID = 102,
        PIC_DISP_3X3_PUREE = 103,

        // ===== Dispenser 6x6 =====
        PIC_DISP_6X6_GRAINS = 104,
        PIC_DISP_6X6_LIQUID = 105,
        PIC_DISP_6X6_PUREE = 106,

        // ===== Other Devices =====
        PIC_REFRIGERATOR= 24,
        PIC_GRINDER = 25,
        PIC_IP = 26,
        PIC_CHIMNEY = 27,
        PIC_DISHWASHER = 28,
        PIC_WTS = 10,

        // ===== Motor Driver (Slave PIC) =====
        PIC_MOTOR_DRIVER_1 = 30,

        // ===== Stepper Motor Drivers =====
        PIC_MOTOR_X = 300,
        PIC_MOTOR_Y = 301,
        PIC_MOTOR_R1 = 302,
        PIC_MOTOR_R2 = 303,
        PIC_MOTOR_R3 = 304,
        PIC_MOTOR_R4 = 305,
        PIC_MOTOR_R5 = 306,

        PIC_MOTOR_L1 = 307,
        PIC_MOTOR_L2 = 308,
        PIC_MOTOR_L3 = 309,
        PIC_MOTOR_L4 = 310
    }
}