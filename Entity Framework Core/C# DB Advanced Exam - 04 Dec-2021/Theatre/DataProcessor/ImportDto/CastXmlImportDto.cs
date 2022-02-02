using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class CastXmlImportDto
    {
        [Required]
        [XmlElement("FullName")]
        [MaxLength(GlobalConstants.CAST_FULLNAME_MAX_LENGTH)]
        [MinLength(GlobalConstants.CAST_FULLNAME_MIN_LENGTH)]
        public string FullName { get; set; }

        [Required]
        [XmlElement("IsMainCharacter")]
        public bool IsMainCharacter { get; set; }

        [Required]
        [XmlElement("PhoneNumber")]
        [MaxLength(GlobalConstants.CAST_PHONENUMBER_LENGTH)]
        [MinLength(GlobalConstants.CAST_PHONENUMBER_LENGTH)]
        [RegularExpression(@"^\+44-\d\d-\d\d\d-\d\d\d\d$")]
        public string PhoneNumber { get; set; }

        [Required]
        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}
