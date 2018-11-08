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


        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            BUS_Employees bus = new BUS_Employees();
            dgvNhanVien.DataSource = bus.GetEmployees();
        }
    }
}
