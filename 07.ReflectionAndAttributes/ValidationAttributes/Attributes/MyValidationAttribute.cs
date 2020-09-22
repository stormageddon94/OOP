using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public abstract class MyValidationAttribute : Attribute, IVallidator
    {
        public abstract bool IsValid(object obj);
    }
}
