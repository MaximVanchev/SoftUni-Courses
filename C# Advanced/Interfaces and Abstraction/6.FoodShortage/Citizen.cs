using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IIdentifiable , IBirthdatable , IBuyer
    {
        private string name;
        private int age;
        private string birthdayDate;
        private int food;
        public Citizen(string name, int age, string id, string birthdayDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthdayDate = birthdayDate;
            Food = 0;
        }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Id { get; private set; }

        public string BirthdayDate { get => birthdayDate; private set => birthdayDate = value; }
        public int Food { get => food; private set => food = value; }                
        public void BuyFood()
        {
            Food += 10;
        }
    }
}
