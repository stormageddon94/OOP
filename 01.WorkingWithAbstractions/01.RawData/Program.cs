using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _01.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < countOfCars; i++)
            {
                var carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = carData[0];
                var engineSpeed = int.Parse(carData[1]);
                var enginePower = int.Parse(carData[2]);
                var engine = new Engine(model, engineSpeed, enginePower);

                var cargoWeight = int.Parse(carData[3]);
                var cargoType = Enum.Parse<CargoType>(carData[4]);
                var cargo = new Cargo(cargoType, cargoWeight);

                var tyresInfo = carData.Skip(5).ToArray();
                var tyres = new List<Tyre>();
                for (int j = 0; j < tyresInfo.Length; j += 2)
                {
                    var tyrePressure = double.Parse(tyresInfo[j]);
                    var tyreAge = int.Parse(tyresInfo[j + 1]);
                    var currentTyre = new Tyre(tyreAge, tyrePressure);
                    tyres.Add(currentTyre);
                }

                var currentCar = new Car(engine, cargo, tyres);
                cars.Add(currentCar);
            }

            var typeOfCargo = Console.ReadLine();
            if (typeOfCargo == "fragile")
            {
                var carsToPrint = cars.Where(x => x.Cargo.CargoType == CargoType.fragile && x.Tyres.Any(x => x.TyrePressure < 1)).ToList();
                foreach (var car in carsToPrint)
                {
                    Console.WriteLine(car.Engine.Model);
                }
            }
            else
            {
                var carsToPrint = cars.Where(x => x.Cargo.CargoType == CargoType.flamable && x.Engine.Power > 250).ToList();
                foreach (var car in carsToPrint)
                {
                    Console.WriteLine(car.Engine.Model);
                }
            }


        }
    }
}
