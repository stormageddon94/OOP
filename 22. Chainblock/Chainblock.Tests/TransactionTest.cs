using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTest
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var id = 1;
            TransactionStatus tr = TransactionStatus.Successfull;
            var from = "TestSender";
            var to = "TestReceiver";
            var amount = 10.00;

            var transcation = new Transaction(id, tr, from, to, amount);

            Assert.AreEqual(transcation.Id, id);
            Assert.AreEqual(tr, transcation.Status);
            Assert.AreEqual(transcation.From, from);
            Assert.AreEqual(transcation.To, to);
            Assert.AreEqual(transcation.Amount, amount);
        }
        [Test]
        public void NegativeIdShouldThrowException()
        {
            //Arrange
            TransactionStatus tr = TransactionStatus.Successfull;
            //Act//Assert
            Assert.That(() => new Transaction(-1, tr, "TestFrom", "TestTo", 10), Throws.ArgumentException.With.Message.EqualTo("ID cannot be negative."));
        }

         [Test]
        public void ZeroIdShouldThrowException()
        {
            //Arrange
            TransactionStatus tr = TransactionStatus.Successfull;
            //Act//Assert
            Assert.That(() => new Transaction(0, tr, "TestFrom", "TestTo", 10), Throws.ArgumentException.With.Message.EqualTo("ID cannot be zero."));
        }

        [Test]
        public void NullFromShouldThrowException()
        {
            //Arrange
            TransactionStatus tr = TransactionStatus.Successfull;
            //Act//Assert
            Assert.That(() => new Transaction(10, tr, null, "TestTo", 10), Throws.ArgumentException.With.Message.EqualTo("Sender cannot be null or empty."));
        }

        [Test]
        public void WhiteSpaceFromShouldThrowException()
        {
            //Arrange
            TransactionStatus tr = TransactionStatus.Successfull;
            //Act//Assert
            Assert.That(() => new Transaction(10, tr, " ", "TestTo", 10), Throws.ArgumentException.With.Message.EqualTo("Sender cannot be null or empty."));
        }

        [Test]
        public void EmptyFromShouldThrowException()
        {
            //Arrange
            TransactionStatus tr = TransactionStatus.Successfull;
            //Act//Assert
            Assert.That(() => new Transaction(10, tr, string.Empty, "TestTo", 10), Throws.ArgumentException.With.Message.EqualTo("Sender cannot be null or empty."));
        }

        [Test]
        public void NullToShouldThrowException()
        {
            //Arrange
            TransactionStatus tr = TransactionStatus.Successfull;

            //Act//Assert
            Assert.That(() => new Transaction(10, tr, "TestSender", null, 10), Throws.ArgumentException.With.Message.EqualTo("Receiver cannot be null or empty."));
        }

        [Test]
        public void WhiteSpaceToShouldThrowException()
        {
            //Arrange
            TransactionStatus tr = TransactionStatus.Successfull;
            //Act//Assert
            Assert.That(() => new Transaction(10, tr, "TestSender", " ", 10), Throws.ArgumentException.With.Message.EqualTo("Receiver cannot be null or empty."));
        }

        [Test]
        public void EmptyToShouldThrowException()
        {
            //Arrange
            TransactionStatus tr = TransactionStatus.Successfull;
           //Act//Assert
            Assert.That(() => new Transaction(10, tr, "TestSender", string.Empty, 10), Throws.ArgumentException.With.Message.EqualTo("Receiver cannot be null or empty."));
        }

        [Test]
        public void NegativeAmountShouldThrowException()
        {
            //Arrange
            TransactionStatus tr = TransactionStatus.Successfull;
            //Act//Assert
            Assert.That(() => new Transaction(10, tr, "TestFrom", "TestTo", -10), Throws.ArgumentException.With.Message.EqualTo("Amount cannot be less than zero."));
        }

        [Test]
        public void ZeroAmountShouldThrowException()
        {
            //Arrange
            TransactionStatus tr = TransactionStatus.Successfull;
            //Act//Assert
            Assert.That(() => new Transaction(10, tr, "TestFrom", "TestTo", 0), Throws.ArgumentException.With.Message.EqualTo("Amount cannot be zero."));
        }
    }
}
