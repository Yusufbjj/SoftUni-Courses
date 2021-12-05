using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;
        private int initialHorsePower;
        private string initialModel;

        protected Car(string model, int horsePower, double cubicCentimetersint, int minHorsePower, int maxHorsePower)
        {
            initialModel = model;
            this.Model = model;
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;
            initialHorsePower = horsePower;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimetersint;
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {initialModel} cannot be less than 4 symbols.");
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {initialHorsePower}.");
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters
        {
            get => this.cubicCentimeters;
            private set
            {
                this.cubicCentimeters = value;
            }
        }

        public int MinHorsePower
        {
            get => this.minHorsePower;
            private set
            {
                this.minHorsePower = value;
            }
        }

        public int MaxHorsePower
        {
            get => this.maxHorsePower;
            private set
            {
               this.maxHorsePower = value;
            }
        }

        public double CalculateRacePoints(int laps)
        {
            double racePoints = CubicCentimeters / HorsePower * laps;
            return racePoints;
        }
    }
}
