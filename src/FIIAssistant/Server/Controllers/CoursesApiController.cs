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

            LogHelper.Log(LogContainer.File, GetType().Name + ": GET returned result");

            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}