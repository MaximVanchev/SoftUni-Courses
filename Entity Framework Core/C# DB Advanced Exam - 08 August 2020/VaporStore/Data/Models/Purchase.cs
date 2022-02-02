using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VaporStore.Common;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PURCHASE_PRODUCTKEY_LENGTH)]
        public string ProductKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required]
        [ForeignKey(nameof(CardId))]
        public virtual Card Card { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }
    }
}
