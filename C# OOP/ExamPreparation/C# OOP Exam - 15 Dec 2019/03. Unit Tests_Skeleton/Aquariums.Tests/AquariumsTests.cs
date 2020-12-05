using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            fish = new Fish("Ivan");
            aquarium = new Aquarium("A", 2);
        }

        [Test]
        public void AquariumNameShouldBeSetCorrectly()
        {
            Aquarium aquarium = new Aquarium("A", 2);
            string actualResult = aquarium.Name;
            string expectedResult = "A";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void EmptyNameShouldThrowExceptionWhenSet()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 100));
        }

        [Test]
        public void NullNameShouldThrowExceptionWhenSet()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 100));
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenSetWithLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("A", -1));
        }

        [Test]
        public void CapacityShouldBeSetCorrectly()
        {
            Aquarium aquarium = new Aquarium("A", 2);
            int actualResult = aquarium.Capacity;
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CountShouldBeSetCorrectly()
        {
            aquarium.Add(fish);
            int actualResult = aquarium.Count;
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddShouldThrowExceptionIfAquariumCapacityISFull()
        {
            aquarium.Add(fish);
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }

        [Test]
        public void RemoveShouldThrowExceptionIFThereIsNoFishWithThatName()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("B"));
        }

        [Test]
        public void RemoveShouldRemoveTheFishWithTheGivenName()
        {
           aquarium.Add(fish);
           aquarium.RemoveFish("Ivan");

           int actualResult = aquarium.Count;
           int expectedResult = 0;

           Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SellFishShouldThrowsExceptionIfNoFishWithThisName()
        {
            aquarium.Add(fish);
            
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("BBB"));
        }

        [Test]
        public void SellFishShouldREturnTheRemovedFish()
        {
            aquarium.Add(fish);

            Fish returnedFish = aquarium.SellFish("Ivan");

            string actualResult = fish.Name;
            string expectedResult = "Ivan";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SellFishShouldSetTheFishAsUnavaileble()
        {
            aquarium.Add(fish);

            Fish returnedFish = aquarium.SellFish("Ivan");

            bool actualResult = fish.Available;
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ReportShouldReturnInfoForTheAquariumAndFish()
        {
            aquarium.Add(fish);
            aquarium.Add(new Fish("Gosho"));

            string actualResult = aquarium.Report();
            string expectedResult = $"Fish available at A: Ivan, Gosho";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
