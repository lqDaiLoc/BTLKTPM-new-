using System;
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
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        DataTable TbEm;
        BUS_Employees bus = new BUS_Employees();
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            TbEm = bus.GetEmployees();
            dgvNhanVien.DataSource = TbEm;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id, ho, ten, diaChi, SDT,gioiTinh, chucVu, ngaySinh, ngayThue;
            id = txtId.Text;
            ho = txtHo.Text;
            ten = txtTen.Text;
            diaChi = txtAddress.Text;
            SDT = txtPhone.Text;
            gioiTinh = cmbSex.Text;
            chucVu = cmbPosition.Text;
            string format = "yyyy-MM-dd";
            ngaySinh = NgaySinh.Value.ToString(format);
            ngayThue = NgayBDLam.Value.ToString(format);
            Employees em = new Employees(id, ho, ten, ngaySinh, gioiTinh, chucVu, ngayThue, diaChi, SDT);
            //bus.Them(TbEm, em);
            
        }
    }
}
