using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private List<Toppings> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Toppings>();

        }
        public string Name 
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15 || value.Length < 1)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public List<Toppings> Toppings 
        { 
            get { return this.toppings; } 
            private set
            {
                //if (value.Count < 0 || value.Count > 10)
                //{
                //    throw new ArgumentException("Number of toppings should be in range [0..10].");
                //}

                this.toppings = value;
            }
        }

        public Dough Dough { get; private set; }

        
        public void AddTopping(Toppings topping)
        {
            if (this.toppings.Count >= 0 && this.toppings.Count <= 10)
            {
                this.toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

        public double CalculateCalories()
        {
            var doughCallories = this.Dough.CalouriesCalculator();
            var toppingCallories = this.Toppings.Select(x => x.CalouriesCalculator()).Sum();
            var result = doughCallories + toppingCallories;
            return result;
        }

        public override string ToString()
        {
            return $"{this.name} - {this.CalculateCalories():F2} Calories.";
        }
    }
}
