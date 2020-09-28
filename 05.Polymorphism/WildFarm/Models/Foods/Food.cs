using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Cotracts;

namespace WildFarm.Models
{
    public abstract class Food : IFood
    {
        public Food(long quantity)
        {
            this.Quantity = quantity;
        }

        public long Quantity { get; private set; }
    }
}
