using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
