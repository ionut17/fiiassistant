using System;
using System.IO;

namespace Server.Logger
{
    public class FileLogger : Logger
    {
        public static string filePath = "D:\\FIIAssistantLogging.txt";

        public override void Log(string message)
        {
            using (var streamWriter = File.AppendText(filePath))
            {
                streamWriter.WriteLine(DateTime.Now + ": " + message);
                streamWriter.Close();
            }
        }

        public static void ClearLogging()
        {
            using (var streamWriter = new StreamWriter(filePath))
            {
                streamWriter.Write("");
                streamWriter.Close();
            }
        }
    }
}