using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Data;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly DataContext _db;
		public ProductRepository(DataContext db) : base(db)
		{
			_db = db;
		}
		public void Update(Product objProduct)
		{
			_db.Products.Update(objProduct);
		}
	}
}
