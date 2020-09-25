using _05.Greedy_Times.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Greedy_Times.Models
{
    public class Bag
    {
        private Dictionary<string, IJewelCollection> allJewelsInBag;
        private long totalAmount;
        private long maxAmount;

        public Bag(long maxAmount)
        {
            this.maxAmount = maxAmount;
            this.allJewelsInBag = new Dictionary<string, IJewelCollection>();
        }

        public Dictionary<string, IJewelCollection> AllJewelsInBag 
        { 
            get => this.allJewelsInBag;
            set
            {
                this.allJewelsInBag = value;
            }
        }

        public long TotalAmount { get; set; }

        public long MaxAmount 
        {
            get => this.maxAmount;
            set
            {
                this.maxAmount = value;
            }
        }

        public void AddJewelAmountToBagAmount(IJewel jewel)
        {
            this.TotalAmount += jewel.Amount;
            if (totalAmount > maxAmount)
            {
                throw new ArgumentException("Max capacity of bag exceeded.");
            }
        }

    }
}
