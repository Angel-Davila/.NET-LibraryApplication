﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Library
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BookReport",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Report", action = "Book", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "UserReport",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Report", action = "User", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "LoanReport",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Report", action = "Loan", id = UrlParameter.Optional }
           );
        }

    }
}
