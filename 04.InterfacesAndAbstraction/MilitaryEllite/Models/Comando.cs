using MilitaryEllite.Enums;
using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class Comando : SpecialisedSoldier, IComando
    {
        public Comando(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName, salary)
        {
            this.Missions = new List<IMission>();
        }


        public ICollection<IMission> Missions { get; set; }

    }
}
