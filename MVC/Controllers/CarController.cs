﻿using MVC.Models;
using System.Web.Mvc;
using MVC.Services;
using System.Diagnostics;

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
            dBService.PostData("Car3", car, DBService<Car>.Req.Post);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int carId)
        {
            dBService.Delete("Car3", "CarId", carId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PutCar(int carId)
        {

            var obList = dBService.GetSingleData("Car3", "CarId", carId);

            int id = (int)obList[0];
            string name = (string)obList[1];
            string color = (string)obList[2];
            int modelYear = (int)obList[3];
            double price = (double)obList[4];
            byte[] img = (byte[])obList[5];

            Car car = new Car() {
                CarId = id,
                Name = name,
                Color = color,
                ModelYear = modelYear,
                Price = price,
                Image = img
            };

            return View(car);


        }

        public ActionResult Put(int carId, Car car)
        {
            dBService.Put("Car3", car, DBService<Car>.Req.Put);
            return RedirectToAction("Index");
        }
    }
}