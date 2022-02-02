namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void When_WeSetName_ShoulBeSetCorrectly()
        {
            string name = "Voden";
            aquarium = new Aquarium(name, 15);
            Assert.AreEqual(name, aquarium.Name);
        }
        [Test]
        public void When_WeSetCapacity_ShoulBeSetCorrectly()
        {
            int capacity = 15;
            aquarium = new Aquarium("Misho", capacity);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }
        [Test]
        public void When_WeSetNameNull_ShouldThrowArgumentNullException()
        {
            string name = null;
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                aquarium = new Aquarium(name, 15);
            });
            Assert.AreEqual("Invalid aquarium name! (Parameter 'value')", ex.Message);
        }
        [Test]
        public void When_WeSetNameEmpty_ShouldThrowArgumentNullException()
        {
            string name = string.Empty;
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                aquarium = new Aquarium(name, 15);
            });
            Assert.AreEqual("Invalid aquarium name! (Parameter 'value')", ex.Message);
        }
        [Test]
        public void When_WeSetCapacitySmollestThanZero_ShouldThrowArgumentException()
        {
            int capacity = -1;
            Assert.That(() =>
            {
                aquarium = new Aquarium("Pesho", capacity);
            }, Throws.ArgumentException.With.Message.EqualTo("Invalid aquarium capacity!"));
        }
        [Test]
        public void When_WeAddSomeFishes_AndGetCount_SholudReternTheCountOfTheFishes()
        {
            aquarium = new Aquarium("Pesho", 10);
            aquarium.Add(new Fish("Koko"));
            aquarium.Add(new Fish("Misho"));
            aquarium.Add(new Fish("Gogi"));
            Assert.AreEqual(3, aquarium.Count);
        }
        [Test]
        public void When_WeAddFish_ShouldBeAddedCorrectly()
        {
            aquarium = new Aquarium("Pesho", 10);
            string fishName = "Koko";
            Fish fish = new Fish(fishName);
            aquarium.Add(fish);
            Assert.AreEqual(fish, aquarium.SellFish(fishName));
        }
        [Test]
        public void When_WeAddFish_ButTheCapacityIsFull_ShouldThrowInvalidOperationException()
        {
            aquarium = new Aquarium("Pesho", 2);
            aquarium.Add(new Fish("Koko"));
            aquarium.Add(new Fish("Misho"));
            Assert.That(() =>
            {
                aquarium.Add(new Fish("Gogi"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("Aquarium is full!"));
        }
        [Test]
        public void When_WeRemoveFish_ShouldBeRemovedCorrectly()
        {
            string fishName = "Koko";
            aquarium = new Aquarium("Pesho", 2);
            aquarium.Add(new Fish(fishName));
            aquarium.RemoveFish(fishName);
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void When_WeRemoveFish_WithTheNonExistingName_ShouldThrowInvalidOperationException()
        {
            string fishName = "Gogi";
            aquarium = new Aquarium("Pesho", 2);
            aquarium.Add(new Fish("Pesho"));
            Assert.That(() =>
            {
                aquarium.RemoveFish(fishName);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Fish with the name {fishName} doesn't exist!"));
        }
        [Test]
        public void When_WeSellFish_ShouldReturnTheFishWithThatName()
        {
            string fishName = "Gogi";
            aquarium = new Aquarium("Pesho", 2);
            Fish fish = new Fish(fishName);
            aquarium.Add(fish);
            Assert.AreEqual(fish, aquarium.SellFish(fishName));
        }
        [Test]
        public void When_WeSellFish_TheFishShouldntBeAvailable()
        {
            string fishName = "Gogi";
            aquarium = new Aquarium("Pesho", 2);
            Fish fish = new Fish(fishName);
            aquarium.Add(fish);
            aquarium.SellFish(fishName);
            Assert.IsFalse(fish.Available);
        }
        [Test]
        public void When_WeSellFish_ButThatFishDoesntExist_ShouldThrowInvalidOperationException()
        {
            string fishName = "Misho";
            aquarium = new Aquarium("Pesho", 2);
            Assert.That(() =>
            {
                aquarium.RemoveFish(fishName);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Fish with the name {fishName} doesn't exist!"));
        }
        [Test]
        public void When_WeReportAquarium_ShouldReturnStringCorrectly()
        {
            string aquariumName = "Voden";
            List<Fish> fishes = new List<Fish>();
            aquarium = new Aquarium(aquariumName, 10);
            fishes.Add(new Fish("Koko"));
            fishes.Add(new Fish("Misho"));
            fishes.Add(new Fish("Gogi"));
            aquarium.Add(new Fish("Koko"));
            aquarium.Add(new Fish("Misho"));
            aquarium.Add(new Fish("Gogi"));
            string result = $"Fish available at {aquariumName}: {string.Join(", ",fishes.Select(f => f.Name))}";
            Assert.AreEqual(result, aquarium.Report());
        }
    }
}
