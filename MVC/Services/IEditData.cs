using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
    public interface IEditData
    {
        void Put(string table, string primeryKey, int id);
    }
}
