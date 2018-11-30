using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace MVC.Controllers
{
    public class AppController : Controller
    {
        // GET: App/GetApps
        public ActionResult GetApps()
        {
            List<App> apps = new List<App>()
            {
                new App {AppId=1, Name="MPCK", Desc="hej"},
                new App {AppId=2, Name="hejhej", Desc="sadsd"}
            }
            ;


            return View(apps);
        }
    }
}