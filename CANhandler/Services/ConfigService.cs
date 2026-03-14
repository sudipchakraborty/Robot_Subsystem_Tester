using System;
using System.Collections.Generic;
using System.Text;

using System.Text.Json;

namespace CANhandler.Services
{
    public static class ConfigService
    {
        private static readonly string ConfigFile =
            Path.Combine(Application.StartupPath, "config.json");

        private static Dictionary<string, object> _config =
            new Dictionary<string, object>();

        static ConfigService()
        {
            LoadConfig();
        }

        private static void LoadConfig()
        {
            if (!File.Exists(ConfigFile))
            {
                _config = new Dictionary<string, object>();
                return;
            }

            string json = File.ReadAllText(ConfigFile);

            _config = JsonSerializer.Deserialize<Dictionary<string, object>>(json)
                      ?? new Dictionary<string, object>();
        }

        private static void SaveConfig()
        {
            string json = JsonSerializer.Serialize(_config, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ConfigFile, json);
        }

        public static void Set(string key, object value)
        {
            _config[key] = value;
            SaveConfig();
        }

        public static T Get<T>(string key, T defaultValue = default!)
        {
            if (_config.ContainsKey(key))
            {
                try
                {
                    return JsonSerializer.Deserialize<T>(_config[key].ToString()!);
                }
                catch
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static Dictionary<string, object> GetAll()
        {
            return _config;
        }
    }
}
