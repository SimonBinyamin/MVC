using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MVC.Services
{
    public class MappingService<T>
    {
        public Dictionary<string, object> MapObject(T obj)
        {
            Dictionary<string, object> myDict = new Dictionary<string, object> { };
            foreach (var item in obj.GetType().GetProperties())
            {

                var attrDataList = from attrData in item.GetCustomAttributesData()
                                   where attrData.AttributeType.Name == "NotMappedAttribute"
                                   select attrData;

                if (item.GetValue(obj).ToString() == "0")
                {
                    Debug.Write("Id is empty");
                }
                else if (item.GetValue(obj) == null)
                {
                    Debug.Write("Object is null");
                }
                else if (attrDataList.Any() == true)
                {
                    Debug.Write("Property contains NotMapped Attribute");
                }
                else
                {
                    var index = item.Name;
                    var value = item.GetValue(obj);
                    myDict[index] = value;
                }
            }
            return myDict;
        }
    }
}