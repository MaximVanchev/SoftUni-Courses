using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Pet : IBirthdatable
    {
        private string name;
        private string birthdayDate;
        public Pet(string name, string birthdayDate)
        {
            Name = name;
            BirthdayDate = birthdayDate;
        }
        public string Name { get => name; set => name = value; }

        public string BirthdayDate { get => birthdayDate; private set => birthdayDate = value; }
    }
}
