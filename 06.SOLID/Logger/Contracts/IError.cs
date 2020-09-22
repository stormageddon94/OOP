using Logger.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }

    }
}
