using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Models;

namespace Ssibir.DAL.Repositories.IRepositories
{
	public interface IClientRepository : IBaseRepository<Client>
	{
		Client GetIdByNameAndPassword(string login, string password);

		Client GetByName(string login);
	}
}
