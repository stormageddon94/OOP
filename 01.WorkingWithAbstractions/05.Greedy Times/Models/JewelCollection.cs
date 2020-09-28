using _05.Greedy_Times.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.Greedy_Times.Models
{
    public class JewelCollection : IJewelCollection
    {
        public JewelCollection()
        { }
        public List<IJewel> JewelsTaken { get; set; } = new List<IJewel>();

        public long TotalAmount => this.JewelsTaken.Sum(x => x.Amount);

        public void AddJewel(IJewel jewel)
        {
            if (jewel.Name == "Gold" && this.JewelsTaken.Any(x => x.Name == "Gold"))
            {
                this.JewelsTaken.FirstOrDefault(x => x.Name == "Gold").Amount += jewel.Amount;
            }
            else
            {
                this.JewelsTaken.Add(jewel);
            }
        }
    }
}
