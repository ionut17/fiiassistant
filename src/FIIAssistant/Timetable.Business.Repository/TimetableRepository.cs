using System;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using Timetable.Data.Model.Common;
using Timetable.Data.Model.Interfaces;

namespace Timetable.Business.Repository
{
    public class TimetableRepository<TRequest> : ITimetableRepository<TRequest, WeekTimetable>
        where TRequest : Request
    {
        private readonly WebClient _webClient;
        private readonly Logger _logger;

        public TimetableRepository()
        {
            _webClient = new WebClient();
            _logger = new Logger();;
        }

        public WeekTimetable GetTimetable(TRequest entity)
        {
            var weekTimetable = new WeekTimetable();
            var document = new HtmlDocument();
            document.OptionReadEncoding = false;

            var url = new Uri(entity.GetAddress());
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET"; 
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    document.Load(stream, Encoding.GetEncoding("ISO-8859-1"));
                    weekTimetable.Title = document.DocumentNode.Descendants("h2").First().InnerText.Replace("\r\n","").Trim();
                    var table = document.DocumentNode.Descendants("table").First();
                    _logger.Log(weekTimetable);
                }
            }

            return weekTimetable;
        }
    }
}