﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Cotracts
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
