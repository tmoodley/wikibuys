﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace seoWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
               "search",                                           // Route name
               "search/{id}",                            // URL with parameters
               new { controller = "Search", action = "Details" }  // Parameter defaults
           );

            routes.MapRoute(
              "department",                                           // Route name
              "department/{id}",                            // URL with parameters
              new { controller = "Department", action = "Details" }  // Parameter defaults
          );
             
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            // this will catch the remaining allowed usernames
            routes.MapRoute("name", "{id}/{controller}/{action}", new { controller = "User", action = "Details", id = "" });
            
        }
    }
}
