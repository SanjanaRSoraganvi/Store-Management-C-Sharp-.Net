using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using _1712412_VuThanhHai_ProjectCK.Objects;
using _1712412_VuThanhHai_ProjectCK.Models;


namespace _1712412_VuThanhHai_ProjectCK.Controllers
{
    class NhanVienConTroller
    {
        NhanVienModel nVienModel = new NhanVienModel();

        public DataTable FetchAllData()
        {
            return nVienModel.fetchAllData();
        }

        public bool AddNhanVien(NhanVien nhanVienInput)
        {
            return nVienModel.addNhanVien(nhanVienInput);
        }

        public bool UpdateNhanVien(NhanVien nhanVienInput)
        {
            return nVienModel.updateNhanVien(nhanVienInput);
        }

        public bool UpdatePasswordNhanVien(NhanVien nhanVienInput)
        {
            return nVienModel.updatePasswordNhanVien(nhanVienInput);
        }

        public bool DeleteDataNhanVien(string id_nhanvien)
        {
            return nVienModel.deleteDataNhanVien(id_nhanvien);
        }
    }
}
