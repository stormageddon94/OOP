using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Interfaces
{
    public interface IComando
    {
        ICollection<IMission> Missions { get; set; }
    }
}
