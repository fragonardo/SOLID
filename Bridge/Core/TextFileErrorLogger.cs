using System;
using System.IO;

namespace Bridge.Core
{
    public class TextFileErrorLogger : IErrorLogger
    {
        public void Log(string msg)
        {
            msg += $"[{DateTime.Now}]";
            msg += "\r\n";
            File.AppendAllText($"{AppSettings.LogFileFolder}/errorLogs.txt", msg);
        }
    }
}