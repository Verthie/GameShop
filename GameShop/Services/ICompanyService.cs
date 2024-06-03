using System;
using Shop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        void UpsertCompany(Company company);
        void DeleteCompany(int id);
    }
}