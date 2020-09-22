using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;
using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                var name = input[0];
                var country = input[1];
                var age = int.Parse(input[2]);
                var citizen = new Citizen(name, age, country);
                IPerson person = citizen;
                Console.WriteLine(person.GetName());
                IResident resident = citizen;
                Console.WriteLine(resident.GetName());

            }
        }
    }
}
