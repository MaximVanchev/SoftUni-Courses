using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totallIncome;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Water")
            {
                drinks.Add(new Water(name, portion, brand));
            }
            else if (type == "Tea")
            {
                drinks.Add(new Tea(name, portion, brand));
            }       
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                bakedFoods.Add(new Bread(name, price));
            }
            else if (type == "Cake")
            {
                bakedFoods.Add(new Cake(name, price));
            }
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                tables.Add(new InsideTable(tableNumber, capacity));
            }
            else if (type == "OutsideTable")
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }
            return string.Format(OutputMessages.TableAdded,tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> notReservedTables = tables.Where(x => x.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var table in notReservedTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totallIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            StringBuilder sb = new StringBuilder();
            ITable table = tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            decimal tableBill = table.GetBill() + table.Price;
            totallIncome += tableBill;
            table.Clear();
            sb.AppendLine($"Table: {tableNumber}");
            sb.Append($"Bill: {tableBill:F2}");
            return sb.ToString();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (tables.Any(x => x.TableNumber == tableNumber))
            {
                if (drinks.Any(x => x.Name == drinkName && x.Brand == drinkBrand))
                {
                    tables.FirstOrDefault(x => x.TableNumber == tableNumber).OrderDrink(drinks.FirstOrDefault(x => x.Name == drinkName));
                    return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, $"{drinkName} {drinkBrand}");
                }
                else
                {
                    return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
                }
            }
            else
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (tables.Any(x => x.TableNumber == tableNumber))
            {
                if (bakedFoods.Any(x => x.Name == foodName))
                {
                    tables.FirstOrDefault(x => x.TableNumber == tableNumber).OrderFood(bakedFoods.FirstOrDefault(x => x.Name == foodName));
                    return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
                }
                else
                {
                    return string.Format(OutputMessages.NonExistentFood, foodName);
                }
            }
            else
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            //niko e tarikat
            if (tables.Any(x => x.IsReserved == false && x.Capacity >= numberOfPeople))
            {
                ITable table = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
                table.Reserve(numberOfPeople);
                return string.Format(OutputMessages.TableReserved, table.TableNumber, table.NumberOfPeople);
            }
            else
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
        }
    }
}
