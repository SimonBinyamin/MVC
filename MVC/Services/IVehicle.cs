using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Services
{

    public interface IVehicle
    {
        int Id { get; set; }
        string Name { get; set; }
        string Color { get; set; }
        int ModelYear { get; set; }
        double Price { get; set; }
        byte[] Image { get; set; }
        HttpPostedFileBase FileBase { get; set; }
    }
}