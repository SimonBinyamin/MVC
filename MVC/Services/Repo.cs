using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Services
{

    public class Repo
    {
        public static List<Car> cars = new List<Car>();
        public void Add(Car car)
        {
            cars.Add(car);
        }
    }
}