using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {

        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Eat(IFood food)
        {
            var foodType = food.GetType();
            if (foodType.Name == "Meat")
            {

                this.FoodEaten = food.Quantity;
                this.Weight += (food.Quantity * 0.25);
            }
            else
            {
                throw new ArgumentException($"Owl does not eat {foodType.Name}!");
            }
        }
    }
}
