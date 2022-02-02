using System;

namespace Proekti
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int pr = int.Parse(Console.ReadLine());
            int cas = pr * 3;
            Console.WriteLine($"The architect {name} will need {cas} hours to complete {pr} project/s.");
        }
    }
}
