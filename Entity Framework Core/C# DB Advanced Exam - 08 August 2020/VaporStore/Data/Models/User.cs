using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Common;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
            Cards = new HashSet<Card>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.USER_USERNAME_MAX_LENGTH)]
        public string Username { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(GlobalConstants.USER_AGE_MIN_VALUE , GlobalConstants.USER_AGE_MAX_VALUE)]
        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
