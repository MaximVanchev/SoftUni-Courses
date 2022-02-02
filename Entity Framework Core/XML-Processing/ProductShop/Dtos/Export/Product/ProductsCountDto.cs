using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.Product
{
    [XmlType("SoldProducts")]
    public class ProductsCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("products")]
        public ProductsDto Products { get; set; }
    }
}
