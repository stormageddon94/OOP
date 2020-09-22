using NUnit.Framework;
using DatabaseExtended;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        public Person pesho;
        public Person gosho;

        private ExtendedDatabase database;

        [SetUp]
        public void TestInit()
        {
            pesho = new Person(114560, "Pesho");
            gosho = new Person(447788556699, "Gosho");
            var people = new Person[] { gosho, pesho };

            database = new ExtendedDatabase(people);
        }

        [Test]
        public void ConstructorShoudInitializeCollection()
        { 
            Assert.IsNotNull(database);
        }

        [Test]
        public void AddToDatabaseExceedingTheGivenArrayRange()
        {
            var people = new Person[17];
            ExtendedDatabase db;
            Assert.That(() => db = new ExtendedDatabase(people),
                Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
            
        }

        [Test]
        public void AddToDatabaseWithingTheGivenArrayRange()
        {
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestShouldAddPerson()
        {
            var newPerson = new Person(123456789, "Stamat");
            database.Add(newPerson);

            int expectedCount = 3;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void AddSameUsernameShouldThrow()
        {
            var newPerson = new Person(447788556699, "Gosho");
            Assert.That(() => database.Add(newPerson), 
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddSameIdShouldThrow()
        {
            var newPerson = new Person(447788556699, "Kari");

            Assert.That(() => database.Add(newPerson), 
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemoveShouldRemove()
        {
            database.Remove();

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void RemoveEmptyCollectionShouldThrow()
        {
            var peopleEmptyCollection = new Person[] { };
            var db = new ExtendedDatabase(peopleEmptyCollection);

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameExistingPersonShouldReturnPerson()
        {
            var expected = pesho;
            var actual = database.FindByUsername("Pesho");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByUsernameNonExistingPersonShouldThrow()
        {
            Assert.That(() => database.FindByUsername("Stamat"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNullArgumentShouldThrow()
        {
            Assert.That(() => database.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameIsCaseSensitive()
        {
            Assert.That(() => database.FindByUsername("GOSHO"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdExistingPersonShouldReturnPerson()
        {
            var expected = pesho;
            var actual = database.FindById(114560);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByIdNonExistingPersonShouldThrow()
        {
            Assert.That(() => database.FindById(123456789), Throws.InvalidOperationException);
        }
        [Test]
        public void FindByUsernameNegativeArgumentShouldThrow()
        {
            Assert.That(() => database.FindById(-5), Throws.Exception);
        }
    }
}