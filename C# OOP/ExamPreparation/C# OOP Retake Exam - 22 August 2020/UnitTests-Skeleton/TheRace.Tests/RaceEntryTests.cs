using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void RaceEntryInstanceSchouldNotBeNull()
        {
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void CounterShouldReturnTheDriversCount()
        {
            int actualResult = raceEntry.Counter;
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CounterShouldReturnCorrectCountAfterAddADriver()
        {
            raceEntry.AddDriver(new UnitDriver("Ivan", new UnitCar("VW", 100, 2000)));

            int actualResult = raceEntry.Counter;
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void WhenReceivedNullAsADriverShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void DriversNameShouldBeUnique()
        {
            raceEntry.AddDriver(new UnitDriver("Ivan", new UnitCar("VW", 100, 2000)));

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(new UnitDriver("Ivan", new UnitCar("VW", 100, 2000))));
        }

        [Test]
        [TestCase("Driver {0} added in race.")]
        public void AddDriverShouldRetundAMessageDriverAddedInRace(string DriverAdded)
        {
            UnitDriver driver = new UnitDriver("Ivan", new UnitCar("VW", 100, 2000));
            raceEntry.AddDriver(driver);


            string actualResult = string.Format(DriverAdded, driver.Name); ;
            string expectedResult = "Driver Ivan added in race.";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RaceShouldNotStartedWithoutMinDrivers()
        {
            UnitDriver driver = new UnitDriver("Ivan", new UnitCar("VW", 100, 2000));
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }


        [Test]
        public void CalculateAverageHorsePowerShouldReturnDoubleAverageFromAllDriversCars()
        {
            UnitDriver firstDriver = new UnitDriver("Ivan", new UnitCar("VW", 100, 2000));
            UnitDriver secondDriver = new UnitDriver("Gosho", new UnitCar("VW", 100, 2000));
            raceEntry.AddDriver(firstDriver);
            raceEntry.AddDriver(secondDriver);

            double actualResult = raceEntry.CalculateAverageHorsePower();
            double expectedResult = 100;

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}