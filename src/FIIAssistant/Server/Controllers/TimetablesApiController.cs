using System;
using Microsoft.AspNetCore.Mvc;
using Server.Logger;
using Server.Resources;
using Server.RestClients;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class TimetablesApiController : Controller
    {
        private readonly RestClient _restClient = new RestClient();

        [HttpGet]
        public IActionResult Get()
        {
            const string url = MicroservicesEndpoints.Timetables;

            var result = _restClient.Get(url).Result;

            var message = new LogMessage(Guid.NewGuid(), "All timetables", "TimetableAPIController", "GET");
            LogHelper.Log(LogContainer.Database, message);
            LogHelper.Log(LogContainer.File, message);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetGroupTimetable(string group)
        {
            var url = string.Format(MicroservicesEndpoints.GroupTimetables, group);

            var result = _restClient.Get(url).Result;
            var message = new LogMessage(Guid.NewGuid(), "Group timetable", "TimetableAPIController", "GET");
            LogHelper.Log(LogContainer.File, message);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}