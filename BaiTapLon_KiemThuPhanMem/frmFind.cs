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

namespace BaiTapLon_KiemThuPhanMem
{
    public partial class frmFind : Form
    {
        SqlConnection cnn;
        SqlDataAdapter da;
        DataSet ds;
        public frmFind()
        {
            InitializeComponent();
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = QLBanPizzaNew; Integrated security = true;";
            cnn = new SqlConnection(cnStr);
            //Gọi phương thức Load DL
            LoadDuLieu("SELECT * FROM DonHang");
        }

        private void LoadDuLieu(String sql)
        {
            ds = new DataSet();
            da = new SqlDataAdapter(sql, cnn);
            da.Fill(ds);
            dgvKetQua.DataSource = ds.Tables[0];
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM DonHang";
            String dk = "";
            //Tim theo MaNV khac rong
            if (txtMaNV.Text.Trim() != "")
            {
                dk += " MaNV LIKE '%" + txtMaNV.Text + "%'";
            }
            //kiem tra NgayDat va MaNV khac rong
            if (txtNgayDat.Text.Trim() != "" && dk != "")
            {
                dk += " AND NgayDat LIKE N'%" + txtNgayDat.Text + "%'";
            }
            //Tim kiem theo NgayDat khi MaKH la rong
            if (txtNgayDat.Text.Trim() != "" && dk == "")
            {
                dk += " NgayDat LIKE N'%" + txtNgayDat.Text + "%'";
            }
            //Ket hoi dk
            if (dk != "")
            {
                sql += " WHERE" + dk;
            }
            //Goi phương thức Load dữ liệu kết hợp điều kiện tìm kiếm
            LoadDuLieu(sql);
        }
    }
}
