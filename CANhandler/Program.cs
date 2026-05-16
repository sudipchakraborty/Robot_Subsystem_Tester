using CANhandler.Services;

// 16.05.2026: 15:02
namespace CANhandler
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ConfigManager.Load();
            Application.Run(new frm_main());
        }
    }
}