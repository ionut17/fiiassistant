namespace Server.Entities
{
    public class RegisterInfo: CreateStudent
    {
        public string Password { get; set; }
        public string[] CoursesNames { get; set; }
    }
}