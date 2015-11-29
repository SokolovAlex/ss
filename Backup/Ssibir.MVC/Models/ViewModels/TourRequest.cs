using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ssibir.MVC.Models.ViewModels
{
	public class TourRequest
	{
		public TourRequest() {
			CreatedDate = DateTime.Now;
		}

		public Guid ManagerId { get; set; }

		public string ManagerName { get; set; }

		public DateTime CreatedDate { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Where { get; set; }

		public string Wishes { get; set; } 

		public DateTime? DepartureDate { get; set; }

		public DateTime? ArrivalDate { get; set; }
	}
}