using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using System.Windows.Forms;

namespace BUS
{
    public class LoginBUS
    {
        //private string userName, passWord;

        // danh cho ham Login
        public string chucVu;
        public bool Login(string userName, string passWord)
        {
            string user = CreateMD5(userName);
            string pass = CreateMD5(passWord);
            LoginDao lg = new LoginDao();
            if(lg.Login(user, pass))
            {
                chucVu = lg.chucVu;
                return true;
            }
            return false;
            
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
