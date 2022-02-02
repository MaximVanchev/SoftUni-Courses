using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person newPerson = new Person(10);
            Console.WriteLine(newPerson.Name);
        }
    }
}
