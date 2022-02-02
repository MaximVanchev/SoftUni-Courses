using NUnit.Framework;

namespace FightingArena.Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;
        private string attackerName = "Gogi";
        private int attackerDamage = 60;
        private int attackerHp = 300;
        private string warriorName = "Gosheto";
        private int warriorDamage = 50;
        private int warriorHp = 350;
        private Warrior attacker;
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            attacker = new Warrior(attackerName, attackerDamage, attackerHp);
            warrior = new Warrior(warriorName, warriorDamage, warriorHp);
        }
        [Test]
        public void When_WeSetName_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(attackerName, attacker.Name);
        }
        [Test]
        public void When_WeSetDamage_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(attackerDamage, attacker.Damage);
        }
        [Test]
        public void When_WeSetHP_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(attackerHp, attacker.HP);
        }
        [Test]
        public void When_WeSetNameNull_ShouldThrowArgumentException()
        {
            Assert.That(() =>
            {
                attacker = new Warrior(null, attackerDamage, attackerHp);
            }, Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }
        [Test]
        public void When_WeSetNameWhitespace_ShouldThrowArgumentException()
        {
            Assert.That(() =>
            {
                attacker = new Warrior(" ", attackerDamage, attackerHp);
            }, Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }
        [Test]
        public void When_WeSetDamageNegative_ShouldThrowArgumentException()
        {
            Assert.That(() =>
            {
                attacker = new Warrior(attackerName, -1, attackerHp);
            }, Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }
        [Test]
        public void When_WeSetDamageZero_ShouldThrowArgumentException()
        {
            Assert.That(() =>
            {
                attacker = new Warrior(attackerName, 0, attackerHp);
            }, Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }
        [Test]
        public void When_WeSetHpNegative_ShouldThrowArgumentException()
        {
            Assert.That(() =>
            {
                attacker = new Warrior(attackerName, attackerDamage, -1);
            }, Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }
        [Test]
        public void When_WeAttackWarrior_ShouldSubtractWarriorDamageFromAttackerHp()
        {
            attacker.Attack(warrior);
            Assert.AreEqual(attackerHp - warriorDamage, attacker.HP);
        }
        [Test]
        public void When_WeAttackWarrior_ShouldSubtractAttackerDamageFromWarriorHp()
        {
            attacker.Attack(warrior);
            Assert.AreEqual(warriorHp - attackerDamage, warrior.HP);
        }
        [Test]
        public void When_WeAttackWarrior_AndWarriarHPIsSmallerThanTheAttacherDamage_WarriarHpShouldBeZero()
        {
            warriorHp = 40;
            warrior = new Warrior(warriorName, warriorDamage, warriorHp);
            attacker.Attack(warrior);
            Assert.AreEqual(0, warrior.HP);
        }
        [Test]
        public void When_AttackerHpIsSmallerThanTheMinAttackHp_ShoudThrowInvalidOperationException()
        {
            attackerHp = 25;
            attacker = new Warrior(attackerName, attackerDamage, attackerHp);
            Assert.That(() =>
            {
                attacker.Attack(warrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }
        [Test]
        public void When_AttackerHpIsEqualToTheMinAttackHp_ShoudThrowInvalidOperationException()
        {
            attackerHp = 30;
            attacker = new Warrior(attackerName, attackerDamage, attackerHp);
            Assert.That(() =>
            {
                attacker.Attack(warrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }
        [Test]
        public void When_WarriarHpIsSmallerThanTheMinAttackHp_ShoudThrowInvalidOperationException()
        {
            warriorHp = 25;
            warrior = new Warrior(warriorName, warriorDamage, warriorHp);
            Assert.That(() =>
            {
                attacker.Attack(warrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));
        }
        [Test]
        public void When_WarriarHpIsEqualToTheMinAttackHp_ShoudThrowInvalidOperationException()
        {
            warriorHp = 30;
            warrior = new Warrior(warriorName, warriorDamage, warriorHp);
            Assert.That(() =>
            {
                attacker.Attack(warrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));
        }
        [Test]
        public void When_AttackerHpIsSmallerThanTheWarriarHp_ShoudThrowInvalidOperationException()
        {
            warriorDamage = 350;
            warrior = new Warrior(warriorName, warriorDamage, warriorHp);
            Assert.That(() =>
            {
                attacker.Attack(warrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"You are trying to attack too strong enemy"));
        }
        [TearDown]
        public void TearDown()
        {
            attackerName = "Gogi";
            attackerDamage = 60;
            attackerHp = 300;
            warriorName = "Gosheto";
            warriorDamage = 50;
            warriorHp = 350;
        }
    }
}