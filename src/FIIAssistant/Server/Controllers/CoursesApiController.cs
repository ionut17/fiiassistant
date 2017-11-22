using Course.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Server.Logger;
using Server.Resources;
using Server.RestClients;
using System;

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

            LogHelper.Log(LogContainer.File, GetType().Name + ": GET returned result");

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CourseDTO course)
        {
            const string url = MicroservicesEndpoints.Courses;

            var result = _restClient.Post(url, course).Result;

            LogHelper.Log(LogContainer.File, GetType().Name + ": POST returned result");

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] CourseDTO course)
        {
            const string url = MicroservicesEndpoints.Courses;

            var result = _restClient.Put(url, course).Result;

            LogHelper.Log(LogContainer.File,
                GetType().Name + ": PUT for student with firstName " + course.Id + " returned result");

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