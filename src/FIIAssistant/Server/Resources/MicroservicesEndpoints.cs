namespace Server.Resources
{
    public class MicroservicesEndpoints
    {
        //Students microservice
        public const string Students = "http://localhost:6497/api/students";

        public const string StudentById = "http://localhost:6497/api/students/{0}";

        public const string Groups = "http://localhost:6497/api/groups";

        //Courses microservice
        public const string Courses = "http://localhost:6479/api/courses";

        public const string CourseStudents = "http://localhost:6479/api/students";
        public const string CourseStudentsById = "http://localhost:6479/api/students/{0}";

        //Timetable microservice
        public const string Timetables = "http://localhost:6459/api/timetables";

        public const string GroupTimetables = "http://localhost:6459/api/timetables/{0}/{1}";

        //Server
        public const string Server = "http://localhost:6438/api/";
    }
}