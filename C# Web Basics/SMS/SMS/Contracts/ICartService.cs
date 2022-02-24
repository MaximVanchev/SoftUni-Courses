using SMS.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface ICartService
    {
        CartDetailsViewModel GetProducts(string userId);

        void AddProduct(string userId, string productId);

        void BuyProducts(string userId);
    }
}
