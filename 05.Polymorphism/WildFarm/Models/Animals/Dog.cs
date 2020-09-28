using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, decimal weight, /*int foodEaten,*/ string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override void Eat(IFood food)
        {
            var foodType = food.GetType();
            if (foodType.Name == "Meat")
            {
                this.FoodEaten = food.Quantity;
                this.Weight += Convert.ToDecimal(0.40);
            }
            else
            {
                throw new ArgumentException($"Dog does not eat {foodType.Name}!");
            }
        }
    }
}
