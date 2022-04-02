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
    class HoaDonController
    {
        HoaDonModel hDonModel = new HoaDonModel();

        public DataTable FetchAllData()
        {
            return hDonModel.fetchAllData();
        }

        public bool AddHoaDon(HoaDon hoaDonInput)
        {
            return hDonModel.addHoaDon(hoaDonInput);
        }

        public bool UpdateHoaDon(HoaDon hoaDonInput)
        {
            return hDonModel.updateHoaDon(hoaDonInput);
        }

        public bool DeleteDataHoaDon(string id_hoaDon)
        {
            return hDonModel.deleteDataHoaDon(id_hoaDon);
        }

        public DataTable fetchHotProductInMonth(int month, int year)
        {
            return hDonModel.fetchHotProductInMonth(month, year);
        }

        public DataTable fetchMonthlyReport(int month, int year)
        {
            return hDonModel.fetchMonthlyReport(month, year);
        }
    }
}
