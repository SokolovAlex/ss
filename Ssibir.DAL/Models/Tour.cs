using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ssibir.DAL.Models
{
	public class Tour : BaseEntity
	{
		public Tour(Guid id) : base(id) {}

		public Tour() : base() { }

		public string Title { get; set; }
		public int Cost { get; set; }

		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		public int? Nights { get; set; }

		[NotMapped]
		public TourType Type { get; set; }

		[Required]
		public int TypeId
		{
			get { return (int)this.Type; }
			set { this.Type = (TourType)value; }
		}

		public bool? isHot { get; set; }

        public Guid? HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public Guid? OperatorId { get; set; }
        public virtual Operator Operator { get; set; }

        public Guid? DirectionId { get; set; }
        public virtual Direction Direction { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
	}
}
