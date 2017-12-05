namespace Server.Logger
{
    public class DatabaseLogger : ILogger
    {
        public DatabaseLoggerContext Context;

        public DatabaseLogger()
        {
            Context = new DatabaseLoggerContext();
        }

        public void Log(LogMessage message)
        {
            Context.Add(message);
            Context.SaveChanges();
        }
    }
}