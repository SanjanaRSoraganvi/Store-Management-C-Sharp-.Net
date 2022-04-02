using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1712412_VuThanhHai_ProjectCK.Objects
{
    class KhachHang
    {
        int     _maKhachHang;
        string _tenKhachHang;
        string _diaChiKhachHang;
        string _sdtKhachHang;
        string _gioiTinhKhachHang;

        public int MaKhachHang { get => _maKhachHang; set => _maKhachHang = value; }
        public string TenKhachHang { get => _tenKhachHang; set => _tenKhachHang = value; }
        public string DiaChiKhachHang { get => _diaChiKhachHang; set => _diaChiKhachHang = value; }
        public string SdtKhachHang { get => _sdtKhachHang; set => _sdtKhachHang = value; }
        public string GioiTinhKhachHang { get => _gioiTinhKhachHang; set => _gioiTinhKhachHang = value; }


        public KhachHang() { }

        public KhachHang(int maKhachHang, string tenKhachHang, string diaChiKhachHang, string sdtKhachHang, string gioiTinhKhachHang)
        {
            this.MaKhachHang = maKhachHang;
            this.TenKhachHang = tenKhachHang;
            this.DiaChiKhachHang = diaChiKhachHang;
            this.SdtKhachHang = sdtKhachHang;
            this.GioiTinhKhachHang = gioiTinhKhachHang;
        }
    }
}
