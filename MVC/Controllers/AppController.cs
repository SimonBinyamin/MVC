using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Threading.Tasks;
using MVC.Services;

namespace MVC.Controllers
{
    public class AppController : Controller
    {
        Repo repo = new Repo();


        public ActionResult Index()
        {
 
            
            return View(Repo.apps);
        }


        public ActionResult PostApp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostApp(App app)
        {
            repo.Add(new App { AppId = app.AppId, Name = app.Name, Desc = app.Desc });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(App app)
        {

            return View();
        }

    }
}