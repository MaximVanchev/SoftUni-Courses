using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using SMS.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;

        public CartsController(Request request , ICartService _cartService) 
            : base(request)
        {
            cartService = _cartService;
        }

        [Authorize]
        public Response Details()
        {
            CartDetailsViewModel model = cartService.GetProducts(User.Id);

            return View(model);
        }
        
        [Authorize]
        public Response AddProduct(string productId)
        {
            try
            {
                cartService.AddProduct(User.Id, productId);
            }
            catch (ArgumentException aex)
            {
                return View(new ErrorViewModel(aex.Message), "/Error");
            }
            catch (Exception)
            {

                return View(new ErrorViewModel("Unexpected Error !"), "/Error");
            }

            return Redirect("/Carts/Details");
        }

        [Authorize]
        public Response Buy()
        {
            cartService.BuyProducts(User.Id);

            return Redirect("/");
        }
    }
}
