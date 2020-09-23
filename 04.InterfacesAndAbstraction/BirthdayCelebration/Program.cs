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
            List<IBirthdate> birthdatesCollected = new List<IBirthdate>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }
                else if (input[0] == "Citizen")
                {
                    var name = input[1];
                    var age = int.Parse(input[2]);
                    var idNumber = input[3];
                    var birthdate = input[4];
                    var person = new Person(name, age, idNumber, birthdate);
                    birthdatesCollected.Add(person);
                }
                else if (input[0] == "Pet")
                {
                    var name = input[1];
                    var birthdate = input[2];
                    var pet = new Pet(name, birthdate);
                    birthdatesCollected.Add(pet);
                }
            }

            var year = Console.ReadLine();

            foreach (var birthday in birthdatesCollected)
            {
                if (birthday.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(birthday.Birthdate);
                }
            }
        }
    }
}
