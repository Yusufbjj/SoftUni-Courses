using NUnit.Framework;

namespace Robots.Tests
{
    using System;
    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void Capacity_Get()
        {

            RobotManager robot = new RobotManager(1);
            int expected = 1;

            Assert.AreEqual(expected, robot.Capacity);

        }

        [Test]
        public void Capacity_ThrowExeption()
        {

            Assert.Throws<ArgumentException>(() => new RobotManager(-1));

        }

        [Test]
        public void Count_GetCount()
        {
            RobotManager robot = new RobotManager(1);

            Assert.AreEqual(robot.Count, 0);
        }

        [Test]
        public void Add_ThrowInvalidOperationExceptionWhenNameAlreadyExistsOrNotEnoughCapacity()
        {
            Robot robot = new Robot("pepi", 1);
            RobotManager menager = new RobotManager(1);

            menager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => menager.Add(robot));
            Assert.Throws<InvalidOperationException>(() => menager.Add(robot));
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
            Robot robot = new Robot("pepi", 1);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => menager.Remove("gogi"));
        }

        [Test]
        public void Remove_Completed()
        {
            Robot robot = new Robot("pepi", 1);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);
            menager.Remove(robot.Name);

            Assert.AreEqual(menager.Count, 0);
        }

        [Test]
        public void Work_ThrowException()
        {
            Robot robot = new Robot("pepi", 1);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => menager.Work("gogi", "clean", 1));
            Assert.Throws<InvalidOperationException>(() => menager.Work("pepi", "clean", 2));

        }

        [Test]
        public void Work_Succesfull()
        {
            Robot robot = new Robot("pepi", 5);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            menager.Work(robot.Name,"clean",1);

            Assert.AreEqual(4,robot.Battery);
        }

        [Test]
        public void Charge_ThrowException()
        {
            Robot robot = new Robot("pepi", 5);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => menager.Charge("gogi"));
        }

        [Test]
        public void Charge_Succesfull()
        {
            Robot robot = new Robot("pepi", 5);
            RobotManager menager = new RobotManager(2);

            menager.Add(robot);

            menager.Charge(robot.Name);

            Assert.AreEqual(robot.MaximumBattery,robot.Battery);
        }

    }
}
