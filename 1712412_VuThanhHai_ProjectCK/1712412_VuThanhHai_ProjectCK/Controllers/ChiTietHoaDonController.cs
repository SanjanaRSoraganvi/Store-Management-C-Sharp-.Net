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
    class ChiTietHoaDonController
    {
        ChiTietHoaDonModel cthdModel = new ChiTietHoaDonModel();

        public DataTable FetchAllData(int id_hoadon)
        {
            return cthdModel.fetchAllData(id_hoadon);
        }

        public bool AddCTHD(ChiTietHoaDon cthdInput)
        {
            return cthdModel.addCtHoaDon(cthdInput);
        }

        public bool UpdateCTHD(ChiTietHoaDon cthdInput)
        {
            return cthdModel.updateCtHoaDon(cthdInput);
        }

        public bool DeleteDataCTHD(string id_SanPham, string id_HoaDon)
        {
            return cthdModel.deleteDataCtHoaDon(id_SanPham, id_HoaDon);
        }

        //public int tinhTongTienCuaCTHD(ChiTietHoaDon cthdInput)
        //{
        //    return cthdModel.
        //}
    }
}
