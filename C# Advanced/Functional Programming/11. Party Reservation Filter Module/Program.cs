using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> filters = new List<string>();
            List<string> command = null;
            while ((command = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries).ToList())[0] != "Print")
            {
                if (command[0] == "Add filter")
                {
                    filters.Add($"{command[1]};{command[2]}");
                }
                else
                {
                    filters.Remove($"{command[1]};{command[2]}");
                }
            }
            Func<string, char, bool> isItStartsWith = (a, b) =>
            {
                if (a[0] == b)
                {
                    return true;
                }
                return false;
            };
            Func<string, char, bool> isItEndsWith = (a, b) =>
            {
                if (a[a.Length-1] == b)
                {
                    return true;
                }
                return false;
            };
            Func<string, int, bool> isItSameLength = (a, b) =>
            {
                if (a.Length == b)
                {
                    return true;
                }
                return false;
            };
            Func<string, string, bool> isItContains = (a, b) =>
            {
                if (a.Contains(b))
                {
                    return true;
                }
                return false;
            };
            foreach (var item in filters)
            {
                List<string> filter = item.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (filter[0] == "Starts with")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (isItStartsWith(guests[i], char.Parse(filter[1])))
                        {
                            guests.Remove(guests[i]);
                        }
                    }
                }
                else if (filter[0] == "Ends with")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (isItEndsWith(guests[i], char.Parse(filter[1])))
                        {
                            guests.Remove(guests[i]);
                        }
                    }
                }
                else if (filter[0] == "Length")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (isItSameLength(guests[i], int.Parse(filter[1])))
                        {
                            guests.Remove(guests[i]);
                        }
                    }
                }
                else if (filter[0] == "Contains")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (isItContains(guests[i], filter[1]))
                        {
                            guests.Remove(guests[i]);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ",guests));
        }
    }
}
