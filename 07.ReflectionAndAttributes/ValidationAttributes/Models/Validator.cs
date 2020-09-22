using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator: IVallidator
    { 
        public bool IsValid(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();


        }
    }
}
