using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Models;
using System.Linq.Expressions;

namespace Ssibir.DAL.Repositories.IRepositories
{
    public interface IBaseIntRepository<T> where T : BaseIntEntity
    {
        IQueryable<T> GetAll();
        T GetByID(int id);
		T GetByKey(string key);
        IQueryable<T> GetFiltered(IList<Expression<Func<T, bool>>> filters);
        List<T> GetPage(IList<Expression<Func<T, bool>>> filters, PagingIntParameters<T> pagingParams);
        T Save(T entity);
        void Commit();
        bool Delete(int id);
    }
}
