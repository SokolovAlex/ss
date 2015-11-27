using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ssibir.DAL.Models
{
	public class SessionEntity : BaseEntity
	{
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		public Guid UserId { get; set; }

		public string Login { get; set; }

		public string Name { get; set; }

		[NotMapped]
		public Roles Role { get; set; }

		[Required]
		public int RoleId
		{
			get { return (int)this.Role; }
			set { this.Role = (Roles)value; }
		}
	}
}
