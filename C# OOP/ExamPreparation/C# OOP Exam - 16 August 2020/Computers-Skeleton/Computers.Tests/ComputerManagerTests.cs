using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        //private ComputerManager computerManager;
        //private Computer computer;

        //[SetUp]
        //public void Setup()
        //{
        //    computer = new Computer("IBM", "P50", 1000);
        //    computerManager = new ComputerManager();
        //}

        //[Test]
        //public void computersData()
        //{
        //    var data = computerManager.Computers;
        //    Assert.IsNotNull(data);
        //}

        //[Test]
        //public void Count()
        //{
        //    var actual = computerManager.Count;
        //    int expected = 0;

        //    Assert.AreEqual(expected, actual);
        //}


        //[Test]
        //public void AddMethodShouldThrowNullExceptionWhenVariableIsNull()
        //{
        //    Computer testComputer = null;
        //    Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(testComputer));
        //}

        //[Test]
        //public void AddMethodShouldThrowExceptionWhenAddSameComputer()
        //{
        //    computerManager.AddComputer(computer);
        //    Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        //}

        //[Test]
        //public void AddMethodShouldWorkCorrectly()
        //{
        //    computerManager.AddComputer(computer);

        //    int actual = computerManager.Count;
        //    int expected = 1;

        //    Assert.AreEqual(expected, actual);
        //}

        //[Test]
        //public void RemoveMethodShouldThrowNullExceptionWhenManufacturerIsNull()
        //{
        //    computerManager.AddComputer(computer);

        //    Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, "P50"));
        //}

        //[Test]
        //public void RemoveMethodShouldThrowNullExceptionWhenModelIsNull()
        //{
        //    computerManager.AddComputer(computer);

        //    Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("IBM", null));
        //}

        //[Test]
        //public void RemoveMethodShouldWorkCorectlly()
        //{
        //    computerManager.AddComputer(computer);

        //    var actualResult = computerManager.RemoveComputer("IBM", "P50");

        //    Assert.AreEqual(actualResult.Manufacturer == "IBM", actualResult.Model == "P50");
        //}

        //[Test]
        //public void GetComputerShouldThrowExceptionWhenComputerIsNull()
        //{
        //    Assert.Throws<ArgumentException>(() => computerManager.GetComputer("NoComp", "Fake"));
        //}

        //[Test]
        //[TestCase(null, "P50")]
        //public void GetComputerShouldThrowExcpetionWhenManufacturerIsNull(string manufacturer, string model)
        //{
        //    Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(manufacturer, model));
        //}

        //[Test]
        //[TestCase("IBM", null)]
        //public void GetComputerShouldThrowExcpetionWhenModelIsNull(string manufacturer, string model)
        //{
        //    Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(manufacturer, model));
        //}


        //[Test]
        //public void GetComputerShouldWorkCorectlly()
        //{
        //    computerManager.AddComputer(computer);

        //    var actual = computerManager.GetComputer("IBM", "P50");
        //    var expected = computer;

        //    Assert.That(expected == actual);
        //}

        //[Test]
        //public void GetComputersShouldThrowExceptionWhenManufacturerIsNull()
        //{
        //    Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));
        //}


        //[Test]
        //public void GetComputersShouldWorkCorrectly()
        //{
        //    computerManager.AddComputer(computer);

        //    Computer secondComp = new Computer("IBM", "P55", 100);
        //    computerManager.AddComputer(secondComp);

        //    var actual = computerManager.GetComputersByManufacturer("IBM").Count;
        //    int expected = 2;

        //    Assert.AreEqual(expected, actual);
        //}

        private Computer computer;
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("IBM", "P50", 100);
            this.computerManager = new ComputerManager();
        }


        [Test]
        public void AddMethodShouldThrowNullExceptionWhenVariableIsNull()
        {
            Computer testComputer = null;
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(testComputer));
        }


        [Test]
        public void AddMethodShouldThrowExceptionWhenAddSameComputer()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }


        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            computerManager.AddComputer(computer);

            int actualResult = computerManager.Count;
            int expectedResult = 1;
            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void RemoveMethodShouldThrowNullExceptionWhenManufacturerIsNull()
        {
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, "Model"));
        }

        [Test]
        public void RemoveMethodShouldThrowNullExceptionWhenModelIsNull()
        {
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("Lenovo", null));
        }


        [Test]
        public void RemoveMethodShouldWorkCorectlly()
        {
            computerManager.AddComputer(computer);

            var test = computerManager.RemoveComputer("IBM", "P50");

            Assert.That(test.Model == "P50" && test.Manufacturer == "IBM");
        }


        [Test]
        public void GetComputerShouldThrowExcpetionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(()  => computerManager.GetComputer(null, "P50"));
        }


        [Test]
        public void GetComputerShouldThrowExcpetionWhenModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("IBM", null));
        }


        [Test]
        public void GetComputerShouldThrowExceptionWhenComputerIsNull()
        {
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("test", "test"));
        }


        [Test]
        public void GetComputerShouldWorkCorectlly()
        {
            computerManager.AddComputer(computer);

            var test = computerManager.GetComputer("IBM", "P50");

            Assert.That(test == computer);
        }

        [Test]
        public void GetComputersShouldThrowExceptionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersShouldWorkCorrectly()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("Dell", "AAA", 1000));

            int actualResult = computerManager.GetComputersByManufacturer("Dell").Count;
            var expectedresult = 1;
            Assert.AreEqual(expectedresult, actualResult);
        }
    }
}