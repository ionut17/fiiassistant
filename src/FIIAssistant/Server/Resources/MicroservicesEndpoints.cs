namespace Server.Resources
{
    public class MicroservicesEndpoints
    {
        public const string Students = "http://localhost:6497/api/students";
        public const string StudentByFirstName = "http://localhost:6497/api/students/{0}";
    }
}