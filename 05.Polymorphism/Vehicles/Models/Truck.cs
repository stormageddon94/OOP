using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override void Refuel(double fuelAmountToAdd)
        {
            var totalFuel = this.FuelQuantity + fuelAmountToAdd;
            if (totalFuel > this.TankCapacity)
            {
                base.Refuel(fuelAmountToAdd);
            }
            else
            {
                var fuelToRemove = fuelAmountToAdd * 0.05;
                fuelAmountToAdd -= fuelToRemove;
                base.Refuel(fuelAmountToAdd);
            }
        }

        //public override string ToString()
        //{
        //    return $"Truck: {this.FuelQuantity:F2}";
        //}
    }
}
