using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyWebSiteMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            string[] currentNamespace = new string[] { "MyWebSiteMVC" };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            //-->
            
            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */
            routes.MapRoute("Default", "", new { controller = "Home", action = "Index" }, currentNamespace);
            routes.MapRoute("Home", "home", new { controller = "Home", action = "Index" }, currentNamespace);
            routes.MapRoute("LeadRegister", "lead/register", new { controller = "Lahar", action = "Register" },  currentNamespace );
            routes.MapRoute("LeadUpdate", "lead/update", new { controller = "Lahar", action = "Update"}, currentNamespace );
        }
    }
}
