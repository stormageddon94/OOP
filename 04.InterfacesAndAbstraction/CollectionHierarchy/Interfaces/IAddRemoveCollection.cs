﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
