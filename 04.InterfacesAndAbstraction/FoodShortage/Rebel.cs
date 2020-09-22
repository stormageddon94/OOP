using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : Person, IBuyer
    {
        public Rebel(string name, int age, string group) : base(name, age)
        {
            this.Group = group;
        }

        public string Group { get; set; }

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
