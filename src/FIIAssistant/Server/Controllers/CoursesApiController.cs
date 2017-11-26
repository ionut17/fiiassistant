using System;
using Microsoft.AspNetCore.Mvc;
using Server.Logger;
using Server.Resources;
using Server.RestClients;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class CoursesApiController : Controller
    {
        private readonly RestClient _restClient = new RestClient();

        [HttpGet]
        public IActionResult Get()
        {
            const string url = MicroservicesEndpoints.Courses;

            var result = _restClient.Get(url).Result;

            var message = new LogMessage(Guid.NewGuid(), "All Courses", "CoursesAPIController", "GET");
            LogHelper.Log(LogContainer.Database, message);
            LogHelper.Log(LogContainer.File, message);
            LogHelper.Log(LogContainer.File, message);

            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}