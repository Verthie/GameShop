using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;

namespace GameShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.Category.GetAll().ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWork.Category.Get(c => c.Id == id);
        }

        public void CreateCategory(Category category)
        {
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
        }

        public void DeleteCategory(int id)
        {
            var category = _unitOfWork.Category.Get(c => c.Id == id);
            if (category != null)
            {
                _unitOfWork.Category.Delete(category);
                _unitOfWork.Save();
            }
        }
    }
}