using System;
using System.Linq;
using System.Text;
using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = default;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
                this.cars.Add(car);
            }
            else if (type == "TunedCar")
            {
                this.cars.Add(new TunedCar(make, model, VIN, horsePower));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.FindBy(carVIN);
            if (car is null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type == "ProfessionalRacer")
            {
                this.racers.Add(new ProfessionalRacer(username, car));
            }
            else if (type == "StreetRacer")
            {
                this.racers.Add(new StreetRacer(username, car));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {

            IRacer racerOne = racers.FindBy(racerOneUsername);

            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var racer in this.racers.Models.OrderByDescending(m => m.DrivingExperience).ThenBy(m => m.Username))
            {
                sb.Append($"{racer.GetType().Name}: {racer.Username}" + Environment.NewLine);
                sb.Append($"--Driving behavior: {racer.RacingBehavior}" + Environment.NewLine);
                sb.Append($"--Driving experience: {racer.DrivingExperience}" + Environment.NewLine);
                sb.Append($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
