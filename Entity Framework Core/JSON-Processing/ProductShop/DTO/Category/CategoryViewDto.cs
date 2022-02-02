using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTO.Category
{
    public class CategoryViewDto
    {
        public string Name { get; set; }

        public int ProductsCount { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
