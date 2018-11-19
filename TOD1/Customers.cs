using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOD
{
    public class Customers
    {
        public string MaKH { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        public Customers(string maNV, string ho, string ten, string ngaySinh, string gioiTinh, string diaChi, string sdt)
        {
            this.MaKH = maNV;
            this.Ho = ho;
            this.Ten = ten;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.SDT = sdt;
            
        }

    }
}
