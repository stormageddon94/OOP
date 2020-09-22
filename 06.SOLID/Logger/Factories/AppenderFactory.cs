using Logger.Contracts;
using Logger.Enumerations;
using Logger.Models;
using Logger.Models.Appenders;
using Logger.Models.Files;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }
        public IAppender ProduceAppender(string appenderType, string layoutType, string levelString)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, true, out level);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level type!");
            }

            ILayout layout = this.layoutFactory.ProduceLayout(layoutType);
            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile("\\data\\", "logs.txt");
                appender = new FileAppender(layout,level,file);
            }
            else
            {
                throw new ArgumentException("Invalid appender type!");
            }

            return appender;
        }
    }
}
