using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            List<string> webs = Console.ReadLine().Split().ToList();
            ISmartphonable smartphone = new Phone();
            IStationaryPhonable stationaryPhone = new Phone();
            try
            {
                foreach (var number in numbers)
                {
                    if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.CallOtherSmartPhones(number)); ;
                    }
                    else if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.CallOtherStationaryPhones(number)); ;
                    }
                }
                foreach (var web in webs)
                {
                    Console.WriteLine(smartphone.BrowseInTheWorldWideWeb(web)); ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
