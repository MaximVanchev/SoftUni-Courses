using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.User
{
    [XmlType("Users")]
    public class UserCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("users")]
        public UsersDto Users { get; set; }
    }
}
