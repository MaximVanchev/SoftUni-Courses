using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using SMS.Models.Products;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IRepository repo;

        public HomeController(Request request , IUserService _userService , IRepository _repo) 
            : base(request)
        {
            userService = _userService;
            repo = _repo;
        }

        public Response Index()
        {
            LeyoutViewModel leyout = new LeyoutViewModel(User.IsAuthenticated);

            if (leyout.IsAuthenticated)
            {
                User user = userService.GetUserById(User.Id);

                List<ProductListViewModel> products = repo.All<Product>()
                    .Select(p => new ProductListViewModel
                    {
                        ProductId = p.Id,
                        ProductName = p.Name,
                        ProductPrice = p.Price,
                    }).ToList();

                IndexLoggedIn model = new IndexLoggedIn(true)
                {
                    Username = user.Username,
                    Products = products
                };

                return View(model , "/Home/IndexLoggedIn");
            }

            return View(leyout);
        }
    }
}