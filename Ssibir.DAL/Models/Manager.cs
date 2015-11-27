using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Ssibir.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Ssibir.DAL.Models.Interfaces;

namespace Ssibir.DAL.Models
{
	public class Manager : BaseEntity, IUser
	{
		[Required]
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		
		[Display(Name="Телефон")]
		public string Phone { get; set; }
		[Display(Name = "Skype")]
		public string Skype { get; set; }
		[Display(Name = "Страница Вконтакте")]
		public string Vk { get; set; }
		[Display(Name = "Почта")]
		public string Email { get; set; }

		public string Description { get; set; }

		public DateTime? Birth { get; set; }

		[NotMapped]
		public string DisplayName
		{
			get
			{
				return String.Concat(FirstName, " ", LastName);
			}
		}

		public string Login { get; set; }
		[ValidatePasswordLength]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[NotMapped]
		public string ImageUrl
		{
			get
			{
				string key = String.IsNullOrWhiteSpace(this.key) == false ? this.key : base.Id.ToString();
				return String.Concat("\\Images\\Managers\\", key, ".jpg");
			}
			private set { }
		}

		[NotMapped]
		public string ThumbUrl
		{
			get
			{
				string key = String.IsNullOrWhiteSpace(this.key) == false ? this.key : base.Id.ToString();
				return String.Concat("\\Images\\Thumbs\\160.110\\", key, ".jpg");
			}
			private set { }
		}

		public String Specialty { get; set; }

		[NotMapped]
		public JobGrid Job { get; set; }

		[NotMapped]
		public string JobDescription { 
			get {
				switch (this.Job) {
					case JobGrid.Trainee:
						return "Менеджер стажер";
					case JobGrid.JuniorManager:
						return "Младший менеджер";
					case JobGrid.Director:
						return "Генеральный Директор";
					case JobGrid.commercialDirector:
						return "Коммерческий директор";
					case JobGrid.MidManager:
						return "Менеджер по туризму";
					case JobGrid.SeniorManager:
						return "Старший менеджер";
					default:
						return this.Job.ToString();
				}
			}
		}

		[Required]
		public int JobId
		{
			get { return (int)this.Job; }
			set { this.Job = (JobGrid)value; }
		}

		public virtual ICollection<Trip> Trips { get; set; }

		public string GetName()
		{
			return DisplayName;
		}

		public Roles GetRole()
		{
			return Roles.Manager;
		}

		public Roles Role
		{
			get { return Roles.Manager; }
		}
	}
}
