using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Common;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserImputDto
    {
        public UserImputDto()
        {
            Cards = new List<CardImputDto>();
        }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.USER_USERNAME_MAX_LENGTH)]
        [MinLength(GlobalConstants.USER_USERNAME_MIN_LENGTH)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(GlobalConstants.USER_AGE_MIN_VALUE, GlobalConstants.USER_AGE_MAX_VALUE)]
        public int Age { get; set; }

        public virtual ICollection<CardImputDto> Cards { get; set; }
    }
}
