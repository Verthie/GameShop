using Shop.DataAccess.Data;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private DataContext _db;
		public ICategoryRepository Category { get; private set; }
		public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public UnitOfWork(DataContext db)
		{
			_db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Category = new CategoryRepository(_db);
			Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
        }

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
