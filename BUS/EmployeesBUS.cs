using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TOD;
using System.Data;

namespace BUS
{
   public class BUS_Employees
    {
        public DataTable GetEmployees()
        {
            DataProvider daP = new DataProvider();
            return daP.GetDataTableNhanVien();
            
        }
    }
}
