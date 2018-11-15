using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            BUS.Them(tb_Khach, cus);
            clearAllTextBox();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Customers cus = GetCustomers();
            BUS.Sua(tb_Khach.Rows[viTri], cus);
            txtID.Enabled = true;
            label1.Enabled = true;
            clearAllTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BUS.Update(tb_Khach);
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
                    BUS.Del(row, tb_Khach);
                }
            }
            clearAllTextBox();
        }

        private void dgvKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            viTri = e.RowIndex;
            int numrow;
            numrow = e.RowIndex;
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
}
