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
        public Hen(string name, decimal weight, /*int foodEaten,*/ decimal wingSize) : base(name, weight, wingSize)
        {
        }


        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Eat(IFood food)
        {

            this.FoodEaten = food.Quantity;
            this.Weight += Convert.ToDecimal(food.Quantity * 0.35);
        }
    }
}
