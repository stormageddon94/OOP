using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTest
    {
        private Chainblock chainblock;
        private Transaction firstTransaction;
        private Transaction secondTransaction;
        private Transaction thirdTransaction;
        private Transaction fourthTransaction;
        private Transaction fifthTransaction;
        private Transaction sixthTransaction;

        [SetUp]
        public void SetUpTransactions()
        {
            this.firstTransaction = new Transaction(10, TransactionStatus.Successfull, "TestSender1", "TestReceiver1", 10);
            this.secondTransaction = new Transaction(11, TransactionStatus.Successfull, "TestSender2", "TestReceiver2", 10);
            this.thirdTransaction = new Transaction(12, TransactionStatus.Failed, "Another TestSender", "Another TestReceiver", 12);
            this.fourthTransaction = new Transaction(10, TransactionStatus.Successfull, "TestSender1", "TestReceiver1", 100);
            this.fifthTransaction = new Transaction(14, TransactionStatus.Successfull, "TestSender4", "TestReceiver1", 100);
            this.sixthTransaction = new Transaction(15, TransactionStatus.Successfull, "TestSender5", "TestReceiver1", 90);
            this.chainblock = new Chainblock();
        }
        [Test]
        public void AddTransactionShouldSaveTheTransaction()
        {
            //Act
            this.chainblock.Add(this.firstTransaction);
            //Assert
            Assert.That(chainblock.Count, Is.EqualTo(1));
            Assert.That(chainblock.First().Id, Is.EqualTo(this.firstTransaction.Id));
            Assert.That(chainblock.First().Status, Is.EqualTo(this.firstTransaction.Status));
            Assert.That(chainblock.First().From, Is.EqualTo(this.firstTransaction.From));
            Assert.That(chainblock.First().To, Is.EqualTo(this.firstTransaction.To));
            Assert.That(chainblock.First().Amount, Is.EqualTo(this.firstTransaction.Amount));
        }

        [Test]
        public void ContainsTransactionShouldReturnTrueIfTransactionExist()
        {
            //Act
            chainblock.Add(this.firstTransaction);
            //Assert
            var result = chainblock.Contains(this.firstTransaction);
            Assert.IsTrue(result);
        }

        [Test]
        public void ContainsTransactionShouldReturnFalseIfTransactionDoesntExist()
        {
            //Assert
            var result = chainblock.Contains(this.firstTransaction);
            Assert.IsFalse(result);
        }

        [Test]
        public void ContainsTransactionShouldThrowExceptionWhenTransactionIsNull()
        {
            //Assert
            Assert.That(() => this.chainblock.Contains(null), Throws.ArgumentException.With.Message.EqualTo("Transaction cannot be null."));
        }

        [Test]
        public void ContainsIdShouldReturnTrueIfIdExist()
        {
            //Act
            chainblock.Add(this.firstTransaction);
            //Assert
            var result = chainblock.Contains(10);
            Assert.IsTrue(result);
        }

        [Test]
        public void ContainsIdShouldReturnFalseIfIdDoesntExist()
        {
            //Assert
            var result = chainblock.Contains(10);
            Assert.IsFalse(result);
        }

        [Test]
        public void ContainsTransactionShouldThrowExceptionWhenIdIsZero()
        {
            //Assert
            Assert.That(() => this.chainblock.Contains(0), Throws.ArgumentException.With.Message.EqualTo("ID cannot be zero or less than zero."));
        }

        [Test]
        public void ContainsTransactionShouldThrowExceptionWhenIdIsNegative()
        {
            //Assert
            Assert.That(() => this.chainblock.Contains(-1), Throws.ArgumentException.With.Message.EqualTo("ID cannot be zero or less than zero."));
        }

        [Test]
        public void CountShouldReturnCorrectTransactionCount()
        {
            //Arrange
            this.chainblock.Add(this.firstTransaction);
            this.chainblock.Add(this.secondTransaction);
            //Act
            var result = this.chainblock.Count;
            //Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeTheStatusIfTransactionExist()
        {
            //Act
            this.chainblock.Add(this.firstTransaction);
            this.chainblock.ChangeTransactionStatus(10, TransactionStatus.Failed);
            //Assert
            var neededStatus = this.chainblock.First().Status;
            Assert.That(neededStatus, Is.EqualTo(TransactionStatus.Failed));
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowExceptionIfTransactionDesntExist()
        {
            //Assert
            Assert.That(() => chainblock.ChangeTransactionStatus(10, TransactionStatus.Failed),
                Throws.ArgumentException.With.Message.EqualTo("Transaction doesn't exist."));
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowExceptionIfIdIsNegative()
        {
            //Assert
            Assert.That(() => chainblock.ChangeTransactionStatus(-10, TransactionStatus.Failed),
                Throws.ArgumentException.With.Message.EqualTo("ID cannot be negative or zero."));
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowExceptionIfIdIsZero()
        {
            //Assert
            Assert.That(() => chainblock.ChangeTransactionStatus(0, TransactionStatus.Failed),
                Throws.ArgumentException.With.Message.EqualTo("ID cannot be negative or zero."));
        }

        [Test]
        public void RemoveTransactionByIdShouldRemoveTrasactionWhenIdExists()
        {
            //Act
            this.chainblock.Add(this.firstTransaction);
            this.chainblock.RemoveTransactionById(10);
            //Assert
            Assert.IsEmpty(this.chainblock);
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowExceptionWhenIdDoesntExists()
        {
            //Act//Assert
            Assert.That(() => this.chainblock.RemoveTransactionById(10), Throws.InvalidOperationException.With.Message.EqualTo("ID doesn't exist."));
        }

        [Test]
        public void GetByIdShouldReturnTrasactionWhenIdExists()
        {
            //Act
            this.chainblock.Add(this.firstTransaction);
            var transaction = this.chainblock.GetById(10);
            //Assert
            Assert.That(transaction.Id, Is.EqualTo(this.firstTransaction.Id));
        }

        [Test]
        public void GetByIdShouldThrowExceptionWhenIdDoesntExists()
        {
            //Act//Assert
            Assert.That(() => this.chainblock.GetById(10), Throws.InvalidOperationException.With.Message.EqualTo("ID doesn't exist."));
        }

        [Test]
        public void GetByTransactionStatusShouldReturnTransactionsWithSameStatus()
        {
            //Arrange
            this.AddMultipleTransactions();
            //Act
            var transactions = this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull).ToList();
            //Assert
            Assert.That(transactions.Count, Is.EqualTo(5));
            Assert.That(transactions[0].Id, Is.EqualTo(10));
        }

        [Test]
        public void GetByTransactionStatusShouldThrowExceptionIfNoTransactionsWithThisStatusAreFound()
        {
            //Arrange
            this.AddMultipleTransactions();
            //Act
            //Assert
            Assert.That(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Aborted),
                Throws.InvalidOperationException.With.Message.EqualTo("No transaction with this status are found."));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnSendersWithThisTransactionStatus()
        {
            //Arrange
            this.AddMultipleTransactions();
            //Act
            var senders = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToList();
            //Assert
            Assert.That(senders.Count, Is.EqualTo(5));
            Assert.That(senders[0] == "TestSender1");
            Assert.That(senders[1] == "TestSender2");
            Assert.That(senders[2] == "TestSender5");
            Assert.That(senders[3] == "TestSender1");
            Assert.That(senders[4] == "TestSender4");
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowExceptionWhenNoSuchTransactionStatusIsFound()
        {
            this.AddMultipleTransactions();
            Assert.That(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted),
                Throws.InvalidOperationException.With.Message.EqualTo("No transactions with this status are found."));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnSendersWithThisTransactionStatus()
        {
            //Arrange
            this.AddMultipleTransactions();
            //Act
            var receivers = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull).ToList();
            //Assert
            Assert.That(receivers.Count, Is.EqualTo(5));

            Assert.That(receivers[0] == "TestReceiver1");
            Assert.That(receivers[1] == "TestReceiver2");
            Assert.That(receivers[2] == "TestReceiver1");
            Assert.That(receivers[3] == "TestReceiver1");
            Assert.That(receivers[4] == "TestReceiver1");
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowExceptionWhenNoSuchTransactionStatusIsFound()
        {
            this.AddMultipleTransactions();
            Assert.That(() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted),
                Throws.InvalidOperationException.With.Message.EqualTo("No transactions with this status are found."));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnCorrectCollectionWithCorrectOrder()
        {
            //Arrange
            this.AddMultipleTransactions();
            //Act
            var orderedTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();
            //Assert
            Assert.That(orderedTransactions[0].Amount, Is.EqualTo(100));
            Assert.That(orderedTransactions[1].Amount, Is.EqualTo(100));
            Assert.That(orderedTransactions[2].Amount, Is.EqualTo(90));
            Assert.That(orderedTransactions[2].Id, Is.EqualTo(15));
            Assert.That(orderedTransactions[3].Amount, Is.EqualTo(12));
            Assert.That(orderedTransactions[3].Id, Is.EqualTo(12));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnCorrectCollectionWhenSenderIsFound()
        {
            //Arrange
            this.AddMultipleTransactions();
            //Act
            var senders = this.chainblock.GetBySenderOrderedByAmountDescending("TestSender1").ToList();
            //Assert
            Assert.That(senders.Count, Is.EqualTo(2));
            Assert.That(senders[0].Amount, Is.EqualTo(100));
            Assert.That(senders[1].Amount, Is.EqualTo(10));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionWhenSenderIsNotFound()
        {
            Assert.That(() => this.chainblock.GetBySenderOrderedByAmountDescending("Kari"),
                Throws.InvalidOperationException.With.Message.EqualTo("Sender not found."));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionWhenSenderIsNull()
        {
            Assert.That(() => this.chainblock.GetBySenderOrderedByAmountDescending(null),
                Throws.InvalidOperationException.With.Message.EqualTo("Sender cannot be null or empty."));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionWhenSenderIsEmpty()
        {
            Assert.That(() => this.chainblock.GetBySenderOrderedByAmountDescending(string.Empty),
                Throws.InvalidOperationException.With.Message.EqualTo("Sender cannot be null or empty."));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnCorrectCollectionWithCorrectOrder()
        {
            this.AddMultipleTransactions();
            //Act
            var orderedCollection = this.chainblock.GetByReceiverOrderedByAmountThenById("TestReceiver1").ToList();
            //Assert
            Assert.That(orderedCollection.Count, Is.EqualTo(4));
            Assert.That(orderedCollection[0].Amount, Is.EqualTo(100));
            Assert.That(orderedCollection[0].Id, Is.EqualTo(10));
            Assert.That(orderedCollection[1].Amount, Is.EqualTo(100));
            Assert.That(orderedCollection[1].Id, Is.EqualTo(14));
            Assert.That(orderedCollection[2].Amount, Is.EqualTo(90));
            Assert.That(orderedCollection[3].Amount, Is.EqualTo(10));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowExceptionWhenNoReceiverIsFound()
        {
            Assert.That(() => this.chainblock.GetByReceiverOrderedByAmountThenById("Kari"),
                Throws.InvalidOperationException.With.Message.EqualTo("Receiver not found."));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowExceptionWhenReceiverIsNull()
        {
            Assert.That(() => this.chainblock.GetByReceiverOrderedByAmountThenById(null),
                Throws.InvalidOperationException.With.Message.EqualTo("Receiver cannot be null or empty."));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowExceptionWhenReceiverIsEmpty()
        {
            Assert.That(() => this.chainblock.GetByReceiverOrderedByAmountThenById(string.Empty),
                Throws.InvalidOperationException.With.Message.EqualTo("Receiver cannot be null or empty."));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountReturnsCorrectCollectionWithCorrectOrder()
        {
            //Arrange
            this.AddMultipleTransactions();
            //Act
            var orderedTransactions = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 95).ToList();
            //Assert
            Assert.That(orderedTransactions.Count(), Is.EqualTo(3));
            Assert.That(orderedTransactions[0].Amount, Is.EqualTo(90));
            Assert.That(orderedTransactions[1].Amount, Is.EqualTo(10));
            Assert.That(orderedTransactions[2].Amount, Is.EqualTo(10));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountReturnsEmptyCollectionWhenNoTransactionsAreFound()
        {
            this.AddMultipleTransactions();
            var orderedTransactions = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, 95).ToList();
            Assert.IsEmpty(orderedTransactions);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnCorrectCollectionInCorrectOrder()
        {
            this.AddMultipleTransactions();
            this.chainblock.Add(new Transaction(13, TransactionStatus.Successfull, "TestSender1", "TestReceiver1", 80));
            var orderedTransactions = this.chainblock.GetBySenderAndMinimumAmountDescending("TestSender1", 50).ToList();
            Assert.That(orderedTransactions.Count(), Is.EqualTo(2));
            Assert.That(orderedTransactions[0].Amount, Is.EqualTo(100));
            Assert.That(orderedTransactions[1].Amount, Is.EqualTo(80));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowExceptionIfNoTransactionsAreFound()
        {
            Assert.That(() => this.chainblock.GetBySenderAndMinimumAmountDescending("TestSender1", 10),
                Throws.InvalidOperationException.With.Message.EqualTo("No transactions are found."));
        }
        [Test]
        public void GetByReceiverAndAmountRangeReturnsCorrectCollectionWithCorrectOreder()
        {
            this.AddMultipleTransactions();
            var orderedTransactions = this.chainblock.GetByReceiverAndAmountRange("TestReceiver1", 99, 120).ToList();
            Assert.That(orderedTransactions.Count(), Is.EqualTo(2));
            Assert.That(orderedTransactions[0].Id, Is.EqualTo(10));
            Assert.That(orderedTransactions[1].Id, Is.EqualTo(14));
        }

        [Test]
        public void GetByReceiverAndAmountRangeThrowsExceptionWhenNoTransactionsAreFound()
        {
            Assert.That(() => this.chainblock.GetByReceiverAndAmountRange("TestReceiver1", 10, 100),
                Throws.InvalidOperationException.With.Message.EqualTo("No transactions are found."));
        }

        [Test]
        public void GetAllInAmountRangeReturnsCorrectCollection()
        {
            this.AddMultipleTransactions();
            var result = this.chainblock.GetAllInAmountRange(12, 120).ToList();
            Assert.That(result.Count(), Is.EqualTo(4));
            Assert.That(result[0].Amount, Is.EqualTo(100));
            Assert.That(result[0].Id, Is.EqualTo(10));
            Assert.That(result[1].Amount, Is.EqualTo(100));
            Assert.That(result[1].Id, Is.EqualTo(14));
            Assert.That(result[2].Amount, Is.EqualTo(90));
            Assert.That(result[3].Amount, Is.EqualTo(12));
        }

        [Test]
        public void GetAllInAmountRangeReturnsEmptyCollectionWhenNoTransactionsAreFound()
        { 
            var result = this.chainblock.GetAllInAmountRange(12, 120).ToList();
            Assert.IsEmpty(result);
        }


            private void AddMultipleTransactions()
        {
            this.chainblock.Add(this.firstTransaction);
            this.chainblock.Add(this.secondTransaction);
            this.chainblock.Add(this.thirdTransaction);
            this.chainblock.Add(this.fourthTransaction);
            this.chainblock.Add(this.fifthTransaction);
            this.chainblock.Add(this.sixthTransaction);
        }
    }
}
