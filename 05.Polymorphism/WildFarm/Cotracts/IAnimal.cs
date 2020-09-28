using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Cotracts
{
    public interface IAnimal
    {
        string Name { get; }

        decimal Weight { get; }

        long FoodEaten { get; }

        string AskForFood();

        void Eat(IFood food);
    }
}
