using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates { get; private set; }

    }
}
