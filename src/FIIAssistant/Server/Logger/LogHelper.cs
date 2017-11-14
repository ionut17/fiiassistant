using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Logger
{
    public static class LogHelper
    {
        private static Logger logger = null;
        public static void Log(LogContainer target, string message)
        {
            switch (target)
            {
                case LogContainer.File:
                    logger = new FileLogger();
                    logger.Log(message);
                    break;
                case LogContainer.DataBase:
                    logger = new EventLogger();
                    logger.Log(message);
                    break;
                default:
                    return;
            }
        }
    }
}
