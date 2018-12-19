using MVC.Models;
using MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class TruckController : Controller
    {
        // GET: Truck
        public ActionResult Index()
        {

            List<IVehicle> trucks = new List<IVehicle>
            {
                     new Truck {
                                    Id = 1,
                                    Name = "Truck1",
                                    Color = "redish",
                                    Image = null,
                                    ModelYear = 11,
                                    Price = 11
                                },
                     new Truck {
                                Id = 1,
                                Name = "Truck2",
                                Color = "redish",
                                Image = null,
                                ModelYear = 11,
                                Price = 11
                            },
            };

            List<IVehicle> cars = new List<IVehicle>
            {
                     new Car {
                                    Id = 1,
                                    Name = "Car1",
                                    Color = "redish",
                                    Image = null,
                                    ModelYear = 11,
                                    Price = 11
                                },
                     new Car {
                                Id = 1,
                                Name = "Car2",
                                Color = "redish",
                                Image = null,
                                ModelYear = 11,
                                Price = 11
                            },
            };

            var model = new TrucksAndCarsViewModel { Trucks = trucks, Cars = cars };

            return View(model);
        }
    }
}