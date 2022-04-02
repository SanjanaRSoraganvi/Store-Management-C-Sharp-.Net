using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1712412_VuThanhHai_ProjectCK.Objects
{
    class NhanVien
    {
        int     _maNhanVien;
        string  _tenNhanVien;
        string  _userNhanVien;
        string  _passwordNhanVien;
        string  _diaChiNhanVien;
        string  _sdtNhanVien;
        string _gioiTinhNhanVien;

        public int MaNhanVien { get => _maNhanVien; set => _maNhanVien = value; }
        public string TenNhanVien { get => _tenNhanVien; set => _tenNhanVien = value; }
        public string UserNhanVien { get => _userNhanVien; set => _userNhanVien = value; }
        public string PasswordNhanVien { get => _passwordNhanVien; set => _passwordNhanVien = value; }
        public string DiaChiNhanVien { get => _diaChiNhanVien; set => _diaChiNhanVien = value; }
        public string SdtNhanVien { get => _sdtNhanVien; set => _sdtNhanVien = value; }
        public string GioiTinhNhanVien { get => _gioiTinhNhanVien; set => _gioiTinhNhanVien = value; }

        public NhanVien() { }

        public NhanVien(int maNhanVien, string tenNhanVien, string userNhanVien, string passwordNhanVien, string diaChiNhanVien, string sdtNhanVien,string gioiTinhNhanVien)
        {
            this.MaNhanVien = maNhanVien;
            this.TenNhanVien = tenNhanVien;
            this.UserNhanVien = userNhanVien;
            this.PasswordNhanVien = passwordNhanVien;
            this.DiaChiNhanVien = diaChiNhanVien;
            this.SdtNhanVien = sdtNhanVien;
            this.GioiTinhNhanVien = gioiTinhNhanVien;
        }

    }
}
