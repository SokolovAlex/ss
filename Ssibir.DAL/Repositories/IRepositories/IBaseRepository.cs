using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Models;
using System.Linq.Expressions;

namespace Ssibir.DAL.Repositories.IRepositories
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		IQueryable<T> GetAll();
		T GetByID(Guid id);
		T GetByKey(string key);
		IQueryable<T> GetFiltered(IList<Expression<Func<T, bool>>> filters);
		List<T> GetPage(IList<Expression<Func<T, bool>>> filters, PagingParameters<T> pagingParams);
		T Save(T entity);
        void Commit();
		bool Delete(Guid id);
	}
}
