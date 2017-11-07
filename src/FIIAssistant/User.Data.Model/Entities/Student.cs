using System;

namespace User.Data.Model.Entities
{
    public class Student : Common.User
    {
        public Student() {
            
        }

        public Student(string firstName)
        {
            FirstName = firstName;
        }

        public int Year { get; set; }

        public string Group { get; set; }
    }
}