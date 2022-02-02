using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Spy : ISoldier, ISpy
    {
        private string id;
        private string name;
        private string latName;
        private int codeNumber;
        public Spy(string id, string name, string latName, int codeNumber)
        {
            Id = id;
            Name = name;
            LastName = latName;
            CodeNumber = codeNumber;
        }
        public string Id { get => id; private set => id = value; }

        public string Name { get => name; private set => name = value; }

        public string LastName { get => latName; private set => latName = value; }

        public int CodeNumber { get => codeNumber; private set => codeNumber = value; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name} {LastName} Id: {Id}");
            sb.Append($"Code Number: {CodeNumber}");
            return sb.ToString();
        }
    }
}
