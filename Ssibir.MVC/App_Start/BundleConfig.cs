using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Ssibir.MVC
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/libraries").Include(
					"~/Scripts/libraries/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/firstInit").Include(
                    "~/Scripts/firstInit/*.js"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/Scripts/custom/table").Include(
				"~/Scripts/custom/table.js"));

			bundles.Add(new ScriptBundle("~/Scripts/custom/init").Include(
				"~/Scripts/custom/init.js"));

            bundles.Add(new ScriptBundle("~/Scripts/custom/managerMenu").Include(
                "~/Scripts/custom/managerMenu.js"));

            bundles.Add(new StyleBundle("~/Content/css/all").Include("~/Content/*.css", "~/Content/css/*.css"));


			BundleTable.EnableOptimizations = true;
		}
	}
}