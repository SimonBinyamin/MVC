using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Threading.Tasks;
using MVC.Services;
using System.Data.SqlClient;
using System.Configuration;
namespace MVC.Controllers
{
    public class CarController : Controller
    {
        Repo repo = new Repo();

        string connStr = ConfigurationManager.ConnectionStrings["SQLConn"].ConnectionString;
        public ActionResult Index()
        {
            return View(Repo.cars);
        }


        public ActionResult PostCar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostCar(Car car)
        {

            using (SqlConnection con = new SqlConnection(connStr))
            {
                 string q = "INSERT INTO Car (CarId, Name, Color, ModelYear, Price, Image) VALUES("+car.CarId+ ", '" + car.Name.ToString() + "', 'black', 1992, 155.55, Null)";
                                SqlCommand cmd = new SqlCommand(q, con);
                con.Open();
                                cmd.ExecuteNonQuery();
            }
          
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Car car)
        {
            return View();
        }

    }
}