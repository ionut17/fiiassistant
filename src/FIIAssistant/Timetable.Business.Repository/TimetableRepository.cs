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
            var document = new HtmlDocument();
            document.Load(_webClient.OpenRead(entity.GetAddress()), Encoding.UTF8);
            _logger.Log(document);
            //Other business logic
            var type = document.GetType();
            _logger.Ok();
            return new WeekTimetable();
        }
    }
}