using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using SMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(Request request , IProductService _productService) 
            : base(request)
        {
            productService = _productService;
        }

        [Authorize]
        public Response Create()
        {
            LeyoutViewModel model = new LeyoutViewModel(User.IsAuthenticated);

            return View(model);
        }

        [HttpPost]
        public Response Create(ProductCreateViewModel model)
        {
            (bool isValid , ErrorViewModel erorr) = productService.ValidateModel(model);

            if (!isValid)
            {
                return View(erorr, "/Error");
            }

            try
            {
                productService.CreateProduct(model);
            }
            catch (Exception)
            {
                return View(new ErrorViewModel("Unexpected Error !"), "/Error");
            }

            return Redirect("/");
        }
    }
}
