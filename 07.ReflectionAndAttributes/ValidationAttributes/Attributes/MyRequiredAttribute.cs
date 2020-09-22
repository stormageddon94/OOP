using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : Attribute, IVallidator
    {
        public bool IsValid(object obj)
        {
            var type = obj.GetType();
            var pi = type.GetProperty("Id");
            var hasIsIdentity = Attribute.IsDefined(pi, typeof(MyRequiredAttribute));

            if (hasIsIdentity)
            {
                return true;
            }

            return false;
        }
    }
}
