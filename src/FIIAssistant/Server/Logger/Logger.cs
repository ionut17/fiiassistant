using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Logger
{
    public  abstract class Logger
    {
        public abstract void Log(string message);

    }
}
