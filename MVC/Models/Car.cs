using MVC.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Models
{
   
    public class Car
    {
        MethodsService methodsService = new MethodsService();
        private HttpPostedFileBase fileBase;

        public int CarId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase FileBase {
           get
            {
                return fileBase;
            } 
            set {
                Image = methodsService.FileBaseToByteImage(value);
                fileBase = value;
            }
        }

    }
}