﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Cotracts
{
    public interface IBird : IAnimal
    {
        double WingSize { get; }
    }
}
