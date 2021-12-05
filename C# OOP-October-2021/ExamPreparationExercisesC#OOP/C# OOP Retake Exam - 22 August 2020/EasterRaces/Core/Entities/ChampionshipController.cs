using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            this.drivers.Add(new Driver(driverName));

            return $"Driver {driverName} is created.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (this.cars.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already create.");
            }
            if (type == "Muscle")
            {
                car = (new MuscleCar(model, horsePower));
            }
            else if (type == "Sports")
            {
                car = (new SportsCar(model, horsePower));
            }

            this.cars.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = null;

            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);

            this.races.Add(race);

            return $"Race {name} is created.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = null;
            IDriver driver = null;

            if (this.races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (this.drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            driver = this.drivers.GetByName(driverName);
            race = this.races.GetByName(raceName);
            race.AddDriver(driver);

            return $"Driver {driver.Name} added in {raceName} race.";

        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = null;
            ICar car = null;

            if (this.drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (this.cars.GetByName(carModel) == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver = this.drivers.GetByName(driverName);
            car = this.cars.GetByName(carModel);
            driver.AddCar(car);

            return $"Driver {driver.Name} received car {car.Model}.";
        }

        public string StartRace(string raceName)
        {

            if (this.races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            IRace race = this.races.GetByName(raceName);

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var sortedDrivers = drivers.GetAll().OrderByDescending(driver =>
                    driver.Car.CalculateRacePoints(race.Laps)).ToList();


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {sortedDrivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {sortedDrivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {sortedDrivers[2].Name} is third in {raceName} race.");

            races.Remove(race);

            return sb.ToString().TrimEnd();

        }
    }
}
