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
    class KhachHangController
    {
        KhachHangModel kHangModel = new KhachHangModel();

        public DataTable FetchAllData()
        {
            return kHangModel.fetchAllData();
        }

        public bool AddKhachHang(KhachHang khachHangInput)
        {
            return kHangModel.addKhachHang(khachHangInput);
        }

        public bool UpdateKhachHang(KhachHang khachHangInput)
        {
            return kHangModel.updateKhachHang(khachHangInput);
        }

        public bool DeleteDataKhachHang(string id_khachhang)
        {
            return kHangModel.deleteDataKhachHang(id_khachhang);
        }
    }
}
