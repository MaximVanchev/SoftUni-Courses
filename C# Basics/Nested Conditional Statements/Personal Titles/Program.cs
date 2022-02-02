using System;

namespace Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string pow = Console.ReadLine();
            if (pow == "m" && age >= 16)
            {
                Console.WriteLine($"Mr.");
            }
            else if (pow == "m" && age < 16)
            {
                Console.WriteLine($"Master");
            }
            else if (pow == "f" && age >= 16)
            {
                Console.WriteLine($"Ms.");
            }
            else if (pow == "f" && age < 16)
            {
                Console.WriteLine($"Miss");
            }
        }
    }
}
