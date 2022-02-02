using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ISoldier
    {
        string Id { get; }
        string Name { get; }
        string LastName { get; }

    }
}
