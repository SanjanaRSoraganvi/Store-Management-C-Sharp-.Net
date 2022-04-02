using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1712412_VuThanhHai_ProjectCK.Objects
{
    class ChiTietHoaDon
    {
        int _maHoaDon;
        int _maSanPham;
        int _soLuong;
        int _donGia;

        public int MaHoaDon { get => _maHoaDon; set => _maHoaDon = value; }
        public int MaSanPham { get => _maSanPham; set => _maSanPham = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public int DonGia { get => _donGia; set => _donGia = value; }

        public ChiTietHoaDon() { }

        public ChiTietHoaDon(int maHoaDon, int maSanPham, int soLuong, int donGia)
        {
            this.MaHoaDon = maHoaDon;
            this.MaSanPham = maSanPham;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
        }
    }
}
