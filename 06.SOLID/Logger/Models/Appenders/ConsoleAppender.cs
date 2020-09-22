using Logger.Contracts;
using Logger.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }
         

        public Level Level { get; private set; }

        public long MessagesApeended { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;
            DateTime datetime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = String.Format(format,
                                                    datetime.ToString("M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                                    message,
                                                    level.ToString());
            Console.WriteLine(formattedMessage);
            this.MessagesApeended++;

        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, " +
                 $"Layout type: {this.Layout.GetType().Name}, " +
                 $"Report level: {this.Level.ToString().ToUpper()}, " +
                 $"Messages appended: {this.MessagesApeended}";
        }
    }
}
