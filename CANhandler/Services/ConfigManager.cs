using System;
using System.Collections.Generic;
using System.Text;

using System.Text.Json;
using CANhandler.Models;

namespace CANhandler.Services
{
    public static class ConfigManager
    {
        private static readonly string ConfigFile =
            Path.Combine(Application.StartupPath, "config.json");

        public static AppConfig Config { get; private set; } = new();

        public static void Load()
        {
            if (!File.Exists(ConfigFile))
            {
                Save();
                return;
            }

            string json = File.ReadAllText(ConfigFile);

            Config = JsonSerializer.Deserialize<AppConfig>(json)
                     ?? new AppConfig();
        }

        public static void Save()
        {
            string json = JsonSerializer.Serialize(Config,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(ConfigFile, json);
        }
    }
}