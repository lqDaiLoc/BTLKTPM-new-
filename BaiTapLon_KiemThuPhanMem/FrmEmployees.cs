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
using BUS;

using TOD;
namespace BaiTapLon_KiemThuPhanMem
{
    public partial class FrmEmployees : Form
    {
        public FrmEmployees()
        {
            InitializeComponent();
        }
        DataTable tb_Emp;
        EmployeesBUS BUS = new EmployeesBUS();
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            tb_Emp = BUS.tb_NhanVien;
            dgvNhanVien.DataSource = tb_Emp;
        }

        private Employees GetEmployees()
        {
            string id, ho, ten, gioiTinh, ngaySinh, chucVu, ngayThue,  diaChi, SDT;
            id = txtId.Text;
            ho = txtHo.Text;
            ten = txtTen.Text;
            gioiTinh = cmbSex.Text;
            string format = "yyyy-MM-dd";
            ngaySinh = NgaySinh.Value.ToString(format);
            chucVu = cmbPosition.Text;
            ngayThue = NgayBDLam.Value.ToString(format);
            diaChi = txtAddress.Text;
            SDT = txtPhone.Text;
            Employees emp = new Employees(id, ho, ten, ngaySinh, gioiTinh, chucVu, ngayThue, diaChi, SDT);
            
            return emp;
        }

        private void clearAllTextBox()
        {
            txtId.Text = txtHo.Text = txtTen.Text = txtAddress.Text = txtPhone.Text = cmbSex.Text = cmbPosition.Text = NgaySinh.Text = NgayBDLam.Text = "";
            txtId.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employees emp = GetEmployees();
            try
            {
                if(txtId.Text != null && txtTen.Text != "")
                    BUS.Them(tb_Emp, emp);
                else
                    MessageBox.Show("Nhap ID va Ten", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException)
            {
                MessageBox.Show("Khong the them employess nay duoc", "error",MessageBoxButtons.OK ,MessageBoxIcon.Information);
                tb_Emp = BUS.GetDataNhanVien();
                dgvNhanVien.DataSource = tb_Emp;
            }
            txtId.Enabled = true;
            label1.Enabled = true;
            clearAllTextBox();
        }

        int viTri = 0;
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Employees emp = GetEmployees();
            try
            {
                if (txtId.Text != "")
                    BUS.Sua(tb_Emp.Rows[viTri], emp);
            }
            catch (SqlException)
            {
                MessageBox.Show("Khong the sua employess nay duoc", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Emp = BUS.GetDataNhanVien();
                dgvNhanVien.DataSource = tb_Emp;
            }
            txtId.Enabled = true;
            label1.Enabled = true;
            clearAllTextBox();
        }

        private void dgvNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            viTri = e.RowIndex;
            int numrow;
            numrow = e.RowIndex;
            if(numrow > 0)
            { 
                txtId.Text = dgvNhanVien.Rows[numrow].Cells["MaNV"].Value.ToString();
                txtHo.Text = dgvNhanVien.Rows[numrow].Cells["Ho"].Value.ToString();
                txtTen.Text = dgvNhanVien.Rows[numrow].Cells["Ten"].Value.ToString();
                cmbSex.Text = dgvNhanVien.Rows[numrow].Cells["GioiTinh"].Value.ToString();
                NgaySinh.Text = dgvNhanVien.Rows[numrow].Cells["NgaySinh"].Value.ToString();
                cmbPosition.Text = dgvNhanVien.Rows[numrow].Cells["ChucVu"].Value.ToString();
                NgayBDLam.Text = dgvNhanVien.Rows[numrow].Cells["NgayThue"].Value.ToString();
                txtAddress.Text = dgvNhanVien.Rows[numrow].Cells["DiaChi"].Value.ToString();
                txtPhone.Text = dgvNhanVien.Rows[numrow].Cells["SDT"].Value.ToString();
                txtId.Enabled = false;
                label1.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BUS.Update(tb_Emp);
            }
            catch (SqlException)
            {
                MessageBox.Show("Khong the update employess nay duoc", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Emp = BUS.GetDataNhanVien();
                dgvNhanVien.DataSource = tb_Emp;
            }
            clearAllTextBox();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dgvNhanVien.Columns[col] is DataGridViewButtonColumn && dgvNhanVien.Columns[col].Name == "Del")
            {
                if (row >= 0 && row < dgvNhanVien.Rows.Count)
                {
                    DialogResult result = MessageBox.Show("Xoa Du Lieu: ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if(result == DialogResult.OK)
                        try
                        {
                            BUS.Del(row, tb_Emp);
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Khong the xoa employess nay duoc, se anh huong den nhung csdl khac", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tb_Emp = BUS.GetDataNhanVien();
                            dgvNhanVien.DataSource = tb_Emp;
                        }
                }
            }
            clearAllTextBox();
        }

        private void FrmEmployees_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FrmChinh frm = new FrmChinh();
            //frm.Show();
            //Application.Exit();
        }
    }
}
