using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class Private : SoldierBase, IPrivate
    {
        private int id;
        private string firstName;
        private string lastName;

        public Private(int id, string firstName, string lastName) :base(id, firstName, lastName)
        {
        }

        public Private(int id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public double Salary { get; private set; }
    }
}
