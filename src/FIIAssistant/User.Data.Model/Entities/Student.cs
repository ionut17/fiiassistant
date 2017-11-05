namespace User.Data.Model.Entities
{
    public class Student : User
    {
        public int Year { get; set; }

        public string Group { get; set; }
    }
}