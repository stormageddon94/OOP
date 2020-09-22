using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : Person, IBuyer, IId, IBirthdate
    {
        public Citizen(string name, int age, string idNumber, string birthdate) : base(name, age)
        {
            IdNumber = idNumber;
            Birthdate = birthdate;
        }

        public string IdNumber { get; set; }
        public string Birthdate { get; set; }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
