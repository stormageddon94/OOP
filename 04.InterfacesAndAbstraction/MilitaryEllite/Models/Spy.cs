using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class Spy : SoldierBase, ISpy
    {
        public Spy(int id, string firstName, string lastName, int spyCodeNumber) : base(id, firstName, lastName)
        {
            this.SpyCodeNumber = spyCodeNumber;
        }

        public int SpyCodeNumber { get; set; }
    }
}
