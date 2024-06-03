using Shop.Models.ViewModels;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Product> GetAllProducts()
        {
            return _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        }

        public ProductVM GetProductVM(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };

            if (id != null && id != 0)
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
            }

            return productVM;
        }

        public bool UpsertProduct(ProductVM objProductVM, IFormFile? file)
        {
            if (objProductVM == null)
            {
                return false;
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\product");

                if (!string.IsNullOrEmpty(objProductVM.Product.ImageURL))
                {
                    var imagePath = Path.Combine(wwwRootPath, objProductVM.Product.ImageURL.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                objProductVM.Product.ImageURL = @"\images\product\" + fileName;
            }

            if (objProductVM.Product.Id != 0)
            {
                _unitOfWork.Product.Update(objProductVM.Product);
            }
            else
            {
                _unitOfWork.Product.Add(objProductVM.Product);
            }

            _unitOfWork.Save();
            return true;
        }

        public bool DeleteProduct(int? id)
        {
            var productDestinedForDeletion = _unitOfWork.Product.Get(u => u.Id == id);
            if (productDestinedForDeletion == null)
            {
                return false;
            }

            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, productDestinedForDeletion.ImageURL.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _unitOfWork.Product.Delete(productDestinedForDeletion);
            _unitOfWork.Save();
            return true;
        }
    }
}
