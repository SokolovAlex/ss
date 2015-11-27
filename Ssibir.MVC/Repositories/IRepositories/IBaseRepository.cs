using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StolicaSibiri.DAL.Models;
using System.Linq.Expressions;

namespace StolicaSibiri.DAL.Repositories.IRepositories
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		IQueryable<T> GetAll();
		T GetByID(Guid id);
		IQueryable<T> GetFiltered(IList<Expression<Func<T, bool>>> filters);
		List<T> GetPage(IList<Expression<Func<T, bool>>> filters, PagingParameters<T> pagingParams);
		void Save(T entity);
		void Delete(Guid id);
	}
}
