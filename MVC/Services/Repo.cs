using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Services
{

    public class Repo
    {
        public static List<App> apps = new List<App>();
        public void Add(App app)
        {
            apps.Add(app);
        }
    }
}