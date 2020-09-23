using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corp;
        public SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corp)
        : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }

        public string Corp
        {
            get
            {
                return this.corp;
            }
            private set
            {
                if (value != "Marines" && value != "Airforces")
                {
                    throw new ArgumentException("Invalid corp.");
                }

                this.corp = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .Append($"Corps: {this.Corp}");
            return sb.ToString();
        }
    }
}
