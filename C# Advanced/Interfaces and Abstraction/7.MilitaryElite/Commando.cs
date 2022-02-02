using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : ISoldier , IPrivate , ISpecialisedSoldier ,ICommando
    {
        private string id;
        private string name;
        private string latName;
        private decimal salary;
        private string crops;
        private List<Mission> missions = new List<Mission>();
        public Commando(string id, string name, string latName, decimal salary, string crops)
        {
            Id = id;
            Name = name;
            LastName = latName;
            Salary = salary;
            Crops = crops;
        }
        public string Id { get => id; private set => id = value; }

        public string Name { get => name; private set => name = value; }

        public string LastName { get => latName; private set => latName = value; }

        public decimal Salary { get => salary; private set => salary = value; }

        public string Crops
        {
            get => crops;
            private set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    crops = value;
                }
                else
                {
                    throw new ArgumentException("invalid");
                }
            }
        }

        public List<Mission> Missions { get => missions; set => missions = value; }

        public void CompleteMission()
        {
            
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine($"Corps: {Crops}");
            sb.AppendLine("Missions:");
            foreach (var item in Missions)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
