using Microsoft.EntityFrameworkCore;
using ProductShop.Dtos.Export.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.User
{
    [XmlType("User")]
    public class UserSoldProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("soldProducts")]
        public SoldProductsDto SoldProducts { get; set; }
    }

    [XmlType("soldProducts")]
    public class SoldProductsDto
    {
        [XmlElement("Product")]
        public ProductNamePriceDto[] Product { get; set; }
    }
}
