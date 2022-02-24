using SMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class IndexLoggedIn
    {
        public IndexLoggedIn(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
        }

        public bool IsAuthenticated { get; set; }

        public bool HaveProducts 
        { 
            get
            {
                if (Products.Count() == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string Username { get; set; }

        public IEnumerable<ProductListViewModel> Products { get; set; }
    }
}
