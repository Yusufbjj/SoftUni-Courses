using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Implementations
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,Corps corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public decimal Salary { get; set; }
        public Corps Corps { get; set; }

    }
}
