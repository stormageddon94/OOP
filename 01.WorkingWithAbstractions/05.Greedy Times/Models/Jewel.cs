using _05.Greedy_Times.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Greedy_Times.Models
{
    public class Jewel : IJewel
    {
        private string name;
        private long amount;

        public Jewel(string name, long amount)
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

        public long Amount
        {
            get => this.amount;
            set
            {
                this.amount = value;
            }
        }

        public override string ToString()
        {
            return $"##{this.Name} - {this.Amount}";
        }
    }
}
