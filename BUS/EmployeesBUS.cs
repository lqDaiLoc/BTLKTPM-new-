using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAO;
using TOD;


namespace BUS
{
   public class EmployeesBUS
    {
       
        EmployeesDAO empDAO = new EmployeesDAO();
        public DataTable tb_NhanVien = new EmployeesDAO().GetDataTableNhanVien();
        public DataTable GetDataNhanVien()
        {
            return new CustomersDAO().GetDataTableNhanVien();
        }
        public void Them(DataTable daT, Employees employees)
        {
            try
            {
                empDAO.Them(daT, employees);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Sua(DataRow row, Employees employees)
        {
            try
            {
                empDAO.Sua(row, employees);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Del(int row, DataTable daT)
        {
            try
            {
                empDAO.Del(row, daT);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Update(DataTable daT)
        {
            try
            {
                empDAO.Update(daT);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
