using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Common;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseXmlImportDto
    {
        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; }

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [XmlElement("Key")]
        [MaxLength(GlobalConstants.PURCHASE_PRODUCTKEY_LENGTH)]
        [RegularExpression(@"^[A-Z\d][A-Z\d][A-Z\d][A-Z\d]-[A-Z\d][A-Z\d][A-Z\d][A-Z\d]-[A-Z\d][A-Z\d][A-Z\d][A-Z\d]$")]
        public string ProductKey { get; set; }

        [Required]
        [XmlElement("Card")]
        [MaxLength(GlobalConstants.CARD_NUMBER_LENGTH)]
        [RegularExpression(@"\d\d\d\d \d\d\d\d \d\d\d\d \d\d\d\d")]
        public virtual string Card { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

    }
}
