using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOD;

namespace DAO
{
    public class CustomersDAO : DataProvider
    {
        private void AddRow(DataRow row, Customers cus)
        {
            row["MaKH"] = cus.MaNV;
            row["Ho"] = cus.Ho;
            row["Ten"] = cus.Ten;
            row["DiaChi"] = cus.DiaChi;
            row["SDT"] = cus.SDT;
            row["NgaySinh"] = cus.NgaySinh;
            row["GioiTinh"] = cus.GioiTinh;
        }

        public void Them(DataTable daT, Customers cus)
        {
            foreach (DataRow r in daT.Rows)
            {
                if (string.Compare(r["MaKH"].ToString(), cus.MaNV) == 0)
                {
                    MessageBox.Show("Trùng Mã Nhân Viên", "Cảnh Báo");
                    return;
                }
            }
            DataRow row = daT.NewRow();
            AddRow(row, cus);
            daT.Rows.Add(row);
        }

        public void Sua(DataRow row, Customers cus)
        {
            AddRow(row, cus);
        }
        public void Del(int row, DataTable daT)
        {
            daT.Rows[row].Delete();

            updateTableKhach(daT);
        }
        public void Update(DataTable daT)
        {
            updateTableKhach(daT);
        }
    }
}
