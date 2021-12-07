using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Computer computer = new Computer("dell", "1", 1000);
            ComputerManager computerManager = new ComputerManager();
        }

        [Test]
        public void Count()
        {
            Computer computer = new Computer("dell", "1", 1000);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);

            Assert.AreEqual(computerManager.Count, 1);
        }

        [Test]
        public void AddComputer_CantBeNull()
        {
            Computer computer = new Computer("dell", "1", 1000);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
        }

        [Test]
        public void AddComputer_ArgumentException()
        {
            Computer computer = new Computer("dell", "1", 1000);

            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        public void AddComputer_Added()
        {
            Computer computer = new Computer("dell", "1", 1000);

            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(computer);

            Assert.AreEqual(computerManager.Count, 1);
        }

        [Test]
        public void RemoveComputer_Removed()
        {
            Computer computer = new Computer("dell", "1", 1000);

            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(computer);

            computerManager.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.AreEqual(computerManager.Count, 0);
        }

        [Test]
        public void GetComputer_CantBeNull()
        {
            Computer computer = new Computer("dell", "1", 1000);

            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "dell"));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("apple", null));
        }

        [Test]
        public void GetComputer_ArgumentException()
        {
            Computer computer = new Computer("dell", "1", 1000);

            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("lg", "2"));
        }

        [Test]
        public void GetComputer_ComputerReturned()
        {
            Computer computer = new Computer("dell", "1", 1000);

            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(computer);

            Assert.That(computerManager.GetComputer("dell", "1"), Is.EqualTo(computer));
        }

        [Test]
        public void GetComputersByManufacturer()
        {
            Computer computer = new Computer("dell", "1", 1000);
            Computer computer2 = new Computer("dell", "2", 1000);
            Computer computer3 = new Computer("dell", "3", 1000);


            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            Assert.That(computerManager.GetComputersByManufacturer("dell"), Is.EqualTo(computerManager.Computers));
        }

    }
}