using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1712412_VuThanhHai_ProjectCK.Objects
{
    class HangDienThoai
    {
        int _maHangDienThoai;
        string _tenHangDienThoai;

        public int MaHangDienThoai { get => _maHangDienThoai; set => _maHangDienThoai = value; }
        public string TenHangDienThoai { get => _tenHangDienThoai; set => _tenHangDienThoai = value; }

        public HangDienThoai() { }

        public HangDienThoai(int maHangDienThoai, string tenHangDienThoai)
        {
            this.MaHangDienThoai = maHangDienThoai;
            this.TenHangDienThoai = tenHangDienThoai;
            
        }
    }
}
