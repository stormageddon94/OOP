using _05.Greedy_Times.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Greedy_Times
{
    class Program
    {
        static List<string> jewelPriorities = new List<string> { "Gold", "Gem", "Cash" };
        static void Main(string[] args)
        {
            var maxBagAmount = long.Parse(Console.ReadLine());
            var bag = new Bag(maxBagAmount);

            var jewels = Console.ReadLine().Split().ToList();

            var jewelPairs = jewels.Select((x, i) => new { Key = i / 2, Value = x })
                                   .GroupBy(x => x.Key, x => x.Value);

            foreach (var pair in jewelPairs)
            {
                var pairAsArray = pair.ToArray();
                var jewelName = pairAsArray[0];
                string jewelType = string.Empty;
                var jewelAmount = long.Parse(pairAsArray[1]);

                if (jewelName == "Gold")
                {
                    jewelType = "Gold";
                }
                else if (jewelName.ToLower().EndsWith("gem") && jewelName.Length >= 4)
                {
                    jewelType = "Gem";
                }
                else if (jewelName.Length == 3)
                {
                    jewelType = "Cash";
                }

                if (!string.IsNullOrEmpty(jewelType))
                {
                    var gemTotalAmount = bag.AllJewelsInBag.FirstOrDefault(x => x.Key == "Gem").Value?.TotalAmount ?? 0;
                    var goldTotalAmount = bag.AllJewelsInBag.FirstOrDefault(x => x.Key == "Gold").Value?.TotalAmount ?? 0;
                    var cashTotalAmount = bag.AllJewelsInBag.FirstOrDefault(x => x.Key == "Cash").Value?.TotalAmount ?? 0;
                    if (jewelType == "Gold" || jewelType == "Gem" && gemTotalAmount + jewelAmount <= goldTotalAmount ||
                        jewelType == "Cash" && cashTotalAmount + jewelAmount <= gemTotalAmount)
                    {
                        var jewel = new Jewel(jewelName, jewelAmount);
                        try
                        {
                            bag.AddJewelAmountToBagAmount(jewel);
                        }
                        catch (ArgumentException)
                        {
                            break;
                        }

                        if (!bag.AllJewelsInBag.ContainsKey(jewelType))
                        {
                            bag.AllJewelsInBag[jewelType] = new JewelCollection();
                        }

                        bag.AllJewelsInBag[jewelType].AddJewel(jewel);
                    }
                }


            }

            var orderedJewelPairs = bag.AllJewelsInBag.OrderByDescending(x => x.Value.TotalAmount);

            foreach (var pair in orderedJewelPairs)
            {
                var orderedCollectionOfJewels = pair.Value.JewelsTaken.OrderByDescending(x => x.Name).ThenBy(y => y.Amount);
                Console.WriteLine($"<{pair.Key}> ${pair.Value.TotalAmount}");

                foreach (var jewel in orderedCollectionOfJewels)
                {
                    Console.WriteLine(jewel);
                }
            }
        }
    }
}
