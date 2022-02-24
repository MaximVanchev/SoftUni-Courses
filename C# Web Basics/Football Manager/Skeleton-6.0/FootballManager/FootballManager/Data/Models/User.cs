using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserPlayers = new HashSet<UserPlayer>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(20 , MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(80 , MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}
