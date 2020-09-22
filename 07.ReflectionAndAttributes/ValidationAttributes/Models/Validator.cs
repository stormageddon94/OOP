using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Validator : IVallidator
    {
        public bool IsValid(object obj)
        {
            var type = obj.GetType();
            return true;
        }
    }
}
