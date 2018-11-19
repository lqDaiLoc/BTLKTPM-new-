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
    /// Summary description for TestChucNang
    /// </summary>
    [TestClass]
    public class TestChucNang
    {
        ListView ListSetUp;
        frmChinh_ChucNangBUS cnBUS = new frmChinh_ChucNangBUS();
        frmChinh_ChucNangDAo cnDAO = new frmChinh_ChucNangDAo();
        [TestInitialize]
        public void SetUp()
        {
            Build bill1 = new Build(1001, "BRau", "Cá Ngừ, Thịt Gà", "Thường", "Đế Dày", "Viền Phô Mai", "Nước Suối(2)", 240000);
            Build bill2 = new Build(1002, "BRau", "Cá Ngừ, Thịt Gà", "Thường", "Đế Dày", "Viền Phô Mai", "Nước Suối(2)", 240000);
            Build bill3 = new Build(1003, "BRau", "Cá Ngừ, Thịt Gà", "Thường", "Đế Dày", "Viền Phô Mai", "Nước Suối(2)", 240000);
            Build bill4 = new Build(1004, "BRau", "Cá Ngừ, Thịt Gà", "Thường", "Đế Dày", "Viền Phô Mai", "Nước Suối(2)", 240000);
            Build bill5 = new Build(1005, "BRau", "Cá Ngừ, Thịt Gà", "Thường", "Đế Dày", "Viền Phô Mai", "Nước Suối(2)", 240000);
            ListSetUp = new ListView();
            cnBUS.AddItemListView(bill1, ListSetUp);
            cnBUS.AddItemListView(bill2, ListSetUp);
            cnBUS.AddItemListView(bill3, ListSetUp);
            cnBUS.AddItemListView(bill4, ListSetUp);
            cnBUS.AddItemListView(bill5, ListSetUp);

        }
        [TestMethod]
        public void TestSubmit()
        {

            Build bill1 = new Build(1001, "BRau", "Cá Ngừ, Thịt Gà", "Thường", "Đế Dày", "Viền Phô Mai", "Nước Suối(2)", 240000);
            Build bill2 = new Build(1002, "BRau", "Cá Ngừ, Thịt Gà", "Thường", "Đế Dày", "Viền Phô Mai", "Nước Suối(2)", 240000);
            ListView List = new ListView();
            cnBUS.AddItemListView(bill1, List);
            cnBUS.AddItemListView(bill2, List);
            Assert.AreEqual(2, List.Items.Count);
        }
        [TestMethod]
        public void TestSubmit_BanhROng()
        {
            Build bill = new Build(1002, "", "Cá Ngừ, Thịt Gà", "Thường", "Đế Dày", "Viền Phô Mai", "Nước Suối(2)", 240000);
            ListView List = new ListView();
            cnBUS.AddItemListView(bill, List);
            Assert.AreEqual(0, List.Items.Count);
        }
        [TestMethod]
        public void TestDel_DongBayKy()
        {
            SetUp();
            int expected = ListSetUp.Items.Count - 1;
            cnDAO.XoaItemListView(ListSetUp, 2);
            int actual = ListSetUp.Items.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDel_DongDau()
        {
            SetUp();
            int expected = ListSetUp.Items.Count - 1;
            cnDAO.XoaItemListView(ListSetUp, 0);
            int actual = ListSetUp.Items.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDel_DongCuoi()
        {
            SetUp();
            int expected = ListSetUp.Items.Count - 1;
            cnDAO.XoaItemListView(ListSetUp, expected);
            int actual = ListSetUp.Items.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLuuDonHang_HoaDon()
        {
            DataTable tb = new DataProvider().GetDataTableDonHang();
            int expected = tb.Rows.Count + 1;
            cnBUS.updateDuLieuHoaDon("C01", "102", 100009);
            tb = new DataProvider().GetDataTableDonHang();
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
            tb.Rows[4].Delete();
            new DataProvider().updateTableDonHang(tb);
        }
        [TestMethod]
        public void TestLuuDonHang_ChiTietBanh()
        {
            DataTable tb = new DataProvider().GetDataTableChiTietBanh();
            int expected = tb.Rows.Count + 1;
            DataRow row = tb.NewRow();
            row[0] = "10";
            row[1] = "501";
            cnBUS.updateDuLieuChiTietDon(row);
            tb = new DataProvider().GetDataTableChiTietBanh();
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
            tb.Rows[1].Delete();
            new DataProvider().updateTableChiTietBanh(tb);
        }
        [TestMethod]
        public void TestLuuDonHang_Banh()
        {
            DataTable tb = new DataProvider().GetDataTableBanh();
            int expected = tb.Rows.Count + 1;
            cnBUS.updateDuLieu_Banh(999);
            tb = new DataProvider().GetDataTableBanh();
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
            tb.Rows[10].Delete();
            new DataProvider().updateTableBanh(tb);
        }
        [TestMethod]
        public void TestLuuDonHang_DonHangBanh()
        {
            DataTable tb = new DataProvider().GetDataTableDonHang_Banh();
            int expected = tb.Rows.Count + 1;
            cnDAO.updateDuLieuDonHang_Banh(100007, 27);
            tb = new DataProvider().GetDataTableDonHang_Banh();
            int actual = tb.Rows.Count;
            Assert.AreEqual(expected, actual);
            tb.Rows[4].Delete();
            new DataProvider().updateTableDonHang_Banh(tb);
        }
        
    }
}
