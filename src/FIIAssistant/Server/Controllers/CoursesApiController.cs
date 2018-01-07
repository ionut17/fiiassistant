using System;
using Course.Data.Model;
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

        [HttpPost]
        public IActionResult Post([FromBody] CourseDTO courseDto)
        {
            const string url = MicroservicesEndpoints.Courses;

            var result = _restClient.Post(url, courseDto).Result;
            var message = new LogMessage(Guid.NewGuid(), "Post Course", "CoursesAPIController", "POST");
            LogHelper.Log(LogContainer.File, message);

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] CourseDTO courseDto)
        {
            const string url = MicroservicesEndpoints.Courses;

            var result = _restClient.Put(url, courseDto).Result;

            var message = new LogMessage(Guid.NewGuid(), "Put Course", "CoursesAPIController", "PUT");
            LogHelper.Log(LogContainer.File, message);

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{firstName}")]
        public IActionResult Delete(Guid id)
        {
            var url = string.Format(MicroservicesEndpoints.Courses, id);

            var result = _restClient.Delete(url).Result;

            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}