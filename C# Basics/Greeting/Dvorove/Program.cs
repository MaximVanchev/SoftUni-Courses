using System;

namespace Dvorove
{
    class Program
    {
        static void Main(string[] args)
        {
            double kvm = Double.Parse(Console.ReadLine());
            double kvm2 = Math.Round(kvm,2);
            double price = kvm2 * 7.61;
            double otstupka = (price * 18) / 100;
            double round2 = Math.Round(otstupka, 2);
            double krcena = price - round2;
            double round = Math.Round(krcena, 2);
            Console.WriteLine($"The final price is: {round} lv.");
            Console.WriteLine($"The discount is: {round2} lv.");

        }
    }
}
