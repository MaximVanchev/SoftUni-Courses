using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductShop.DTO.Product
{
    public class ProductsCountViewDto
    {
        public int Count => Products.Count();

        public ICollection<ProductNamePriceViewDto> Products { get; set; }
    }
}
