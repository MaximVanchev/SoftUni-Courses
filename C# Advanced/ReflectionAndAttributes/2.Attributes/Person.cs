using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }
        [MyRange(12, 90)]
        public int Age { get; private set; }
        [MyRequired]
        public string FullName { get; private set; }
    }
}
