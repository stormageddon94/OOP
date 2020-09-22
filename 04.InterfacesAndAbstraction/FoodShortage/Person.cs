using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public abstract class Person : IBuyer
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public int Food { get; set; }

        public abstract void BuyFood();
    }
}
