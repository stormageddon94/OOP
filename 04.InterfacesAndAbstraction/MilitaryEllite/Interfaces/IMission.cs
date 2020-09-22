using MilitaryEllite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; set; }

        MissionStateType State { get; set; }
    }
}
