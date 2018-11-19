using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using BUS;
using TOD;
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
            int expected = 3;
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
            expected = 2;
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
            int expected = 4;
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
            expected = 3;
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
        EmployeesDAO emp = new EmployeesDAO();
        [TestMethod]
        public void TestThemNV()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("109", "", "", "", "", "", "", "", "");
            emp.Them(tb, employees);
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVThieu1()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("109", "123", "", "", "", "", "", "", "");
            emp.Them(tb, employees);
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestThemNVThieu2()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("109", "", "123", "", "", "", "", "", "");
            emp.Them(tb, employees);
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVThieu3()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("109", "", "", "", "123", "", "", "", "");
            emp.Them(tb, employees);
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVTrung()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            DataRow row = tb.NewRow();
            Employees employees = new Employees("101", "", "", "", "123", "", "", "", "");
            emp.Them(tb, employees);
            int expected = 4;
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSuaNV_Ten()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("104", "Nguyễn Ngọc", "Mai Vy Ly", "1997 - 10 - 10", "Nữ", "Agent", "2018 - 03 - 01", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "01278912034");
            emp.Sua(tb.Rows[3], employees);
            Assert.AreEqual("Mai Vy Ly", tb.Rows[3][2].ToString());
        }
        [TestMethod]
        public void TestSuaNV_Ho()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("104", "Nguyễn", "Mai Vy Ly", "1997 - 10 - 10", "Nữ", "Agent", "2018 - 03 - 01", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "01278912034");
            emp.Sua(tb.Rows[3], employees);
            Assert.AreEqual("Nguyễn", tb.Rows[3][1].ToString());
        }
        [TestMethod]
        public void TestSuaNV_SDT()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("104", "Nguyễn", "Mai Vy Ly", "1997 - 10 - 10", "Nữ", "Agent", "2018 - 03 - 01", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            emp.Sua(tb.Rows[3], employees);
            Assert.AreEqual("0125", tb.Rows[3][8].ToString());
        }
        CustomersBUS cus = new CustomersBUS();
        [TestMethod]
        public void TestThemKH()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("104", "Nguyễn", "Mai Vy Ly", "Nữ", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            int expected = tb.Rows.Count + 1;
            cus.Them(tb, customers);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemKHTrung()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C01", "Nguyễn", "Mai Vy Ly", "Nữ", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            int expected = tb.Rows.Count;
            cus.Them(tb, customers);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThemKHThieuDuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableKhachHang();
            Customers customers = new Customers("C09", "23123", "", "", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            int expected = tb.Rows.Count;
            cus.Them(tb, customers);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSuaKH_Ten()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Customers customers = new Customers("C01", "23123", "", "", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            cus.Sua(tb.Rows[0], customers);
            Assert.AreEqual("23123", tb.Rows[0][1].ToString());
        }

        [TestMethod]
        public void TestSuaKH_Ho()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Customers customers = new Customers("C01", "23123", "", "", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            cus.Sua(tb.Rows[0], customers);
            Assert.AreEqual("", tb.Rows[0][2].ToString());
        }

        [TestMethod]
        public void TestSuaKH_SDT()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Customers customers = new Customers("C01", "23123", "", "", "1997 - 10 - 10", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            cus.Sua(tb.Rows[0], customers);
            Assert.AreEqual("0125", tb.Rows[0][6].ToString());
        }
    }
}
