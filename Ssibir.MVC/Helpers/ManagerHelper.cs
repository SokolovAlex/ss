using Ssibir.DAL.Models;
using Ssibir.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ssibir.MVC.Helpers
{
	public class ManagerHelper
	{
		public static string GetPreview(Manager manager) {
			return manager.Description;
		}

		public static List<ExtraData> GetExtras(Manager manager)
		{
			List<ExtraData> result = new List<ExtraData>();

			if (String.IsNullOrWhiteSpace(manager.Email) == false) {
			   result.Add(new ExtraData() {
				   type = extraType.Email,
				   value = manager.Email
				});
			}
			if (String.IsNullOrWhiteSpace(manager.Skype) == false)
			{
				result.Add(new ExtraData()
				{
					type = extraType.Skype,
					value = manager.Skype
				});
			}
			if (String.IsNullOrWhiteSpace(manager.Vk) == false)
			{
				result.Add(new ExtraData()
				{
					type = extraType.Vk,
					value = "Вконтакте",
					href = manager.Vk
				});
			}
			if (String.IsNullOrWhiteSpace(manager.Phone) == false)
			{
				result.Add(new ExtraData()
				{
					type = extraType.Phone,
					value = manager.Phone
				});
			}

			return result;
		}
	}
}