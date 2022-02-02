using NUnit.Framework;
using System;

namespace ExtendedDatabase.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        Person[] people = new Person[16];
        private int count = 16;
        private ExtendedDatabase database;
        [SetUp]
        public void SetUp()
        {
            for (int i = 0; i < 16; i++)
            {
                people[i] = new Person(i, i.ToString());
            }
            database = new ExtendedDatabase(people);
        }
        [Test]
        public void When_CountIsSet_ShouldToBeSetCorrectly()
        {
            Assert.AreEqual(count, database.Count);
        }
        [Test]
        public void When_PeopleIsSet_ShouldToBeSetCorrectly()
        {
            Assert.AreEqual(people[0], database.FindById(0));
        }
        [Test]
        public void When_WeAdd_TheCountShouldBePlusOne()
        {
            database = new ExtendedDatabase();
            database.Add(new Person(15,"Gogi"));
            Assert.AreEqual(1, database.Count);
        }
        [Test]
        public void When_WeMakeDatabaseWithMoreThan16People_ShouldThrowArgumentException()
        {
            people = new Person[17];
            Assert.That(() =>
            {
                database = new ExtendedDatabase(people);
            }, Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }
        [Test]
        public void When_WeAddPersonAndTheCountIs16_ShouldThrowInvalidOperationExeption()
        {
            Assert.That(() =>
            {
                database.Add(new Person(12,"Gosheto"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void When_WeAddPersonWithUsernameThatOtherPersonHave_ShouldThrowInvalidOperationException()
        {
            database = new ExtendedDatabase();
            database.Add(new Person(15, "Gosheto"));
            Assert.That(() =>
            {
                database.Add(new Person(12, "Gosheto"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }
        [Test]
        public void When_WeAddPersonWithIdThatOtherPersonHave_ShouldThrowInvalidOperationException()
        {
            database = new ExtendedDatabase();
            database.Add(new Person(12, "Misho"));
            Assert.That(() =>
            {
                database.Add(new Person(12, "Gosheto"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }
        [Test]
        public void When_WeRemoveElement_ShouldBeRemoved()
        {
            Person lastPerson = new Person(15,"15");
            database.Remove();
            Assert.That(() =>
            {
                database.FindById(lastPerson.Id);
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
            Assert.That(() =>
            {
                database.FindByUsername(lastPerson.UserName);
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }
        [Test]
        public void When_WeAddElement_ShouldBeAdded()
        {
            database = new ExtendedDatabase();
            Person person = new Person(16, "Gogi");
            database.Add(person);
            Assert.AreEqual(person, database.FindById(person.Id));
            Assert.AreEqual(person, database.FindByUsername(person.UserName));
        }
        [Test]
        public void When_WeRemovePersonAndTheCountIsZero_ShouldThrowInvalidOperationExeption()
        {
            database = new ExtendedDatabase();
            Assert.That(() =>
            {
                database.Remove();
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void When_WeFindByUsername_ShouldReturnThePerson()
        {
            database = new ExtendedDatabase();
            Person person = new Person(16, "Gogi");
            database.Add(new Person(10, "Pepe"));
            database.Add(person);
            database.Add(new Person(13, "Koko"));
            Assert.AreEqual(person, database.FindByUsername(person.UserName));
        }
        [Test]
        public void When_WeFindById_ShouldReturnThePerson()
        {
            database = new ExtendedDatabase();
            Person person = new Person(16, "Gogi");
            database.Add(new Person(10,"Pepe"));
            database.Add(person);
            database.Add(new Person(13,"Koko"));
            Assert.AreEqual(person, database.FindById(person.Id));
        }
        [Test]
        public void When_WeFindByUsernameWithNull_ShouldThrowArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
            Assert.AreEqual("Username parameter is null!", ex.ParamName);
        }
        [Test]
        public void When_WeFindByIdWithNegativeNum_ShouldThrowArgumentOutOfRangeException()
        {
            ArgumentOutOfRangeException ex =Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            });
            Assert.AreEqual("Id should be a positive number!", ex.ParamName);
        }
        [TearDown]
        public void TearDown()
        {
            people = new Person[16];
            count = 16;
        }
    }
}
