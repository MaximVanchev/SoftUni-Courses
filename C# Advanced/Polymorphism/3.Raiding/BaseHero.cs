using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        private string name;
        private int power;
        public BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get => name; private set => name = value; }
        public int Power { get => power; protected set => power = value; }
        public virtual string CastAbility()
        {
            return "";
        }
    }
}
