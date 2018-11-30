using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class AppController : Controller
    {
        // GET: App/GetApps
        public ActionResult GetApps()
        {
            List<App> apps = new List<App>()
            {
                new App {AppId=1, Name="xv", Desc="hej"},
                new App {AppId=2, Name="hejhej", Desc="sadsd"}
            }
            ;
            return View(apps);
        }

                
        public ActionResult PostApp()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult PostApp0(App app)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Delete(App app)
        {

            return View();
        }

    }
}