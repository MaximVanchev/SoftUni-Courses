using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : ISoldier, ILieutenantGeneral, IPrivate
    {
        private string id;
        private string name;
        private string latName;
        private decimal salary;
        private List<IPrivate> privates = new List<IPrivate>();
        public LieutenantGeneral(string id, string name, string latName, decimal salary, List<IPrivate> privates)
        {
            Id = id;
            Name = name;
            LastName = latName;
            Salary = salary;
            Privates = privates;
        }
        public string Id { get => id; private set => id = value; }

        public string Name { get => name; private set => name = value; }

        public string LastName { get => latName; private set => latName = value; }

        public decimal Salary { get => salary; private set => salary = value; }

        public List<IPrivate> Privates { get => privates; private set => privates = value; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine("Privates:");
            foreach (var item in Privates)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
