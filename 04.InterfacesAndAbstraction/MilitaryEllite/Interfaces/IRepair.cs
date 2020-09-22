using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Interfaces
{
    public interface IRepair
    {
        string PartName { get; set; }

        int HoursWorked { get; set; }
    }
}
