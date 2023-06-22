using GameShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _db;
        public CategoryController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
    }
}
