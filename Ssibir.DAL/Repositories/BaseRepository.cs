using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Repositories.IRepositories;
using Ssibir.DAL.Models;
using Ssibir.DAL.Models.Context;
using System.Linq.Expressions;
using System.Data.Objects;
using System.Data.Entity;

namespace Ssibir.DAL.Repositories
{
	public abstract class BaseRepository<T> : IBaseRepository<T>
		where T : BaseEntity
	{
		protected DbCatalog context { get; set; }

		protected BaseRepository()
		{
			this.context = new DbCatalog();
		}

		protected BaseRepository(DbCatalog _context)
		{
			this.context = _context;
		}

		public IQueryable<T> GetAll()
		{
			return GetTable().AsQueryable();
		}

		public virtual T GetByID(Guid id)
		{
			if (id == Guid.Empty) return null;
			var item = GetTable().SingleOrDefault(x => x.Id == id);
			if (item == null) return null;
			return item;
		}

		public virtual T GetByKey(string key)
		{
			if (String.IsNullOrWhiteSpace(key) == true) return null;
			var item = GetTable().SingleOrDefault(x => x.key == key);
			if (item == null) return null;
			return item;
		}

		public virtual T Save(T entity)
		{
			if (entity.IsNew())
			{
				entity.Id = Guid.NewGuid();
				return GetTable().Add(entity);
			}
			else
			{
				T dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
				dbEntity.Id = entity.Id;
				if (dbEntity == null) return null;
                return dbEntity;
			}
		}

		public virtual bool Delete(Guid id)
		{
			var dbEntity = GetTable().SingleOrDefault(x => x.Id == id);
			if (dbEntity == null)
				return false;
			GetTable().Remove(dbEntity);// DeleteObject(dbEntity);
            return true;
		}


		public IQueryable<T> GetFiltered(IList<Expression<Func<T, bool>>> filters)
		{
			IQueryable<T> query = GetAll();
			if (filters != null)
			{
				foreach (var filter in filters)
				{
					query = query.Where(filter);
				}
			}
			return query;
		}

		/// <summary>
		/// Generic method to get filtered objects by pages
		/// </summary>
		/// <param name="filter">Expression to filter objects by. If null, then no filtering</param>
		/// <param name="pagingParams">Paging Parameters. If no sorting or pagesize = 0, then no paging</param>
		/// <returns>Page of filtered objects</returns>
		public List<T> GetPage(IList<Expression<Func<T, bool>>> filters, PagingParameters<T> pagingParams)
		{
			IQueryable<T> query = GetFiltered(filters);

			if (pagingParams.OrderBy == null)   //cannot use paging without sorting
			{
				return query.ToList();
			}

			var query1 = pagingParams.Asc
								 ? query.OrderBy(pagingParams.OrderBy)
								 : query.OrderByDescending(pagingParams.OrderBy);

			return pagingParams.PageSize == 0 ?
				query1.ToList() :
				query1.Skip(pagingParams.PageIndex * pagingParams.PageSize).Take(pagingParams.PageSize).ToList();
		}

        public void Commit() {
            context.SaveChanges();
        }

		protected abstract DbSet<T> GetTable();
	}

	public class PagingParameters<T> where T : BaseEntity
	{
		public int PageIndex = 0;
		public int PageSize = 0;
		public Func<T, object> OrderBy = null;
		public bool Asc = true;
	}
}

