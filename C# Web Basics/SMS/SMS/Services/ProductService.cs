using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using SMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository _repo)
        {
            repo = _repo;
        }

        public void CreateProduct(ProductCreateViewModel model)
        {
            Product product = new Product()
            {
               Name = model.Name,
               Price = model.Price
            };

            repo.Add(product);
            repo.SaveChanges();
        }

        public (bool IsValid, ErrorViewModel error) ValidateModel(ProductCreateViewModel model)
        {
            bool isValid = true;

            ErrorViewModel error = null;

            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(model.Name) || model.Price == null)
            {
                isValid = false;
                sb.AppendLine(" Name and Price are reqired !");
            }

            if (model.Name.Length < 4 || model.Name.Length > 20)
            {

                isValid = false;
                sb.AppendLine(" Name must be 4 to 20 characters !");
            }

            if (model.Price < 0.05M || model.Price > 1000)
            {
                isValid = false;
                sb.AppendLine(" Price must be in range 0.05 to 1000 !");
            }

            error = new ErrorViewModel(sb.ToString());

            return (isValid, error);
        }
    }
}
