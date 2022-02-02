using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Products> products = new Dictionary<string, Products>();
            string input = null;
            while ((input = Console.ReadLine()) != "buy")
            {
                List<string> prodict = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (products.ContainsKey(prodict[0]))
                {
                    products[prodict[0]].productQuantity += Convert.ToInt32(prodict[2]);
                    if (products[prodict[0]].productPrice != Convert.ToDouble(prodict[1]))
                    {
                        products[prodict[0]].productPrice = Convert.ToDouble(prodict[1]);
                    }
                }
                else
                {
                    products.Add(prodict[0],new Products(Convert.ToDouble(prodict[1]), Convert.ToInt32(prodict[2])));
                }
            }
            foreach (var item in products)
            {
                double totalPrice = item.Value.productPrice * item.Value.productQuantity;
                Console.WriteLine($"{item.Key} -> {totalPrice:F2}");
            }
        }
    }
    public class Products
    {
        public double productPrice { get; set; }
        public int productQuantity { get; set; }
        public Products(double price,int quantity)
        {
            productPrice = price;
            productQuantity = quantity;
        }
    }
}

