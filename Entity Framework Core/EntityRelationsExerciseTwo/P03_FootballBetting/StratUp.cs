using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    class StratUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext db = new FootballBettingContext();
            db.Database.EnsureCreated();
            Console.WriteLine("db created");
        }
    }
}
