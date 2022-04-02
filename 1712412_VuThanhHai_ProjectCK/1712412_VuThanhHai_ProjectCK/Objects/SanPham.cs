using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1712412_VuThanhHai_ProjectCK.Objects
{
    class SanPham
    {
        int _maSanPham;
        int _maHangDienThoai;
        string _tenSanPham;
        int _soLuongSanPham;
        string _moTaSanPham;
        int _giaThanhSanPham;

        

        public int MaSanPham { get => _maSanPham; set => _maSanPham = value; }
        public int MaHangDienThoai { get => _maHangDienThoai; set => _maHangDienThoai = value; }
        public string TenSanPham { get => _tenSanPham; set => _tenSanPham = value; }
        public int SoLuongSanPham { get => _soLuongSanPham; set => _soLuongSanPham = value; }
        public string MoTaSanPham { get => _moTaSanPham; set => _moTaSanPham = value; }
        public int GiaThanhSanPham { get => _giaThanhSanPham; set => _giaThanhSanPham = value; }

        public SanPham() { }

        public SanPham(int maKhachHang, int maHangDienThoai, string tenSanPham, int soLuongSanPham, string moTaSanPham, int giaThanhSanPham)
        {
            this.MaSanPham = maKhachHang;
            this.MaHangDienThoai = maHangDienThoai;
            this.TenSanPham = tenSanPham;
            this.SoLuongSanPham = soLuongSanPham;
            this.MoTaSanPham = moTaSanPham;
            this.GiaThanhSanPham = giaThanhSanPham;
        }
    }
}
