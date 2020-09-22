using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class Airforce : SoldierBase, ISpecialisedSoldierCorp
    {
        public Airforce(int id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }
    }
}
