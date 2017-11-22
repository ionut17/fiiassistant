using Microsoft.AspNetCore.Mvc;

namespace Timetable.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class TimetablesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] {"A5 timetable", "ISS timetable"});
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(new[] { "A5 timetable", "ISS timetable" });
        }
    }
}