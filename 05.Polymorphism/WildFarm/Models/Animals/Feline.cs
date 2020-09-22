using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight:F2}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
