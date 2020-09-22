using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        public string PartName { get; set; }

        public int HoursWorked { get; set; }
    }
}
