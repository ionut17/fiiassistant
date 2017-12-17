using System;
using Course.Business.Repository;
using Course.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Course.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly CourseRepository _courseRepository;

        public CoursesController(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
        }

        [HttpPost]
        public IActionResult Post([FromBody] CourseDTO courseDto)
        {
        }


        [HttpPut]
        public IActionResult Put([FromBody] CourseDTO courseDto)
        {
        }

        [HttpDelete("{firstName}")]
        public IActionResult Delete(Guid id)
        {
        }
    }
}