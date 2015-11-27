using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ssibir.DAL.Models.Interfaces;
using System.Security.Principal;

namespace Ssibir.DAL.Models
{
	public class Client : BaseEntity, IUser
	{
		[Required]
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		[Display(Name="Mobile Phone")]
		public string mobile { get; set; }
		public DateTime? Birth { get; set; }
		public string Description { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public Guid? DocId { get; set; }

		[NotMapped]
		public string DisplayName {
			get{
				return String.Concat(FirstName," ", LastName);
			}
		}

		public virtual Doc Docs { get; set; }
		public virtual ICollection<Trip> Trips { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }

		public string GetName()
		{
			return DisplayName;
		}

		public Enums.Roles GetRole()
		{
			return Enums.Roles.Client;
		}

		private Enums.Roles _role = Enums.Roles.Client;

		public Enums.Roles Role
		{
			get { return _role; }
			set { _role = value; }
		}
	}
}
