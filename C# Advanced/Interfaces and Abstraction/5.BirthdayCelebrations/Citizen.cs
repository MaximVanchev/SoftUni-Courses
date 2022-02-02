using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IIdentifiable , IBirthdatable
    {
        private string name;
        private int age;
        private string birthdayDate;
        public Citizen(string name, int age, string id, string birthdayDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthdayDate = birthdayDate;
        }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Id { get; private set; }

        public string BirthdayDate { get => birthdayDate; private set => birthdayDate = value; }
    }
}
