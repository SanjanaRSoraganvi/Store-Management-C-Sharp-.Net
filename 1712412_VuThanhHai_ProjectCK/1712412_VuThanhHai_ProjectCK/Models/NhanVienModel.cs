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
    class NhanVienModel
    {
        Connections con = new Connections();
        SqlCommand cmd = new SqlCommand();

        public DataTable fetchAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select ID_NHANVIEN, TENNHANVIEN, DIACHI, SDT, GIOITINH FROM NHAN_VIEN";
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

        public bool addNhanVien(NhanVien nhanVienInput)
        {
            cmd.CommandText = $"Insert into NHAN_VIEN values ('{nhanVienInput.MaNhanVien}',N'{nhanVienInput.TenNhanVien}',N'{nhanVienInput.TenNhanVien}',N'{nhanVienInput.TenNhanVien}',N'{nhanVienInput.DiaChiNhanVien}',N'{nhanVienInput.SdtNhanVien}','{nhanVienInput.GioiTinhNhanVien}')";
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

        public bool updateNhanVien(NhanVien nhanVienInput)
        {
            cmd.CommandText = $"Update NHAN_VIEN set  TENNHANVIEN = N'{nhanVienInput.TenNhanVien}', DIACHI = N'{nhanVienInput.DiaChiNhanVien}', SDT = '{nhanVienInput.SdtNhanVien}', GIOITINH = '{nhanVienInput.GioiTinhNhanVien}' Where ID_NHANVIEN = '{nhanVienInput.MaNhanVien}'";
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

        public bool updatePasswordNhanVien(NhanVien nhanVienInput)
        {
            cmd.CommandText = $"Update NHAN_VIEN set MatKhau ='{nhanVienInput.PasswordNhanVien}' Where ID_NHANVIEN = '{nhanVienInput.MaNhanVien}'";
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

        public bool deleteDataNhanVien(string id_nhanvien)
        {
            cmd.CommandText = $"Delete NHAN_VIEN Where ID_NHANVIEN = '{id_nhanvien}'";
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
