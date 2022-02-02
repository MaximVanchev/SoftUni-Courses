using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainBlockTests
    {
        private IChainblock chainblock;
        [SetUp]
        public void SetUp()
        {
            chainblock = new Chainblock();
        }
        [Test]
        public void When_WeAddSomeTransactions_ColuntShouldReturnTheCountOfTheTransactions()
        {
            chainblock.Add(new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200));
            chainblock.Add(new Transaction(14, TransactionStatus.Successfull, "Koko", "Pepe", 100));
            chainblock.Add(new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300));
            Assert.AreEqual(3, chainblock.Count);
        }
        [Test]
        public void When_WeAddSomeTransactions_ShouldBeAddCorrectly()
        {
            chainblock.Add(new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200));
            chainblock.Add(new Transaction(14, TransactionStatus.Successfull, "Koko", "Pepe", 100));
            chainblock.Add(new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300));
            Assert.IsTrue(chainblock.Contains(14));
        }
        [Test]
        public void When_WeAddTransactionThatIsAddedAlready_ShouldNotBeAdded()
        {
            chainblock.Add(new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200));
            chainblock.Add(new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200));
            Assert.AreEqual(1, chainblock.Count);
        }
        [Test]
        public void When_WeAddTransaction_AndContainsById_ShouldReturnTrue()
        {
            chainblock.Add(new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200));
            Assert.IsTrue(chainblock.Contains(13));
        }
        [Test]
        public void When_WeAddTransaction_AndContainsByTransaction_ShouldReturnTrue()
        {
            Transaction transaction = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(transaction));
        }
        [Test]
        public void When_WeContainsByIdTransactionThatIsNotInTheList_ShouldReturnFalse()
        {
            chainblock.Add(new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200));
            Assert.IsFalse(chainblock.Contains(12));
        }
        [Test]
        public void When_WeContainsByTransactionTransactionThatIsNotInTheList_ShouldReturnFalse()
        {
            Transaction transaction = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Piko", "Tosho", 500);
            chainblock.Add(transaction);
            Assert.IsFalse(chainblock.Contains(transactionTwo));
        }
        [Test]
        public void When_WeChangeTransactionStatus_ShouldBeChangedCorrectly()
        {
            Transaction transaction = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(13, TransactionStatus.Aborted);
            Assert.AreEqual(TransactionStatus.Aborted, chainblock.GetById(13).Status);
        }
        [Test]
        public void When_WeChangeTransactionStatus_AndTheIdIsInvalid_ShouldThrowArgumentException()
        {
            Transaction transaction = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            chainblock.Add(transaction);
            Assert.That(() =>
            {
                chainblock.ChangeTransactionStatus(12, TransactionStatus.Aborted);
            }, Throws.ArgumentException);
        }
        [Test]
        public void When_WeRemoveSomeTransactionById_ShouldBeRemovedCorrectly()
        {
            chainblock.Add(new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200));
            chainblock.Add(new Transaction(14, TransactionStatus.Successfull, "Koko", "Pepe", 100));
            chainblock.Add(new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300));
            chainblock.RemoveTransactionById(14);
            Assert.IsFalse(chainblock.Contains(14));
        }
        [Test]
        public void When_WeRemoveSomeTransaction_AndTheIdIsInvalid_ShouldThrowInvalidOperationException()
        {
            chainblock.Add(new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200));
            chainblock.Add(new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300));
            Assert.That(() =>
            {
                chainblock.RemoveTransactionById(16);
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void When_WeAddTransaction_AndGetById_ShouldReturnTheTransaction()
        {
            Transaction transaction = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            chainblock.Add(transaction);
            Assert.AreEqual(transaction, chainblock.GetById(13));
        }
        [Test]
        public void When_WeGetById_AndTheTransactionDoesntExist_ShouldThrowInvalidOperationException()
        {
            Transaction transaction = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            chainblock.Add(transaction);
            Assert.That(() =>
            {
                chainblock.GetById(14);
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetByTransactionStatus_ShouldReturnListOfTransactionsWithTheGivenTransactionStatus()
        {
            List<ITransaction> list = new List<ITransaction>();
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            list.Add(transactionOne);
            list.Add(transactionTwo);
            chainblock.Add(transactionOne);
            chainblock.Add(new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100));
            chainblock.Add(transactionTwo);
            Assert.AreEqual(list.OrderByDescending(x => x.Amount).ToList(), chainblock.GetByTransactionStatus(TransactionStatus.Successfull));
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetByTransactionStatus_AndTransactionWithThatTransactionStatusDoesntExist_ShouldThrowInvalidOperationException()
        {
            List<ITransaction> list = new List<ITransaction>();
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            list.Add(transactionOne);
            list.Add(transactionTwo);
            chainblock.Add(transactionOne);
            chainblock.Add(new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100));
            chainblock.Add(transactionTwo);
            Assert.That(() =>
            {
                chainblock.GetByTransactionStatus(TransactionStatus.Failed);
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetAllSendersWithTransactionStatus_ShouldReturnListOfSendersWithTheGivenTransactionStatus()
        {
            List<ITransaction> list = new List<ITransaction>();
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            list.Add(transactionOne);
            list.Add(transactionTwo);
            chainblock.Add(transactionOne);
            chainblock.Add(new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100));
            chainblock.Add(transactionTwo);
            list = list.OrderByDescending(x => x.Amount).ToList();
            List<string> senders = list.Select(x => x.From).ToList();
            Assert.AreEqual(senders, chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull));
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetAllSendersWithTransactionStatus_AndTransactionWithThatTransactionStatusDoesntExist_ShouldThrowInvalidOperationException()
        {
            List<ITransaction> list = new List<ITransaction>();
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            list.Add(transactionOne);
            list.Add(transactionTwo);
            chainblock.Add(transactionOne);
            chainblock.Add(new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100));
            chainblock.Add(transactionTwo);
            list = list.OrderByDescending(x => x.Amount).ToList();
            List<string> senders = list.Select(x => x.From).ToList();
            Assert.That(() =>
            {
                chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed);
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetAllReceiversWithTransactionStatus_ShouldReturnListOfReceiversWithTheGivenTransactionStatus()
        {
            List<ITransaction> list = new List<ITransaction>();
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            list.Add(transactionOne);
            list.Add(transactionTwo);
            chainblock.Add(transactionOne);
            chainblock.Add(new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100));
            chainblock.Add(transactionTwo);
            list = list.OrderByDescending(x => x.Amount).ToList();
            List<string> receivers = list.Select(x => x.To).ToList();
            Assert.AreEqual(receivers, chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull));
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetAllReceiversWithTransactionStatus_AndTransactionWithThatTransactionStatusDoesntExist_ShouldThrowInvalidOperationException()
        {
            List<ITransaction> list = new List<ITransaction>();
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            list.Add(transactionOne);
            list.Add(transactionTwo);
            chainblock.Add(transactionOne);
            chainblock.Add(new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100));
            chainblock.Add(transactionTwo);
            list = list.OrderByDescending(x => x.Amount).ToList();
            List<string> senders = list.Select(x => x.To).ToList();
            Assert.That(() =>
            {
                chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed);
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetAllOrderedByAmountDescendingThenById_ShouldReturnAllTransactionsOrderedByAmountDescendingThenById()
        {
            List<ITransaction> list = new List<ITransaction>();
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100);
            list.Add(transactionOne);
            list.Add(transactionTwo);
            list.Add(transactionTree);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            list = list.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
            Assert.AreEqual(list, chainblock.GetAllOrderedByAmountDescendingThenById());
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetByReceiverOrderedByAmountThenById_ShouldReturnAllTransactionsWithThatReceiverOrderedByAmountThenById()
        {
            List<ITransaction> list = new List<ITransaction>();
            string receiver = "Denis";
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", receiver, 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", receiver, 100);
            list.Add(transactionOne);
            list.Add(transactionTree);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            list = list.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
            Assert.AreEqual(list, chainblock.GetByReceiverOrderedByAmountThenById(receiver));
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetByReceiverOrderedByAmountThenById_AndTransactionWithThatReceiverDoesntExist_ShouldThrowInvalidOperationException()
        {
            List<ITransaction> list = new List<ITransaction>();
            string receiver = "Denis";
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", receiver, 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", receiver, 100);
            list.Add(transactionOne);
            list.Add(transactionTree);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            list = list.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
            Assert.That(() =>
            {
                chainblock.GetByReceiverOrderedByAmountThenById("Koko");
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetBySenderOrderedByAmountThenById_ShouldReturnAllTransactionsWithThatSenderOrderedByAmountThenById()
        {
            List<ITransaction> list = new List<ITransaction>();
            string sender = "Penis";
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, sender, "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, sender, "Koko", 100);
            list.Add(transactionOne);
            list.Add(transactionTree);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            list = list.OrderByDescending(x => x.Amount).ToList();
            Assert.AreEqual(list, chainblock.GetBySenderOrderedByAmountDescending(sender));
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetBySenderOrderedByAmountThenById_AndTransactionWithThatSenderDoesntExist_ShouldThrowInvalidOperationException()
        {
            List<ITransaction> list = new List<ITransaction>();
            string sender = "Penis";
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, sender, "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, sender, "Koko", 100);
            list.Add(transactionOne);
            list.Add(transactionTree);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            list = list.OrderByDescending(x => x.Amount).ToList();
            Assert.That(() =>
            {
                chainblock.GetBySenderOrderedByAmountDescending("Koko");
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetByTransactionStatusAndMaximumAmount_ShouldReturnAllTransactionsWithThatStatusAndLessOrEqualToMaximumAmount()
        {
            List<ITransaction> list = new List<ITransaction>();
            int maximumAmount = 200;
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100);
            Transaction transactionFour = new Transaction(14, TransactionStatus.Successfull, "Mesho", "Keko", 100);
            list.Add(transactionOne);
            list.Add(transactionFour);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            chainblock.Add(transactionFour);
            list = list.OrderByDescending(x => x.Amount).ToList();
            Assert.AreEqual(list, chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, maximumAmount));
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetByTransactionStatusAndMaximumAmount_AndThereIsNoSuchTransaction_ShouldReturnEmptyList()
        {
            List<ITransaction> list = new List<ITransaction>();
            int maximumAmount = 200;
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100);
            Transaction transactionFour = new Transaction(14, TransactionStatus.Successfull, "Mesho", "Keko", 100);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            chainblock.Add(transactionFour);
            list = list.OrderByDescending(x => x.Amount).ToList();
            Assert.AreEqual(list, chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, maximumAmount));
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetBySenderAndMinimumAmountDescending_ShouldReturnAllTransactionsWithThatSenderAndBiggerThenMinimumAmountDescending()
        {
            List<ITransaction> list = new List<ITransaction>();
            int minimumAmount = 200;
            string sender = "Misho";
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, sender, "Peko", 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100);
            Transaction transactionFour = new Transaction(14, TransactionStatus.Successfull, sender, "Keko", 400);
            list.Add(transactionTwo);
            list.Add(transactionFour);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            chainblock.Add(transactionFour);
            list = list.OrderByDescending(x => x.Amount).ToList();
            Assert.AreEqual(list, chainblock.GetBySenderAndMinimumAmountDescending(sender, minimumAmount));
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetBySenderAndMinimumAmountDescending_AndThereIsNoSuchTransaction_ShouldThrowInvalidOperationException()
        {
            List<ITransaction> list = new List<ITransaction>();
            int minimumAmount = 200;
            string sender = "Penis";
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, sender, "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100);
            Transaction transactionFour = new Transaction(14, TransactionStatus.Successfull, "Mesho", "Keko", 100);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            chainblock.Add(transactionFour);
            list = list.OrderByDescending(x => x.Amount).ToList();
            Assert.That(() =>
            {
                chainblock.GetBySenderAndMinimumAmountDescending(sender, minimumAmount);
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetByReceiverAndAmountRange_ShouldReturnAllTransactionsWithReceiverAndBetweenAmountRange()
        {
            List<ITransaction> list = new List<ITransaction>();
            int minimumAmount = 200;
            int maximumAmount = 300;
            string receiver = "Denis";
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", receiver, 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", receiver, 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100);
            Transaction transactionFour = new Transaction(14, TransactionStatus.Successfull, "Misho", receiver, 234);
            list.Add(transactionOne);
            list.Add(transactionFour);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            chainblock.Add(transactionFour);
            list = list.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
            Assert.AreEqual(list, chainblock.GetByReceiverAndAmountRange(receiver, minimumAmount, maximumAmount));
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetByReceiverAndAmountRange_AndThereIsNoSuchTransaction_ShouldThrowInvalidOperationException()
        {
            List<ITransaction> list = new List<ITransaction>();
            int minimumAmount = 200;
            int maximumAmount = 300;
            string receiver = "Denis";
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", receiver, 100);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", receiver, 300);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 100);
            Transaction transactionFour = new Transaction(14, TransactionStatus.Successfull, "Misho", receiver, 190);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            chainblock.Add(transactionFour);
            list = list.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
            Assert.That(() =>
            {
                chainblock.GetByReceiverAndAmountRange(receiver, minimumAmount, maximumAmount);
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetAllInAmountRange_ShouldReturnAllTransactionsInAmountRange()
        {
            List<ITransaction> list = new List<ITransaction>();
            int minimumAmount = 200;
            int maximumAmount = 300;
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 200);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 100);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 300);
            Transaction transactionFour = new Transaction(14, TransactionStatus.Successfull, "Mesho", "Keko", 250);
            list.Add(transactionOne);
            list.Add(transactionTree);
            list.Add(transactionFour);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            chainblock.Add(transactionFour);
            Assert.AreEqual(list, chainblock.GetAllInAmountRange(minimumAmount, maximumAmount));
        }
        [Test]
        public void When_WeAddSomeTransactions_AndGetAllInAmountRange_AndThereIsNoSuchTransaction_ShouldReturnEmptyList()
        {
            List<ITransaction> list = new List<ITransaction>();
            int minimumAmount = 200;
            int maximumAmount = 300;
            Transaction transactionOne = new Transaction(13, TransactionStatus.Successfull, "Penis", "Denis", 330);
            Transaction transactionTwo = new Transaction(15, TransactionStatus.Successfull, "Mimi", "Peko", 100);
            Transaction transactionTree = new Transaction(14, TransactionStatus.Aborted, "Koko", "Pepe", 400);
            Transaction transactionFour = new Transaction(14, TransactionStatus.Successfull, "Mesho", "Keko", 190);
            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionTree);
            chainblock.Add(transactionFour);
            Assert.AreEqual(list, chainblock.GetAllInAmountRange(minimumAmount, maximumAmount));
        }
    }
}
