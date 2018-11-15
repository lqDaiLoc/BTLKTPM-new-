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
    public class CustomersBUS
    {
        CustomersDAO cusDAO = new CustomersDAO();
        public DataTable tb_Khach = new CustomersDAO().GetDataTableKhachHang();

        public void Them(DataTable daT, Customers cus)
        {
            try
            {
                cusDAO.Them(daT, cus);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi them Customers", "error");
                throw ex;
            }
        }
        public void Sua(DataRow row, Customers cus)
        {
            try
            {
                cusDAO.Sua(row, cus);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi Sua Customers", "error");
                throw ex;
            }
        }
        public void Del(int row, DataTable daT)
        {
            try
            {
                cusDAO.Del(row, daT);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi Xoa Customers", "error");
                throw ex;
            }
        }
        public void Update(DataTable daT)
        {
            try
            {
                cusDAO.Update(daT);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi Update Customers", "error");
                throw ex;
            }
        }
    }
}
