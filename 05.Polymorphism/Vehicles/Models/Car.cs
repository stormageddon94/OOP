using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        //public override string ToString()
        //{
        //    return $"Car: {this.FuelQuantity:F2}";
        //}
    }
}
