namespace Server.Entities
{
    public class RegisterInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GroupName { get; set; }
        public string[] CoursesNames { get; set; }
    }
}