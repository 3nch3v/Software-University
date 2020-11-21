using System;
using NUnit.Framework;
using SemanticComparison;
using CarManager;

namespace Tests
{

    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Mercedes", "G-Class", 18.2, 100);
        }

        [Test]
        public void ConstrunctorShouldCreatACarDifferentFromNull()
        {
            Assert.NotNull(car);
        }

        [Test]
        public void CreatCar()
        {
            var actualResult = car;
            var expected = new Car("Mercedes", "G-Class", 18.2, 100);

            var actual = new Likeness<Car, Car>(actualResult);

            Assert.AreEqual(expected, actual);
        }



        [Test]
        public void MakeShouldReturnCorrectvalue()
        {
            var actualResult = car.Make;
            var expectedResult = "Mercedes";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MakeCannotBeEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Car(string.Empty, "G-Class", 18.2, 100));
        }

        [Test]
        public void MakeCannotBeNullI()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "G-Class", 18.2, 100));
        }

        [Test]
        public void ModelShouldSettedCorrect()
        {
            var actualResult = car.Model;
            var experctedResult = "G-Class";

            Assert.AreEqual(experctedResult, actualResult);
        }

        [Test]
        public void ModelCannotBeEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", string.Empty, 18.2, 100));
        }
        [Test]
        public void ModelCannotBeNullI()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", null, 18.2, 100));
        }

        [Test]
        public void FuelConsumptionShouldreturnCorrectResult()
        {
            var actualResult = car.FuelConsumption;
            var experctedResult = 18.2;

            Assert.AreEqual(experctedResult, actualResult);
        }

        [Test]
        public void FuelConsumptionCannotBeZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "G-Class", -12, 100));
        }

        [Test]
        public void InitialFuelAmountShouldReturnZero()
        {
            var actualResult = car.FuelAmount;
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void FuelCapacityShouldReturnCorrectResult()
        {
            var actualResult = car.FuelCapacity;
            var expectedResult = 100;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FuelCapacityCannotBeZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "G-Class", 18.2, -100));
        }


        [Test]
        public void FuelToRefuelShouldThrowExceptionIfZeroOrNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(-1));
        }

        [Test]
        public void FuelToRefuelShouldThrowExceptionIfZero()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }

        [Test]
        public void FuelToRefuelShouldAddFuelToTank()
        {
            car.Refuel(10);

            var actualResult = car.FuelAmount;
            var expectedResult = 10;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FuelToRefuelShouldCanNotAddMoreFuelThanTheTankCapacity()
        {
            car.Refuel(200);

            var actualResult = car.FuelAmount;
            var expectedResult = 100;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DriveShouldThrowExceptionIfFuelNeededIsBiggerThanFuelAmount()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(10000000));
        }


        [Test]
        [TestCase(100)]
        public void DriveFuelNeededShouldConsiderCorrectTheFuelNeeded(int distance)
        {
            var actualResult = (distance / 100) * car.FuelConsumption;
            var expectedResult = 18.2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DriveShouldDecreiseTheFuelAmount()
        {
            car.Refuel(100);
            car.Drive(100);

            var actualResult = car.FuelAmount;
            var expectedResult = 81.8;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}