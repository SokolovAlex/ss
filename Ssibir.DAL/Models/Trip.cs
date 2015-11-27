using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Ssibir.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ssibir.DAL.Models
{
	public class Trip : BaseEntity
	{
		[Required]
		public string AgreementNumber { get; set; }

		[NotMapped]
		public TripStatus Status { get; set; }
		[Required]
		public int StatusId {
			get { return (int)Status; }
			set { this.Status = (TripStatus)value; } 
		}

		public DateTime? AgreementDate { get; set; }
		public DateTime? DepartmentDate { get; set; }
		public DateTime? ArrivalDate { get; set; }

		public Guid TourId { get; set; }
		public virtual Tour Tour { get; set; }

		public Guid ClientId { get; set; }
		public virtual Client Client { get; set; }

		public Guid? ManagerId { get; set; }
		public virtual Manager Manager { get; set; }
	}
}
