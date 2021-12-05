using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private string initialName;
        public Driver(string name)
        {
            initialName = name;
            this.Name = name;
           
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {initialName} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public ICar Car
        {
            get => this.car;
            private set
            {

            }
        }

        public int NumberOfWins { get; private set; }
        public bool CanParticipate { get; private set; }
        public void WinRace()
        {
            NumberOfWins += 1;
        }

        public void AddCar(ICar car)
        {
            if (car is null)
            {
                throw new ArgumentNullException("Car cannot be null.");
            }

            this.car = car;
            CanParticipate = true;
        }
    }
}
