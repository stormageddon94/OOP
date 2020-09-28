using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, decimal weight, /*int foodEaten,*/ decimal wingSize) : base(name, weight, wingSize)
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
                this.Weight += Convert.ToDecimal(food.Quantity * 0.25);
            }
            else
            {
                throw new ArgumentException($"Owl does not eat {foodType.Name}!");
            }
        }
    }
}
