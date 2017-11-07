using System;

namespace User.Data.Model.Entities
{
    public class Student : Common.User
    {
        public Student(string firstName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
        }

        public Student()
        {
        }

        public int Year { get; set; }

        public string Group { get; set; }
    }
}