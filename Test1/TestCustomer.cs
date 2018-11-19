using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using BUS;
using TOD;
using BaiTapLon_KiemThuPhanMem;
using System.Data;
using System.Windows.Forms;

namespace Test1
{
    /// <summary>
    /// Summary description for TestCustomer
    /// </summary>
    [TestClass]
    public class TestCustomer
    {
        CustomersBUS cus = new CustomersBUS();
        [TestMethod]
        public void TestThemKH()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C05", "Nguyễn", "Mai Vy Ly", "Nữ", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            int expected = tb.Rows.Count + 1;
            cus.Them(tb, customers);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemKHTrungMaKH()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C01", "Nguyễn", "Mai Vy Ly", "Nữ", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            int expected = tb.Rows.Count;
            cus.Them(tb, customers);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThemKHThieu1DuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C09", "", "Mai Vy Ly", "Nữ", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            int expected = tb.Rows.Count;
            cus.Them(tb, customers);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemKHThieu2DuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C09", "", "", "Nữ", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            int expected = tb.Rows.Count;
            cus.Them(tb, customers);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemKHThieu3DuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C09", "", "", "", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            int expected = tb.Rows.Count;
            cus.Them(tb, customers);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSuaKH_Ten()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C01", "Phạm Đỗ", "Thùy Linh Tinh", "Nữ", "1993-12-27", "13 Phú Thọ Hòa Q.Tân Phú", "0906745123");
            cus.Sua(tb.Rows[0], customers);
            Assert.AreEqual("Thùy Linh Tinh", tb.Rows[0][2].ToString());
        }

        [TestMethod]
        public void TestSuaKH_Ho()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C01", "Phạm Đỗ Thừa", "Thùy Linh", "Nữ", "1993-12-27", "13 Phú Thọ Hòa Q.Tân Phú", "0906745123");
            cus.Sua(tb.Rows[0], customers);
            Assert.AreEqual("Phạm Đỗ Thừa", tb.Rows[0][1].ToString());
        }

        [TestMethod]
        public void TestSuaKH_DiaChi()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C01", "Phạm Đỗ", "Thùy Linh", "Nữ", "1993-12-27", "American", "0906745123");
            cus.Sua(tb.Rows[0], customers);
            Assert.AreEqual("American", tb.Rows[0][5].ToString());
        }

        [TestMethod]
        public void TestSuaKH_GioiTinh()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C01", "Phạm Đỗ", "Thùy Linh", "Nam", "1993-12-27", "13 Phú Thọ Hòa Q.Tân Phú", "0906745123");
            cus.Sua(tb.Rows[0], customers);
            Assert.AreEqual("Nam", tb.Rows[0][4].ToString());
        }
        [TestMethod]
        public void TestXoaKH_Dau()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            int expected = tb.Rows.Count;
            cus.Del(0, tb);
            tb = new DataProvider().GetDataTableKhachHang();
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXoaKH_Cuoi()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            int expected = tb.Rows.Count;
            cus.Del(expected-1, tb);
            tb = new DataProvider().GetDataTableKhachHang();
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXoaKH_BatKi()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            int expected = tb.Rows.Count;
            cus.Del(1, tb);
            tb = new DataProvider().GetDataTableKhachHang();
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

    }
}
