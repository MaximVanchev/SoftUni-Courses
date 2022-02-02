using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int DateModifierMathod(string dateOne,string dateTwo)
        {
            DateTime dateTimeOne = DateTime.ParseExact(dateOne,"yyyy MM dd" , CultureInfo.InvariantCulture);
            DateTime dateTimeTwo = DateTime.ParseExact(dateTwo,"yyyy MM dd" , CultureInfo.InvariantCulture);
            if (dateTimeOne.Ticks < dateTimeTwo.Ticks)
            {
                return int.Parse((dateTimeTwo - dateTimeOne).TotalDays.ToString()); 
            }
            return int.Parse((dateTimeOne - dateTimeTwo).TotalDays.ToString());
        }
    }
}
