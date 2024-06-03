using Shop.Models.ViewModels;
using Shop.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GameShop.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        ProductVM GetProductVM(int? id);
        bool UpsertProduct(ProductVM objProductVM, IFormFile? file);
        bool DeleteProduct(int? id);
    }
}
