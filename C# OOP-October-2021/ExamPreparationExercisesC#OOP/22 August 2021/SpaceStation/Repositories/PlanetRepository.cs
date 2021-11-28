using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private HashSet<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new HashSet<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
        {
            get => this.planets;
        }
        public void Add(IPlanet model)
        {
            this.planets.Add(model);
        }

        public bool Remove(IPlanet model)
        {
            return this.planets.Remove(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.planets.FirstOrDefault(p => p.Name == name);
        }
    }
}
