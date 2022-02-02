using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get => tableNumber; private set => tableNumber = value; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get => pricePerPerson; private set => pricePerPerson = value; }

        public bool IsReserved { get => isReserved; private set => isReserved = value; }

        public decimal Price {  get => numberOfPeople * pricePerPerson; }

        public void Clear()
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
            numberOfPeople = 0;
            IsReserved = false;
        }

        public decimal GetBill()
        {
            decimal bill = 0;
            foreach (var food in foodOrders)
            {
                bill += food.Price;
            }
            foreach (var drink in drinkOrders)
            {
                bill += drink.Price;
            }
            return bill;
        }

        public abstract string GetFreeTableInfo();

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }
    }
}
