using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Private : ISoldier, IPrivate
    {
        private string id;
        private string name;
        private string latName;
        private decimal salary;
        public Private(string id, string name, string latName, decimal salary)
        {
            Id = id;
            Name = name;
            LastName = latName;
            Salary = salary;
        }
        public string Id { get => id; private set => id = value; }

        public string Name { get => name; private set => name = value; }

        public string LastName { get => latName; private set => latName = value; }

        public decimal Salary { get => salary; private set => salary = value; }
        public override string ToString()
        {
            return $"Name: {Name} {LastName} Id: {Id} Salary: {Salary:F2}";
        }
    }
}
