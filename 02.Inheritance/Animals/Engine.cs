using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class Engine
    {
        private const string EndOfInputCommand = "Beast!";
        private readonly List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string type;
            while ((type = Console.ReadLine()) != EndOfInputCommand)
            {

                string[] animalArgs = Console.ReadLine().Split(" ").ToArray();

                var animal = GetAnimal(type, animalArgs);
                this.animals.Add(animal);
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Animal GetAnimal (string type, string[] animalArgs)
        {
            string name = animalArgs[0];
            int age = int.Parse(animalArgs[1]);

            Animal animal = null;

            if (type == "Dog")
            {
                animal = new Dog(name, age, animalArgs[2]);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, animalArgs[2]);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, animalArgs[2]);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tom")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid inout!");
            }
            return animal;
        }
    }
}
