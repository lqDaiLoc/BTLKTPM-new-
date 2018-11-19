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
    public class TestEmloyees
    {
        EmployeesDAO emp = new EmployeesDAO();
        
        [TestInitialize]
        public void SetUp()
        {
            
        }
        [TestMethod]
        public void TestThemNV()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("109", "Nguyen Thi", "Binh",  "1987-02-14", "Nu", "Supervisor", "2018-01-01", "TpHCM", "0167496339");
            int expected = tb.Rows.Count + 1;
            emp.Them(tb, employees);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVThieu7DuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("109", "Nguyen Thi", "", "", "", "", "", "", "");
            int expected = tb.Rows.Count;
            emp.Them(tb, employees);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVThieu6DuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("109", "Nguyen Thi", "Binh", "", "", "", "", "", "");
            int expected = tb.Rows.Count;
            emp.Them(tb, employees);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVThieu5DuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("109", "Nguyen Thi", "Binh", "1987-02-14", "", "", "", "", "");
            int expected = tb.Rows.Count;
            emp.Them(tb, employees);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVThieu4DuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            int expected = tb.Rows.Count;
            Employees employees = new Employees("109", "Nguyen Thi", "Binh", "1987-02-14", "Nu", "", "", "", "");
            emp.Them(tb, employees);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVThieu3DuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            int expected = tb.Rows.Count;
            Employees employees = new Employees("109", "Nguyen Thi", "Binh", "1987-02-14", "Nu", "Supervisor", "", "", "");
            emp.Them(tb, employees);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVThieu2DuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            int expected = tb.Rows.Count;
            Employees employees = new Employees("109", "Nguyen Thi", "Binh", "1987-02-14", "Nu", "Supervisor", "2018-01-01", "", "");
            emp.Them(tb, employees);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVThieu1DuLieu()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("109", "Nguyen Thi", "Binh", "1987-02-14", "Nu", "Supervisor", "2018-01-01", "TpHCM", "");
            int expected = tb.Rows.Count;
            emp.Them(tb, employees);
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemNVTrungMaNV()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            DataRow row = tb.NewRow();
            int expected = tb.Rows.Count;
            Employees employees = new Employees("101", "Nguyen Thi", "Binh", "1987-02-14", "Nu", "Supervisor", "2018-01-01", "TpHCM", "");
            emp.Them(tb, employees);
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
            Employees employees = new Employees("104", "Nguyễn", "Mai Vy", "1997 - 10 - 10", "Nữ", "Agent", "2018 - 03 - 01", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "01278912034");
            emp.Sua(tb.Rows[3], employees);
            Assert.AreEqual("Nguyễn", tb.Rows[3][1].ToString());
        }
        [TestMethod]
        public void TestSuaNV_SDT()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("104", "Nguyễn Ngọc", "Mai Vy", "1997 - 10 - 10", "Nữ", "Agent", "2018 - 03 - 01", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "0125");
            emp.Sua(tb.Rows[3], employees);
            Assert.AreEqual("0125", tb.Rows[3][8].ToString());
        }
        [TestMethod]
        public void TestSuaNV_GioiTinh()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("104", "Nguyễn Ngoc", "Mai Vy", "1997 - 10 - 10", "Nam", "Agent", "2018 - 03 - 01", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "01278912034");
            emp.Sua(tb.Rows[3], employees);
            Assert.AreEqual("Nam", tb.Rows[3][3].ToString());
        }
        [TestMethod]
        public void TestSuaNV_NgaySinh()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            Employees employees = new Employees("104", "Nguyễn Ngoc", "Mai Vy", "2000 - 10 - 10", "Nữ", "Agent", "2018 - 03 - 01", "9 Nguyễn Ảnh Thủ H.Hóc Môn", "01278912034");
            emp.Sua(tb.Rows[3], employees);
            Assert.AreEqual("2000 - 10 - 10", tb.Rows[3][4].ToString());
        }
        [TestMethod]
        public void TestXoaNV_BatKi()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            int expected = tb.Rows.Count;
            emp.Del(1, tb);
            tb = new DataProvider().GetDataTableNhanVien();
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXoaNV_Dau()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            int expected = tb.Rows.Count;
            emp.Del(0, tb);
            tb = new DataProvider().GetDataTableNhanVien();
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXoaNV_Cuoi()
        {
            DataTable tb = new DataProvider().GetDataTableNhanVien();
            int expected = tb.Rows.Count;
            emp.Del(expected-1, tb);
            tb = new DataProvider().GetDataTableNhanVien();
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
