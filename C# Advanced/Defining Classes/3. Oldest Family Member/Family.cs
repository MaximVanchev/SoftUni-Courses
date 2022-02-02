using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public static class Family
    {
        private static List<Person> familyMembers = new List<Person>();
        public static void AddMember(string member,int age)
        {
            familyMembers.Add(new Person(member,age));
        }
        public static Person GetOldestMember()
        {
            return familyMembers.OrderByDescending(x => x.Age).ToList()[0];
        }
    }
}
