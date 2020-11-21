namespace Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using NUnit.Framework;
    using SemanticComparison;
    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase(new Person[] { new Person(1, "Ivan"), new Person(2, "Gosho") });
        }

        [Test]
        public void DatabaseShouldNotBeNull()
        {
            Assert.NotNull(database);
        }

        [Test]
        public void DatabaseLengthSizeShouldBeSixteen()
        {
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(new Person[]
            {
                new Person(1, "Ivan"), new Person(2, "Gosho1"), new Person(3, "Gosho2"),
                new Person(4, "Gosho4"), new Person(5, "Gosho5"), new Person(6, "Gosho6"), new Person(7, "Gosho7"),
                new Person(8, "Gosho8"), new Person(9, "Gosho9"), new Person(10, "Gosho10"), new Person(11, "Gosho11"),
                new Person(12, "Gosho12"), new Person(13, "Gosho13"), new Person(14, "Gosho14"), new Person(15, "Gosho15"),
                new Person(16, "Gosho16"), new Person(17, "Gosho17")
            }));
        }


        [Test]
        public void CheckingDatabaseCount()
        {
            var actualResult = database.Count;
            var expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void DatabaseShouldAddElement()
        {
            database.Add(new Person(3, "Stamat"));
            var actualResult = database.Count;
            var expectedResult = 3;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseShouldNotBeAbleToAddAPersonWithTheSameName()
        {
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(22, "Ivan")));
        }

        [Test]
        public void DatabaseShouldNotBeAbleToAddAPersonWithTheSameId()
        {
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "New")));
        }

        [Test]
        public void DatabaseShouldNotWithSizeSixteen()
        {
            ExtendedDatabase database = new ExtendedDatabase
            (new Person(1, "Ivan"), new Person(2, "Gosho1"), new Person(3, "Gosho2"), new Person(4, "Gosho4"), 
                new Person(5, "Gosho5"), new Person(6, "Gosho6"), new Person(7, "Gosho7"), new Person(8, "Gosho8"),
                new Person(9, "Gosho9"), new Person(10, "Gosho10"), new Person(11, "Gosho11"), new Person(12, "Gosho12"), 
                new Person(13, "Gosho13"), new Person(14, "Gosho14"), new Person(15, "Gosho15"), new Person(16, "Gosho16"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "New")));
        }


        [Test]
        public void RemoveShouldThrowExceptionIfEmpty()
        {
            ExtendedDatabase data = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void DatabaseShouldCanRemoveElement()
        {
            database.Remove();
            var actualResult = database.Count;
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindingByNameShouldThrowExceptionIfNameIsNullOrEmpty()
        {
            string name = null;

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));
        }

        [Test]
        public void FindingByNameShouldThrowExceptionIfNameIsMissing()
        {
            string name = "Urud";

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(name));
        }

        [Test]
        public void FindingByNameShouldReturnApersonWithTheName()
        {
            string name = "Ivan";
            var actualResult = database.FindByUsername(name);
            var expectedResult = new Person(1, "Ivan");

            var actual = new Likeness<Person, Person>(actualResult);

            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void FindingByNameShouldReturnNull()
        {
            string name = "Ivan";
            var actualResult = database.FindByUsername(name);
    
            Assert.NotNull(actualResult);
        }


        [Test]
        [TestCase(-1)]
        public void IdShouldBePositiveNumber(long incorrectId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(incorrectId));
        }

        [Test]
        [TestCase(180)]
        public void DatabaseShouldContainTheId(long missingId)
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(missingId));
        }

        [Test]
        [TestCase(1)]
        public void DatabaseShouldReturnAPersonWithgivenId(long correctId)
        {
            var person = database.FindById(correctId);

            Assert.NotNull(person);
        }

        [Test]
        public void FindingByIdShouldReturnApersonWithTheName()
        {
            long id = 1;
            var actualResult = database.FindById(id);
            var expectedResult = new Person(1, "Ivan");

            var actual = new Likeness<Person, Person>(actualResult);

            Assert.AreEqual(expectedResult, actual);
        }
    }
}