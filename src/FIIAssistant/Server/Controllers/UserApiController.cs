using System;
using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Server.Resources;
using Server.RestClients;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class UserApiController : Controller
    {
        private readonly RestClient _restClient = new RestClient();

        [Route("api/login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginInfo loginInfo)
        {
            var student = _restClient.Post(MicroservicesEndpoints.Login, loginInfo);

            if (student == null)
                return NotFound();
            return Ok(student);

            var courses = _restClient.Get(MicroservicesEndpoints.Courses);

            return Ok(
                new
                {
                    student,
                    courses
                });
        }

        [Route("api/register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterInfo registerInfo)
        {
            var student = _restClient.Post(MicroservicesEndpoints.Students, registerInfo.Student);

            return Ok(student);
            var courses = _restClient.Post(MicroservicesEndpoints.CourseStudents, new
            {
                student,
                courses = registerInfo.Courses
            });

            return Ok(new
            {
                student,
                courses
            });
        }

        [Route("api/register")]
        [HttpGet]
        public IActionResult Register()
        {
            var courses = _restClient.Get(MicroservicesEndpoints.Courses);
            var groups = _restClient.Get(MicroservicesEndpoints.Groups);

            return Ok(new
            {
                courses,
                groups
            });
        }

        [HttpGet]
        public IActionResult Get()
        {
            const string url = MicroservicesEndpoints.Students;

            var result = _restClient.Get(url).Result;

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var url = string.Format(MicroservicesEndpoints.StudentById, id);

            var result = _restClient.Get(url).Result;

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            const string url = MicroservicesEndpoints.Students;

            var result = _restClient.Post(url, student).Result;

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateStudent student)
        {
            var url = string.Format(MicroservicesEndpoints.StudentById, id);

            var result = _restClient.Put(url, student).Result;

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var url = string.Format(MicroservicesEndpoints.StudentById, id);

            var result = _restClient.Delete(url).Result;

            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}