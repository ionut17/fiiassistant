using System;
using System.IO;

namespace Server.Logger
{
    public class FileLogger : Logger
    {
        private const string FilePath = "./FIIAssistantLogging.txt";

        public override void Log(string message)
        {
            using (var streamWriter = File.AppendText(FilePath))
            {
                streamWriter.WriteLine(DateTime.Now + ": " + message);
                streamWriter.Close();
            }
        }

        public static void ClearLogging()
        {
            using (var streamWriter = new StreamWriter(FilePath))
            {
                streamWriter.Write("");
                streamWriter.Close();
            }
        }
    }
}