using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaInput = Console.ReadLine().Split();
                var pizzaName = pizzaInput[1];

                var doughInput = Console.ReadLine().Split();
                var flourType = doughInput[1].ToLower();
                var bakingTechnique = doughInput[2].ToLower();
                var doughWeight = double.Parse(doughInput[3]);

                var dough = new Dough(flourType, bakingTechnique, doughWeight);


                var pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    var toppingInput = Console.ReadLine().Split();

                    if (toppingInput[0] == "END")
                    {
                        break;
                    }
                    var toppingType = toppingInput[1];
                    var toppingWeight = double.Parse(toppingInput[2]);

                    var topping = new Toppings(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
