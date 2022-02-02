using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.User
{
    [XmlType("users")]
    public class UsersDto
    {
        [XmlElement("User")]
        public UserWithProductsDto[] User { get; set; }
    }
}
