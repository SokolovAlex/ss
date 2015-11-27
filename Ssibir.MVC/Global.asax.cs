using Ninject;
using Ninject.Web.Common;
using Ssibir.DAL.Models.ContextModel;
using Ssibir.DAL.Models.Interfaces;
using Ssibir.DAL.Repositories;
using Ssibir.MVC.App_Start;
using Ssibir.MVC.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Ssibir.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
		protected override void OnApplicationStarted()
        {
			base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
			Database.SetInitializer(new InitSsibir());
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

		protected override Ninject.IKernel CreateKernel()
		{
			var kernel = new StandardKernel(new DIModule());
			return kernel;
		}

		protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
		{
			//Request.Cookies.Clear();
			HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			if (authCookie != null)
			{
				FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
				var principal = new WrappedUser(authTicket.Name);
				HttpContext.Current.User = principal;
			}
			else{
				HttpContext.Current.User = new WrappedUser();
			}
		}
	}
}