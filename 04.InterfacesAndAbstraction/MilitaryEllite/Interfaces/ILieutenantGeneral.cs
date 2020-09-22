using MilitaryEllite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEllite.Interfaces
{
    public interface ILieutenantGeneral 
    {
        ICollection<IPrivate> Privates { get; }
    }
}
