using System;

namespace PizzaCalories
{
    public class Toppings
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 50;

        private string type;
        private double typeModifier;
        private double weight;

        public Toppings(string type, double weight, double typeModifier = 0.0)
        {
            this.Type = type;
            this.Weight = weight;
            this.TypeModifier = typeModifier;
        }

        public string Type
        {
            get { return this.type; }
            private set
            {
                if (value != "meat" && value != "Meat"
                    && value != "veggies" && value != "Veggies"
                    && value != "cheese" && value != "Cheese"
                    && value != "sauce" && value != "Sauce"
                    || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double TypeModifier
        {
            get { return this.typeModifier; }
            private set
            {
                if (this.type == "meat" || this.type == "Meat")
                {
                    this.typeModifier = 1.2;
                }
                else if (this.type == "veggies" || this.type == "Veggies")
                {
                    this.typeModifier = 0.8;
                }
                else if (this.type == "cheese" || this.type == "Cheese")
                {
                    this.typeModifier = 1.1;
                }
                else if (this.type == "sauce" || this.type == "Sauce")
                {
                    this.typeModifier = 0.9;
                }
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (MinWeight > value || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double CalouriesCalculator()
        {
            var result = 2 * this.weight * this.typeModifier;
            return result;
        }
    }
}