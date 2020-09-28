using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Cotracts;
using WildFarm.Foods;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {

            var rowCounter = 0;
            var animals = new List<IAnimal>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                if (rowCounter % 2 == 0)
                {
                    var animalInfo = input.Split();
                    var animalType = animalInfo[0];
                    var animalName = animalInfo[1];
                    var animalWeight = decimal.Parse(animalInfo[2]);

                    var foodInfo = Console.ReadLine().Split();
                    var foodName = foodInfo[0];
                    //var vegetable = new Vegetable(4);
                    //var typePath = vegetable.GetType().FullName;
                    //var foodType = Type.GetType(typePath);
                    var foodType = Type.GetType($"WildFarm.Foods.{foodName}"); 
                    var foodQuantity = int.Parse(foodInfo[1]);
                    var food = Activator.CreateInstance(foodType, new Object[] { foodQuantity });
                    //var food = new Vegetable(int.Parse(foodInfo[1]));


                    if (animalType == "Tiger")
                    {
                        var livingRegion = animalInfo[3];
                        var breed = animalInfo[4];
                        var tiger = new Tiger(animalName, animalWeight, livingRegion, breed);
                        Console.WriteLine(tiger.AskForFood());
                        TryEatFood(tiger, (IFood)food);
                        animals.Add(tiger);
                    }
                    else if (animalType == "Cat")
                    {
                        
                        var livingRegion = animalInfo[3];
                        var breed = animalInfo[4];
                        var cat = new Cat(animalName, animalWeight, livingRegion, breed);
                        Console.WriteLine(cat.AskForFood()); 
                        TryEatFood(cat, (IFood)food);
                        animals.Add(cat);
                    }
                    else if (animalType == "Owl")
                    {
                        var wingSize = decimal.Parse(animalInfo[3]);
                        var owl = new Owl(animalName, animalWeight, wingSize);
                        Console.WriteLine(owl.AskForFood()); 
                        TryEatFood(owl, (IFood)food);
                        animals.Add(owl);
                    }
                    else if (animalType == "Hen")
                    {
                        var wingSize = decimal.Parse(animalInfo[3]);
                        var hen = new Hen(animalName, animalWeight, wingSize);
                        Console.WriteLine(hen.AskForFood()); 
                        TryEatFood(hen, (IFood)food);
                        animals.Add(hen);
                    }
                    else if (animalType == "Mouse")
                    {
                        var livingRegion = animalInfo[3];
                        var mouse = new Mouse(animalName, animalWeight, livingRegion);
                        Console.WriteLine(mouse.AskForFood()); 
                        TryEatFood(mouse, (IFood)food);
                        animals.Add(mouse);
                    }
                    else if (animalType == "Dog")
                    {
                        var livingRegion = animalInfo[3];
                        var dog = new Dog(animalName, animalWeight, livingRegion);
                        Console.WriteLine(dog.AskForFood()); 
                        TryEatFood(dog, (IFood)food);
                        animals.Add(dog);
                    }
                }

                rowCounter += 2;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }

        public static void TryEatFood(IAnimal animal, IFood food)
        {
            try
            {
                animal.Eat((IFood)food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
