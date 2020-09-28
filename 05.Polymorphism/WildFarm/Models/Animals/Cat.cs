using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, decimal weight, /*int foodEaten,*/ string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        
        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Eat(IFood food)
        {
            var foodType = food.GetType();
            if (foodType.Name == "Vegetable" || foodType.Name == "Meat")
            {
                this.FoodEaten = food.Quantity;
                this.Weight +=  Convert.ToDecimal(food.Quantity * 0.30);
            }
            else
            {
                throw new ArgumentException($"Cat does not eat {foodType.Name}!");
            }
        }
    }
}
