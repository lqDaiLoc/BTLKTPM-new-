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
    /// Summary description for TestLogin
    /// </summary>
    [TestClass]
    public class TestLogin
    {
        LoginBUS login;
        [TestInitialize]
        public void SetUp()
        {
            login = new LoginBUS();
        }
        [TestMethod]
        public void TestLoginQuanLy()
        {
            SetUp();
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
    }
}
