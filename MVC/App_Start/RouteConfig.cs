using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
            "Mod",
            "Car/Put/{id}",
            new { controller = "Car", action = "Put" }
            );


            routes.MapRoute(
            "ModCar",
            "Car/PutCar/{id}",
            new { controller = "Car", action = "PutCar" }
            );

            routes.MapRoute(
            "DeleteCar",
            "Car/Delete/{id}",
            new { controller = "Car", action = "Delete"}
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
