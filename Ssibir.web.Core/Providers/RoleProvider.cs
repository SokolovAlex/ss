using Ssibir.DAL.Models.Enum;
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
	public class UserRoleProvider : RoleProvider, IUserRoleProvider
	{
		public IClientRepository _clientRepository;

		public IManagerRepository _managerRepository;

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override string ApplicationName
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override void CreateRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			throw new NotImplementedException();
		}

		public override string[] GetRolesForUser(string username)
		{
			throw new NotImplementedException();
		}

		public override string[] GetUsersInRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override bool IsUserInRole(string username, string roleName)
		{
			bool result = false;
			switch(roleName){
				case "Client":
					if(_clientRepository.GetByName(username)!=null)
						result= true;
					break;
				case "Manager":
					if(_managerRepository.GetByName(username)!=null)
						result = true;
					break;
			}
			return result;
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists(string roleName)
		{
			throw new NotImplementedException();
		}
	}
}
