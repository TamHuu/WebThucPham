﻿using System.Web.Mvc;
using System.Web.Routing;

public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        // How It Work
        routes.MapRoute(
          name: "Howitwork",
          url: "how-it-work", // link seo
          defaults: new { controller = "Home", action = "HowItWork", id = UrlParameter.Optional },
          namespaces: new string[] { "WebThucPham.Controllers" } // Specify the main project's namespace
      );

        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "WebThucPham.Controllers" } // Specify the main project's namespace
        );
    }
}
