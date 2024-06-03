using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;

namespace GameShop.Services
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWork.Product.GetAll(includeProperties: "Category");
        }

        public ShoppingCart GetShoppingCartDetails(int productId)
        {
            return new ShoppingCart
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
        }

        public void AddOrUpdateShoppingCart(ShoppingCart shoppingCart, string userId)
        {
            shoppingCart.ApplicationUserId = userId;
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == shoppingCart.ProductId);

            if (cartFromDb != null)
            {
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                UpdateSessionCartCount(userId);
            }
            _unitOfWork.Save();
        }

        public void UpdateSessionCartCount(string userId)
        {
            int cartCount = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count();
            _httpContextAccessor.HttpContext.Session.SetInt32(SD.SessionCart, cartCount);
        }

        public int GetCartItemCount(string userId)
        {
            return _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count();
        }
    }
}