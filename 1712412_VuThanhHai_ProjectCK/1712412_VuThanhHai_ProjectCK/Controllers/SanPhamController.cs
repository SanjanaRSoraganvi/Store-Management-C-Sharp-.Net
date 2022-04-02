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
    class SanPhamController
    {
        SanPhamModel sPhamModel = new SanPhamModel();

        public DataTable FetchAllData()
        {
            return sPhamModel.fetchAllData();
        }

        public bool AddSanPham(SanPham sanPhamInput)
        {
            return sPhamModel.addSanPham(sanPhamInput);
        }

        public bool UpdateSanPham(SanPham sanPhamInput)
        {
            return sPhamModel.updateSanPham(sanPhamInput);
        }

        public bool DeleteDataSanPham(string id_sanpham)
        {
            return sPhamModel.deleteDataSanPham(id_sanpham);
        }

        public DataTable lowOnStockProduct()
        {
            return sPhamModel.lowOnStockProduct();
        }
    }
}
