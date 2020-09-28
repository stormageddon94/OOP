using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, decimal weight, /*int foodEaten,*/ string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override void Eat(IFood food)
        {
            var foodType = food.GetType();
            if (foodType.Name == "Vegetable" || foodType.Name == "Fruit")
            {

                this.FoodEaten = food.Quantity;
                this.Weight += Convert.ToDecimal(food.Quantity * 0.10);
            }
            else
            {
                throw new ArgumentException($"Mouse does not eat {foodType.Name}!");
            }
        }
    }
}
