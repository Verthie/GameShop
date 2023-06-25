using Shop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using Shop.Utility;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace GameShop.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
			return View(objCompanyList);
        }
        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Company objCompany)
        {
            if (ModelState.IsValid)
            {
                if (objCompany.Id != 0)
                {
                    _unitOfWork.Company.Update(objCompany);
                }
                else
                {
                    _unitOfWork.Company.Add(objCompany);
                }
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(objCompany);
            }

        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyDestinedForDeletion = _unitOfWork.Company.Get(u =>u.Id == id);
            if (companyDestinedForDeletion == null) {
                return Json(new { success = false, message = "Error while deleting" });
            }
            
            _unitOfWork.Company.Delete(companyDestinedForDeletion);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Company erased" });
        }
        #endregion
    }
}
