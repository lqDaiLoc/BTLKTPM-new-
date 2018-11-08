using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOD
{
    public class Employees
    {
       
        public string MaNV { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }
        public string NgayThue { get; set; }
        public string SDT { get; set; }

        public Employees(string maNV,string ho,string ten,string ngaySinh,string gioiTinh,string chucVu,string ngayThue,string diaChi,string sdt)
        {
            this.MaNV = maNV;
            this.Ho = ho;
            this.Ten = ten;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.ChucVu = chucVu;
            this.SDT = sdt;
            this.NgayThue = ngayThue;
        }
    }
}
