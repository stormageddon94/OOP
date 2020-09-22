using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationeryPhone : IStationeryPhone
    {
        public string Dial(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Dialing... {number}";
        }
    }
}
