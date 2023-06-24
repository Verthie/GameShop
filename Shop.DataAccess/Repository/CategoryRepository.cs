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
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly DataContext _db;
		public CategoryRepository(DataContext db) : base(db)
		{
			_db = db;
		}
		public void Update(Category objCategory)
		{
			_db.Categories.Update(objCategory);
		}
	}
}
