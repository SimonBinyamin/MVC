using MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class TrucksAndCarsViewModel
    {
        public IEnumerable<IVehicle> Cars { get; set; }
        public IEnumerable<IVehicle> Trucks { get; set; }
    }
}