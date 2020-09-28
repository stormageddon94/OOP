using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, decimal weight /*int foodEaten*/)
        {
            this.Name = name;
            this.Weight = weight;
            //this.FoodEaten = foodEaten;
        }
        public string Name { get; protected set; }

        public decimal Weight { get; protected set; }

        public long FoodEaten { get; protected set; }

        public abstract string AskForFood();

        public abstract void Eat(IFood food);
    }
}
