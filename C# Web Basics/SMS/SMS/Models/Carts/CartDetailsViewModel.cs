using SMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.Carts
{
    public class CartDetailsViewModel
    {
        public IEnumerable<ProductListViewModel> Products { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
