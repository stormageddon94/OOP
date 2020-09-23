using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Greedy_Times.Contracts
{
    public interface IJewelCollection
    {
        public List<IJewel> JewelsTaken { get; set; }

        public int TotalAmount { get; set; }

        public void AddJewel(IJewel jewel);
    }
}
