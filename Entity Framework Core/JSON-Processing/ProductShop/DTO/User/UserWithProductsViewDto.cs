using ProductShop.DTO.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductShop.DTO.User
{
    public class UserWithProductsViewDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public ProductsCountViewDto SoldProducts { get; set; }
    }
}
