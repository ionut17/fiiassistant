﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using User.Data.Model.Entities;

namespace User.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        //TODO: delete mocked students, created for testing RESTClient
        public static List<Student> Students = new List<Student>
        {
            new Student("Anca"),
            new Student("Dan"),
            new Student("Ionut"),
            new Student("Silvan")
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Students);
        }

        [HttpGet("{firstName}")]
        public IActionResult Get(string firstName)
        {
            return Ok(Students.FirstOrDefault(student => student.FirstName == firstName));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            Students.Add(student);
            return Ok(Students);
        }

        [HttpDelete("{firstName}")]
        public void Delete([FromBody] string firstName)
        {
            Students.RemoveAll(student => student.FirstName == firstName);
        }
    }
}