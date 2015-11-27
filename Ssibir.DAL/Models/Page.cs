using Ssibir.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssibir.DAL.Models
{
    public class Page : BaseIntEntity
    {
        public string Title { get; set; }

        [DefaultValue(false)]
        public bool IsManual { get; set; }

        public int Priority { get; set; }

		//[StringLength(10000)]
		public string Html { get; set; }

        public string PreText { get; set; }

        public string Part1 { get; set; }

        public string Part2 { get; set; }

        public string Part3 { get; set; }

		public string[] Images { get; set; }

        public DateTime? CreatedDate { get; set; }

        [NotMapped]
        public PageType Type { get; set; }

        [Required]
        public int TypeId
        {
            get { return (int)this.Type; }
			set { this.Type = (PageType)value; }
        }

		[NotMapped]
        public string ImageUrl {
            get {
				string key = String.IsNullOrWhiteSpace(this.key) == false ? this.key : base.Id.ToString();
				return String.Concat("\\Images\\Pages\\", key, ".jpg"); 
			} 
            private set {}
        }

		[NotMapped]
        public string ThumbUrl {
            get {
				string key = String.IsNullOrWhiteSpace(this.key) == false ? this.key : base.Id.ToString();
				return String.Concat("\\Images\\Thumbs\\160.110\\", key, ".jpg");
			}
            private set { }
        }

		public Guid? CreatedById { get; set; }
		public virtual Manager CreatedBy { get; set; }

        public Guid? OperatorId { get; set; }
        public virtual Operator Operator { get; set; }

		public Guid? LocationId { get; set; }
		public virtual Location Location { get; set; }

		public Guid? DirectionId { get; set; }
		public virtual Direction Direction { get; set; }

        public Guid? TourId { get; set; }
        public virtual Tour Tour { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
