using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            List<string> command = null;
            while ((command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList())[0] != "End")
            {
                Animal animal = null;
                if (command[0] == "Owl")
                {
                    animal = new Owl(command[1], double.Parse(command[2]), double.Parse(command[3]));
                }
                else if (command[0] == "Hen")
                {
                    animal = new Hen(command[1], double.Parse(command[2]), double.Parse(command[3]));
                }
                else if (command[0] == "Mouse")
                {
                    animal = new Mouse(command[1], double.Parse(command[2]), command[3]);
                }
                else if (command[0] == "Dog")
                {
                    animal = new Dog(command[1], double.Parse(command[2]), command[3]);
                }
                else if (command[0] == "Cat")
                {
                    animal = new Cat(command[1], double.Parse(command[2]), command[3], command[4]);
                }
                else if (command[0] == "Tiger")
                {
                    animal = new Tiger(command[1], double.Parse(command[2]), command[3], command[4]);
                }
                animals.Add(animal);
                Console.WriteLine(animal.Ability());
                List<string> foodInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                Food food = null;
                if (foodInput[0] == "Vegetable")
                {
                    food = new Vegetable(int.Parse(foodInput[1]));
                }
                else if (foodInput[0] == "Fruit")
                {
                    food = new Fruit(int.Parse(foodInput[1]));
                }
                else if (foodInput[0] == "Meat")
                {
                    food = new Meat(int.Parse(foodInput[1]));
                }
                else if (foodInput[0] == "Seeds")
                {
                    food = new Seeds(int.Parse(foodInput[1]));
                }
                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
