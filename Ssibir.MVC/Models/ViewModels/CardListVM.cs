using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ssibir.MVC.Models.ViewModels
{
	public class CardListVM
	{
		public List<CardVM> Cards { get; set; }

		public string Title { get; set; }
	}
}