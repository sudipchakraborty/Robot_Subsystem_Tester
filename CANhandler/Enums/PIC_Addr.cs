namespace CANhandler.Enums
{
    public enum PIC_Address : ushort
    {
        // ===== Dispenser 3x3 =====
        DISP_3X3_GRAINS = 101,
        DISP_3X3_LIQUID = 102,
        DISP_3X3_PUREE = 103,

        // ===== Dispenser 6x6 =====
        DISP_6X6_GRAINS = 104,
        DISP_6X6_LIQUID = 105,
        DISP_6X6_PUREE = 106,

        // ===== Other Devices =====
        IP = 26,
        CHIMNEY = 27,
        DISHWASHER = 28,
        WTS = 29,

        // ===== Motor Driver (Slave PIC) =====
        MOTOR_DRIVER_1 = 30,

        // ===== Stepper Motor Drivers =====
        MOTOR_X = 300,
        MOTOR_Y = 301,

        MOTOR_R1 = 302,
        MOTOR_R2 = 303,
        MOTOR_R3 = 304,
        MOTOR_R4 = 305,
        MOTOR_R5 = 306,

        MOTOR_L1 = 307,
        MOTOR_L2 = 308,
        MOTOR_L3 = 309,
        MOTOR_L4 = 310
    }
}