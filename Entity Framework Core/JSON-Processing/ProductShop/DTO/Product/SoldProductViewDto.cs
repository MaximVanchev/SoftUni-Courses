using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop.DTO.Product
{
    public class SoldProductViewDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string BuyerFirstName { get; set; }
        
        [Required]
        public string BuyerLastName { get; set; }
    }
}
