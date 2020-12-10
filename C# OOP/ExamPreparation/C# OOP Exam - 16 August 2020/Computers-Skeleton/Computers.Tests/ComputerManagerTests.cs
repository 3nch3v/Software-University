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

            Computer actual = computerManager.RemoveComputer("IBM", "P50");

            Assert.That(actual.Model == "P50" && actual.Manufacturer == "IBM");
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