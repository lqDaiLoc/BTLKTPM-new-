using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using BUS;
using BaiTapLon_KiemThuPhanMem;
using System.Data;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        LoginBUS login = new LoginBUS();
        [TestInitialize]
        public void SetUp()
        {

        }
        [TestMethod]
        public void TestLoginQuanLy()
        {
            bool expected = true;
            bool actual = true;
            string user = "admin";
            string pass = "123";
            if (login.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLoginNullID()
        {
            SetUp();
            bool expected = false;

            string user = "";
            string pass = "sasa";
            bool actual = true;
            if (login.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLoginNullPass()
        {
            SetUp();
            bool expected = false;

            string user = "admin";
            string pass = "";
            bool actual = true;
            if (login.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLoginNullAll()
        {
            SetUp();
            bool expected = false;

            string user = "";
            string pass = "";
            bool actual = true;
            if (login.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLoginGetManager()
        {
            SetUp();
            string expected = "1";

            string user = "admin";
            string pass = "123";
            string actual = "1";
            if (login.Login(user, pass) == true)
            {
                actual = login.chucVu;

            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLoginGetEmployee()
        {
            SetUp();
            string expected = "2";

            string user = "NguyenMinhDiem";
            string pass = "NguyenMinhDiem";
            string actual = "2";
            if (login.Login(user, pass) == true)
            {
                actual = login.chucVu;

            }
            Assert.AreEqual(expected, actual);
        }

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
            int expected = 22;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableChiTietBanh()
        {
            DataTable tb = new DataProvider().GetDataTableChiTietBanh();
            int expected = 26;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableDonHang()
        {
            DataTable tb = new DataProvider().GetDataTableDonHang();
            int expected = 2;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDataTableDonHang_Banh()
        {
            DataTable tb = new DataProvider().GetDataTableDonHang_Banh();
            int expected = 3;
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
            int expected = 23;
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
            expected = 22;
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
            int expected = 27;
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
            expected = 26;
            actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
