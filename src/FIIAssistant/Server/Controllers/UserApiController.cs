using System;
using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Server.Logger;
using Server.Resources;
using Server.RestClients;
using User.Data.Model.Entities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class UserApiController : Controller
    {
        private readonly RestClient _restClient = new RestClient();

        [HttpPost]
        public IActionResult Login([FromBody] LoginInfo loginInfo)
        {
            var student = _restClient.Get(string.Format(MicroservicesEndpoints.StudentByEmail, loginInfo.Email));
            if (student == null)
            {
                return NotFound();
            }
//            var courses = _restClient.Get(MicroservicesEndpoints.C)
            return Ok();
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterInfo registerInfo)
        {
            var student = _restClient.Post(MicroservicesEndpoints.Students, new
            {
                registerInfo.FirstName,
                registerInfo.LastName,
                registerInfo.Email,
                Group = registerInfo.GroupName
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

            var message = new LogMessage(Guid.NewGuid(), "All students", "StudentsAPIController", "GET");
            LogHelper.Log(LogContainer.Database, message);
            LogHelper.Log(LogContainer.File, message);


            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{firstName}")]
        public IActionResult Get(string firstName)
        {
            var url = string.Format(MicroservicesEndpoints.StudentByEmail, firstName);

            var result = _restClient.Get(url).Result;

            var message = new LogMessage(Guid.NewGuid(), "Student with the first name: " + firstName,
                "StudentsAPIController", "GET");
            LogHelper.Log(LogContainer.Database, message);
            LogHelper.Log(LogContainer.File, message);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            const string url = MicroservicesEndpoints.Students;

            var result = _restClient.Post(url, student).Result;

            var message = new LogMessage(Guid.NewGuid(), "Added student with the first name: " + student.FirstName,
                "StudentsAPIController", "POST");
            LogHelper.Log(LogContainer.Database, message);
            LogHelper.Log(LogContainer.File, message);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            const string url = MicroservicesEndpoints.Students;

            var result = _restClient.Put(url, student).Result;

            var message = new LogMessage(Guid.NewGuid(), "Put result.", "StudentsAPIController", "PUT");
            LogHelper.Log(LogContainer.Database, message);
            LogHelper.Log(LogContainer.File, message);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{firstName}")]
        public IActionResult Delete(string firstName)
        {
            var url = string.Format(MicroservicesEndpoints.StudentByEmail, firstName);

            var result = _restClient.Delete(url).Result;

            var message = new LogMessage(Guid.NewGuid(), "Added student with the first name: " + firstName,
                "StudentsAPIController", "DELETE");
            LogHelper.Log(LogContainer.Database, message);
            LogHelper.Log(LogContainer.File, message);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}