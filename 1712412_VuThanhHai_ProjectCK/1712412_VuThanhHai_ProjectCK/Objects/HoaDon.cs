using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1712412_VuThanhHai_ProjectCK.Objects
{
    class HoaDon
    {
        int _maHoaDon;
        int _maNhanVien;
        int _maKhachHang;
        int _tongTien;
        string _ngayLap;

        public int MaHoaDon { get => _maHoaDon; set => _maHoaDon = value; }
        public int MaNhanVien { get => _maNhanVien; set => _maNhanVien = value; }
        public int MaKhachHang { get => _maKhachHang; set => _maKhachHang = value; }
        public int TongTien { get => _tongTien; set => _tongTien = value; }
        public string NgayLap { get => _ngayLap; set => _ngayLap = value; }

        public HoaDon() { }

        public HoaDon(int maHoaDon, int maNhanVien, int maKhachHang, int tongTien, string ngayLap)
        {
            this.MaHoaDon = maHoaDon;
            this.MaNhanVien = maNhanVien;
            this.MaKhachHang = MaKhachHang;
            this.TongTien = tongTien;
            this.NgayLap = ngayLap;
        }
    }
}
