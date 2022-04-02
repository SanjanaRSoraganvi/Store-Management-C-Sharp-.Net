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
    class HangDienThoaiController
    {
        HangDienThoaiModel hDienThoai = new HangDienThoaiModel();

        public DataTable FetchAllData()
        {
            return hDienThoai.fetchAllData();
        }

        public bool AddHangDienThoai(HangDienThoai hDienThoaiInput)
        {
            return hDienThoai.addHangDienTHoai(hDienThoaiInput);
        }

        public bool UpdateHangDienThoai(HangDienThoai hDienThoaiInput)
        {
            return hDienThoai.updateHangDienTHoai(hDienThoaiInput);
        }

        public bool DeleteDataHangDienThoai(string id_hangdienthoai)
        {
            return hDienThoai.deleteDataHangDienTHoai(id_hangdienthoai);
        }
    }
}
