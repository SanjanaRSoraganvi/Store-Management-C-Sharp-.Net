using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using _1712412_VuThanhHai_ProjectCK.Objects;

namespace _1712412_VuThanhHai_ProjectCK.Models
{
    class ChiTietHoaDonModel
    {
        Connections con = new Connections();
        SqlCommand cmd = new SqlCommand();

        public DataTable fetchAllData(int id_hoadon)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = $"select hd.ID_HOADON, sp.TENSANPHAM, cthd.SOLUONG, (cthd.SOLUONG * sp.GIATHANH) as TONGGIA from HOA_DON hd, SAN_PHAM sp, CHI_TIET_HOA_DON cthd where hd.ID_HOADON = '{id_hoadon}' and cthd.ID_SANPHAM =  sp.ID_SANPHAM and cthd.ID_HOADON = hd.ID_HOADON ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }

        public bool addCtHoaDon(ChiTietHoaDon cthdInput)
        {
            cmd.CommandText = $"Insert into CHI_TIET_HOA_DON values ('{cthdInput.MaHoaDon}',N'{cthdInput.MaSanPham}',N'{cthdInput.SoLuong}',N'{cthdInput.DonGia}')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

        public bool updateCtHoaDon(ChiTietHoaDon cthdInput)
        {
            cmd.CommandText = $"Update CHI_TIET_HOA_DON set  ID_SANPHAM = N'{cthdInput.MaSanPham}', SOLUONG = N'{cthdInput.SoLuong}', DONGIA = '{cthdInput.DonGia}' Where ID_HOADON = '{cthdInput.MaHoaDon}'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

        public bool deleteDataCtHoaDon(string id_SanPham, string id_HoaDon)
        {
            cmd.CommandText = $"Delete CHI_TIET_HOA_DON Where ID_SANPHAM = '{id_SanPham}' and ID_HOADON = '{id_HoaDon}'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
    }
}
