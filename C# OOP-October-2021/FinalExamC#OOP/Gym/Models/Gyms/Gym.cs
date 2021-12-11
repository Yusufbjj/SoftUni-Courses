using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;
        private double equipmentWeight;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipments = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                capacity = value;
            }
        }

        public double EquipmentWeight { get => this.equipments.Sum(e => e.Weight); }

        public ICollection<IEquipment> Equipment { get => this.equipments.AsReadOnly(); }

        public ICollection<IAthlete> Athletes { get => this.athletes.AsReadOnly(); }

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == this.athletes.Count)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }

            this.athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            var athleteForRemoval = this.athletes.FirstOrDefault(a => a.FullName == athlete.FullName);
            return this.athletes.Remove(athleteForRemoval);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (IAthlete athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {this.GetType().Name}:");

            if (this.athletes.Any())
            {
                sb.Append("Athletes: ");

                List<string> athletesNames = new List<string>();

                foreach (IAthlete athlete in this.athletes)
                {
                    athletesNames.Add(athlete.FullName);
                }

                sb.AppendLine(string.Join(", ", athletesNames));

            }
            else
            {
                sb.AppendLine("Athletes: No athletes");
            }

            sb.AppendLine($"Equipment total count: {this.equipments.Count}");

            sb.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
