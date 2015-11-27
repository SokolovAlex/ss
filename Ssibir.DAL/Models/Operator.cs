using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ssibir.DAL.Models
{
	public class Operator : BaseEntity
	{
		public string Title { get; set; }
		public string OfficialSite { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public virtual ICollection<Tour> Tours { get; set; }
	}
}
