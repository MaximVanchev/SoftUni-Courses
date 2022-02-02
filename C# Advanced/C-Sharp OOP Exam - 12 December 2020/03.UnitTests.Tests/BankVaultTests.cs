using System;
using NUnit.Framework;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault bankVault;
        [SetUp]
        public void SetUp()
        {
            bankVault = new BankVault();
        }
        [Test]
        public void When_WeCreateBankVault_ShoudSetCorrectly()
        {
            Assert.AreEqual(null, bankVault.VaultCells["A1"]);
        }
        [Test]
        public void When_WeAddCell_ShouldBeAddedToVaultCells()
        {
            string cell = "B3";
            Item item = new Item("Gogi", "13");
            bankVault.AddItem(cell, item);
            Assert.AreEqual(item, bankVault.VaultCells[cell]);
        }
        [Test]
        public void When_WeAddCell_ShouldBeAddedCorrectly()
        {
            string cell = "C1";
            Item item = new Item("Misho", "16");
            bankVault.AddItem(cell, item);
            Assert.AreEqual(item, bankVault.VaultCells[cell]);
        }
        [Test]
        public void When_WeAddCell_AndThatCellDoesntExist_ShouldThrowArgumentException()
        {
            string cell = "W3";
            Item item = new Item("Gogi", "13");
            Assert.That(() =>
            {
                bankVault.AddItem(cell, item);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }
        [Test]
        public void When_WeAddCell_ButThatCellIsTakenAlready_ShouldThrowArgumentException()
        {
            string cell = "B3";
            Item itemOne = new Item("Gogi", "13");
            Item itemTwo = new Item("Misho", "16");
            bankVault.AddItem(cell, itemOne);
            Assert.That(() =>
            {
                bankVault.AddItem(cell, itemTwo);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell is already taken!"));
        }
        [Test]
        public void When_WeAddCell_ButThatItemIdIsAlreadySet_ShouldThrowInvalidOperationException()
        {
            string cellOne = "B3";
            string cellTwo = "A2";
            Item itemOne = new Item("Gogi", "16");
            Item itemTwo = new Item("Misho", "16");
            bankVault.AddItem(cellOne, itemOne);
            Assert.That(() =>
            {
                bankVault.AddItem(cellTwo, itemTwo);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Item is already in cell!"));
        }
        [Test]
        public void When_WeAddCell_ShouldReturnCorrectString()
        {
            string cell = "C1";
            Item item = new Item("Misho", "16");
            string addReturnedString = bankVault.AddItem(cell, item);
            Assert.AreEqual($"Item:{item.ItemId} saved successfully!", addReturnedString);
        }
        [Test]
        public void When_WeRemoveCell_ShouldBeRemovedCorrectly()
        {
            string cell = "C1";
            Item item = new Item("Misho", "16");
            bankVault.AddItem(cell, item);
            bankVault.RemoveItem(cell, item);
            Assert.AreEqual(null, bankVault.VaultCells[cell]);
        }
        [Test]
        public void When_WeRemoveCell_AndThatCellDoesntExist_ShouldThrowArgumentException()
        {
            string cell = "W3";
            Item item = new Item("Gogi", "13");
            bankVault.AddItem("A1", item);
            Assert.That(() =>
            {
                bankVault.RemoveItem(cell, item);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }
        [Test]
        public void When_WeRemoveCell_AndTheItemIsNotTheSame_ShouldThrowArgumentException()
        {
            string cell = "C1";
            Item itemOne = new Item("Misho", "16");
            Item itemTwo = new Item("Tosho", "17");
            bankVault.AddItem(cell,itemOne);
            Assert.That(() =>
            {
                bankVault.RemoveItem(cell, itemTwo);
            }, Throws.ArgumentException.With.Message.EqualTo($"Item in that cell doesn't exists!"));
        }
        [Test]
        public void When_WeRemoveCell_ShouldReturnCorrectString()
        {
            string cell = "C1";
            Item item = new Item("Misho", "16");
            bankVault.AddItem(cell, item);
            string removeReturnedString = bankVault.RemoveItem(cell, item);
            Assert.AreEqual($"Remove item:{item.ItemId} successfully!", removeReturnedString);
        }
    }
}
