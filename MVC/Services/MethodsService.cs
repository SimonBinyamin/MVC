using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVC.Services
{
    public class MethodsService
    {
        public byte[] FileBaseToByteImage(HttpPostedFileBase file)
        {
            var length = file.InputStream.Length;
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            return fileData;

        }
    }
}