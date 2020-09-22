using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName, salary)
        {
            this.SpecialisedCorps = new List<ISpecialisedSoldierCorp>();
        }

        public List<ISpecialisedSoldierCorp> SpecialisedCorps { get; set; }
    }
}
