using CANhandler.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Management;

namespace CANhandler.Communication
{
    public class SerialPortSearchService
    {
        public List<SerialPortInfo> GetAvailablePorts()
        {
            var portList = new List<SerialPortInfo>();

            try
            {
                using (var searcher = new ManagementObjectSearcher(
                    "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'"))
                {
                    foreach (var device in searcher.Get())
                    {
                        string name = device["Name"]?.ToString();

                        if (string.IsNullOrEmpty(name))
                            continue;

                        string portName = ExtractPortName(name);

                        if (!string.IsNullOrEmpty(portName))
                        {
                            portList.Add(new SerialPortInfo
                            {
                                PortName = portName,
                                Description = name
                            });
                        }
                    }
                }

                // Fallback (if WMI fails)
                if (portList.Count == 0)
                {
                    portList = SerialPort.GetPortNames()
                        .Select(p => new SerialPortInfo
                        {
                            PortName = p,
                            Description = "Unknown Device"
                        })
                        .ToList();
                }

                // Sort COM ports numerically
                return portList
                    .OrderBy(p => int.Parse(p.PortName.Replace("COM", "")))
                    .ToList();
            }
            catch
            {
                return new List<SerialPortInfo>();
            }
        }

        private string ExtractPortName(string fullName)
        {
            int start = fullName.LastIndexOf("(COM");
            if (start == -1) return null;

            int end = fullName.IndexOf(")", start);
            if (end == -1) return null;

            return fullName.Substring(start + 1, end - start - 1);
        }
    }
}
