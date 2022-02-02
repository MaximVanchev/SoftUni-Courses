using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> people = new List<People>();
            string input = null;
            while ((input = Console.ReadLine()) != "End")
            {
                List<string> peopleInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                People newPerson = new People(peopleInfo[0],peopleInfo[1],Convert.ToInt32(peopleInfo[2]));
                people.Add(newPerson);
            }
            Console.WriteLine(string.Join(Environment.NewLine,people.OrderBy(x => x.personAge)));
        }
    }
    public class People
    {
        public string personName { get; set; }
        public string personID { get; set; }
        public int personAge { get; set; }
        public People(string name,string id,int age)
        {
            personName = name;
            personID = id;
            personAge = age;
        }
        public override string ToString()
        {
            return $"{personName} with ID: {personID} is {personAge} years old.";
        }
    }
}
