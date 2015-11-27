using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StolicaSibiri.DAL.Repositories.IRepositories;
using StolicaSibiri.DAL.Models;
using StolicaSibiri.DAL.Models.Context;
using System.Linq.Expressions;
using System.Data.Objects;
using System.Data.Entity;

namespace StolicaSibiri.DAL.Repositories
{
	public abstract class BaseRepository<T> : IBaseRepository<T>
		where T : BaseEntity
	{
		protected DbCatalog context { get; set; }

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

		public virtual void Save(T entity)
		{
			if (entity.IsNew())
			{
				entity.Id = Guid.NewGuid();
				GetTable().Add(entity);
			}
			else
			{
				T dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
				dbEntity.Id = entity.Id;
				if (dbEntity == null) return;
			}
			context.SaveChanges();
		}

		public virtual void Delete(Guid id)
		{
			var dbEntity = GetTable().SingleOrDefault(x => x.Id == id);
			if (dbEntity == null)
				return;
			GetTable().Remove(dbEntity);// DeleteObject(dbEntity);
			context.SaveChanges();
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

