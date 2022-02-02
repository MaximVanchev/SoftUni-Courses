using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Phone : ISmartphonable , IStationaryPhonable
    {
        private string number;
        public string BrowseInTheWorldWideWeb(string web)
        {
            if (Regex.IsMatch(web, @"\d+") || web.Contains(" "))
            {
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {web}!"; 
            }
        }

        public string CallOtherSmartPhones(string number)
        {
            if (!IsDigitsOnly(number))
            {
                return "Invalid number!";
            }
            else
            {
                return $"Calling... {number}"; 
            }
        }
        public string CallOtherStationaryPhones(string number)
        {
            if (!IsDigitsOnly(number))
            {
                return "Invalid number!";
            }
            else
            {
                return $"Dialing... {number}"; 
            }
        }
        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
