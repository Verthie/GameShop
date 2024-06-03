using Shop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shop.Utility;
using Microsoft.AspNetCore.Authorization;
using GameShop.Services;

namespace GameShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        public IActionResult Upsert(int? id)
        {
            var productVM = _productService.GetProductVM(id);
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM objProductVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var success = _productService.UpsertProduct(objProductVM, file);
                if (success)
                {
                    TempData["success"] = "Product created successfully";
                }
                else
                {
                    TempData["error"] = "Error creating product";
                }
                return RedirectToAction("Index");
            }
            else
            {
                objProductVM.CategoryList = _productService.GetProductVM(objProductVM.Product.Id).CategoryList;
                return View(objProductVM);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Json(new { data = products });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var success = _productService.DeleteProduct(id);
            if (success)
            {
                return Json(new { success = true, message = "Product erased" });
            }
            else
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
        }
    }
}
