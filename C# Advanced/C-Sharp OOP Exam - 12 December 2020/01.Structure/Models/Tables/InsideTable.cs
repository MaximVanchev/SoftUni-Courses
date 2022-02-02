using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal InitialPricePerPerson = 2.50M;
        public InsideTable(int tableNumber, int capacity)
            :base(tableNumber, capacity, InitialPricePerPerson)
        { }

        public override string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: InsideTable");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.Append($"Price per Person: {PricePerPerson}");
            return sb.ToString();
        }
    }
}
