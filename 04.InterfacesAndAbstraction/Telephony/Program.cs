using System;

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
                        ISmartPhone smartPhone = new SmartPhone();
                        Console.WriteLine(smartPhone.Call(number));
                    }
                    else if (number.Length == 7)
                    {
                        IStationeryPhone stationeryPhone = new StationeryPhone();
                        Console.WriteLine(stationeryPhone.Dial(number));
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
                    ISmartPhone smartPhone = new SmartPhone();
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
