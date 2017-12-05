using System;
using System.IO;
using Timetable.Data.Model.Common;

namespace Timetable.Business.Repository
{
    internal class Logger
    {
        private const string FilePath = "./week-timetable.log";

        public void Log(WeekTimetable timetable)
        {
            Console.WriteLine("Requested: " + timetable.Title);
            using (var streamWriter = File.AppendText(FilePath))
            {
                streamWriter.WriteLine(DateTime.Now + ": " + timetable.Title);
                streamWriter.Close();
            }
        }

        public static void Clear()
        {
            using (var streamWriter = new StreamWriter(FilePath))
            {
                streamWriter.Write("");
                streamWriter.Close();
            }
        }
    }
}