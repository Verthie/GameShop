﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using Shop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Shop.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly DataContext _db;
		internal DbSet<T> dbSet;
		public Repository(DataContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
			_db.Products.Include(u => u.Category).Include(u => u.CategoryId);
        }

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public void Delete(T entity)
		{
			dbSet.Remove(entity);
		}

		public void DeleteRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}

		public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll(string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();
		}
	}
}
