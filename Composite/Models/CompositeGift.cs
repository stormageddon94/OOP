﻿using Composite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;
        public CompositeGift(string name, int price) : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;
            Console.WriteLine($"{name} contains the following products with prices:");

            foreach (var gift in this.gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }
    }
}
