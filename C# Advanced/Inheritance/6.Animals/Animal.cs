using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public string Name 
        {
            get => name; set => name = value; 
        }
        public int Age 
        { 
            get => age; set => age = value; 
        }
        public virtual string Gender 
        { 
            get => gender; set => gender = value; 
        }
        public virtual string ProduceSound()
        {
            return $"";
        }
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(GetType().Name)
                .AppendLine($"{Name} {Age} {Gender}")
                .Append($"{ProduceSound()}");
            return builder.ToString();
        }
    }
}
