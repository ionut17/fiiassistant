namespace Server.Resources
{
    public class MicroservicesEndpoints
    {
        public const string GetAllStudents = "http://localhost:6497/api/students";
        public const string GetStudentByFirstName = "http://localhost:6497/api/students/{0}";
        public const string PostStudent = "http://localhost:6497/api/students/";
    }
}