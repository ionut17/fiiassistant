using Microsoft.AspNetCore.Mvc;
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

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{firstName}")]
        public IActionResult Get(string firstName)
        {
            var url = string.Format(MicroservicesEndpoints.StudentByFirstName, firstName);

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

        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            const string url = MicroservicesEndpoints.Students;

            var result = _restClient.Put(url, student).Result;

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