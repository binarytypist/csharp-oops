using NUnit.Framework;
using System;

namespace Robots.Tests
{
    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager storage;

        [SetUp]
        public void Setup()
        {
            // Arrange
            robot = new Robot("R2-D2", 80);
            storage = new RobotManager(2);
            storage.Add(robot);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(robot);
            Assert.IsNotNull(storage);
        }

        [Test]
        public void VerifyCapacityProperty()
        {
            Assert.AreEqual(2, storage.Capacity);
        }

        [Test]
        public void Capacity_ShouldThrow_WhenNegative()
        {
            Assert.Throws<ArgumentException>(() =>
                new RobotManager(-10));
        }

        [Test]
        public void VerifyCount()
        {
            Assert.AreEqual(1, storage.Count);
        }

        [Test]
        public void VerifyAddMethod()
        {
            Robot temp = new Robot("Temp", 2);

            storage.Add(temp);

            Assert.AreEqual(2, storage.Count);
        }

        [Test]
        public void Add_ShouldThrow_WhenDuplicateName()
        {
            Assert.Throws<InvalidOperationException>(() =>
                storage.Add(new Robot("R2-D2", 5)));
        }

        [Test]
        public void Add_ShouldThrow_WhenOverCapacity()
        {
            storage.Add(new Robot("Temp", 2));

            Assert.Throws<InvalidOperationException>(() =>
                storage.Add(new Robot("Extra", 5)));
        }

        [Test]
        public void Remove_ShouldWork()
        {
            Robot temp = new Robot("Temp", 2);

            storage.Add(temp);
            storage.Remove(temp.Name);

            Assert.AreEqual(1, storage.Count);
        }

        [Test]
        public void Remove_ShouldThrow_WhenRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
                storage.Remove("Goshko"));
        }

        [Test]
        public void Work_ShouldReduceBattery()
        {
            storage.Work(robot.Name, "Engineering", 20);

            Assert.AreEqual(60, robot.Battery);
        }

        [Test]
        public void Work_ShouldThrow_WhenRobotNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
                storage.Work("FakeRobot", "Cleaning", 20));
        }

        [Test]
        public void Work_ShouldThrow_WhenNotEnoughBattery()
        {
            Robot temp = new Robot("Toshko", 20);

            storage.Add(temp);

            Assert.Throws<InvalidOperationException>(() =>
                storage.Work(temp.Name, "Cleaning", 555));
        }

        [Test]
        public void Charge_ShouldRestoreBattery()
        {
            storage.Work(robot.Name, "Drinking", 30);

            storage.Charge(robot.Name);

            Assert.AreEqual(80, robot.Battery);
        }

        [Test]
        public void Charge_ShouldThrow_WhenRobotNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
                storage.Charge("UnknownRobot"));
        }
    }
}