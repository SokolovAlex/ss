using DevOne.Security.Cryptography.BCrypt;
using Ssibir.DAL.Models;
using Ssibir.DAL.Models.Interfaces;
using Ssibir.DAL.Repositories.IRepositories;
using Ssibir.web.Core.Providers.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Ssibir.web.Core.Providers
{
	public class UserProvider : IUserProvider
	{
		public IClientRepository _clientRepository;

		public IManagerRepository _managerRepository;

		public UserProvider(IClientRepository clientRepository, IManagerRepository managerRepository){
			_clientRepository = clientRepository;
			_managerRepository = managerRepository;
		}

		public IUser GetUser(string username)
		{
			var client = _clientRepository.GetByName(username);
			if (client != null)
			{
				return client;
				//return new MembershipUser();
			}

			var manager = _managerRepository.GetByName(username);
			if (manager != null)
			{
				return manager;
			}
			return null;
		}

		public Guid CreateClient(Client client)
		{
			_clientRepository.Save(client);
			return client.Id;
		}

		public Guid CreateManager(Manager manager)
		{
			_managerRepository.Save(manager);
			return manager.Id;
		}

		public bool ValidateUser(string username, string password)
		{
			var user = _clientRepository.GetByName(username);
			var isCorrectPassword = false;
			if (user != null) {
				isCorrectPassword = BCryptHelper.CheckPassword(password, user.Password);
				if (!isCorrectPassword) { return false; }
				else return true;
			}

			var manager = _managerRepository.GetByName(username);
			if (manager != null) {
				isCorrectPassword = BCryptHelper.CheckPassword(password, manager.Password);
				if (!isCorrectPassword) { return false; }
				else return true;
				}
			return false;
		}

		public string GetDisplayName(string userName){
			var client = _clientRepository.GetByName(userName);
			if (client != null)
				return client.DisplayName;
			var manager = _managerRepository.GetByName(userName);
			if (manager != null)
				return manager.DisplayName;
			return string.Empty;
		}
	}
}
