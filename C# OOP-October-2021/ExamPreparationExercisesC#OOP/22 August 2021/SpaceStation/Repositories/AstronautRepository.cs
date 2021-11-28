using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private HashSet<IAstronaut> astronauts;
        public AstronautRepository()
        {
            this.astronauts = new HashSet<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models
        {
            get => this.astronauts;
        }
        public void Add(IAstronaut model)
        {
            this.astronauts.Add(model);
        }

        public bool Remove(IAstronaut model)
        {
            return this.astronauts.Remove(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronaut = this.astronauts.FirstOrDefault(a => a.Name == name);
            return astronaut;
        }
    }
}
