using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ssibir.MVC.Models.User
{
	public interface ICustomPrincipal : System.Security.Principal.IPrincipal
	{
		string FirstName { get; set; }

		string LastName { get; set; }
	}
}