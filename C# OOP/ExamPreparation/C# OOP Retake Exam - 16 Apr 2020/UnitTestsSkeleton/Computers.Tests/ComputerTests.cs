using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        private Computer computer;
        private Part part;

        [SetUp]
        public void Setup()
        {
            part = new Part("CD", 100);
            computer = new Computer("IBM");

        }

        [Test]
        public void NameShouldreturnCorrectResult()
        {
            string actual = computer.Name;
            string expected = "IBM";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NameShouldSetCorrectName()
        {
            Computer computer = new Computer("Dell");
            string expected = "Dell";

            Assert.AreEqual(expected, computer.Name);
        }

        [Test]
        public void NameShouldNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(null));
        }

        [Test]
        public void NameShouldNotBeEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(string.Empty));
        }


        [Test]
        public void PartsCollectionShouldBeInitialised()
        {
            computer.AddPart(part);
            var actual = computer.Parts;

            Assert.IsNotNull(actual);
        }


        [Test]
        public void PartsCollectionShoulRetunrTheSameCollection()
        {
            computer.AddPart(part);
            var actual = computer.Parts;
            var expected = new List<Part>() {part};

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddPartsShouldThrowExceptionIfPartIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }

        [Test]
        public void AddPartsShouldReturnCollection()
        {
            computer.AddPart(part);
            computer.AddPart(part);

            int actual = computer.Parts.Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TotalPriceShouldReturnCorrectAmount()
        {
            computer.AddPart(part);
            computer.AddPart(part);

            decimal actual = computer.TotalPrice;
            decimal expected = 200;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TotalPriceShouldReturnZeroIfThereIsNoParts()
        {
            decimal actual = computer.TotalPrice;
            decimal expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveShouldReturnBoolean()
        {
            var actual = computer.RemovePart(null);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveShouldReturnTrue()
        {
            computer.AddPart(part);
            var actual = computer.RemovePart(part);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        //public Part GetPart(string partName)
        //    => this.Parts.FirstOrDefault(x => x.Name == partName);

        [Test]
        public void GetPartShouldReturnThePartByName()
        {
            computer.AddPart(part);
            Part getPart = computer.GetPart("CD");
            var actual = getPart.Name;
            var expected = "CD";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPartShouldReturnNullIfPartIsMissing()
        {
            Part actual = computer.GetPart("CD");
            Part expected = null;
            Assert.AreEqual(expected, actual);
        }

    }
}