using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Theatre.Common;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CAST_FULLNAME_MAX_LENGTH)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CAST_PHONENUMBER_LENGTH)]
        public string PhoneNumber { get; set; }

        [Required]
        public int PlayId { get; set; }

        [ForeignKey(nameof(PlayId))]
        public virtual Play Play { get; set; }
    }
}
