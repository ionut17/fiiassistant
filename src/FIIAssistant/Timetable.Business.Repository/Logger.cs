using System;
using HtmlAgilityPack;

namespace Timetable.Business.Repository
{
    class Logger
    {

        public void Log(HtmlDocument document)
        {
            Console.WriteLine("Parsed: "+document.ToString());
        }

        public void Ok()
        {
            Console.WriteLine("Parsed succesfully!");
        }

    }
}