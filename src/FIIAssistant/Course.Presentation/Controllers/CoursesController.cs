using Course.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpPost]
        public IActionResult Post([FromBody] CourseDTO course)
        {
            return Ok(course);
        }


        [HttpPut]
        public IActionResult Put([FromBody] CourseDTO course)
        {
            return Ok(course);
        }

        [HttpDelete("{firstName}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(new CourseDTO());
        }
    }

}