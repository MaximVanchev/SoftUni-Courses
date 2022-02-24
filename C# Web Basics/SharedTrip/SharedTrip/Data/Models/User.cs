using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Data.Models
{
    public class User
    {
        public User()
        {
            UserTrips = new HashSet<UserTrip>();
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(20 , MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}

//Has an Id – a string, Primary Key
//Has a Username – a string with min length 5 and max length 20 (required)
//Has an Email - a string (required)
//Has a Password – a string with min length 6 and max length 20 - hashed in the database(required)
//Has UserTrips collection – a UserTrip type
