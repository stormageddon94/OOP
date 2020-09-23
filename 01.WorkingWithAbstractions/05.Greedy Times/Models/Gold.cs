using _05.Greedy_Times.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Greedy_Times.Models
{
    public class Gold : IJewel
    {
        private string name;
        private int amount;

        public Gold(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }

        public int Amount
        {
            get => this.amount;
            set
            {
                this.amount = value;
            }
        }
    }
}
