using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Telephony
{
    public class SmartPhone : PhoneBase, IBrowsable
    {
        public string Browse(string website)
        {
            if (website.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {website}!";
        }
    }
}
