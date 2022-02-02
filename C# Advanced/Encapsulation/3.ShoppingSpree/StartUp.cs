using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> personsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
                Dictionary<string, Person> persons = new Dictionary<string, Person>();
                Dictionary<string, Product> products = new Dictionary<string, Product>();
                foreach (var item in personsInput)
                {
                    List<string> person = item.Split("=", StringSplitOptions.RemoveEmptyEntries).ToList();
                    persons.Add(person[0], new Person(person[0], int.Parse(person[1])));
                }
                foreach (var item in productsInput)
                {
                    List<string> product = item.Split("=", StringSplitOptions.RemoveEmptyEntries).ToList();
                    products.Add(product[0], new Product(product[0], int.Parse(product[1])));
                }
                List<string> command = null;
                while ((command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList())[0] != "END")
                {
                    persons[command[0]].AddProduct(products[command[1]]);
                }
                foreach (var person in persons.Values)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
