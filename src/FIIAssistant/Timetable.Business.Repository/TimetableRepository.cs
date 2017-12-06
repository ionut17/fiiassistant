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
        private readonly string[] _days = {"Luni", "Marti", "Miercuri", "Joi", "Vineri"};
        private readonly Logger _logger;
        private readonly WebClient _webClient;

        public TimetableRepository()
        {
            _webClient = new WebClient();
            _logger = new Logger();
        }

        public WeekTimetable GetTimetable(TRequest entity)
        {
            var weekTimetable = new WeekTimetable();
            var document = new HtmlDocument {OptionReadEncoding = false};

            var url = new Uri(entity.GetAddress());
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET";
            using (var response = (HttpWebResponse) request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    document.Load(stream, Encoding.GetEncoding("ISO-8859-1"));
                    weekTimetable.Title = ExtractContent(document.DocumentNode.Descendants("h2").First().InnerText);
                    var table = document.DocumentNode.Descendants("table").First();
                    var rows = table.SelectNodes("//tr");
                    var day = new DayTimetable();
                    var index = 0;
                    foreach (var row in rows)
                    {
                        if (row.InnerText.Contains("De la") && index > 0)
                        {
                            break;
                        }
                        //Check if it's a day of the week
                        var currentContent = ExtractContent(row.InnerText);
                        var currentDay = currentContent.Split(" ")[0];
                        if (_days.Contains(currentDay))
                        {
                            day = new DayTimetable
                            {
                                Day = currentContent
                            };
                            weekTimetable.Days.Add(day);
                        }
                        //Add entries to the day
                        else if (index > 0)
                        {
                            var cols = row.ChildNodes;
                            day.Entries.Add(new EntryTimetable
                            {
                                StartHour = ExtractContent(cols[1].InnerText),
                                EndHour = ExtractContent(cols[3].InnerText),
                                Groups = ExtractContent(cols[5].InnerText),
                                Course = ExtractContent(cols[7].InnerText),
                                Type = ExtractContent(cols[9].InnerText),
                                Lecturer = ExtractContent(cols[11].InnerText),
                                Location = ExtractContent(cols[13].InnerText),
                                Package = ExtractContent(cols[17].InnerText)
                            });
                        }
                        index++;
                    }
                    _logger.Log(weekTimetable);
                }
            }

            return weekTimetable;
        }

        private static string ExtractContent(string from)
        {
            return from.Replace("\r\n", "").Trim();
        }
    }
}