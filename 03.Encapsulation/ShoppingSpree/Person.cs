using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> BagOfProducts { get; set; }

        public string BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                return $"{this.Name} can't afford {product.Name}";
            }
            else
            {
                this.Money -= product.Cost;
                this.BagOfProducts.Add(product);
                return $"{this.Name} bought {product.Name}";
            }
        }

        public override string ToString()
        {
            string person = $"{this.Name} - ";

            if (this.BagOfProducts.Count == 0)
            {
                person += "Nothing bought";
            }
            else
            {
                var productNames = this.BagOfProducts.Select(x => x.Name);
                person += string.Join(", ", productNames);
            }

            return person;
        }


    }
}
