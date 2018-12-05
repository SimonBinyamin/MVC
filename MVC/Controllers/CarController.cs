using MVC.Models;
using System.Web.Mvc;
using MVC.Services;

namespace MVC.Controllers
{
    public class CarController : Controller
    {
        DBService<Car> dBService = new DBService<Car>();

        
        public ActionResult Index()
        {
            return View(dBService.GetData("Car3"));
        }


        public ActionResult PostCar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostCar(Car car)
        {
          
            dBService.PostData("Car3", car);
          
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Car car)
        {
            return View();
        }

    }
}