using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.Product
{
    [XmlType("Product")]
    public class GetProductsInRangeDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("buyer")]
        public string Buyer { get; set; }
    }
}
