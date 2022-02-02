using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command = null;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (int.Parse(input[1]) > 0 && (input[2] == "Male" || input[2] == "Female"))
                {
                    if (command == "Cat")
                    {
                        Cat cat = new Cat(input[0], int.Parse(input[1]), input[2]);
                        animals.Add(cat);
                    }
                    else if (command == "Dog")
                    {
                        Dog dog = new Dog(input[0], int.Parse(input[1]), input[2]);
                        animals.Add(dog);
                    }
                    else if (command == "Frog")
                    {
                        Frog frog = new Frog(input[0], int.Parse(input[1]), input[2]);
                        animals.Add(frog);
                    }
                    else if (command == "Kitten")
                    {
                        Kitten kitten = new Kitten(input[0], int.Parse(input[1]), input[2]);
                        animals.Add(kitten);
                    }
                    else if (command == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(input[0], int.Parse(input[1]), input[2]);
                        animals.Add(tomcat);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
