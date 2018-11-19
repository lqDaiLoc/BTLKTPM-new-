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
    
    [TestClass]
    public class TestDataProvider
    {
        [TestMethod]
        public void TestGetDataSet()
        {
            DataSet ds = new DataProvider().GetDataSet();
            int expected = 10;
            int actual = ds.Tables.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableBanh()
        {
            DataTable tb = new DataProvider().GetDataTableBanh();
            int expected = 24;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableChiTietBanh()
        {
            DataTable tb = new DataProvider().GetDataTableChiTietBanh();
            int expected = 1;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableDonHang()
        {
            DataTable tb = new DataProvider().GetDataTableDonHang();
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableDonHang_Banh()
        {
            DataTable tb = new DataProvider().GetDataTableDonHang_Banh();
            int expected = 5;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableHang()
        {
            DataTable tb = new DataProvider().GetDataTableHang();
            int expected = 35;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableKhachHang()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            int expected = 3;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableLoai()
        {
            DataTable tb = new DataProvider().GetDataTableLoai();
            int expected = 5;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableNhaCungCap()
        {
            DataTable tb = new DataProvider().GetDataTableNhaCungCap();
            int expected = 2;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableNhanVien()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableUsers()
        {
            DataTable tb = new DataProvider().GetDataTableUsers();
            int expected = 2;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateBanh()
        {
            DataTable tb = new DataProvider().GetDataTableBanh();
            DataRow row = tb.NewRow();
            row[0] = 100;
            tb.Rows.Add(row);
            int expected = 25;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
            foreach (DataRow item in tb.Rows)
            {
                if (item[0].ToString() == "100")
                {
                    item.Delete();
                    break;
                }
            }
            new DataProvider().updateTableBanh(tb);
            expected = 24;
            actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateChiTietBanh()
        {
            DataTable tb = new DataProvider().GetDataTableChiTietBanh();
            DataRow row = tb.NewRow();
            row[0] = 100;
            row[1] = 501;
            row[2] = "Thịt gà";
            row[3] = 11;
            row[4] = 1;
            row[5] = 39000;
            tb.Rows.Add(row);
            int expected = 2;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
            foreach (DataRow item in tb.Rows)
            {
                if (item[0].ToString() == "100")
                {
                    item.Delete();
                    break;
                }
            }
            new DataProvider().updateTableChiTietBanh(tb);
            expected = 1;
            actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateDonHang()
        {
            DataTable tb = new DataProvider().GetDataTableDonHang();
            DataRow row = tb.NewRow();
            row[0] = 100002;
            row[1] = "C01";
            row[2] = "102";
            row[3] = DateTime.Today;
            tb.Rows.Add(row);
            int expected = 5;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
            foreach (DataRow item in tb.Rows)
            {
                if (item[0].ToString() == "100002")
                {
                    item.Delete();
                    break;
                }
            }
            new DataProvider().updateTableDonHang(tb);
            expected = 4;
            actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateDonHang_Banh()
        {
            DataTable tb = new DataProvider().GetDataTableDonHang_Banh();
            DataRow row = tb.NewRow();
            row[0] = 100002;
            row[1] = 1;
            tb.Rows.Add(row);
            int expected = 6;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
            foreach (DataRow item in tb.Rows)
            {
                if (item[0].ToString() == "100002")
                {
                    item.Delete();
                    break;
                }
            }
            new DataProvider().updateTableDonHang_Banh(tb);
            expected = 5;
            actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateKhachHang()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            DataRow row = tb.NewRow();
            row[0] = "C05";
            row[1] = "Nguyễn";
            row[2] = "Minh Nhật";
            row[3] = "Nam";
            row[4] = "1993-04-01";
            row[5] = "21 Nguyễn Văn Nguyễn Q.1";
            row[6] = "0908750234";
            row[7] = "";
            tb.Rows.Add(row);
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
            foreach (DataRow item in tb.Rows)
            {
                if (item[0].ToString() == "C05")
                {
                    item.Delete();
                    break;
                }
            }
            new DataProvider().updateTableKhach(tb);
            expected = 3;
            actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateNhanVien()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            DataRow row = tb.NewRow();
            row[0] = "103";
            row[1] = "Hoàng Cao";
            row[2] = "Băng Tâm";
            row[3] = "Nữ";
            row[4] = "1994-04-04";
            row[5] = "Sr Agent";
            row[6] = "2018-02-01";
            row[7] = "7 Phùng Văn Cung Q.Phú Nhuận";
            row[8] = "01268887672";
            tb.Rows.Add(row);
            int expected = 5;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
            foreach (DataRow item in tb.Rows)
            {
                if (item[0].ToString() == "103")
                {
                    item.Delete();
                    break;
                }
            }
            new DataProvider().updateTableNhanVien(tb);
            expected = 4;
            actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
