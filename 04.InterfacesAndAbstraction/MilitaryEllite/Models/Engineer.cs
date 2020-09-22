using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName, salary)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get ; set ; }
    }
}
