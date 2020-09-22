using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelCapacity;
            
        [SetUp]
        public void Setup()
        {
            this.make = "Seat";
            this.model = "Leon";
            this.fuelConsumption = 7.2;
            this.fuelCapacity = 100.00;
        }

        [Test]
        public void PrivateConstrucotrCreateCar()
        {
            var car = Activator.CreateInstance(typeof(Car), true);
            Assert.IsNotNull(car);
        }

        [Test]
        public void ConstructorShouldInitializeCarWithProvidedParameters()
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.IsNotNull(car);
        }

        [Test]
        public void MakeNullThrowsException()
        {
            string nullMake = null;
            Assert.That(() => new Car(nullMake, model, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void MakeEmptyThrowsException()
        {
            string emptyMake = "";
            Assert.That(() => new Car(emptyMake, model, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void ModelNullThrowsException()
        {
            string nullModel = null;
            Assert.That(() => new Car(make, nullModel, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void ModelEmptyThrowsException()
        {
            string emptyModel = "";
            Assert.That(() => new Car(make, emptyModel, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void ZeroFuelConsumptionThrowsException()
        {
            var zeroFuelConsumption = 0;
            Assert.That(() => new Car(make, model, zeroFuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void NegativeFuelCapacityThrowsException()
        {
            var negativeFuelConsumption = -5;
            Assert.That(() => new Car(make, model, negativeFuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void RefuelWithNegativeNumberShouldThrow()
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.That(() => car.Refuel(-10), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void RefuelWithZeroShouldThrow()
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.That(() => car.Refuel(0), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void TestRegularRefuelWithoutExcidingTheCapacity()
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10.00);
            Assert.That(car.FuelAmount, Is.EqualTo(10));
        }

        [Test]
        public void TestRegularRefuelExcidingTheCapacity()
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(110.00);
            Assert.That(car.FuelAmount, Is.EqualTo(100));
        }

        [Test]
        public void DriveWithSuficientFuelAmount()
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(100.00);
            car.Drive(300);
            Assert.That(car.FuelAmount, Is.EqualTo(78.40));
        }

        [Test]
        public void DriveWithInsuficientFuelAmount()
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);
            Assert.That(() => car.Drive(10000), Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}