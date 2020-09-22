using CommandPattern.Core.Contracts;
using CommandPattern.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class CommandExecutor : ICommand
    {
        private readonly Command _command;
        private readonly CommandName _commandName;

        public CommandExecutor(Command command, CommandName commandName)
        {
            this._command = command;
            this._commandName = commandName;
        }
        public string Execute(string[] args)
        {
            if (_commandName == CommandName.HelloCommand)
            {
                return $"Hellow, {args[0]}";
            }
            else
            {
                return null;
            }
        }
    }
}
