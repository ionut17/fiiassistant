using Microsoft.AspNetCore.Mvc;
using Timetable.Business.Service;
using Timetable.Data.Model.Common;

namespace Timetable.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class TimetablesController : Controller
    {
        public TableService Service { get; set; } = new TableService();

        [HttpGet("{group}/{year}")]
        public IActionResult Get(string group, int year)
        {
            var request = new GroupRequest
            {
                Group = group,
                Year = year,
                BaseAddress = "https://profs.info.uaic.ro/~orar"
            };
            var result = Service.GetTimetable(request);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("works");
        }
    }
}