using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Services
{
    public class MappingService<T>
    {
        public Dictionary<string, string>  MapObject(T obj)
        {
            Dictionary<string, string> myDict = new Dictionary<string, string> { };
            foreach (var item in obj.GetType().GetProperties())
            {
              switch(item.GetValue(obj))
                {
                    case 0:
                        break;
                    case null:
                        break;
                    default:
                        var index = item.Name;
                        var value = item.GetValue(obj);
                        myDict[index] = value.ToString();
                        break;
                }
            }
            return myDict;
        }
    }
}