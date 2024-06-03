using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;
using Shop.Models.ViewModels;

namespace GameShop.Services
{
    public interface ICartService
    {
        ShoppingCartVM GetShoppingCart(string userId);
        ShoppingCartVM GetOrderSummary(string userId);
        void CreateOrder(ShoppingCartVM shoppingCartVM, string userId, ApplicationUser applicationUser);
        void ConfirmOrder(int orderId);
        void IncreaseCartItemCount(int cartId);
        void DecreaseCartItemCount(int cartId);
        void RemoveCartItem(int cartId);
        double GetProductPrice(ShoppingCart shoppingCart);
    }
}