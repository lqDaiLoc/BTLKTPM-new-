using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Data;
using TOD;

namespace DAO
{
    public class EmployeesDAO : DataProvider
    {

        private void AddRow(DataRow row, Employees employees)
        {
            row["MaNV"] = employees.MaNV;
            row["Ho"] = employees.Ho;
            row["Ten"] = employees.Ten;
            row["GioiTinh"] = employees.GioiTinh;
            row["NgaySinh"] = employees.NgaySinh;
            row["ChucVu"] = employees.ChucVu;
            row["DiaChi"] = employees.DiaChi;
            row["NgayThue"] = employees.NgayThue;
            row["SDT"] = employees.SDT;
            
        }

        public void Them(DataTable daT, Employees employees)
        {
            if (employees.MaNV != "" && employees.Ho != "" && employees.Ten != "" && employees.GioiTinh != "" && employees.NgaySinh != "" && employees.ChucVu != "" && employees.NgayThue != "" && employees.DiaChi != "" && employees.SDT != "")
            {
                foreach (DataRow r in daT.Rows)
                {
                    if (string.Compare(r["MaNV"].ToString(), employees.MaNV) == 0)
                    {
                        MessageBox.Show("Trùng Mã Nhân Viên", "Cảnh Báo");
                        return;
                    }
                }
                DataRow row = daT.NewRow();
                AddRow(row, employees);
                daT.Rows.Add(row);
            }
            else
                MessageBox.Show("Thieu du loei", "error");

        }

        public void Sua(DataRow row, Employees employees)
        {
            AddRow(row, employees);
        }
        public void Del(int row, DataTable daT)
        {
            try
            {
                daT.Rows[row].Delete();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            updateTableNhanVien(daT);

        }
        
        private void Del_TbChiTietBanh(string maBanh, DataTable tb_ChiTietBanh)
        {
            foreach(DataRow row in tb_ChiTietBanh.Rows)
            {
                if(string.Compare(row["MaBanh"].ToString(), maBanh) == 0)
                {
                    row.Delete();
                }
            }
            updateTableChiTietBanh(tb_ChiTietBanh);
        }
        private void Del_TbDonHang(string maDonHang, DataTable tb_DonHang)
        {
            foreach (DataRow row in tb_DonHang.Rows)
            {
                if (string.Compare(row["MaDH"].ToString(), maDonHang) == 0)
                {
                    row.Delete();
                }
            }
            updateTableDonHang(tb_DonHang);
        }
        private void Del_DonHang_Banh(string maDonHang, DataTable DonHang_Banh)
        {
            foreach (DataRow row_DonHang_Banh in DonHang_Banh.Rows)
            {
                if (string.Compare(row_DonHang_Banh["MaDH"].ToString(), maDonHang) == 0)
                {
                    row_DonHang_Banh.Delete();
                }
            }
            updateTableDonHang_Banh(DonHang_Banh);
        }
        public void Update(DataTable daT)
        {
            updateTableNhanVien(daT);
        }

    }
}
