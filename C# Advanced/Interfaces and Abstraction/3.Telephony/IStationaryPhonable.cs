using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IStationaryPhonable
    {
        string CallOtherStationaryPhones(string number);
    }
}
