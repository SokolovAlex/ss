using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ssibir.DAL.Models
{
	public class Hotel : BaseEntity
	{
		public String Name { get; set; }

		public String Address { get; set; }

		[NotMapped]
		public HotelStars Stars { get; set; }
		public int StarsId
		{
			get { return (int)Stars; }
			set { this.Stars = (HotelStars)value; }
		}

		public String GoogleMapLink { get; set; }

		public virtual ICollection<Tour> Tours { get; set; }
	}
}
