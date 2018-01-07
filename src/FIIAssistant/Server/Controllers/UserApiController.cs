using System;
using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Server.Logger;
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
            var student = _restClient.Get(string.Format(MicroservicesEndpoints.StudentById, loginInfo.Email));
            if (student == null)
            {
                return NotFound();
            }

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
            var student = _restClient.Post(MicroservicesEndpoints.Students, new
            {
                registerInfo.Email,
                registerInfo.FirstName,
                registerInfo.LastName,
                registerInfo.Year,
                registerInfo.Group
            });

            var courses = _restClient.Post(MicroservicesEndpoints.CourseStudents, new
            {
                student,
                courses = registerInfo.CoursesNames
            });

            return Ok(
                new
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

            //var message = new LogMessage(Guid.NewGuid(), "All students", "StudentsAPIController", "GET");
            //LogHelper.Log(LogContainer.Database, message);
            //LogHelper.Log(LogContainer.File, message);


            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var url = string.Format(MicroservicesEndpoints.StudentById, id);

            var result = _restClient.Get(url).Result;

            //var message = new LogMessage(Guid.NewGuid(), "Student with id: " + id,
            //    "StudentsAPIController", "GET");
            //LogHelper.Log(LogContainer.Database, message);
            //LogHelper.Log(LogContainer.File, message);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateStudent student)
        {
            const string url = MicroservicesEndpoints.Students;

            var result = _restClient.Post(url, student).Result;

            //var message = new LogMessage(Guid.NewGuid(), "Added student with the email: " + student.Email,
            //    "StudentsAPIController", "POST");
            //LogHelper.Log(LogContainer.Database, message);
            //LogHelper.Log(LogContainer.File, message);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateStudent student)
        {
            string url = string.Format(MicroservicesEndpoints.StudentById, id);

            var result = _restClient.Put(url, student).Result;

            //var message = new LogMessage(Guid.NewGuid(), "Put result.", "StudentsAPIController", "PUT");
            //LogHelper.Log(LogContainer.Database, message);
            //LogHelper.Log(LogContainer.File, message);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var url = string.Format(MicroservicesEndpoints.StudentById, id);

            var result = _restClient.Delete(url).Result;

            //var message = new LogMessage(Guid.NewGuid(), "Deleted student with id: " + id,
            //    "StudentsAPIController", "DELETE");
            //LogHelper.Log(LogContainer.Database, message);
            //LogHelper.Log(LogContainer.File, message);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}