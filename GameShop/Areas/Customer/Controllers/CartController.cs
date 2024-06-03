using GameShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using Shop.Models.ViewModels;
using Shop.Utility;
using System.Security.Claims;

namespace GameShop.Areas.Customer.Controllers
{
    [Area("customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public CartController(ICartService cartService, IUnitOfWork unitOfWork)
        {
            _cartService = cartService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ShoppingCartVM = _cartService.GetShoppingCart(userId);
            return View(ShoppingCartVM);
        }

        public IActionResult Summary()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ShoppingCartVM = _cartService.GetOrderSummary(userId);
            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            ShoppingCartVM = _cartService.GetShoppingCart(userId);

            if (ShoppingCartVM == null)
            {
                return BadRequest("Shopping cart is empty.");
            }

            if (ShoppingCartVM.ShoppingCartList == null || !ShoppingCartVM.ShoppingCartList.Any())
            {
                return BadRequest("Shopping cart list is empty.");
            }

            _cartService.CreateOrder(ShoppingCartVM, userId, applicationUser);

            return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.OrderHeader.Id });
        }



        public IActionResult OrderConfirmation(int id)
        {
            _cartService.ConfirmOrder(id);
            return View(id);
        }

        public IActionResult Plus(int cartId)
        {
            _cartService.IncreaseCartItemCount(cartId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            _cartService.DecreaseCartItemCount(cartId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            _cartService.RemoveCartItem(cartId);
            return RedirectToAction(nameof(Index));
        }
    }
}
