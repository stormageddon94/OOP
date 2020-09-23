using _05.Greedy_Times.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Greedy_Times.Models
{
    public class GoldCollection : IJewelCollection
    {
        private List<IJewel> jewelsTaken;

        public GoldCollection()
        {
            this.jewelsTaken = new List<IJewel>();
        }
        public List<IJewel> JewelsTaken { get; set; }
        public int TotalAmount { get; set; }

        public void AddJewel(IJewel jewel)
        {
            this.jewelsTaken.Add(jewel);
        }
    }
}
