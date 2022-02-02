using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthdatable> birthdatables = new List<IBirthdatable>();
            List<string> command = null;
            while ((command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList())[0] != "End")
            {
                if (command[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(command[1], int.Parse(command[2]), command[3], command[4]);
                    birthdatables.Add(citizen);
                }
                else if (command[0] == "Pet")
                {
                    Pet pet = new Pet(command[1], command[2]);
                    birthdatables.Add(pet);
                }
                else if (command[0] == "Robot")
                {
                    Robot robot = new Robot(command[1], command[2]);
                }
            }
            string specialNum = Console.ReadLine();
            foreach (var item in birthdatables)
            {
                string birthdayYear = item.BirthdayDate.Split("/")[2];
                if (birthdayYear == specialNum)
                {
                    Console.WriteLine(item.BirthdayDate);
                }
            }
        }
    }
}
