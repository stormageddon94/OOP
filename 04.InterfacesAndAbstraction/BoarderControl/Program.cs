using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BoarderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IId> idsChecked = new List<IId>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 3)
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var idNumber = input[2];
                    var person = new Person(name, age, idNumber);
                    idsChecked.Add(person);
                }
                else if (input.Length == 2)
                {
                    var model = input[0];
                    var idNumber = input[1];
                    var robot = new Robot(idNumber, model);
                    idsChecked.Add(robot);
                }
            }

            var endDigits = Console.ReadLine();

            foreach (var id in idsChecked)
            {
                if (id.IdNumber.EndsWith(endDigits))
                {
                    Console.WriteLine(id.IdNumber);
                }
            }
        }
    }
}
