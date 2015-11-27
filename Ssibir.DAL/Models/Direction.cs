using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ssibir.DAL.Models
{
	public class Direction : BaseEntity
	{
		public Direction(Guid id) : base(id) {}

		public Direction () : base() {}

		public string Title { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Tour> Tours { get; set; }
	}
}
