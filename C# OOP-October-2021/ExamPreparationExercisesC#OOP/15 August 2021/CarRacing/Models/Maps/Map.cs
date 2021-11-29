using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerTwo.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else
            {
                racerOne.Race();
                racerTwo.Race();

                int chanceOfWinningRacerOne = 0;
                int chanceOfWinningRacerTwo = 0;

                if (racerOne.RacingBehavior == "aggressive")
                {
                    chanceOfWinningRacerOne = (int)(racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1);
                }
                else
                {
                    chanceOfWinningRacerOne = (int)(racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2);
                }

                if (racerTwo.RacingBehavior == "aggressive")
                {
                    chanceOfWinningRacerTwo = (int)(racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1);
                }
                else
                {
                    chanceOfWinningRacerTwo = (int)(racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2);
                }

                if (chanceOfWinningRacerOne > chanceOfWinningRacerTwo)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username,
                        racerOne.Username);
                }
                else
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username,
                        racerTwo.Username);
                }
            }
        }
    }
}
