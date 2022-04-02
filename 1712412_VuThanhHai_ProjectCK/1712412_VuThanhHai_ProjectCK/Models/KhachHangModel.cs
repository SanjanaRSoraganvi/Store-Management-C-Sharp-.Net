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
    class KhachHangModel
    {
        Connections con = new Connections();
        SqlCommand cmd = new SqlCommand();

        public DataTable fetchAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select ID_KHACHHANG, TENKHACHHANG, DIACHI, SDT, GIOITINH FROM KHACH_HANG";
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

        public bool addKhachHang(KhachHang khachHangInput)
        {
            cmd.CommandText = $"Insert into KHACH_HANG values ('{khachHangInput.MaKhachHang}',N'{khachHangInput.TenKhachHang}',N'{khachHangInput.DiaChiKhachHang}',N'{khachHangInput.SdtKhachHang}','{khachHangInput.GioiTinhKhachHang}')";
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

        public bool updateKhachHang(KhachHang khachHangInput)
        {
            cmd.CommandText = $"Update KHACH_HANG set  TENKHACHHANG = N'{khachHangInput.TenKhachHang}', DIACHI = N'{khachHangInput.DiaChiKhachHang}', SDT = '{khachHangInput.SdtKhachHang}', GIOITINH = '{khachHangInput.GioiTinhKhachHang}' Where ID_KHACHHANG = '{khachHangInput.MaKhachHang}'";
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

        public bool deleteDataKhachHang(string id_khachhang)
        {
            cmd.CommandText = $"Delete KHACH_HANG Where ID_KHACHHANG = '{id_khachhang}'";
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
