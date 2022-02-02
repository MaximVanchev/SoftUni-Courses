using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission
    {
        private string name;
        private string state;
        public Mission(string name , string state)
        {
            Name = name;
            State = state;
        }
        public string Name { get => name; private set => name = value; }
        public string State 
        {
            get => state;
            private set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    state = value;
                }
                else
                {
                    throw new ArgumentException("invalid");
                }
            }
        }
        public override string ToString()
        {
            return $"Code Name: {Name} State: {State}";
        }
    }
}
