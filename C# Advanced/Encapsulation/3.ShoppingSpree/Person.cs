using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bagOfProducts = new List<Product>();
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
        }
        public IReadOnlyList<Product> BagOfProducts
        {
            get => bagOfProducts.AsReadOnly();
        }
        public string Name
        {
            get => name;
            set
            {
                if (value == "" || value == null || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public int Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public void AddProduct(Product product)
        {
            if (CanYouBuyProduct(product))
            {
                Console.WriteLine($"{name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{name} can't afford {product.Name}");
            }
        }
        private bool CanYouBuyProduct(Product product)
        {
            if (product.Cost > money)
            {
                return false;
            }
            money -= product.Cost;
            bagOfProducts.Add(product);
            return true;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{name} - ");
            if (bagOfProducts.Count > 0)
            {
                List<string> currentDigit = new List<string>();
                foreach (var product in bagOfProducts)
                {
                    currentDigit.Add(product.Name);
                }
                sb.Append(string.Join(", ", currentDigit));
            }           
            else
            {
                sb.Append("Nothing bought");
            }
            return sb.ToString();
        }
    }
}
