using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
            RaceEntry raceEntry = new RaceEntry();

        }

        [Test]
        public void Counter()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("model", 300, 200);
            UnitDriver driver = new UnitDriver("driverName", car);
            raceEntry.AddDriver(driver);

            Assert.AreEqual(raceEntry.Counter, 1);

        }

        [Test]
        public void AddDriver_IsNull()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("model", 300, 200);
            UnitDriver driver = new UnitDriver("driverName", car);
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));

        }

        [Test]
        public void AddDriver_AlreadyExists()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("model", 300, 200);
            UnitDriver driver = new UnitDriver("driverName", car);
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));

        }

        [Test]
        public void AddDriver()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("model", 300, 200);
            UnitDriver driver = new UnitDriver("driverName", car);


            Assert.That(raceEntry.AddDriver(driver), Is.EqualTo($"Driver {driver.Name} added in race."));

        }

        [Test]
        public void CalculateAverageHorsePower_CannotStart()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("model", 300, 200);
            UnitDriver driver = new UnitDriver("driverName", car);
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());

        }

        [Test]
        public void CalculateAverageHorsePower()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar car = new UnitCar("model", 300, 200);
            UnitCar car2 = new UnitCar("model", 350, 200);
            UnitDriver driver = new UnitDriver("driverName", car);
            UnitDriver driver2 = new UnitDriver("driverName2", car2);
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(driver2);

            var averageHpCars = 0;

            averageHpCars = (car.HorsePower + car2.HorsePower) / 2;

            var average = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(averageHpCars,average);
        }
    }
}