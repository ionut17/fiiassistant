using System;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces;
using User.Presentation.Dtos;

namespace User.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            Ensure.That(studentRepository).IsNotNull();

            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _studentRepository.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateStudentDto studentDto)
        {
            var student = new Student
            {
                Email = studentDto.Email,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Group = studentDto.Group,
                Year = studentDto.Year
            };

            _studentRepository.Add(student);
            return Ok(_studentRepository.GetAll());
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateStudentDto student)
        {
            var studentToUpdate = _studentRepository.GetById(id);

            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.Group = student.Group;
            studentToUpdate.Year = student.Year;

            _studentRepository.Update(studentToUpdate);
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _studentRepository.Delete(id);
            return NoContent();
        }
    }
}