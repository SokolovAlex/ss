using Newtonsoft.Json;
using Ssibir.DAL.Models;
using Ssibir.DAL.Models.Context;
using Ssibir.DAL.Models.Enum;
using Ssibir.DAL.Models.Enums;
using Ssibir.DAL.Repositories;
using Ssibir.MVC.Models.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ssibir.MVC.Helpers;

namespace Ssibir.MVC.Controllers
{
    public class PageController : Controller
    {
		private List<CardVM> getListData(string list, string filter, string sort)
		{
			DbCatalog dataSource = new DbCatalog();
			var rep = new PageRepository(dataSource);

			List<CardVM> PageList;

			if (list == "tour" || list == "specialize")
			{
				PageList = rep.GetAll().Where(z => z.TourId != null).Select(x => new CardVM
				{
					title = x.Title,
					preText = x.PreText,
					tour = x.Tour,
					id = x.Id,
					key = x.key
				}).ToList();
			}
			else if (list == "directions")
			{
				PageList = rep.GetAll().Where(z => z.DirectionId != null).Select(x => new CardVM
				{
					title = x.Title,
					preText = x.PreText,
					tour = x.Tour,
					id = x.Id,
					key = x.key
				}).ToList();
			}
			else if (list == "cruise")
			{
				PageList = rep.GetAll().Include(x => x.Tour).Where(z => z.Tour != null && z.Tour.TypeId == (int)TourType.Cruise).Select(x => new CardVM
				{
					title = x.Title,
					preText = x.PreText,
					tour = x.Tour,
					id = x.Id,
					key = x.key
				}).ToList();
			}
			else if (list == "managers")
			{
				var managerRepository = new ManagerRepository(dataSource);
				PageList = managerRepository.GetAll().Select(x => new CardVM
				{
					manager = x,
					key = x.key
				}).ToList();

				foreach(CardVM page in PageList){
					page.title = page.manager.DisplayName;
					page.extras =  ManagerHelper.GetExtras(page.manager);
					page.preText = ManagerHelper.GetPreview(page.manager);
				}
			}
			else
			{

				PageType type;
				if (Enum.TryParse<PageType>(list, true, out type) == false)
				{
					throw new Exception(String.Concat("not exist type:", list));
				}


				PageList = rep.GetAll().Where(z => z.TypeId == (int)type).Select(x => new CardVM
				{
					title = x.Title,
					preText = x.PreText,
					tour = x.Tour,
					id = x.Id,
					key = x.key
				}).ToList();
			};

			return PageList;
		}
       
        //
        // GET: /Page/
		public ActionResult Page(string id)
		{
			DbCatalog dataSource = new DbCatalog();
			var rep = new PageRepository(dataSource);

			// custom pages
			if (id == "About" || id == "Vacancies" || id == "Search")
			{
				//string path = string.Format("/Views/Main/{0}.cshtml", id);
				//path = this.Server.MapPath(path);
				//string lines = System.IO.File.ReadAllText(path);

				//var Page = new Page()
				//{
				//	Html = lines,
				//	Key = id
				//};

				//return PartialView(id, new
				//{
				//	message = "",
				//	key = id
				//});

				return View(id);
			}

            var intKey = 0;
            Page model;
            if (Int32.TryParse(id, out intKey) == true)
            {
                model = rep.GetByID(intKey);
            }
            else {
                model = rep.GetByKey(id);
            } 

			if (model == null)
			{
				return View("Error", new
				{
					message = "",
					key = id
				});
			}

			if (model.Type == PageType.Manager) {
				var managerRepository = new ManagerRepository(dataSource);
				var manager = managerRepository.GetByKey(model.key);
				return View("Manager", manager);
			}

			return View("Page", model);
		}

		//
		// GET: /List/
		public ActionResult list(string list, string filter, string sort)
		{
			DbCatalog dataSource = new DbCatalog();
			var rep = new PageRepository(dataSource);

			List<CardVM> PageList;
			try
			{
				PageList = getListData(list, filter, sort);
			}
			catch (Exception ex)
			{
				return View("Error", new
				{
					message = "",
					ex = ex,
					key = list
				});
			}
			// 	common operations
			foreach (CardVM item in PageList)
			{
				var key = String.IsNullOrWhiteSpace(item.key) ? item.id.ToString() : item.key;
				item.href = String.Concat("/ss/Page/", key);
				item.thumbUrl = String.Concat("\\Images\\Thumbs\\160.110\\", key, ".jpg");
			}

			if (PageList == null)
			{
				return View("Error", new
				{
					message = "",
					key = list
				});
			}

			return View(new CardListVM() {
				Cards = PageList,
				Title = GetTitle(list)
			});
		}

        public string PageData(int key)
        {
			DbCatalog dataSource = new DbCatalog();
            var rep = new PageRepository(dataSource);

			var model = rep.GetByID(key);

			if (model == null)
			{
				return JsonConvert.SerializeObject(new { 
					error = true,
					massage = String.Concat("Page with key: ", key.ToString(), " doesn\'t exist")
				});
			}

			return JsonConvert.SerializeObject(new
			{
				model = model,
				custom = false
			});
        }

		public string PageDataByKey(String key)
		{
			DbCatalog dataSource = new DbCatalog();
			var rep = new PageRepository(dataSource);

			// custom pages
			if (key == "About" || key == "Vacancies" || key == "Search")
			{
				string path = string.Format("/Views/Page/{0}.cshtml", key);
				path = this.Server.MapPath(path);
				string lines = System.IO.File.ReadAllText(path);

				var Page = new Page() {
					Html = lines,
					key = key
				};

				return JsonConvert.SerializeObject(new
				{
					model = Page,
					custom = true
				});
			}

			var model = rep.GetByKey(key);

			if (model == null)
			{
				return JsonConvert.SerializeObject(new { 
					error = true,
					massage = String.Join("Page with key: ", key, " doesn\'t exist")
				});
			}

			if (model.Type == PageType.Manager)
			{
				var managerRepository = new ManagerRepository(dataSource);
				var manager = managerRepository.GetByKey(model.key);
				return JsonConvert.SerializeObject(new
				{
					model = manager,
					type = "manager",
					custom = false
				});
			}

			return JsonConvert.SerializeObject(new {
				model = model,
				custom = false
			});
		}

		public string ListData(string list, string filter, string sort)
		{
			DbCatalog dataSource = new DbCatalog();
			var rep = new PageRepository(dataSource);

			List<CardVM> PageList;
			try
			{
				PageList = getListData(list, filter, sort);
			}
			catch(Exception ex) {

				return JsonConvert.SerializeObject(new
				{
					error = true,
					ex = ex,
					massage = String.Concat("List with key: ", list, " doesn\'t exist")
				});
			}

			// 	common operations
			foreach (CardVM item in PageList) {
				var key = String.IsNullOrWhiteSpace(item.key) ? item.id.ToString() : item.key;
				item.href = String.Concat("/ss/Page/", key);
				item.thumbUrl = String.Concat("\\Images\\Thumbs\\160.110\\", key, ".jpg");
			}

			return JsonConvert.SerializeObject(new {
				list = PageList,
				error = false
			});
		}

		private string GetTitle(string name)
		{
			switch (name) {
				case "hot":
					return "Горящие путевки";
				case "directions":
					return "Направления";
				case "managers":
					return "Коллектив";
				default:
					return "Туры";
			}

		}
    }
}
