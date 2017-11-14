namespace User.Data.Model.Entities
{
    public class Student : User
    {
        public Student()
        { }

        public Student(string firstName)
        {
            FirstName = firstName;
        }

        public int Year { get; set; }

        public string Group { get; set; }
    }
}