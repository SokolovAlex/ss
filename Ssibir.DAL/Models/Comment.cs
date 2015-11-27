using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Ssibir.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ssibir.DAL.Models
{
	public class Comment : BaseEntity
	{
		public string Body { get; set; }

		[NotMapped]
		public MarkEnum Mark { get; set; }

		[Required]
		public int MarkId
		{
			get { return (int)this.Mark; }
			set { this.Mark = (MarkEnum)value; }
		}

		[NotMapped]
		public CommentCategory Category { get; set; }

		[Required]
		public int CategoryId
		{
			get { return (int)this.Category; }
			set { this.Category = (CommentCategory)value; }
		}

		public Guid TourId { get; set; }
		public virtual Tour Tour { get; set; }

		public Guid ClientId { get; set; }
		public virtual Client Client { get; set; }
	}
}
