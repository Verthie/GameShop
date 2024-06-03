using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Shop.Models;
using System.Diagnostics;
using System.Security.Claims;
using Shop.Utility;
using Microsoft.AspNetCore.Http;
using GameShop.Services;

namespace GameShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                _homeService.UpdateSessionCartCount(claim.Value);
            }

            var productList = _homeService.GetAllProducts();
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            var cart = _homeService.GetShoppingCartDetails(id);
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            _homeService.AddOrUpdateShoppingCart(shoppingCart, userId);
            TempData["success"] = "Cart updated successfully";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}