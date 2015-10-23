using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NoticiasWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{reD:\Source\NoticiasWeb\NoticiasWeb\NoticiasWeb\App_Start\RouteConfig.cssource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Noticias", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
