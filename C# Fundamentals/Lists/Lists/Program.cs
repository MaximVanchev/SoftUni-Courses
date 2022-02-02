using System;
using System.Linq;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int peopleMax = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input[0] == 'A')
                {
                    numbers.Add(addList(input));
                }
                else
                {
                    int addPeople = int.Parse(input);
                    for (int i = 0; i < numbers.Count - 1; i++)
                    {
                        if (numbers[i] + addPeople <= peopleMax)
                        {
                            numbers[i] += addPeople;
                            break;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
        static int addList(string i)
        {
            string currentDigit = null;
            for (int j = 4; j <= i.Length - 1; j++)
            {
                currentDigit += i[j];
            }
            return Convert.ToInt32(currentDigit);
        }
    }
}
