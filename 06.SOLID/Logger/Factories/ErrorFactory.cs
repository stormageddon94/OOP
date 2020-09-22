using Logger.Contracts;
using Logger.Enumerations;
using Logger.Models.Errors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string DateFormat = "M/dd/yyyy h:mm:ss tt";
        public IError ProduceError(string date, string message, string levelString)
        {
            DateTime dateTime;
            try
            {
                dateTime = DateTime.ParseExact(date, DateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid date format!", ex);
            }

            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, true, out level);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level type!");
            }

            IError error = new Error(dateTime, message, level);
            return error;
        }
    }
}
