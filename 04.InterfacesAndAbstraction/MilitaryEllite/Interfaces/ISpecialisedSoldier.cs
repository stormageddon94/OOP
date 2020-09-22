using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Interfaces
{
    public interface ISpecialisedSoldier
    {
        List<ISpecialisedSoldierCorp> SpecialisedCorps { get; set; }
    }
}
