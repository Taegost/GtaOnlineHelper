using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GTA_Online_Helper
{
    class ErrorHandling
    {
        static string buildEnv = "";
#if Debug
        buildEnv = "DEBUG";
#elif Release
        buildEnv = "RELEASE";
#endif
        static private string logDirectory = "";

        public ErrorHandling()
        {
            logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", buildEnv);
            if (!Directory.Exists(logDirectory)) { Directory.CreateDirectory(logDirectory); }
        } // constructor

        static public void WriteToLog(string input)
        {
            string fileName = $"{DateTime.Now.ToString("ErrorLog_yyyyMMdd")}";
            File.AppendAllTextAsync(Path.Combine(logDirectory, fileName), input);
            Console.WriteLine(input);
        } // method WriteToLog

    } // class ErrorHandling
}
