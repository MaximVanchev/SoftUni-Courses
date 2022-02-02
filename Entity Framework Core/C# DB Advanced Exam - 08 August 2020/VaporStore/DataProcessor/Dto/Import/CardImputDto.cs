using System.ComponentModel.DataAnnotations;
using VaporStore.Common;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardImputDto
    {
        [Required]
        [MaxLength(GlobalConstants.CARD_NUMBER_LENGTH)]
        [RegularExpression(@"\d\d\d\d \d\d\d\d \d\d\d\d \d\d\d\d")]
        public string Number { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CARD_CVC_LENGTH)]
        [RegularExpression(@"\d\d\d")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}