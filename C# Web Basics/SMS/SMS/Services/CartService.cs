using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models.Carts;
using SMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;
        private readonly IUserService userService;

        public CartService(IRepository _repo , IUserService _userService)
        {
            repo = _repo;
            userService = _userService;
        }

        public void AddProduct(string userId, string productId)
        {
            var user = userService.GetUserById(userId);
            var product = repo.All<Product>().FirstOrDefault(p => p.Id == productId);

            if (user == null || product == null)
            {
                throw new ArgumentException("User or Product not found");
            }

            product.Cart = user.Cart;

            repo.SaveChanges();
        }

        public void BuyProducts(string userId)
        {
            var user = userService.GetUserById(userId);

            var cart = repo.All<Cart>().FirstOrDefault(c => c.Id == user.CartId);

            cart.Products = new List<Product>();

            repo.SaveChanges();
        }

        public CartDetailsViewModel GetProducts(string userId)
        {
            var products = repo.All<Product>();

            CartDetailsViewModel cartDetails = new CartDetailsViewModel()
            {
                Products = products.Select(p => new ProductListViewModel()
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductPrice = p.Price
                }),
                IsAuthenticated = true
            };

            return cartDetails;
        }
    }
}
