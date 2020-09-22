using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;
        public CommandInterpreter()
        {
            _commands = new List<ICommand>();
        }
        public void SetCommand(ICommand command) => _command = command;
        public void Invoke(string[] args)
        {
            _commands.Add(_command);
            _command.Execute(args);
        }

        public string Read(string args)
        {
            var commandData = args.Split();
            return _command.Execute(commandData);
        }
    }
}
