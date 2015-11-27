using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Ssibir.DAL.Models
{
	public class Doc : BaseEntity
	{
		[Display(Name="Series of RF passport")]
		public int? SRFPassport { get; set; }
		[Display(Name="Number of RF passport")]
		public int? NrRFPassport { get; set; }
		[Display(Name="Series of foreign passport")]
		public int? SForPassport { get; set; }
		[Display(Name="Number of foreign passport")]
		public int? NrForPassport { get; set; }
		[Display(Name="Expiration Date")]
		public DateTime? ExpirationDate { get; set; }

		[Display(Name = "Name")]
		public string FirstName { get; set; }
		[Display(Name = "FamilyName")]
		public string LastName { get; set; }
		[Display(Name = "FatherName")]
		public string MiddleName { get; set; }

		public Guid ClientId { get; set; }
		public virtual Client Client { get; set; }
	}
}
