using System;
using System.Linq;
using Course.Business.Repository;
using Course.Data.Model;
using Course.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Course.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = _courseRepository.GetAll();

            if (courses.ToList().Count == 0)
            {
                return NoContent();
            }

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var course = _courseRepository.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCourseDto courseModel)
        {
            var course = new Data.Model.Course
            {
                Id = Guid.NewGuid(),
                Name = courseModel.Name,
                Url = courseModel.Url,
                Semester = courseModel.Semester,
                Teacher = courseModel.Teacher
            };

            _courseRepository.AddCourse(course);

            return Ok(_courseRepository.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateCourseDto updatedCourse)
        {
            var course = _courseRepository.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            course.Name = updatedCourse.Name;
            course.Semester = updatedCourse.Semester;
            course.Teacher = updatedCourse.Teacher;
            course.Url = updatedCourse.Url;

            _courseRepository.UpdateCourse(course);

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _courseRepository.DeleteCourse(id);

            return NoContent();
        }

        [HttpPut("{id}/subscribe/{studentId}")]
        public IActionResult Subscribe(Guid id, Guid studentId)
        {
            _courseRepository.AddStudentCourse(new StudentCourse
            {
                CourseId = id,
                StudentId = studentId
            });

            return Ok();
        }

        [HttpPut("{id}/unsubscribe/{studentId}")]
        public IActionResult Unsubscribe(Guid id, Guid studentId)
        {
            _courseRepository.DeleteStudentCourse(new StudentCourse
            {
                CourseId =  id,
                StudentId = studentId
            });

            return NoContent();
        }
    }
}