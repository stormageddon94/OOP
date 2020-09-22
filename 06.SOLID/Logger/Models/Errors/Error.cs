using Logger.Contracts;
using Logger.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string messgae, Level level)
        {
            this.DateTime = dateTime;
            this.Message = messgae;
            this.Level = level;
        }
        public DateTime DateTime { get; private set; }

        public string Message { get; private set; }

        public Level Level { get; private set; }
}
