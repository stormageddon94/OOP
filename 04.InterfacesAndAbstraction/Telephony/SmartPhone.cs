using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Telephony
{
    public class SmartPhone : ISmartPhone
    {
        public string Browse(string website)
        {
            if (website.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {website}!";
        }

        public string Call(string phonenumber)
        {
            if (phonenumber.Any(x => !char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {phonenumber}";
        }

    }
}
