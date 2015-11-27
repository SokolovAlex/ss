using Ssibir.DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Ssibir.web.Core.Providers.IProviders
{
	public interface IUserProvider
	{
		IUser GetUser(string username);

		bool ValidateUser(string username, string password);

		string GetDisplayName(string userName);
	}
}
