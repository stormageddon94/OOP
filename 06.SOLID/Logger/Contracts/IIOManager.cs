using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
     public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        string GetCurrentDirectory();

        void EnsureDirectoryAndFileExist();
    }
}
