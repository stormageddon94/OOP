using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var id = input[2];
                    var birthday = input[3];
                    var person = new Citizen(name, age, id, birthday);
                    people.Add(person);
                }
                else if(input.Length == 3)
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var group = input[2];
                    var rebel = new Rebel(name, age, group);
                    people.Add(rebel);
                }
            }

            while (true)
            {
                var name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                var indexOfPerson = people.FindIndex(x => x.Name == name);
                if (indexOfPerson != -1)
                {
                    people[indexOfPerson].BuyFood();
                }
            }

            var totalAmountOfFood = people.Select(x => x.Food).Sum();
            Console.WriteLine(totalAmountOfFood);
        }
    }
}
