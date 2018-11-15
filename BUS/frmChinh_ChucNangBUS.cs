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
        frmChinh_ChucNangDAo chucNang = new frmChinh_ChucNangDAo();

        /// <summary>
        /// lay gia tien cua ten banh
        /// </summary>
        /// <param name="tenBanh"></param>
        /// <returns></returns>
        public double getTienHang(string tenBanh)
        {
            return chucNang.getTienHang(tenBanh);
        }

        /// <summary>
        /// Nhap thong tin hang vao tb
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        public void GetDataRowChiTietBanh(DataTable tb, string tenHang, int MaBanh)
        {
            chucNang.GetDataRowChiTietBanh(tb, tenHang, MaBanh);
        }
        /// <summary>
        /// Xoa thong tin cua hang khoi table
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        public void RemoveDataRowHang(DataTable tb, string tenHang, int maBanh)
        {
            chucNang.RemoveDataRowHang(tb, tenHang, maBanh);
        }
        /// <summary>
        /// Lay thong tin nuoc uong cua khach vao table, Co lay so luong
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        /// <param name="SoLuong"></param>
        public void GetDataRowNuoc(DataTable tb, string tenHang, int SoLuong, int MaBanh)
        {
            chucNang.GetDataRowNuoc(tb, tenHang, SoLuong, MaBanh);
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
            
            // Xoa trong listView
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                
                if (listView1.Items[i].Selected)
                {   
                    maBanh = listView1.Items[i].Text;
                    listView1.Items[i].Remove();
                }
            }
            //for (int i = 0; i < listView1.Items.Count; i++)
            //{
            //    int sMa = int.Parse(listView1.Items[i].SubItems[0].Text);
            //    int sMaBanhBo = int.Parse(maBanh);
            //    if (sMa > sMaBanhBo)
            //    {
            //        listView1.Items[i].SubItems[0].Text = (int.Parse(listView1.Items[i].SubItems[0].Text) - 1).ToString();                    
            //    }
            //}
            // Xoa trong dataTable
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string s = tb.Rows[i]["MaBanh"].ToString();
                if (s == maBanh.ToString())
                {
                    tb.Rows.Remove(tb.Rows[i]);
                    i--;
                }
            }
            //for (int i = 0; i < tb.Rows.Count; i++)
            //{
            //    int sMa = int.Parse(tb.Rows[i]["MaBanh"].ToString());
            //    int sMaBanhBo = int.Parse(maBanh);
            //    if(sMa > sMaBanhBo)
            //    {
            //        tb.Rows[i]["MaBanh"] = (int.Parse(tb.Rows[i]["MaBanh"].ToString()) - 1); 
            //    }
            //}
        }

        /// <summary>
        /// Lay ma Banh cao nhat trong Database
        /// </summary>
        /// <returns></returns>
        public int GetMaBanh()
        {
            int kq = chucNang.GetMaBanh();
            return kq;
        }

        /// <summary>
        /// Lay ma hoa don lon nhat tu table HOADON
        /// </summary>
        /// <returns></returns>
        public int getMaHoaDon()
        {
            int kq = chucNang.getMaHoaDon();
            return kq;
        }

        /// <summary>
        /// Update du lieu tu ListView len dataBase_TableBanh
        /// </summary>
        public void updateDuLieu_Banh(int maBanh)
        {
            chucNang.updateDuLieu_Banh(maBanh);
        }
        /// <summary>
        /// Update du lieu tu ListView len dataBase_TableHoaDon_Banh
        /// </summary>
        /// <param name="maHoaDon"></param>
        /// <param name="maBanh"></param>
        public void updateDuLieuDonHang_Banh(int maHoaDon, int maBanh)
        {
            chucNang.updateDuLieuDonHang_Banh(maHoaDon, maBanh);
        }
        /// <summary>
        /// Update du lieu tu ListView len dataBase_TableHoaDon
        /// </summary>
        /// <param name="MaKhach"></param>
        /// <param name="MaNV"></param>
        /// <param name="maHoaDon"></param>
        public void updateDuLieuHoaDon(string MaKhach, string MaNV, int maHoaDon)
        {
            chucNang.updateDuLieuHoaDon(MaKhach, MaNV, maHoaDon);
        }
        /// <summary>
        /// Update du lieu tu ListView len dataBase_TableChiTietDon
        /// </summary>
        /// <param name="row"></param>
        public void updateDuLieuChiTietDon(DataRow row)
        {
            chucNang.updateDuLieuChiTietDon(row);
        }

        /// <summary>
        /// Update thong tin len cac Table Banh, HoaDon, ChiTietBanh, HoaDon_Banh
        /// </summary>
        /// <param name="MaNV"></param>
        /// <param name="MaKhach"></param>
        /// <param name="tb"></param>
        /// <param name="list"></param>
        public void ThemHoaDon(string MaNV, string MaKhach, DataTable tb, ListView list)
        {            
            if (tb.Rows.Count != 0)
            { 
                // update ddu lieu len tb HOADON
                int maHoaDon = getMaHoaDon();
                updateDuLieuHoaDon(MaKhach, MaNV, maHoaDon);
                int maBanh = GetMaBanh() - 1;
                foreach (DataRow row in tb.Rows)
                {
                    if (int.Parse(row[0].ToString()) != maBanh)
                    {
                        maBanh = int.Parse(row[0].ToString());
                        updateDuLieu_Banh(maBanh);
                        updateDuLieuDonHang_Banh(maHoaDon, maBanh);
                    }
                    updateDuLieuChiTietDon(row);
                }
                tb.Clear();
                list.Items.Clear() ;
            }
        }
    }
}
