using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Tickets = new List<Ticket>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(20 , MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(60 , MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
