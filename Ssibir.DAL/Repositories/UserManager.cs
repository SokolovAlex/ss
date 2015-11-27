using Ssibir.DAL.Models;
using Ssibir.DAL.Models.Interfaces;
using Ssibir.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssibir.DAL.Repositories
{
	public class UserManager
	{
		public IClientRepository _clientRepository;

		public IManagerRepository _managerRepository;

		public UserManager(){
			_clientRepository = new ClientRepository();
			_managerRepository = new ManagerRepository();
		}

		public IUser GetAnonim()
		{
			return new Client(){
				Role = Models.Enums.Roles.NotRegistred,
				FirstName ="Anonim"
			};
		}

		public IUser GetUserByName(string userName)
		{
			var client = _clientRepository.GetByName(userName);
			if (client != null)
				return client;
			var manager = _managerRepository.GetByName(userName);
			if (manager != null)
				return manager;
			return null;
		}
	}
}
