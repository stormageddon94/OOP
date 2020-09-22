using Database;
using Newtonsoft.Json.Converters;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private DatabaseType database;
        private readonly int[] InitialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new DatabaseType(InitialData);
        }

        [Test]
        public void TestDatabaseCount()
        {
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddToDatabaseWithingTheGivenArrayRange()
        {
            database.Add(3);
            Assert.That(database.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddToDatabaseExceedingTheGivenArrayRange()
        {
            var arrayRange = 16;
            
            for (int i = 0; i < arrayRange; i++)
            {
                if (database.Count == 16)
                {
                    Assert.That(() => database.Add(i), Throws.InvalidOperationException
                                                             .With
                                                             .Message
                                                             .EqualTo("Array's capacity must be exactly 16 integers!"));
                    break;
                }
                else
                {
                    database.Add(i);
                }
            }
        }

        [Test]
        public void RemoveFromDatabaseWithElements()
        {
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveFromDatabaseWithoutElements()
        {
            for (int i = database.Count - 1; i >= -1; i--)
            {
                if (i != -1)
                {
                    database.Remove();
                }
                else
                {
                    Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
                }
            }
        }

        [Test]
        public void ReturnAllElementsInTheArray()
        {
            int[] actualResult = database.Fetch();
            CollectionAssert.AreEqual(InitialData, actualResult);
        }
    }
}