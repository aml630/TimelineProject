using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TimeLineBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
          name: "LoadTimeline",
          url: "Timeline/{slug}",
          defaults: new { controller = "Timeline", action = "LoadTimeline", slug = UrlParameter.Optional }
      );

            routes.MapRoute(
                name: "TrumpRussia",
                url: "{controller}/trump-russia",
                defaults: new { controller = "Blog", action = "TrumpRussia" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
