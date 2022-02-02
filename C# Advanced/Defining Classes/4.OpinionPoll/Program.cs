using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                if (Convert.ToInt32(input[1]) > 30)
                {
                    Person newPerson = new Person(input[0], Convert.ToInt32(input[1]));
                    persons.Add(newPerson);
                }
            }
            foreach (var item in persons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
