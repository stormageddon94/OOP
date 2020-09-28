using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, decimal weight, /*int foodEaten,*/ string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override void Eat(IFood food)
        {
            var foodType = food.GetType();
            if (foodType.Name == "Meat")
            {

                this.FoodEaten = food.Quantity;
                this.Weight += Convert.ToDecimal(food.Quantity * 1.00);
            }
            else
            {
                this.FoodEaten = 0;
                throw new ArgumentException($"Tiger does not eat {foodType.Name}!");
            }
        }
    }
}
