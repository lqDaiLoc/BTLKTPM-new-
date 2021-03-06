﻿using System;
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
            row[0] = cus.MaKH;
            row["Ho"] = cus.Ho;
            row["Ten"] = cus.Ten;
            row["DiaChi"] = cus.DiaChi;
            row["SDT"] = cus.SDT;
            row["NgaySinh"] = cus.NgaySinh;
            row["GioiTinh"] = cus.GioiTinh;
        }

        public void Them(DataTable daT, Customers cus)
        {
            if (cus.MaKH != "" && cus.Ho != "" && cus.Ten != "" && cus.GioiTinh != "" && cus.NgaySinh != "" && cus.DiaChi != "" && cus.SDT != "")
            {
                foreach (DataRow r in daT.Rows)
                {
                    if (string.Compare(r["MaKH"].ToString(), cus.MaKH) == 0)
                    {
                        MessageBox.Show("Trùng Mã Khach", "Cảnh Báo");
                        return;
                    }
                }
                DataRow row = daT.NewRow();
                AddRow(row, cus);
                daT.Rows.Add(row);
            }
            else
                MessageBox.Show("thieu Du Lieu", "error");
        }

        public void Sua(DataRow row, Customers cus)
        {
            AddRow(row, cus);
        }
        public void Del(int row, DataTable daT)
        {
            string maKH = daT.Rows[row][0].ToString();
            bool Xoa = true;
            DataTable tb = GetDataTableKhachHang();
            foreach(DataRow item in tb.Rows)
            {
                if (string.Compare(item[0].ToString(), maKH) == 0)
                    Xoa = false;
            }
            if (Xoa)
                daT.Rows[row].Delete();
            else
                MessageBox.Show("khong Xoa duoc, anh huong den nhung csdl khac....", "Khong xoa dc");
            //updateTableKhach(daT);
        }
        public void Update(DataTable daT)
        {
            updateTableKhach(daT);
        }
    }
}
