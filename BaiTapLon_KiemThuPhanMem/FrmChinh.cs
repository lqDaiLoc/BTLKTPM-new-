﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using TOD;


namespace BaiTapLon_KiemThuPhanMem
{
    public partial class FrmChinh : Form
    {
        
        public FrmChinh()
        {
            InitializeComponent();
        }
        DataTable tbDonHang = new DataTable();
        DataTable tbtmp = new DataTable();
        BUS_ChucNang bus = new BUS_ChucNang();
        bool flag = true;
        double tienNuoc = 0;
        double tienLoaiPizza = 0;
        double tienVoBanh = 0;
        double tienSize = 1;
        double tienTpPhu = 0;
        double tongTien = 0;
        int MaBanh_ = 0;
        int i = 0;


        private void FrmChinh_Load(object sender, EventArgs e)
        {
            MaBanh_ = bus.GetMaBanh();
            this.Visible = false;
            frmLogin frm = new frmLogin();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
                // Neu la Manager thi cho phep them 1 so chuc nang nua
                // con ko phai la Manager thi chuc nang nhap tt khach va nhap tt nv ko dc mo~
                string loai = frm.chucVu;
                if (loai == "1")
                {
                    btnNhapTTKhach.Enabled = true;  
                    btnNhapTTNhanVien.Enabled = true;
                }
            }
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        //Chon Ten Banh
        private void CheckedChange_radTenBanh(object sender, EventArgs e)
        {
            string tenBanh;
            RadioButton rad = sender as RadioButton;
            tenBanh = rad.Text;
            lblTenBanh.Text = tenBanh;
            tienLoaiPizza = bus.getTienHang(tenBanh);
            lblTienTenBanh.Text = tienLoaiPizza.ToString();

            if (rad.Checked == true)
                bus.GetDataRowChiTietBanh(tbDonHang, tenBanh, MaBanh_);
            else
                if (!rad.Checked && flag != false)
                    bus.RemoveDataRowHang(tbDonHang, tenBanh,MaBanh_);
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        ////Chon Size
        private void CheckedChange_radSize(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            lblSize.Text = rad.Text;
            tienSize = bus.getTienHang(rad.Text);
            lblTienSize.Text = "x" + tienSize.ToString();

            if (rad.Checked)
                bus.GetDataRowChiTietBanh(tbDonHang, rad.Text, MaBanh_);
            else
                if(!rad.Checked && flag != false)
                    bus.RemoveDataRowHang(tbDonHang, rad.Text, MaBanh_);
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        //Chon nước uống
        private void btnChonNuoc_Click(object sender, EventArgs e)
        {
            lblThucUong.Text = "";
            tienNuoc = 0;
            int slCoCa = int.Parse(txtSoLuongCoCa.Text);
            txtSoLuongCoCa.Text = slCoCa.ToString();
            if (slCoCa != 0)
            {
                bus.GetDataRowNuoc(tbDonHang, "CoCa", slCoCa, MaBanh_);
                lblThucUong.Text += "CoCa (" + slCoCa + ")\n";
                tienNuoc += (bus.getTienHang("CoCa")) * slCoCa;
            }
            int slSuprise = int.Parse(txtSoLuongSuprise.Text);
            txtSoLuongSuprise.Text = slSuprise.ToString();
            if (slSuprise != 0)
            {
                bus.GetDataRowNuoc(tbDonHang, "Suprise", slSuprise, MaBanh_);
                lblThucUong.Text += "Suprise (" + slSuprise + ")\n";
                tienNuoc += (bus.getTienHang("Suprise")) * slSuprise;
            }
            int slNumber1 = int.Parse(txtSoLuongNumberOne.Text);
            txtSoLuongNumberOne.Text = slNumber1.ToString();
            if (slNumber1 != 0)
            {
                bus.GetDataRowNuoc(tbDonHang, "Number One", slNumber1, MaBanh_);
                lblThucUong.Text += "Number One (" + slNumber1 + ")\n";
                tienNuoc += (bus.getTienHang("Number One")) * slNumber1;
            }
            int slSuoi = int.Parse(txtSoLuongSuoi.Text);
            txtSoLuongSuoi.Text = slSuoi.ToString();
            if (slSuoi != 0)
            {
                bus.GetDataRowNuoc(tbDonHang, "Nước Suối", slSuoi, MaBanh_);
                lblThucUong.Text += "Nước Suối (" + slSuoi + ")\n";
                tienNuoc += (bus.getTienHang("Nước Suối")) * slSuoi;
            }
            int slDrThanh = int.Parse(txtSoLuongDrThanh.Text);
            txtSoLuongDrThanh.Text = slDrThanh.ToString();
            if (slDrThanh != 0)
            {
                bus.GetDataRowNuoc(tbDonHang, "DrThanh", slDrThanh, MaBanh_);
                lblThucUong.Text += "DrThanh (" + slDrThanh + ")\n";
                tienNuoc += (bus.getTienHang("DrThanh")) * slDrThanh;
            }
            int slPepsi = int.Parse(txtSoLuongPesi.Text);
            txtSoLuongPesi.Text = slPepsi.ToString();
            if (slPepsi != 0)
            {
                bus.GetDataRowNuoc(tbDonHang, "Pepsi", slPepsi, MaBanh_);
                lblThucUong.Text += "Pepsi (" + slPepsi + ")\n";
                tienNuoc += (bus.getTienHang("Pepsi")) * slPepsi;
            }
            int slCam = int.Parse(txtSoLuongCam.Text);
            txtSoLuongCam.Text = slCam.ToString();
            if (slCam != 0)
            {
                bus.GetDataRowNuoc(tbDonHang, "Cam", slCam, MaBanh_);
                lblThucUong.Text += "Cam (" + slCam + ")\n";
                tienNuoc += (bus.getTienHang("Cam")) * slCam;
            }
            int slBiDao = int.Parse(txtSoLuongBiDao.Text);
            txtSoLuongBiDao.Text = slBiDao.ToString();
            if (slBiDao != 0)
            {
                bus.GetDataRowNuoc(tbDonHang, "Bí Đao", slBiDao, MaBanh_);
                lblThucUong.Text += "Bí Đao (" + slBiDao + ")\n";
                tienNuoc += (bus.getTienHang("Bí Đao")) * slBiDao;
            }
            int slSting = int.Parse(txtSoLuongSting.Text);
            txtSoLuongSting.Text = slSting.ToString();
            if (slSting != 0)
            {
                bus.GetDataRowNuoc(tbDonHang, "Sting", slSting, MaBanh_);
                lblThucUong.Text += "Sting (" + slSting + ")\n";
                tienNuoc += (bus.getTienHang("Sting")) * slSting;
            }
            int slSoda = int.Parse(txtSoLuongSoda.Text);
            txtSoLuongSoda.Text = slSoda.ToString();
            if (slSoda != 0)
            {
                bus.GetDataRowNuoc(tbDonHang, "SoDa", slSoda, MaBanh_);
                lblThucUong.Text += "SoDa (" + slSoda + ")\n";
                tienNuoc += (bus.getTienHang("SoDa")) * slSoda;
            }
            lblTienNuoc.Text = tienNuoc.ToString();
            tongTien += tienNuoc;

        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        // CHon tp Phu
        private void CheckedChanged_TpPhu(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            if (check.Checked)
            {
                flag = true;
                bus.GetDataRowChiTietBanh(tbDonHang, check.Text, MaBanh_);
                lblTpPhu.Text += check.Text + ", ";
                tienTpPhu += bus.getTienHang(check.Text);
            }
            else
            {
                if (!check.Checked && flag != false)
                {
                    bus.RemoveDataRowHang(tbDonHang, check.Text, MaBanh_);
                    lblTpPhu.Text = lblTpPhu.Text.Replace(check.Text + ", ", "");
                    tienTpPhu -= bus.getTienHang(check.Text);
                }
            }
            lblTienPhu.Text = tienTpPhu.ToString();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        // Chon De Banh
        private void CheckedChang_DeBanh(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            lblDeBanh.Text = "Đế Bánh " + rad.Text;
            if (rad.Checked)
                bus.GetDataRowChiTietBanh(tbDonHang, rad.Text, MaBanh_);
            else
                if (!rad.Checked && flag)
                    bus.RemoveDataRowHang(tbDonHang, rad.Text, MaBanh_);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        // Chon Vien Banh
        private void CheckedChang_VienBanh(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            lblVienBanh.Text = rad.Text;
            if (rad.Checked)
            {   
                tienVoBanh = bus.getTienHang(rad.Text);
                bus.GetDataRowChiTietBanh(tbDonHang, rad.Text, MaBanh_);
            }
            else
            {
                if(!rad.Checked && flag)
                {
                    tienVoBanh -= bus.getTienHang(rad.Text);
                    bus.RemoveDataRowHang(tbDonHang, rad.Text, MaBanh_);
                }
            }
            lblTienVoBanh.Text = tienVoBanh.ToString();
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        private bool isNumber(string s)
        {
            char[] arr;
            arr = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
                if (!char.IsDigit(arr[i]))
                    return false;
            return true;
            
        }

        private void TextChanged_ThucUong(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            
            if (!isNumber(txt.Text))
                errorProvider1.SetError(txt, "Phải nhập số");
            else
                errorProvider1.Clear();
            if (String.IsNullOrWhiteSpace(txt.Text))
                txt.Text = "0";
                        
            
        }
//--------------------------------------------------------------------------------------------------------------------------------------       
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lblTenBanh.Text != "")
            {   
                tongTien = (tienVoBanh + tienTpPhu + tienNuoc + tienLoaiPizza) * tienSize;
                Build bill = new Build(MaBanh_,lblTenBanh.Text, lblTpPhu.Text, lblSize.Text, lblDeBanh.Text, lblVienBanh.Text, lblThucUong.Text, tongTien);
                bus.AddItemListView(bill, listView1);

                //Test Up dataTable lên gridView để dễ xem và kiểm xoát  --- Sẽ Xóa
                //----------------------------------------------------------------------------------------------------------
                dataGridView1.DataSource = tbDonHang;
                tbtmp = tbDonHang;

                //----------------------------------------------------------------------------------------------------------
                //i++;
                MaBanh_ ++;
                //----------------------------------------------------------------------------------------------------------
                // Thanh phan phu
                flag = false;
                checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = checkBox4.Checked = checkBox5.Checked = false;
                checkBox6.Checked = checkBox7.Checked = checkBox8.Checked = checkBox9.Checked = false;
                checkBox10.Checked = checkBox11.Checked = checkBox12.Checked = false;
                // Size
                radLon.Checked = radNho.Checked = radThuong.Checked = false;
                // Ten Banh
                radHaiSan.Checked = radXucXich.Checked = radThapCam.Checked = radTom.Checked = radRau.Checked = false;
                // De Banh
                radDeBanh_Day.Checked = radDeBanh_Mong.Checked = radDeBanh_Vua.Checked = radVienPhoMai.Checked = radVienXucXich.Checked = false;
                // Thuc Uong
                txtSoLuongBiDao.Text = txtSoLuongCam.Text = txtSoLuongCoCa.Text = txtSoLuongDrThanh.Text = txtSoLuongNumberOne.Text = "0";
                txtSoLuongPesi.Text = txtSoLuongSoda.Text = txtSoLuongSting.Text = txtSoLuongSuoi.Text = txtSoLuongSuprise.Text = "0";
                // cac label 
                lblVienBanh.Text = lblDeBanh.Text = lblSize.Text = lblTenBanh.Text = lblThucUong.Text = lblTpPhu.Text = "";

                // tiền các loại
                tienLoaiPizza = tienNuoc = tienSize = tienTpPhu = tienVoBanh = 0;
                // label tien
                lblTienNuoc.Text = lblTienPhu.Text = lblTienSize.Text = lblTienTenBanh.Text = lblTienVoBanh.Text = "";
                //----------------------------------------------------------------------------------------------------------
                flag = true;
                return;
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập bánh!!!", "Cảnh báo", MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Tên Bánh
            
            // Thành phần phũ 
        }
        private void btnXoaBill_Click(object sender, EventArgs e)
        {
            bus.XoaItemListView(tbDonHang,listView1);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bus.ThemHoaDon(txtNhanVien.Text, txtKhach.Text, tbDonHang, listView1);
            dataGridView1.DataSource = tbDonHang;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnTKiem_Click(object sender, EventArgs e)
        {
            //frmFind frm = new frmFind();
            //frm.ShowDialog();
        }
    }
}
