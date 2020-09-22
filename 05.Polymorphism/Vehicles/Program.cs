using System;
using Vehicles.Models;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var fuelQuantity = double.Parse(carInfo[1]);
            var fuelConsumption = double.Parse(carInfo[2]);
            var tankCapacity = double.Parse(carInfo[3]);
            var car = new Car(tankCapacity, fuelQuantity, fuelConsumption);

            var truckInfo = Console.ReadLine().Split();
            fuelQuantity = double.Parse(truckInfo[1]);
            fuelConsumption = double.Parse(truckInfo[2]);
            tankCapacity = double.Parse(truckInfo[3]);
            var truck = new Truck(tankCapacity, fuelQuantity, fuelConsumption);

            var busInfo = Console.ReadLine().Split();
            fuelQuantity = double.Parse(busInfo[1]);
            fuelConsumption = double.Parse(busInfo[2]);
            tankCapacity = double.Parse(busInfo[3]);
            var bus = new Bus(tankCapacity, fuelQuantity, fuelConsumption);

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var commandData = Console.ReadLine().Split();
                var command = commandData[0];
                var vehicleType = commandData[1];
                if (command == "Drive")
                {
                    var distance = double.Parse(commandData[2]);
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(0.9, distance, vehicleType)); 
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(1.6, distance, vehicleType));
                    }
                    else
                    {
                        Console.WriteLine(bus.Drive(1.4, distance, vehicleType));
                    }
                }
                else if(command == "DriveEmpty")
                {
                    var distance = double.Parse(commandData[2]);
                    Console.WriteLine(bus.Drive(0.0, distance, vehicleType));
                }
                else 
                {
                    try
                    {
                        var fuelToAdd = double.Parse(commandData[2]);
                        if (vehicleType == "Car")
                        {
                            try
                            {
                                car.Refuel(fuelToAdd);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (vehicleType == "Truck")
                        {
                            try
                            {
                                truck.Refuel(fuelToAdd);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                bus.Refuel(fuelToAdd);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                   
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
