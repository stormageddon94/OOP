using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public interface IVallidator
    {
        bool IsValid(object obj);
    }
}
