using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, decimal weight, /*int foodEaten,*/ string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override string ToString()
        {
            var weight = string.Format("{0:0.#####}", this.Weight);
            return $"{this.GetType().Name} [{this.Name}, {weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

    }
}
