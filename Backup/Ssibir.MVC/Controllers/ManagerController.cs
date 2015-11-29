using Newtonsoft.Json;
using Ssibir.DAL.Models;
using Ssibir.DAL.Models.Context;
using Ssibir.DAL.Models.Enum;
using Ssibir.DAL.Repositories;
using Ssibir.MVC.Helpers;
using Ssibir.MVC.Models.User;
using Ssibir.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ssibir.MVC.Controllers
{
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/

        public ActionResult ManagerMenu()
        {
            DbCatalog dataSource = new DbCatalog();
            var rep = new PageRepository(dataSource);
            var clRep = new ClientRepository(dataSource);

            ViewBag.Data = JsonConvert.SerializeObject(new { 
                Pages = rep.GetAll().OrderByDescending(x => x.CreatedDate).ToList(),
				Clients = clRep.GetAll().OrderBy(x => x.LastName).ToList()
            });
            return View();
        }

        public ActionResult NewPage(int type)
        {
            return PartialView(getPageName(type));
        }

        public string EditPage(Page page)
        {
            return "";
        }

        [HttpPost]
        public string Save(HttpPostedFileBase file, string title, string text, string pretext, int type)
        {
            string serverFileName = "";
            Page result;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName); 

                serverFileName = string.Join(fileName, "");

                var path = Path.Combine(Server.MapPath("~/Images/Pages"), fileName);
                file.SaveAs(path);

                ImageHelper.CreateThumbnail(file.InputStream, serverFileName);

                DbCatalog dataSource = new DbCatalog();
                var rep = new PageRepository(dataSource);

                var page = new Page() {
                    Type = (PageType)type,
                    Html = text,
                    CreatedDate = DateTime.Now,
                    Title = title
                };

                result = rep.Save(page);
                rep.Commit();
            }
            else
            {
                return JsonConvert.SerializeObject(new
                {
                    meassge = "fuck",
                    error = true
                });
            }

            return JsonConvert.SerializeObject(new
            {
                meassge = "Upload ok",
                error = false,
                data = result
            });
        }

        [HttpPost]
        public string DeletePage(int id)
        {
            DbCatalog dataSource = new DbCatalog();
            var rep = new PageRepository(dataSource);

            var result = rep.Delete(id);

            if (result != true) {
                return JsonConvert.SerializeObject(new
                {
                    meassge = "Delete failed",
                    error = true
                });
            
            }
            rep.Commit();
            return JsonConvert.SerializeObject(new
            {
                message = "Delete success",
                error = false
            });
        }


        public string getPageName(int type){
           var page = (PageType)type;
           switch(page) {
              case PageType.News:
                   return "_newsPage";
              case PageType.Hot:
                   return "_newsPage";
              case PageType.Simple:
                   return "_newsPage";
              case PageType.Specialize:
                   return "_newsPage";
              case PageType.Subpage:
                   return "_newsPage";
              default:
                   return "_newsPage";
           }
        }

    }
}
