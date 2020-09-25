using _05.Greedy_Times.Contracts;
using _05.Greedy_Times.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxBagAmount = long.Parse(Console.ReadLine());
            var bag = new Bag(maxBagAmount);

            var jewels = Console.ReadLine().Split().ToList();

            for (int i = 0; i < jewels.Count; i += 2)
            {
                var jewelName = jewels[i].ToLower();
                var jewelAmount = long.Parse(jewels[i + 1]);
                string keyForBagJewelsList;
                //if the new jewel amount is bigger than the ones already in the list
                //remove the lowest amount jewel and add the new jewel
                // same  as above goes to Jewel collection
                // if the total amount of the bag is exceeded program doesn't break
                // double check the Bag class
                if (jewelName == "gold")
                {
                    var gold = new Gold(jewelName, jewelAmount);
                    keyForBagJewelsList = "Gold";
                    if (!bag.AllJewelsInBag.ContainsKey(keyForBagJewelsList))
                    {
                        bag.AllJewelsInBag[keyForBagJewelsList] = new GoldCollection();
                    }

                    bag.AllJewelsInBag[keyForBagJewelsList].AddJewel(gold);
                    try
                    {
                        bag.AddJewelAmountToBagAmount(gold);
                    }
                    catch (ArgumentException)
                    {
                        break;
                    }
                }
                else if (jewelName.EndsWith("gem") && jewelName.Length >= 4)
                {
                    var gem = new Gem(jewelName, jewelAmount);
                    keyForBagJewelsList = "Gem";
                    if (!bag.AllJewelsInBag.ContainsKey(keyForBagJewelsList))
                    {
                        bag.AllJewelsInBag[keyForBagJewelsList] = new GemCollection();
                    }

                    bag.AllJewelsInBag[keyForBagJewelsList].AddJewel(gem);
                    try
                    {
                        bag.AddJewelAmountToBagAmount(gem);
                    }
                    catch (ArgumentException)
                    {
                        break;
                    }
                }
                else if (jewelName.Length == 3)
                {
                    var cash = new Cash(jewelName, jewelAmount);
                    keyForBagJewelsList = "Cash";
                    if (!bag.AllJewelsInBag.ContainsKey(keyForBagJewelsList))
                    {
                        bag.AllJewelsInBag[keyForBagJewelsList] = new CashCollection();
                    }

                    bag.AllJewelsInBag[keyForBagJewelsList].AddJewel(cash);
                    try
                    {
                        bag.AddJewelAmountToBagAmount(cash);
                    }
                    catch (ArgumentException)
                    {
                        break;
                    }
                }
            }
        }
    }
}
