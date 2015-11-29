using Ssibir.DAL.Models.Enum;
using Ssibir.DAL.Models.Interfaces;
using Ssibir.DAL.Repositories;
using Ssibir.web.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Ssibir.MVC.Models.User
{
	public class WrappedUser : ICustomPrincipal
	{
		public MyIdentity Identity { get; private set; }

		public WrappedUser(string username)
		{
			var pr = new UserManager();
			IUser user = pr.GetUserByName(username);
			this.Identity = new MyIdentity(user);
		}

		public WrappedUser()
		{
			var pr = new UserManager();
			IUser user = pr.GetAnonim();
			this.Identity = new MyIdentity(user);
		}

		public bool IsInRole(string role)
		{
			var pr = new UserRoleProvider();
			return Identity != null && Identity.IsAuthenticated &&
			   !string.IsNullOrWhiteSpace(role) && pr.IsUserInRole(Identity.Name, role);
		}

		public string FirstName
		{
			get
			{
				return Identity.FirstName;
			}
			set
			{
				Identity.FirstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return Identity.LastName;
			}
			set
			{
				Identity.LastName = value;
			}
		}

		IIdentity IPrincipal.Identity
		{
			get { return Identity; }
		}
	}

	public class MyIdentity: IIdentity
	{
		public int UserId;
		public string FirstName;
		public string LastName;
		public string DisplayName;
		public string Login;
		public bool _IsAuthenticated;
		public Ssibir.DAL.Models.Enums.Roles Role;

		public MyIdentity(IUser user)
		{
			FirstName = user.FirstName;
			LastName = user.LastName;
			Role = user.Role;
			Login = user.Login;
			DisplayName = user.DisplayName;
			if (user.Role == DAL.Models.Enums.Roles.NotRegistred) _IsAuthenticated = false;
			else _IsAuthenticated = true;
		}

		public string AuthenticationType
		{
			get { return "Custom Indentity"; }
		}

		public bool IsAuthenticated
		{
			get { return _IsAuthenticated; }
		}

		public string Name
		{
			get {return Login; }
		}
	}
}