using System;
using System.Collections.Generic;
using System.Text;

using System.Text.Json;
using CANhandler.Models;

namespace CANhandler.Services
{
    public static class ProgramFileService
    {
        public static void Save(string path, List<ProgramStep> steps)
        {
            string json = JsonSerializer.Serialize(steps, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }

        public static List<ProgramStep> Load(string path)
        {
            string json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<List<ProgramStep>>(json) ?? new List<ProgramStep>();
        }
    }
}