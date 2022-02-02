using Microsoft.EntityFrameworkCore;
using ProductShop.DTO.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTO.User
{
    public class UserSoldProductsViewDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<SoldProductViewDto> SoldProducts { get; set; }
    }
}
