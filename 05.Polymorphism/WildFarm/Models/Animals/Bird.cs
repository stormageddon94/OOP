using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
     public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, decimal weight, /*int foodEaten,*/ decimal wingSize) : base(name, weight/*foodEaten*/)
        {
            this.WingSize = wingSize;
        }

        public decimal WingSize { get; private set; }

        public override string ToString()
        {
            var weight = string.Format("{0:0.#####}", this.Weight);
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {weight}, {this.FoodEaten}]";
        }

    }
}
