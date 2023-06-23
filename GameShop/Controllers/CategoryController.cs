using Microsoft.AspNetCore.Mvc;
using Shop.Models;

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
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Category objCategory)		
		{
		//	if (objCategory.Name.ToLower() == "validation test")
		//	{
		//		ModelState.AddModelError("Name", "The name cannot be validation test");
		//	}
			if (ModelState.IsValid)
			{
				_db.Categories.Add(objCategory);
				_db.SaveChanges();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");
			}
			return View();
			
		}
		public IActionResult Edit(int? id)
		{
			if(id==null || id == 0)
			{
				return NotFound();
			}
			Category categoryfromDb = _db.Categories.Find(id);
			if(categoryfromDb == null)
			{
				return NotFound();
			}
			return View(categoryfromDb);
		}
		[HttpPost]
		public IActionResult Edit(Category objCategory)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Update(objCategory);
				_db.SaveChanges();
				TempData["success"] = "Category edited successfully";
				return RedirectToAction("Index");
			}
			return View();

		}

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromDb = _db.Categories.Find(id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
			Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
				return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
