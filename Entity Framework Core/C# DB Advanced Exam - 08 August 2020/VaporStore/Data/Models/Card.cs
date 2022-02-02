using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VaporStore.Common;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
            Purchases = new HashSet<Purchase>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CARD_NUMBER_LENGTH)]
        public string Number { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CARD_CVC_LENGTH)]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
