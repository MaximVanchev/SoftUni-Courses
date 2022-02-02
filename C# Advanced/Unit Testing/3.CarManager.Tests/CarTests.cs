using NUnit.Framework;
using System;

namespace CarManager.Tests
{
    [TestFixture]
    public class CarTests
    {
        private string make = "abc";

        private string model = "BMW";

        private double fuelConsumption = 1.5;

        private double fuelAmount = 0;

        private double fuelCapacity = 100;

        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }
        [Test]
        public void When_WeSetMake_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(make, car.Make);
        }
        [Test]
        public void When_WeSetModel_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(model, car.Model);
        }
        [Test]
        public void When_WeSetFuelConsumption_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
        }
        [Test]
        public void When_WeSetFuelCapacity_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }
        [Test]
        public void When_WeSetFuelAmount_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }
        [Test]
        public void When_WeSetTheMakeNull_ShouldThrowArgumentExeption()
        {
            make = null;
            Assert.That(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }
        [Test]
        public void When_WeSetTheMakeEmpty_ShouldThrowArgumentExeption()
        {
            make = string.Empty;
            Assert.That(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }
        [Test]
        public void When_WeSetTheModelNull_ShouldThrowArgumentExeption()
        {
            model = null;
            Assert.That(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }
        [Test]
        public void When_WeSetTheModelEmpty_ShouldThrowArgumentExeption()
        {
            model = string.Empty;
            Assert.That(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }
        [Test]
        public void When_WeSetTheFuelConsumptionNegative_ShouldThrowArgumentExeption()
        {
            fuelConsumption = -1;
            Assert.That(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }
        [Test]
        public void When_WeSetTheFuelConsumptionZero_ShouldThrowArgumentExeption()
        {
            fuelConsumption = 0;
            Assert.That(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }
        [Test]
        public void When_WeSetTheFuelCapacityNegative_ShouldThrowArgumentExeption()
        {
            fuelCapacity = -1;
            Assert.That(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }
        [Test]
        public void When_WeSetTheFuelCapacityZero_ShouldThrowArgumentExeption()
        {
            fuelCapacity = 0;
            Assert.That(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }
        [Test]
        public void When_WeRefuel_TheFuelShouldBeAddedToTheFuelAmount()
        {
            car.Refuel(30);
            Assert.AreEqual(fuelAmount + 30, car.FuelAmount);
        }
        [Test]
        public void When_WeRefuelNegativeFuel_ShouldThrowArgumentExeption()
        {
            Assert.That(() =>
            {
                car.Refuel(-20);
            }, Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }
        [Test]
        public void When_WeRefuelZeroFuel_ShouldThrowArgumentExeption()
        {
            Assert.That(() =>
            {
                car.Refuel(0);
            }, Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }
        [Test]
        public void When_WeRefuel_AndTheAmountGotBiggerThanTheFuelCapacity_TheFualAmountShoudBeEqualToTheCapacity()
        {
            car.Refuel(30);
            car.Refuel(90);
            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }
        [Test]
        public void When_WeDrive_TheFuelAmountShoudBeSubtracted()
        {
            double distance = 35;
            double amountToSubtract = (distance / 100) * fuelConsumption;
            car.Refuel(50);
            car.Drive(distance);
            Assert.AreEqual(50 - amountToSubtract, car.FuelAmount);
        }
        [Test]
        public void When_WeDrive_AndTheFuelAmountIsSmallerThanTheFuelNeeded_SholdThrowInvalidOperationException()
        {
            double distance = 200;
            double amountToSubtract = (distance / 100) * fuelConsumption;
            car.Refuel(1);
            Assert.That(() =>
            {
                car.Drive(distance);
            }, Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }
        [TearDown]
        public void TearDown()
        {
            make = "abc";

            model = "BMW";

            fuelConsumption = 1.5;

            fuelAmount = 0;

            fuelCapacity = 100;
        }
    }
}
