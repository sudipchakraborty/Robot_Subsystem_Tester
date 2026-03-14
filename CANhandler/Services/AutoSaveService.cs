using System;
using System.Collections.Generic;
using System.Text;

using CANhandler.Models;
using System.Text.Json;

namespace CANhandler.Services
{
    public static class AutoSaveService
    {
        private static readonly string AutoSaveFile =
            Path.Combine(Application.StartupPath, "autosave_program.json");

        public static void Save(List<ProgramStep> steps)
        {
            var json = JsonSerializer.Serialize(steps, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(AutoSaveFile, json);
        }

        public static List<ProgramStep> Load()
        {
            if (!File.Exists(AutoSaveFile))
                return new List<ProgramStep>();

            string json = File.ReadAllText(AutoSaveFile);

            return JsonSerializer.Deserialize<List<ProgramStep>>(json)
                   ?? new List<ProgramStep>();
        }
    }
}
