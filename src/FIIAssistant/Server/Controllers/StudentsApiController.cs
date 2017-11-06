using Microsoft.AspNetCore.Mvc;
using Server.Resources;
using Server.RestClients;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class StudentsApiController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            const string url = MicroservicesEndpoints.Students;
            var result = RestClient.Get(url);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{firstName}")]
        public IActionResult Get(string firstName)
        {
            var url = string.Format(MicroservicesEndpoints.StudentByFirstName, firstName);
            var result = RestClient.Get(url);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] object student)
        {
            const string url = MicroservicesEndpoints.Students;
            var result = RestClient.Post(url, student);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] object student)
        {
            const string url = MicroservicesEndpoints.StudentByFirstName;
            var result = RestClient.Put(url, student);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{firstName}")]
        public IActionResult Delete(string firstName)
        {
            var url = string.Format(MicroservicesEndpoints.StudentByFirstName, firstName);
            var result = RestClient.Delete(url);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}