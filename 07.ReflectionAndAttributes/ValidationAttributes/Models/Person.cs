﻿using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        [MyRequiredAttribute]
        public string Name { get; private set; }

        [MyRangeAttribute(12, 90)]
        public int Age { get; private set; }
    }
}
