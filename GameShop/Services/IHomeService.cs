using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;

namespace GameShop.Services
{
    public interface IHomeService
    {
        IEnumerable<Product> GetAllProducts();
        ShoppingCart GetShoppingCartDetails(int productId);
        void AddOrUpdateShoppingCart(ShoppingCart shoppingCart, string userId);
        void UpdateSessionCartCount(string userId);
        int GetCartItemCount(string userId);
    }
}