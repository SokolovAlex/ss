using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ssibir.DAL.Repositories;
using Ssibir.DAL.Models.Context;
using Ssibir.DAL;
using Ssibir.DAL.Repositories.IRepositories;
using Ssibir.DAL.Models;
using Ssibir.DAL.Models.Enums;
using System.Web.Security;
using Ssibir.MVC.Models.ViewModels;
using Ssibir.MVC.Models.User;
using Newtonsoft.Json;
using Ssibir.DAL.Models.Enum;
using Ssibir.MVC.Helpers;

namespace Ssibir.MVC.Controllers
{
	public class MainController : Controller
	{
        private PageRepository _pageRepository;

        public MainController(PageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

		public ActionResult Enter()
		{
			var Url = Request.Url;

			redirectHash(Url);
	
			var TourPages = _pageRepository.GetAll().Where(x => x.TypeId == (int)PageType.Hot).OrderByDescending(x => x.Priority).ToList();
			var News = _pageRepository.GetAll().Where(x => x.TypeId == (int)PageType.News).OrderBy(x => x.Priority).ToList();
            string data = JsonConvert.SerializeObject(new
            {
                tourPages = TourPages,
				news = News
            });
            ViewBag.Data = data;
            return View();
		}


		public string TourRequestInfo()
		{
			DbCatalog dataSource = new DbCatalog();
			var managerRepository = new ManagerRepository(dataSource);
			var PageList = managerRepository.GetAll().Select(x => new CardVM
			{
				manager = x,
				key = x.key
			}).ToList();

			return JsonConvert.SerializeObject(new
			{
				error = false,
				managers = managerRepository.GetAll().ToList(),
				requestHystory = new {}
			});
		}


		public string TourRequest(TourRequest req)
		{
			DbCatalog dataSource = new DbCatalog();
			var managerRepository = new ManagerRepository(dataSource);
			var manager = managerRepository.GetByID(req.ManagerId);

			var sg = new SendGridHelper();

			req.ManagerName = manager.DisplayName;

			var mail = sg.createMail(manager.Email, req);
			sg.sendMail(mail);

			// Send Email 
			return JsonConvert.SerializeObject(new
			{
				error = false
			});
		}

		public void redirectHash(Uri url)
		{
			var urlString = url.OriginalString.ToString();
			if (urlString.Contains('#') == true) {
				var Hash = urlString.Split('#').Last();

				var parts = Hash.Split('/');

				if (String.IsNullOrWhiteSpace(parts[0]) == false && parts[0].Equals("page") == true)
				{
					if (String.IsNullOrWhiteSpace(parts[1]) == false &&  parts[1].Equals("about") == true)
					{
						Redirect("About");
					}
				}

			}
		}


	}
}
