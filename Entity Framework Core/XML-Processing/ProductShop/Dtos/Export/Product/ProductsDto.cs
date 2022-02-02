using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.Product
{
    [XmlType("products")]
    public class ProductsDto
    {
        [XmlElement("Product")]
        public ProductNamePriceDto[] Product { get; set; }
    }
}
