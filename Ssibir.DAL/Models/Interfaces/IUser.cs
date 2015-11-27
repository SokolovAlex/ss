using Ssibir.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssibir.DAL.Models.Interfaces
{
	public interface IUser
	{
		string FirstName { get; set; }
		string Login { get; set; }
		string MiddleName { get; set; }
		string LastName { get; set; }
		string DisplayName {get;}
		string Password { get; }
		Guid Id{get;}
		Roles Role { get; }
	}
}
