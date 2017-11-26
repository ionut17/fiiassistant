using log4net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Server.Logger;

namespace Server
{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            FileLogger.ClearLogging();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}