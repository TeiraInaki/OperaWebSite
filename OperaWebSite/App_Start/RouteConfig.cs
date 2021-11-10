using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OperaWebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Rutas personalizadas
            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{name}/{role}",
                defaults: new {controller="Test", action="Login"}
             );

            routes.MapRoute(
                name: "SearchByTitle",
                url: "{controller}/{title}",
                defaults: new { controller = "Test", action = "SearchByTitle"}
            );

            //Ruta Default (encima las rutas personalizadas)
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
