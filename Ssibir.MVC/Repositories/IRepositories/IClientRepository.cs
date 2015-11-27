using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StolicaSibiri.DAL.Models;

namespace StolicaSibiri.DAL.Repositories.IRepositories
{
	public interface IClientRepository : IBaseRepository<Client>
	{
		Guid GetIdByNameAndPassword(string login, string password);
	}
}
