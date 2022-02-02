using System;
using System.Linq;
using System.Collections.Generic;
namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (numbers.ContainsKey(num))
                {
                    numbers[num]++;
                }
                else
                {
                    numbers.Add(num, 1);
                }    
            }
            Console.WriteLine(Kur(numbers));
        }
        public static double Kur(Dictionary<double,int> a)
        {
            int b = 0;
            double c = 0;
            foreach (var item in a)
            {
                if (item.Value > b)
                {
                    b = item.Value;
                    c = item.Key;
                }
            }
            return c;
        }
    }
}
