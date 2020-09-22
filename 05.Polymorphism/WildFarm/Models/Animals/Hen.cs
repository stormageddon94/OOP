using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;
using WildFarm.Foods;
using WildFarm.Models;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }


        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Eat(IFood food)
        {

            this.FoodEaten = food.Quantity;
            this.Weight += (food.Quantity * 0.35);
        }
    }
}
