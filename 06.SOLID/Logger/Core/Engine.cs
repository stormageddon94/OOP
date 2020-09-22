using Logger.Contracts;
using Logger.Core.Contracts;
using Logger.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger) : this()
        {
            this.logger = logger;
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var level = inputArgs[0];
                var dateTime = inputArgs[1];
                var message = inputArgs[2];

                try
                {
                    IError error = this.errorFactory.ProduceError(dateTime, message, level);
                    this.logger.Log(error);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(this.logger);
        }
    }
}
