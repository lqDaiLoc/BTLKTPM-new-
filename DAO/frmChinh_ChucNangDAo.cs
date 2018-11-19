using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOD;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
    public class frmChinh_ChucNangDAo : DataProvider
    {
        public double getTienHang(string tenBanh)
        {
            double kq = 0;
            //DataProvider dp = new DataProvider();
            
            ConnecTion();
            DataTable tb_Banh = GetDataTableHang();
            try
            {
                foreach (DataRow row in tb_Banh.Rows)
                {
                    if (row[1].ToString() == (tenBanh))
                    {
                        kq = double.Parse(row[5].ToString());
                        return kq;
                    }
                }
                DisConnecTion();
                return kq;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Tên Bánh Sai...", "error getTienBanh");
                throw ex;
            }
            finally { DisConnecTion(); }

        }

        /// <summary>
        /// Nhap thong tin hang vao tb
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        public void GetDataRowChiTietBanh(DataTable tb, string tenHang, int MaBanh)
        {
            DataRow row = tb.NewRow();
            SqlDataAdapter adapter = new SqlDataAdapter("Select MaBanh = '" + MaBanh + "', MaHang, TenHang, MaLoai, SoLuong = 1, GiaHang from Hang Where TenHang = N'" + tenHang.ToString() + "'", cnn);
            adapter.Fill(tb);
        }
        /// <summary>
        /// Xoa thong tin cua hang khoi table
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        public void RemoveDataRowHang(DataTable tb, string tenHang, int maBanh)
        {
            foreach (DataRow ros in tb.Rows)
            {
                if (ros["TenHang"].ToString() == tenHang && ros["MaBanh"].ToString() == maBanh.ToString())
                {
                    tb.Rows.Remove(ros);
                    return;
                }
            }
        }
        /// <summary>
        /// Lay thong tin nuoc uong cua khach vao table, Co lay so luong
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        /// <param name="SoLuong"></param>
        public void GetDataRowNuoc(DataTable tb, string tenHang, int SoLuong, int MaBanh)
        {
            DataRow row = tb.NewRow();
            SqlDataAdapter adapter = new SqlDataAdapter("Select MaBanh = '" + MaBanh + "', MaHang, TenHang, MaLoai, SoLuong = '" + SoLuong.ToString() + "' , GiaHang from Hang Where TenHang = N'" + tenHang.ToString() + "'", cnn);
            adapter.Fill(tb);
        }

        /// <summary>
        /// Lay ma Banh cao nhat trong Database
        /// </summary>
        /// <returns></returns>
        public int GetMaBanh()
        {
            int max = 0;
            DataTable tb_Banh = GetDataTableBanh();
            if (tb_Banh.Rows[0][0].ToString() != null)
            {
                max = int.Parse(tb_Banh.Rows[0][0].ToString());
                foreach (DataRow row in tb_Banh.Rows)
                {
                    int value = int.Parse(row[0].ToString());
                    if (max < value)
                        max = value;
                }
            }
            return ++max;
        }

        /// <summary>
        /// Lay ma hoa don lon nhat tu table HOADON
        /// </summary>
        /// <returns></returns>
        public int getMaHoaDon()
        {
            int max = 0;
            DataTable tb_HoaDon = GetDataTableDonHang();
            if (tb_HoaDon.Rows[0][0].ToString() != null)
            {
                max = int.Parse(tb_HoaDon.Rows[0][0].ToString());
                foreach (DataRow row in tb_HoaDon.Rows)
                {
                    int value = int.Parse(row[0].ToString());
                    if (max < value)
                        max = value;
                }
            }
            return ++max;
        }
        /// <summary>
        /// Update du lieu tu ListView len dataBase_TableBanh
        /// </summary>
        public void updateDuLieu_Banh(int maBanh)
        {
            DataTable tbBanh = GetDataTableBanh();
            DataRow rowBanh = tbBanh.NewRow();
            rowBanh[0] = maBanh;
            tbBanh.Rows.Add(rowBanh);
            updateTableBanh(tbBanh);
        }
        /// <summary>
        /// Update du lieu tu ListView len dataBase_TableHoaDon_Banh
        /// </summary>
        /// <param name="maHoaDon"></param>
        /// <param name="maBanh"></param>
        public void updateDuLieuDonHang_Banh(int maHoaDon, int maBanh)
        {
            DataTable tbHoaDon_Banh = GetDataTableDonHang_Banh();
            DataRow rowHoaDon_Banh = tbHoaDon_Banh.NewRow();
            rowHoaDon_Banh[0] = maHoaDon;
            rowHoaDon_Banh[1] = maBanh;
            tbHoaDon_Banh.Rows.Add(rowHoaDon_Banh);
            updateTableDonHang_Banh(tbHoaDon_Banh);
        }
        /// <summary>
        /// Update du lieu tu ListView len dataBase_TableHoaDon
        /// </summary>
        /// <param name="MaKhach"></param>
        /// <param name="MaNV"></param>
        /// <param name="maHoaDon"></param>
        public void updateDuLieuHoaDon(string MaKhach, string MaNV, int maHoaDon)
        {
            DataTable tbDonHang = GetDataTableDonHang();
            DataRow rowDonHang = tbDonHang.NewRow();
            rowDonHang[0] = maHoaDon;
            rowDonHang[1] = MaKhach;
            rowDonHang[2] = MaNV;
            rowDonHang[3] = string.Format("{0:dd/MM/yyyy}",DateTime.Now);
            tbDonHang.Rows.Add(rowDonHang);
            updateTableDonHang(tbDonHang);
        }
        /// <summary>
        /// Update du lieu tu ListView len dataBase_TableChiTietDon
        /// </summary>
        /// <param name="row"></param>
        public void updateDuLieuChiTietDon(DataRow row)
        {
            DataTable tbChiTiet = GetDataTableChiTietBanh();
            DataRow rowChiTietBanh = tbChiTiet.NewRow();
            rowChiTietBanh[0] = row[0];
            rowChiTietBanh[1] = row[1];
            rowChiTietBanh[2] = row[2];
            rowChiTietBanh[3] = row[3];
            rowChiTietBanh[4] = row[4];
            rowChiTietBanh[5] = row[5];
            tbChiTiet.Rows.Add(rowChiTietBanh);
            updateTableChiTietBanh(tbChiTiet);
        }
        public void XoaItemListView(ListView listView1, int selected)
        {
            listView1.Items[selected].Remove();
        }
        public void XoaItemListView(DataTable tb, int selected)
        {
            tb.Rows.Remove(tb.Rows[selected]);
        }
    }
}
