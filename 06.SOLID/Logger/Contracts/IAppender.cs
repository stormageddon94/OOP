using Logger.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        long MessagesApeended { get; }

        void Append(IError error);
    }
}
