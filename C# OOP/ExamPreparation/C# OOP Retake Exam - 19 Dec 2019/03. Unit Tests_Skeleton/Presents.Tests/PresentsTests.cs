using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Presents.Tests
{
    using System;

    public class PresentsTests
    {
        private Bag bag;
        private Present present;

        [SetUp]
        public void SetUp()
        {
            present = new Present("A", 1);
            bag = new Bag();
        }

        [Test]
        public void CreateShouldThrowExceptionIfPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void CreateShouldThrowExceptionIfPresentAlreadyExist()
        {
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateShouldAddThePresentToTheBag()
        {
            bag.Create(present);
            int actualResult = bag.GetPresents().Count;
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CreateShouldReturnCorrectMessageAfterAddIt()
        {
            string actualResult = bag.Create(present);
            string expectedResult = $"Successfully added present {present.Name}.";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveShouldReturnFalseIfThePresentNotAvailable()
        {
            bool actualResult = bag.Remove(new Present("ABC", 11));
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveShouldReturnTrueIfRemoved()
        {
            bag.Create(present);
            bool actualResult = bag.Remove(present);
            bool expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldReturnThePresentWithLeastMagic()
        {
            bag.Create(present);
            bag.Create(new Present("L", 0.1));

            Present leastMAgic = bag.GetPresentWithLeastMagic();

            string actualResult = leastMAgic.Name;
            string expectedResult = "L";

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void GetPresentShouldReturnThePresent()
        {
            bag.Create(present);

            Present leastMAgic = bag.GetPresent("A");

            string actualResult = leastMAgic.Name;
            string expectedResult = "A";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetPresentShouldReturnNullIfItMissing()
        {
            Present leastMagic = bag.GetPresent("B");

            Assert.AreEqual(null, leastMagic);
        }

        [Test]
        public void GetPresentsShouldReturnCollection()
        {
            bag.Create(present);
            bag.Create(new Present("B", 12));

            ICollection<Present> presents = bag.GetPresents().ToList();
            int actualResult = presents.Count;
            int expectedResult = 2;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
