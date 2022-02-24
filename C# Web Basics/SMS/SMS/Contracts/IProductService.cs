using SMS.Models;
using SMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface IProductService
    {
        (bool IsValid, ErrorViewModel error) ValidateModel(ProductCreateViewModel model);

        void CreateProduct(ProductCreateViewModel model);
    }
}
