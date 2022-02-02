using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public interface ILayout
    {
        string LayoutString(string dateTime, string reportLevel, string message);
    }
}
