using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StolicaSibiri.DAL.Repositories.IRepositories
{
	public interface IManagerRepository : IBaseRepository<StolicaSibiri.DAL.Models.Manager>
	{
		Guid GetIdByNameAndPassword(string login, string password);
	}
}
