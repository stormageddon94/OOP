using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter _commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this._commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            var commands = new List<ICommand>();
            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(this._commandInterpreter.Read(input));
            }
        }
    }
}
