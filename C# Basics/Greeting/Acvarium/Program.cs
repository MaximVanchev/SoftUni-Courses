using System;

namespace Acvarium
{
    class Program
    {
        static void Main(string[] args)
        {
            int dl = int.Parse(Console.ReadLine());
            int shr  = int.Parse(Console.ReadLine());
            int vis = int.Parse(Console.ReadLine());
            double pro = double.Parse(Console.ReadLine());
            double obem = (dl * shr * vis) * 0.001;
            double round = Math.Round(pro, 3);
            double nevod = (obem* round) /100;
            double litri = obem - nevod;
            double krlitri = Math.Round(litri, 3);
            Console.WriteLine(krlitri);
        }
    }
}
