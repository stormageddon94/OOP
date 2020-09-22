using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight:F2}, {this.LivingRegion}, {this.FoodEaten}]";
        }

    }
}
