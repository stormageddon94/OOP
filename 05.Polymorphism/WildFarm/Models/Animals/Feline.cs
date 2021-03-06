﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Animals
{
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, decimal weight, /*int foodEaten,*/ string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            var weight = string.Format("{0:0.#####}", this.Weight);
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
