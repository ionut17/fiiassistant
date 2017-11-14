using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Logger
{
    public class FileLogger: Logger
    {
        public static string filePath = "D:\\FIIAssistantLogging.txt";

        public override void Log(string message)
        {
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                streamWriter.WriteLine(DateTime.Now.ToString() +": " +message);
                streamWriter.Close();
            }
        }

        public static void ClearLogging()
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.Write("");
                streamWriter.Close();
            }
        }
    }
}
