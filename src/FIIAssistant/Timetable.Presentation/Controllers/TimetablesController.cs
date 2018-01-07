using System;
using Microsoft.AspNetCore.Mvc;
using Timetable.Business.Service;
using Timetable.Data.Model.Common;

namespace Timetable.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class TimetablesController : Controller
    {
        public TableService Service { get; set; } = new TableService();

        [HttpGet("{group}")]
        public IActionResult Get(string group)
        {
            var request = new GroupRequest
            {
                Group = group,
                Year = 3,
                BaseAddress = "https://profs.info.uaic.ro/~orar"
            };

            try
            {
                var result = Service.GetTimetable(request);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}