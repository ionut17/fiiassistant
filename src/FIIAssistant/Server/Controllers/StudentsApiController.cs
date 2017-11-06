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
            const string url = MicroservicesEndpoints.GetAllStudents;
            var result = RestClient.Get(url);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{firstName}")]
        public IActionResult Get(string firstName)
        {
            var url = string.Format(MicroservicesEndpoints.GetStudentByFirstName, firstName);
            var result = RestClient.Get(url);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] object student)
        {
            const string url = MicroservicesEndpoints.PostStudent;
            var result = RestClient.Post(url, student);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}