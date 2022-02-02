using System;
using System.Collections.Generic;

namespace Objects_and_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            int generateNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < generateNum; i++)
            {
                Messages.randomMessagesPrint();
            }
        }
    }
    public class Messages
    {
       public static List<string> phrases = new List<string> {"Excellent product.","Such a great product.","I always use that product.","Best product of itscategory.","Exceptional product.","I can’t live without this product."};
       public static List<string> events = new List<string> {"Now I feel good.","I have succeeded with this product.","Makes miracles.I am happy of theresults!","I cannot believe but now I feel awesome.","Try it yourself, I am very satisfied.","I feel great!"};
       public static List<string> authors = new List<string> {"Diana","Petya","Stella","Elena","Katya","Iva","Annie","Eva"};
       public static List<string> cities = new List<string> {"Burgas","Sofia","Plovdiv","Varna","Ruse"};
        public static void randomMessagesPrint()
        {
            string result = null;
            Random rnd = new Random();
            result += phrases[rnd.Next(0,phrases.Count)];
            result += $" {events[rnd.Next(0,events.Count)]}";
            result += $" {authors[rnd.Next(0,authors.Count)]}";
            result += $" - {cities[rnd.Next(0,cities.Count)]}";
            Console.WriteLine(result);
        }
    }
}
