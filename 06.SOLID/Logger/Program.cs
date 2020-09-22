using Logger.Contracts;
using Logger.Core;
using Logger.Core.Contracts;
using Logger.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {

            var count = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();
            ParseAppendersInput(count, appenders);

            ILogger logger = new Logger.Models.Logger(appenders);

            IEngine engine = new Engine(logger);
            engine.Run();

        }

        private static void ParseAppendersInput(int count, ICollection<IAppender> appenders)
        {
            for (int i = 0; i < count; i++)
            {

                AppenderFactory appenderFactory = new AppenderFactory();
                var appenderArg = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var appenderType = appenderArg[0];
                var layoutType = appenderArg[1];
                var level = "INFO";

                if (appenderArg.Length == 3)
                {
                    level = appenderArg[2];
                }

                try
                {
                    var appender = appenderFactory.ProduceAppender(appenderType, layoutType, level);
                    appenders.Add(appender);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
