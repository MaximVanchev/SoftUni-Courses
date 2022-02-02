using System;
using System.Linq;
using NUnit.Framework;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private int[] data = new int[16] { 3, 5, 6, 7, 0, 10, 37, 99, 18, 37, 10, 34, 78, 14, 82, 58 };
        private int count = 16;
        private Database database;
        [SetUp]
        public void SetUp()
        {
            database = new Database(data);
        }
        [Test]
        public void When_CountIsSet_ShouldToBeSetCorrectly()
        {
            Assert.AreEqual(count, database.Count);
        }
        [Test]
        public void When_DataIsSet_ShouldToBeSetCorrectly()
        {
            Assert.AreEqual(data, database.Fetch());
        }
        [Test]
        public void When_WeAdd_TheCountShouldBePlusOne()
        {
            database = new Database();
            database.Add(2);
            Assert.AreEqual(1, database.Count);
        }
        [Test]
        public void When_WeMakeDatabaseWithMoreThan16Elemonts_ShouldThrowInvalidOperationExeption()
        {
            data = new int[17];
            Assert.That(() =>
            {
                database = new Database(data);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void When_WeAddElementAndTheCountIs16_ShouldThrowInvalidOperationExeption()
        {
            Assert.That(() =>
            {
                database.Add(3);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void When_WeRemoveElement_ShouldBeRemoved()
        {
            int lastNum = 58;
            database.Remove();
            int[] elements = database.Fetch();
            Assert.IsFalse(elements.Contains(lastNum));
        }
        [Test]
        public void When_WeAddElement_ShouldBeAdded()
        {
            database = new Database();
            database.Add(123);
            int[] elements = database.Fetch();
            Assert.IsTrue(elements.Contains(123));
        }
        [Test]
        public void When_WeRemoveElementAndTheCountIsZero_ShouldThrowInvalidOperationExeption()
        {
            database = new Database();
            Assert.That(() =>
            {
                database.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }
        [Test]
        public void When_WeFetchDatabase_ShouldGiveIntArrayOfTheElements()
        {
            Assert.AreEqual(data, database.Fetch());
        }
        [TearDown]
        public void TearDown()
        {
            data = new int[16] { 3, 5, 6, 7, 0, 10, 37, 99, 18, 37, 10, 34, 78, 14, 82, 58 };
            count = 16;
        }
    }
}
