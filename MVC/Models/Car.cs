using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
    }
}