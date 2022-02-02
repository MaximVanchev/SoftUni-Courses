using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Repair
    {
        private string name;
        private int hoursWorked;
        public Repair(string name, int hoursWorked)
        {
            Name = name;
            HoursWorked = hoursWorked;
        }
        public string Name { get => name; private set => name = value; }
        public int HoursWorked { get => hoursWorked; private set => hoursWorked = value; }
        public override string ToString()
        {
            return $"Part Name: {Name} Hours Worked: {HoursWorked}";
        }
    }
}
