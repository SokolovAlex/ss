using Ssibir.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ssibir.DAL.Repositories.IRepositories
{
	public interface IManagerRepository : IBaseRepository<Ssibir.DAL.Models.Manager>
	{
		Manager GetByNameAndPassword(string login, string password);
		Manager GetByName(string login);
	}
}
