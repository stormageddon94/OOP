using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Interfaces
{
    public interface IEngineer
    {
        ICollection<IRepair> Repairs { get; set; }
    }
}
