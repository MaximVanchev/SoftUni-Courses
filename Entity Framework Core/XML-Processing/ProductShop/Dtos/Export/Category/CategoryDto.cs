using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTO.Category
{
    [XmlType("Category")]
    public class CategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public string ProductsCount { get; set; }

        [XmlElement("averagePrice")]
        public string AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public string TotalRevenue { get; set; }
    }
}
