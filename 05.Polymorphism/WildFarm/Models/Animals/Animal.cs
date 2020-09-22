using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }
        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string AskForFood();

        public abstract void Eat(IFood food);
    }
}
