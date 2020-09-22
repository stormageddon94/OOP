using MilitaryEllite.Enums;
using MilitaryEllite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateType state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public string CodeName { get; set; }
        public MissionStateType State { get; set; }
    }
}
