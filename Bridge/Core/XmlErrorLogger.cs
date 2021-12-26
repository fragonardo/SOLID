using System;
using System.IO;

namespace Bridge.Core
{
    public class XmlErrorLogger : IErrorLogger
    {
        public void Log(string msg)
        {
            msg = $"<error><timestamp>{DateTime.Now}</timestamp><message>{msg}</message></error>";
            File.AppendAllText($"{AppSettings.LogFileFolder}/errolog.xml", msg);
        } 
    }
}