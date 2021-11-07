using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Implementations;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public List<Repair> Repairs { get; set; }

    }
}
