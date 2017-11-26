using System;

namespace Server.Logger
{
    public class LoggerPool
    {
        private readonly DatabaseLogger _databaseLogger = new DatabaseLogger();
        private readonly FileLogger _fileLogger = new FileLogger();

        public ILogger GetLogger(LogContainer logContainer)
        {
            switch (logContainer)
            {
                case LogContainer.File:
                    return _fileLogger;
                case LogContainer.Database:
                    return _databaseLogger;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logContainer), logContainer, null);
            }
        }
    }
}