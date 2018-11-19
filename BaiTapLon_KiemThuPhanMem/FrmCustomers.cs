using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOD;
using BUS;

namespace BaiTapLon_KiemThuPhanMem
{
    public partial class FrmCustomers : Form
    {
        public string maKhach = "";
        public FrmCustomers()
        {
            InitializeComponent();
        }

        CustomersBUS BUS = new CustomersBUS();
        DataTable tb_Khach;

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            tb_Khach = BUS.tb_Khach;
            dgvKhachHang.DataSource = tb_Khach;

                      
        }

        private Customers GetCustomers()
        {
            string id, ho, ten, diaChi, SDT, gioiTinh, ngaySinh;
            id = txtID.Text;
            ho = txtHo.Text;
            ten = txtTen.Text;
            diaChi = txtDiaChi.Text;
            SDT = txtSDT.Text;
            gioiTinh = cmbSex.Text;
            string format = "yyyy-MM-dd";
            ngaySinh = NgaySinh.Value.ToString(format);
            Customers cus = new Customers(id, ho, ten, ngaySinh, gioiTinh, diaChi, SDT);
            return cus;
        }
        private void clearAllTextBox()
        {
            txtID.Text = txtHo.Text = txtTen.Text = txtDiaChi.Text = txtSDT.Text = cmbSex.Text = "";
            txtID.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customers cus = GetCustomers();
            try
            {
                if (txtID.Text != null && txtTen.Text != "")
                    BUS.Them(tb_Khach, cus);
                else
                    MessageBox.Show("Nhap ID va Ten", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("Khong the them Customers", "error");
                tb_Khach = BUS.GetDataKhach();
                dgvKhachHang.DataSource = tb_Khach;
            }
            txtID.Enabled = true;
            label1.Enabled = true;
            clearAllTextBox();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Customers cus = GetCustomers();
            try
            {
                if (txtID.Text != "")
                    BUS.Sua(tb_Khach.Rows[viTri], cus);
            }
            catch (SqlException)
            {
                MessageBox.Show("Loi Sua Customers", "error");
                tb_Khach = BUS.GetDataKhach();
                dgvKhachHang.DataSource = tb_Khach;
            }
            txtID.Enabled = true;
            label1.Enabled = true;
            clearAllTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BUS.Update(tb_Khach);
            }
            catch (SqlException)
            {
                MessageBox.Show("Khong the update customer nay duoc", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Khach = BUS.GetDataKhach();
                dgvKhachHang.DataSource = tb_Khach;
            }
            clearAllTextBox();
        }

        int viTri = 0;
        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dgvKhachHang.Columns[col] is DataGridViewButtonColumn && dgvKhachHang.Columns[col].Name == "Del")
            {
                if (row >= 0 && row < dgvKhachHang.Rows.Count)
                {
                    DialogResult result = MessageBox.Show("Xoa Du Lieu: ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                        try
                        {
                            BUS.Del(row, tb_Khach);
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Khogng the xoa Customer nay vi xe anh huong den nhung csdl khac", "error");
                            tb_Khach = BUS.GetDataKhach();
                            dgvKhachHang.DataSource = tb_Khach;
                        }

                }
            }
            clearAllTextBox();
        }

        private void dgvKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            viTri = e.RowIndex;
            int numrow;
            numrow = e.RowIndex;
            if (numrow > 0)
            {
                txtID.Text = dgvKhachHang.Rows[numrow].Cells["MaKH"].Value.ToString();
                txtHo.Text = dgvKhachHang.Rows[numrow].Cells["Ho"].Value.ToString();
                txtTen.Text = dgvKhachHang.Rows[numrow].Cells["Ten"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[numrow].Cells["DiaChi"].Value.ToString();
                txtSDT.Text = dgvKhachHang.Rows[numrow].Cells["SDT"].Value.ToString();
                cmbSex.Text = dgvKhachHang.Rows[numrow].Cells["GioiTinh"].Value.ToString();
                txtID.Enabled = false;
                label1.Enabled = false;
            }
        }

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
        private void btOk_Click(object sender, EventArgs e)
        {

            if (txtKhach.Text != "")
                maKhach = txtKhach.Text;
            else
                MessageBox.Show("Phai Nhap MA KHach", "error");
            this.Close();
        }
    }
}
