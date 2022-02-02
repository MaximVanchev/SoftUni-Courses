using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    class SimpleLayout : ILayout
    {
        public string LayoutString(string dateTime, string reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel} - {message}";
        }
    }
}
