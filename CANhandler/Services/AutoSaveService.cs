using System;
using System.Collections.Generic;
using System.Text;

using CANhandler.Models;
using System.Text.Json;

namespace CANhandler.Services
{
    public static class AutoSaveService
    {
        //private static readonly string AutoSaveFile =
        //    Path.Combine(Application.StartupPath, "autosave_program.json");

        public static void Save(List<ProgramStep> steps, string path)
        {
            var json = JsonSerializer.Serialize(steps, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }

        public static List<ProgramStep> Load(string path)
        {
            if (!File.Exists(path))
                return new List<ProgramStep>();

            string json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<List<ProgramStep>>(json)
                   ?? new List<ProgramStep>();
        }
    }
}
