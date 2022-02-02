using NUnit.Framework;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }
        [Test]
        public void When_WeAddSomeDrivers_AndGetCount_ShouldReturnTheCountOfTheDrivers()
        {
            raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Kola", 20, 10)));
            raceEntry.AddDriver(new UnitDriver("Misho", new UnitCar("Lambo", 30, 2)));
            raceEntry.AddDriver(new UnitDriver("Gogo", new UnitCar("Suzuki", 60, 4)));
            Assert.AreEqual(3, raceEntry.Counter);
        }
        [Test]
        public void When_WeAddDriver_ButTheDriverIsNull_ShouldThrowInvalidOperationException()
        {
            Assert.That(() =>
            {
                raceEntry.AddDriver(null);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Driver cannot be null."));
        }
        [Test]
        public void When_WeAddDriver_ButTheDriverIsAlreadyAdded_ShouldThrowInvalidOperationException()
        {
            string name = "Gogi";
            raceEntry.AddDriver(new UnitDriver(name, new UnitCar("Kola", 20, 10)));
            Assert.That(() =>
            {
                raceEntry.AddDriver(new UnitDriver(name, new UnitCar("Kola", 20, 10)));
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Driver {name} is already added."));
        }
        [Test]
        public void When_WeAddDriver_ShouldReturnCorrectString()
        {
            string name = "Gogi";
            string driverAddedString = $"Driver {name} added in race.";
            Assert.AreEqual(driverAddedString, raceEntry.AddDriver(new UnitDriver(name, new UnitCar("Kola", 20, 10))));
        }
        [Test]
        public void When_WeAddSomeDrivers_And_ShouldReturnTheAverageHorsePower()
        {
            raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Kola", 20, 10)));
            raceEntry.AddDriver(new UnitDriver("Misho", new UnitCar("Lambo", 30, 2)));
            raceEntry.AddDriver(new UnitDriver("Gogo", new UnitCar("Suzuki", 60, 4)));
            double averageHorsePower = (20 + 30 + 60) / 3.0;
            Assert.AreEqual(averageHorsePower, raceEntry.CalculateAverageHorsePower());
        }
        [Test]
        public void When_WeGetCalculateAverageHorsePower_AndTheDriversAreSmollestThanTheMinParticipants_ShouldThrowInvalidOperationException()
        {
            int minParticipants = 2;
            raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Kola", 20, 10)));
            Assert.That(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            }, Throws.InvalidOperationException.With.Message.EqualTo($"The race cannot start with less than {minParticipants} participants."));
        }
    }
}