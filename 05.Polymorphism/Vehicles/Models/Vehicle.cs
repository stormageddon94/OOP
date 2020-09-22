using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double TankCapacity { get; private set; }

        public double FuelQuantity 
        { 
            get { return this.fuelQuantity; }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption { get; private set; }
        
        public virtual string Drive(double additionalFuelConsumption, double distance, string type)
        {
            var fuelConsumed = (this.FuelConsumption + additionalFuelConsumption) * distance;
            if (this.FuelQuantity >= fuelConsumed)
            {
                this.FuelQuantity -= fuelConsumed;
                return $"{type} travelled {distance} km";
            }
            else
            {
                return $"{type} needs refueling";
            }
        }

        public virtual void Refuel(double fuelAmountToAdd)
        {
            if (fuelAmountToAdd <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            var totalFuel = this.FuelQuantity + fuelAmountToAdd;
            if (totalFuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmountToAdd} fuel in the tank");
            }

            this.FuelQuantity += fuelAmountToAdd;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:F2}";
        }

    }
}
