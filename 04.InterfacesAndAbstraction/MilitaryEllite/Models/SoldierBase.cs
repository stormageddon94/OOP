using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class SoldierBase : ISoldier
    {
        public SoldierBase(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
