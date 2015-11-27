using Ssibir.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ssibir.MVC.Models.ViewModels
{
	public class CardVM
	{
		public string title {get; set;}
		public string thumbUrl {get; set;}
		public string preText {get; set;}
		public Tour tour { get; set; }
		public Manager manager { get; set; }
		public Direction direction { get; set; }
		public List<ExtraData> extras { get; set; }
		public int? id {get; set;}
		public string href {get; set;}
		public string key {get; set;}
	}

	public class ExtraData {
		public extraType type {get; set;}
		public string value { get; set; }
		public string href { get; set; }

		public string className
		{
			get
			{
				return this.type.ToString();
			}
		}

		public string label {
			get {
				switch(this.type) {
					case extraType.Phone:
						return "Тел.";
					case extraType.Vk:
						return "Вконтакте";
					default:
						return this.type.ToString();
				}
			}
		}
	}

	public enum extraType {
		Phone,
		Skype,
		Email,
		Vk
	}
}
