namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PhoneBase : ICallable
    {
        public virtual string Call(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {number}";
        }
    }
}
