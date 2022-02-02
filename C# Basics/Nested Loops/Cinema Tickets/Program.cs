using System;

namespace Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int seats = int.Parse(Console.ReadLine());
            int ticketCount = 0;
            int studentCount = 0;
            int standardCount = 0;
            int kidsCount = 0;
            while (true)
            {
                int seatsCount = 0;
                while (seats > seatsCount)
                {
                    string ticket = Console.ReadLine();
                    if (ticket == "student")
                    {
                        studentCount++;
                        seatsCount++;
                        ticketCount++;
                    }
                    else if (ticket == "standard")
                    {
                        standardCount++;
                        seatsCount++;
                        ticketCount++;
                    }
                    else if (ticket == "kid")
                    {
                        kidsCount++;
                        seatsCount++;
                        ticketCount++;
                    }
                    else if (ticket == "End")
                    {
                        break;
                    }
                }
                Console.WriteLine($"{movie} - {((double)seatsCount / seats) * 100:F2}% full.");
                movie = Console.ReadLine();
                if (movie == "Finish")
                {
                    break;
                }
                seats = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Total tickets: {ticketCount}");
            Console.WriteLine($"{((double)studentCount/ticketCount)*100:F2}% student tickets.");
            Console.WriteLine($"{((double)standardCount / ticketCount)*100:F2}% standard tickets.");
            Console.WriteLine($"{((double)kidsCount / ticketCount)*100:F2}% kids tickets.");
        }
    }
}
