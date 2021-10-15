using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }

        public int Count => Participants.Count;

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }


        public void Add(Car car)
        {


            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate) &&
                Capacity >= Participants.Count + 1 &&
                car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }


        }

        public bool Remove(string licensePlate)
        {
            var car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (car == null)
            {
                return false;
            }
            else
            {
                Participants.Remove(car);
                return true;
            }
        }

        public Car FindParticipant(string licensePlate)
        {
            var car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (car == null)
            {
                return null;
            }
            else
            {
                return car;
            }
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count > 0)
            {
                var sortedByHorsePowerParticipants = Participants.OrderByDescending(x => x.HorsePower).ToList();
                var mostPowerfulCar = sortedByHorsePowerParticipants[0];
                return mostPowerfulCar;
            }
            else
            {
                return null;
            }
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                stringBuilder.AppendLine(car.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
