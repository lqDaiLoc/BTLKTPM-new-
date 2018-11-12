using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TOD;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class BUS_ChucNang
    {

        
        /// <summary>
        /// lay gia tien cua ten banh
        /// </summary>
        /// <param name="tenBanh"></param>
        /// <returns></returns>
        public double getTienHang(string tenBanh)
        {
            double kq = 0;
            DataProvider dp = new DataProvider();
            dp.ConnecTion();
            DataTable tb_Banh = dp.GetDataTableHang();
            try
            {   
                foreach(DataRow row in tb_Banh.Rows)
                {
                    if (row[1].ToString() == (tenBanh))
                    {
                        kq = double.Parse(row[5].ToString());
                        return kq;
                    }
                }
                dp.DisConnecTion();
                return kq;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Tên Bánh Sai...", "error getTienBanh");
                throw ex;
            }
            finally
            {
                dp.DisConnecTion();
                
            }

        }

        /// <summary>
        /// Nhap thong tin hang vao tb
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        public void GetDataRowHang(DataTable tb, string tenHang, int MaBanh)
        {
            DataRow row = tb.NewRow();
            DataProvider dp = new DataProvider();
            SqlDataAdapter adapter = new SqlDataAdapter("Select MaBanh = '" + MaBanh + "', MaHang, TenHang, MaLoai, SoLuong = 1, GiaHang from Hang Where TenHang = N'" + tenHang.ToString() + "'", dp.cnn);

            adapter.Fill(tb);

        }
        /// <summary>
        /// Xoa thong tin cua hang khoi table
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        public void RemoveGetDataRowHang(DataTable tb, string tenHang, int maBanh)
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
            DataProvider dp = new DataProvider();
            SqlDataAdapter adapter = new SqlDataAdapter("Select MaBanh = '" + MaBanh + "', MaHang, TenHang, MaLoai, SoLuong = '" + SoLuong.ToString() + "' , GiaHang from Hang Where TenHang = N'" + tenHang.ToString() + "'", dp.cnn);
            adapter.Fill(tb);
        }
        /// <summary>
        /// Them bill vao listView
        /// </summary>
        /// <param name="bill"></param>
        public void AddItemListView(Build bill, ListView listView1)
        {
            ListViewItem pizza = new ListViewItem(bill.MaBanh.ToString());
            pizza.SubItems.Add(bill.TenBanh);
            pizza.SubItems.Add(bill.TpPhu);
            pizza.SubItems.Add(bill.Size);
            pizza.SubItems.Add(bill.DeBanh + " " + bill.VienBanh);
            pizza.SubItems.Add(bill.ThucUong);
            pizza.SubItems.Add(bill.TongTien.ToString());
            listView1.Items.Add(pizza);
        }
        /// <summary>
        /// Xóa những bánh nào đã được click
        /// </summary>
        /// <param name="list"></param>
        public void XoaItemListView(DataTable tb, ListView listView1)
        {
            string maBanh = "";
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    maBanh = listView1.Items[i].Text;
                    listView1.Items[i].Remove();
                }
            }
            for(int i = 0; i < tb.Rows.Count; i++)
            {
                string s = tb.Rows[i]["MaBanh"].ToString();
                if (s == maBanh.ToString())
                {
                    tb.Rows.Remove(tb.Rows[i]);
                    i--;
                }
            }
        }

        /// <summary>
        /// Lay ma Banh cao nhat trong Database
        /// </summary>
        /// <returns></returns>
        public int GetMaBanh()
        {
            int max = 0;
            DataTable tb_Banh = new DataProvider().GetDataTableBanh();
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
            DataTable tb_HoaDon = new DataProvider().GetDataTableDonHang();
            if(tb_HoaDon.Rows[0][0].ToString() !=  null)
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

        public void updateDuLieu_Banh()
        {
            DataTable tbBanh = new DataProvider().GetDataTableBanh();
            DataRow rowBanh = tbBanh.NewRow();
            rowBanh[0] = GetMaBanh();
            tbBanh.Rows.Add(rowBanh);
            new DataProvider().updateTableBanh(tbBanh);
        }
        public void updateDuLieuDonHang_Banh()
        {

        }
        public void ThemHoaDon(string MaNV, string MaKhach, DataTable tb, ListView list)
        {            
            if (tb.Rows.Count != 0)
            {
                // update ddu lieu len tb HOADON
                DataTable tbDonHang = new DataProvider().GetDataTableDonHang();
                DataRow rowDonHang = tbDonHang.NewRow();
                int maHoaDon = getMaHoaDon();
                rowDonHang[0] = maHoaDon;
                rowDonHang[1] = MaKhach;
                rowDonHang[2] = MaNV;
                tbDonHang.Rows.Add(rowDonHang);
                new DataProvider().updateTableDonHang(tbDonHang);
                int maBanh = GetMaBanh() - 1;
                foreach (DataRow row in tb.Rows)
                {
                    if (int.Parse(row[0].ToString()) != maBanh)
                    {
                        maBanh = int.Parse(row[0].ToString());
                        //update du lieu len tb Banh
                        DataTable tbBanh = new DataProvider().GetDataTableBanh();
                        DataRow rowBanh = tbBanh.NewRow();
                        rowBanh[0] = GetMaBanh();
                        tbBanh.Rows.Add(rowBanh);
                        new DataProvider().updateTableBanh(tbBanh);
                        //updateDuLieu_Banh();

                        //updata du lieu len tb HoaDOn_Banh
                        DataTable tbHoaDon_Banh = new DataProvider().GetDataTableDonHang_Banh();
                        DataRow rowHoaDon_Banh = tbHoaDon_Banh.NewRow();
                        rowHoaDon_Banh[0] = maHoaDon;
                        rowHoaDon_Banh[1] = maBanh;
                        tbHoaDon_Banh.Rows.Add(rowHoaDon_Banh);
                        new DataProvider().updateTableDonHang_Banh(tbHoaDon_Banh);
                    }
                    DataTable tbChiTiet = new DataProvider().GetDataTableChiTietBanh();
                    DataRow rowChiTietBanh = tbChiTiet.NewRow();
                    rowChiTietBanh[0] = row[0];
                    rowChiTietBanh[1] = row[1];
                    rowChiTietBanh[2] = row[2];
                    rowChiTietBanh[3] = row[3];
                    rowChiTietBanh[4] = row[4];
                    rowChiTietBanh[5] = row[5];
                    tbChiTiet.Rows.Add(rowChiTietBanh);
                    new DataProvider().updateTableChiTietBanh(tbChiTiet);
                }
                tb.Clear();
                list.Clear();
            }
            
        }
        

    }
}
