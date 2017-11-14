namespace Server.Logger
{
    public static class LogHelper
    {
        private static Logger logger;

        public static void Log(LogContainer target, string message)
        {
            switch (target)
            {
                case LogContainer.File:
                    logger = new FileLogger();
                    logger.Log(message);
                    break;
                case LogContainer.DataBase:
                    logger = new DataBaseLogger();
                    logger.Log(message);
                    break;
                default:
                    return;
            }
        }
    }
}