using Microsoft.AspNetCore.Mvc;

namespace Course.Presentation.Controllers
{
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] {"Computer networks", "Java", "Math"});
        }
    }
}