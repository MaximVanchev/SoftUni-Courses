using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Models
{
    public class Destination
    {
        public Destination()
        {
            Tickets = new List<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50 , MinimumLength = 2)]
        public string DestinationName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Origin { get; set; }

        [Required]
        [StringLength(30)]
        public string Date { get; set; }

        [Required]
        [StringLength(30)]
        public string Time { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
