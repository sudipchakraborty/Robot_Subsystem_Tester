using CANhandler.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CANhandler.Services
{
    public static class ConfigManager
    {
        //private static readonly string ConfigFile =
        //    Path.Combine(Application.StartupPath, "config.json");
        private static readonly string ConfigFile =
    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\config.json"));

        public static AppConfig Config { get; private set; } = new();

        public static void Load()
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() } // 👈 enum as string
            };

            if (!File.Exists(ConfigFile))
            {
                Config = new AppConfig();
                Save();
                return;
            }

            string json = File.ReadAllText(ConfigFile);

            Config = JsonSerializer.Deserialize<AppConfig>(json, options)
                     ?? new AppConfig();
        }

        public static void Save()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() } // 👈 enum as string
            };

            string json = JsonSerializer.Serialize(Config, options);

            File.WriteAllText(ConfigFile, json);
        }
    }
}