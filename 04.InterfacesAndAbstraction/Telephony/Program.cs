using System;
using System.Collections.Generic;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split();
            var websites = Console.ReadLine().Split();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        ICallable smartPhone = new SmartPhone();
                        Console.WriteLine(smartPhone.Call(number));
                    }
                    else
                    {
                        ICallable stationeryPhone = new StationeryPhone();
                        Console.WriteLine(stationeryPhone.Call(number));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var website in websites)
            {
                try
                {
                    IBrowsable smartPhone = new SmartPhone();
                    Console.WriteLine(smartPhone.Browse(website));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
