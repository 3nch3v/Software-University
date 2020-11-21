
namespace Tests
{
    using System;
    using NUnit.Framework;
    using Database;

    public class DatabaseTests
    {
        private Database data;

        [SetUp]
        public void Setup()
        {
            data = new Database();

        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void DatabaseShouldHasCapacityWithSizeSixteen(int[] args)
        {
            data = new Database(args);
            var actualLength = data.Count;
            var expectedResult = 16;

            Assert.AreEqual(expectedResult, actualLength);
        }

        [Test]
        [TestCase(new int[] {1 ,2 ,3 ,4 , 5 , 6 ,7 ,8 ,9, 10, 11, 12 ,13 ,14 ,15, 16})]
        public void DatabaseShouldThrowExceptionIfCapacityIsDifferentFromSixteen(int[] args)
        {
            data = new Database(args);

            Assert.Throws<InvalidOperationException>(() => data.Add(17));
        }

        [Test]
        public void DatabaseShouldAddElment()
        {
            data.Add(111);

            var actualResult = data.Count;
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseShouldCanRemoveElment()
        {
            data.Add(1);
            data.Add(2);
            
            data.Remove();

            var actualResult = data.Count;
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseShouldThrowExceptionIfRemoveElementFromEmptyDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void FetchShouldReturnADatabaseCopy()
        {
            data.Add(1);
            data.Add(2);

            var actualResult = data.Fetch();
            var expectedResult = new int[] {1, 2 };

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

    }
}