using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

namespace DAO
{
    public class LoginDao : DataProvider
    {
        public string chucVu;
        public bool Login(string userName, string passWord)
        {
            
            //DataProvider dp = new DataProvider();
            string sqlStr = "SELECT Type FROM Users WHERE Username = N'" + userName + "' AND Password = N'" + passWord + "'";
            ConnecTion();
            SqlCommand cmd = new SqlCommand(sqlStr);
            cmd.Connection = cnn;
            cmd.CommandText = sqlStr;
            cmd.CommandType = CommandType.Text;
            chucVu = (string)cmd.ExecuteScalar();
            DisConnecTion();
            try
            {
                if (chucVu == "1" || chucVu == "2")
                    return true;
                return false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ko lay duoc du lieu", " error ");
                throw ex;
            }
            finally
            {
                DisConnecTion();
            }
        }
    }
}
