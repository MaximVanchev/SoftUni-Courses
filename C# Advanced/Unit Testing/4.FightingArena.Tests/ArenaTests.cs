using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FightingArena.Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private List<Warrior> warriarList;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warriarList = new List<Warrior>();
        }
        [Test]
        public void When_WeMakeArena_WarriorsShouldBeEmptyList()
        {
            Assert.AreEqual(warriarList, arena.Warriors);
        }
        [Test]
        public void When_WeEnrollSomeWarriors_TheCountShouldBeTheCountOfTheWarriors()
        {
            arena.Enroll(new Warrior("Gogi", 10, 100));
            arena.Enroll(new Warrior("Pepi", 10, 100));
            arena.Enroll(new Warrior("Koko", 10, 100));
            int arenaCount = 3;
            Assert.AreEqual(arenaCount, arena.Count);
        }
        [Test]
        public void When_WeEnrollWarriorWhoIsEnrolledAlready_ShouldThrowInvalidOperationException()
        {
            arena.Enroll(new Warrior("Gogi", 10, 100));
            Assert.That(() =>
            {
                arena.Enroll(new Warrior("Gogi", 10, 100));
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Warrior is already enrolled for the fights!"));
        }
        [Test]
        public void When_WeFightTwoWarriors_ButWarriorIsNotInTheWarriorsList_ShouldThrowInvalidOperationException()
        {
            arena.Enroll(new Warrior("Gogi", 10, 100));
            arena.Enroll(new Warrior("Pepi", 10, 100));
            arena.Enroll(new Warrior("Koko", 10, 100));
            string missingName = "Misho";
            Assert.That(() =>
            {
                arena.Fight("Gogi", missingName);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {missingName} enrolled for the fights!"));
        }
        [Test]
        public void When_WeFightTwoWarriors_ButAttackerIsNotInTheWarriorsList_ShouldThrowInvalidOperationException()
        {
            arena.Enroll(new Warrior("Gogi", 10, 100));
            arena.Enroll(new Warrior("Pepi", 10, 100));
            arena.Enroll(new Warrior("Koko", 10, 100));
            string missingName = "Misho";
            Assert.That(() =>
            {
                arena.Fight(missingName, "Koko");
            }, Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {missingName} enrolled for the fights!"));
        }
        [Test]
        public void When_WeFightTwoWarriors_ButOneOfThemIsNotInTheWarriorsList_ShouldThrowInvalidOperationException()
        {
            arena.Enroll(new Warrior("Gogi", 10, 100));
            arena.Enroll(new Warrior("Pepi", 10, 100));
            arena.Enroll(new Warrior("Koko", 10, 100));
            string firstMissingName = "Misho";
            string secondMissingName = "Smrudlo";
            Assert.That(() =>
            {
                arena.Fight(firstMissingName, secondMissingName);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {secondMissingName} enrolled for the fights!"));
        }
        [Test]
        public void When_WeEnrollSomeWarriors_TheWarriorsSholdBeEnrolledCorrectly()
        {
            string name = "Gogi";
            arena.Enroll(new Warrior(name, 10, 100));
            Assert.IsTrue(arena.Warriors.Any(w => w.Name == name));
        }
    }
}
