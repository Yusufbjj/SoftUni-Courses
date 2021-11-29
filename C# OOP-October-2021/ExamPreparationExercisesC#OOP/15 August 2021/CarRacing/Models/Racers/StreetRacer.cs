using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const string racingBehavior = "aggressive";
        private const int drivingExperience = 10;
        public StreetRacer(string username, ICar car) 
            : base(username, racingBehavior, drivingExperience, car)
        {
        }

        public override void Race()
        {
            this.DrivingExperience += 5;
            this.Car.Drive();
        }
    }
}
