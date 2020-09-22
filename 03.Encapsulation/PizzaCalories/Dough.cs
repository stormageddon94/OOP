using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaCalories
{
    public class Dough
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 200;

        private string flourType;
        private double flourModifier;
        private string bakingTechnique;
        private double bakingModifier;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight, double flourModifier = 0.0, double bakingModifier = 0.0)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            this.FlourModifier = flourModifier;
            this.BakingModifier = bakingModifier;
        }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (value != "white" && value != "wholegrain" || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public double FlourModifier
        {
            get { return this.flourModifier; }
            private set
            {
                if (this.flourType == "white")
                {
                    this.flourModifier = 1.5;
                }
                else if (this.flourType == "wholegrain")
                {
                    this.flourModifier = 1.0;
                }
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (value != "crispy" 
                    && value != "chewy" 
                    && value != "homemade" 
                    || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value; 
            }
        }

        public double BakingModifier
        {
            get { return this.bakingModifier; }
            private set
            {
                if (this.bakingTechnique == "crispy")
                {
                    this.bakingModifier = 0.9;
                }
                else if (this.bakingTechnique == "chewy")
                {
                    this.bakingModifier = 1.1;
                }
                else
                {
                    this.bakingModifier = 1.0;
                }
            }
        }

        public double Weight
        {
            get {  return this.weight; }
            private set 
            {
                if (MinWeight < value && value > MaxWeight)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }


        public double CalouriesCalculator()
        {
            var result = 2*this.weight*this.flourModifier*this.bakingModifier;
            return result;
        }
    }
}