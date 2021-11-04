using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ValidateStat(nameof(Endurance), value);
                this.endurance = value;
            }
        }


        public int Sprint
        {
            get => this.sprint;
            private set
            {
                ValidateStat(nameof(Sprint), value);
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            set
            {
                ValidateStat(nameof(Dribble), value);
                this.dribble = value;
            }

        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                ValidateStat(nameof(Passing), value);
                this.passing = value;
            }

        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                ValidateStat(nameof(Shooting), value);
                this.shooting = value;
            }

        }

        public double Stats 
            => (double)(Endurance + Sprint + Passing + Shooting + Dribble) / 5.0;

        private void ValidateStat(string stat, int value)
        {
            
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{stat} should be between 0 and 100.");
            }
        }

    }
}
