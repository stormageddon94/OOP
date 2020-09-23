using System;
using System.Collections.Generic;
using System.Text;

namespace BoarderControl
{
    public class Person : IId, IBirthdate
    {
        public Person(string name, int age, string idNumber, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.IdNumber = idNumber;
            this.Birthdate = birthdate;
        }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }

        //public bool IsIdFake(string endNumbers)
        //{
        //    if (this.IdNumber.EndsWith(endNumbers))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

    }
}
