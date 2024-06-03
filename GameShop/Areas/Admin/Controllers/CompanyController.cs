using Shop.Models;
using GameShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Shop.Utility;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            List<Company> objCompanyList = _companyService.GetAllCompanies().ToList();
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // create
                return View(new Company());
            }
            else
            {
                // update
                Company companyObj = _companyService.GetCompanyById(id.Value);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company objCompany)
        {
            if (ModelState.IsValid)
            {
                _companyService.UpsertCompany(objCompany);
                TempData["success"] = "Company saved successfully";
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
            List<Company> objCompanyList = _companyService.GetAllCompanies().ToList();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _companyService.DeleteCompany(id.Value);
            return Json(new { success = true, message = "Company deleted successfully" });
        }
        #endregion
    }
}
