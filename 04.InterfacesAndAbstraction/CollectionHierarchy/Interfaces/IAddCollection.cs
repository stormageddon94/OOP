using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAddCollection<T>
    {
        int Add(T element);
    }
}
