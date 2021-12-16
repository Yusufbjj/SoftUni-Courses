using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private HashSet<Drone> drones;
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.drones = new HashSet<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public int Count => this.drones.Count;

        public IReadOnlyCollection<Drone> Drones => this.drones;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (Count == Capacity)
            {
                return "Airfield is full.";
            }

            this.drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var drone = this.drones.FirstOrDefault(d => d.Name == name);

            return this.drones.Remove(drone);
        }

        public int RemoveDroneByBrand(string brand)
        {
            int dronesRemoved = 0;

            foreach (Drone drone in this.drones.ToList())
            {
                if (drone.Brand == brand)
                {
                    this.drones.Remove(drone);
                    dronesRemoved++;
                }
            }

            return dronesRemoved;
        }

        public Drone FlyDrone(string name)
        {
            var drone = this.drones.FirstOrDefault(d => d.Name == name && d.Available == true);
            drone.Available = false;
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = new List<Drone>();
            foreach (Drone drone in this.drones)
            {
                if (drone.Range >= range && drone.Available == true)
                {
                    FlyDrone(drone.Name);

                    drones.Add(drone);
                }
            }

            return drones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {Name}:");
            foreach (Drone drone in drones)
            {
                if (drone.Available == true)
                {
                    sb.AppendLine(drone.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}
