using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    class OutsideTable : Table
    {
        private const decimal InitialPricePerPerson = 3.50M;
        public OutsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, InitialPricePerPerson)
        { }

        public override string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: OutsideTable");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.Append($"Price per Person: {PricePerPerson}");
            return sb.ToString();
        }
    }
}
