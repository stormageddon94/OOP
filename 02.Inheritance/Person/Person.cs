using System;
using System.Text;

namespace _01.Person
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age 
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Person age should be more than 0");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Name: {this.Name}, Age: {this.Age}");
            return sb.ToString();
        }
    }
}
