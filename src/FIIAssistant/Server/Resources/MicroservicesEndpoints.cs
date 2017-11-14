namespace Server.Resources
{
    public class MicroservicesEndpoints
    {
        public const string Students = "http://localhost:6497/api/students";
        public const string StudentByFirstName = "http://localhost:6497/api/students/{0}";

        public const string Courses = "http://localhost:6479/api/courses";

        public const string Timetables = "http://localhost:6459/api/timetables";

        public const string Server = "http://localhost:6438/api/";
    }
}