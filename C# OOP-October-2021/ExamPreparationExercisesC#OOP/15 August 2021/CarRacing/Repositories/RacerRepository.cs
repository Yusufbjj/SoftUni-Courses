using System;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private HashSet<IRacer> racers;

        public RacerRepository()
        {
            this.racers = new HashSet<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models
        {
            get => this.racers;
        }
        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            this.racers.Add(model);
        }

        public bool Remove(IRacer model)
        {
            return this.racers.Remove(model);
        }

        public IRacer FindBy(string property)
        {
            IRacer racer = this.racers.FirstOrDefault(r => r.Username == property);

            return racer;
        }
    }
}
