using log4net;
using Microsoft.AspNetCore.Mvc;
using Server.Logger;
using Server.Resources;
using Server.RestClients;
using User.Data.Model.Entities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class StudentsApiController : Controller
    {
        private readonly RestClient _restClient = new RestClient();

        [HttpGet]
        public IActionResult Get()
        {
            const string url = MicroservicesEndpoints.Students;

            var result = _restClient.Get(url).Result;

            Logger.LogHelper.Log(LogContainer.File, this.GetType().Name + ": GET returned result");

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{firstName}")]
        public IActionResult Get(string firstName)
        {
            var url = string.Format(MicroservicesEndpoints.StudentByFirstName, firstName);

            var result = _restClient.Get(url).Result;

            Logger.LogHelper.Log(LogContainer.File, this.GetType().Name + ": GET for student with firstName "+ firstName +" returned result");

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            const string url = MicroservicesEndpoints.Students;

            var result = _restClient.Post(url, student).Result;

            Logger.LogHelper.Log(LogContainer.File, this.GetType().Name + ": POST returned result");

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            const string url = MicroservicesEndpoints.Students;

            var result = _restClient.Put(url, student).Result;

            Logger.LogHelper.Log(LogContainer.File, this.GetType().Name.ToString() + ": PUT for student with firstName "+student.FirstName+" returned result");

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{firstName}")]
        public IActionResult Delete(string firstName)
        {
            var url = string.Format(MicroservicesEndpoints.StudentByFirstName, firstName);

            var result = _restClient.Delete(url).Result;

            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}