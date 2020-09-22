using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class Marine : SoldierBase, ISpecialisedSoldierCorp
    {
        public Marine(int id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }
    }
}
