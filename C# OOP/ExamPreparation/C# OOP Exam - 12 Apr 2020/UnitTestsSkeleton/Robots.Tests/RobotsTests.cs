using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Ivan", 100);
            manager = new RobotManager(2);
        }


        [Test]
        public void CapacityShouldThrowExceptionWhenLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }

        [Test]
        public void CapacityCanBeZero()
        {
            RobotManager manager = new RobotManager(0);

           int capacity = manager.Capacity;
           int expected = 0;

           Assert.AreEqual(expected, capacity);
        }

        [Test]
        public void CapacityShouldReturnCorrcetValue()
        {
            int actual = manager.Capacity;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountShouldReturnCorrectValue()
        {
            int actual = manager.Count;
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AddShouldReturnCorrectValueAfterAddRobot()
        {
            manager.Add(robot);
            int actual = manager.Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AddShouldThrowExceptionWhenAddAgainTheSameRobot()
        {
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Add(robot));
        }

        [Test]
        public void AddShouldThrowExceptionWhenNoMoreSpace()
        {
            manager.Add(robot);
            manager.Add(new Robot("Giga", 1));

            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot("Gosho", 1)));
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenThereIsNoSuchRobot()
        {
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Remove("Pesho"));
        }

        [Test]
        public void RemoveShouldRemoveRobotByName()
        {
            manager.Add(robot);
            manager.Remove("Ivan");

            int actual = manager.Count;
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WorkShouldThrowExceptionIfNoSuchRobot()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Work("Strahil", "paint", 10));
        }

        [Test]
        public void WorkShouldThrowExceptionIfBatteryToLow()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Work("Ivan", "paint", 111));
        }

        [Test]
        public void WorkShouldReduceTheBatteryPower()
        {
            manager.Add(robot);
            manager.Work("Ivan", "paint", 10);

            int actual = robot.Battery;
            int expected = 90;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChargeShouldThrowExceptionIfNoSuchRobot()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Charge("Strahil"));
        }

        [Test]
        public void ChargeShouldRechargeTheBattery()
        {
            manager.Add(robot);
            manager.Work("Ivan", "paint", 50);

            manager.Charge("Ivan");

            int actual = robot.Battery;
            int expected = 100;

            Assert.AreEqual(expected, actual);
        }
    }
}
