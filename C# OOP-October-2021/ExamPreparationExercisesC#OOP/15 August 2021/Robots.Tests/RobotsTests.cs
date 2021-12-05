using NUnit.Framework;

namespace Robots.Tests
{
    using System;
    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorInitializeCorrectly()
        {

            int capacity = 1;
            RobotManager robotManager = new RobotManager(capacity);


            Assert.AreEqual(robotManager.Capacity, capacity);

        }

        [Test]
        public void Capacity_Get()
        {

            RobotManager robotManager = new RobotManager(1);

            Assert.That (robotManager.Capacity,Is.EqualTo(1));

        }

        [Test]
        public void Capacity_ThrowExeption()
        {

            Assert.Throws<ArgumentException>(() => new RobotManager(-1));

        }

        [Test]
        public void Count_GetCount()
        {
            RobotManager robotMenager = new RobotManager(1);
            Robot robot = new Robot("name", 1);
            robotMenager.Add(robot);
            Assert.AreEqual(1, robotMenager.Count);
        }

        [Test]
        public void Add_ThrowInvalidOperationExceptionWhenNameAlreadyExists()
        {
            Robot robot = new Robot("pepi", 1);
            RobotManager menager = new RobotManager(1);

            menager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => menager.Add(robot));
        }

        [Test]
        public void Add_ThrowInvalidOperationExceptionWhenNameCapacityIsNotEnough()
        {
            Robot robot = new Robot("pepi", 1);
            RobotManager menager = new RobotManager(1);

            menager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => menager.Add(new Robot("name", 2)));
        }

        [Test]
        public void Add_Successfull()
        {
            Robot robot = new Robot("pepi", 1);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            Assert.AreEqual(menager.Count, 1);
        }

        [Test]
        public void Remove_ThrowException()
        {
            Robot robot = new Robot("name", 1);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => menager.Remove(null));
        }

        [Test]
        public void Remove_Completed()
        {
            Robot robot = new Robot("pepi", 1);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);
            menager.Remove(robot.Name);

            Assert.AreEqual(0, menager.Count);
        }

        [Test]
        public void Work_ThrowException()
        {
            Robot robot = new Robot("pepi", 1);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => menager.Work("gogi", "clean", 1));

        }

        [Test]
        public void Work_ThrowExceptionNotEnoughBattery()
        {
            Robot robot = new Robot("pepi", 1);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => menager.Work("pepi", "clean", 3));

        }

        [Test]
        public void Work_Succesfull()
        {
            Robot robot = new Robot("pepi", 5);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            menager.Work(robot.Name, "clean", 1);

            Assert.AreEqual(4, robot.Battery);
        }

        [Test]
        public void Charge_ThrowException()
        {
            Robot robot = new Robot("pepi", 5);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => menager.Charge(null));
        }

        [Test]
        public void Charge_Succesfull()
        {
            Robot robot = new Robot("pepi", 5);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);
            menager.Work(robot.Name, "clean", 2);
            menager.Charge(robot.Name);

            Assert.AreEqual(robot.MaximumBattery, robot.Battery);
        }

    }
}
