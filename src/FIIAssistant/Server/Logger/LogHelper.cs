namespace Server.Logger
{
    public static class LogHelper
    {
        private static readonly LoggerPool LoggerPool = new LoggerPool();

        public static void Log(LogContainer target, LogMessage message)
        {
            LoggerPool.GetLogger(target).Log(message);
        }
    }
}