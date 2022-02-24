using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            Products = new HashSet<Product>();
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
