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
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _unitOfWork.Company.GetAll().ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _unitOfWork.Company.Get(u => u.Id == id);
        }

        public void UpsertCompany(Company company)
        {
            if (company.Id != 0)
            {
                _unitOfWork.Company.Update(company);
            }
            else
            {
                _unitOfWork.Company.Add(company);
            }
            _unitOfWork.Save();
        }

        public void DeleteCompany(int id)
        {
            var company = _unitOfWork.Company.Get(u => u.Id == id);
            if (company != null)
            {
                _unitOfWork.Company.Delete(company);
                _unitOfWork.Save();
            }
        }
    }
}