using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Timetable.Data.Model.Common;
using Timetable.Data.Model.Interfaces;

namespace Timetable.Business.Repository
{
    public class TimetableRepository<TRequest> : ITimetableRepository<TRequest, WeekTimetable> where TRequest : Request
    {

        private readonly WebClient _webClient;

        public TimetableRepository()
        {
            _webClient = new WebClient();
        }

        public WeekTimetable GetTimetable(TRequest entity)
        {
            var document = new HtmlAgilityPack.HtmlDocument();
            document.Load(_webClient.OpenRead(entity.GetAddress()), Encoding.UTF8);
            return new WeekTimetable();
        }
    }
}