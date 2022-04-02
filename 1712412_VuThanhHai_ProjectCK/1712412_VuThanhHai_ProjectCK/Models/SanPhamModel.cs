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
    class SanPhamModel
    {
        Connections con = new Connections();
        SqlCommand cmd = new SqlCommand();

        public DataTable fetchAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select sp.ID_SANPHAM, hdt.TENHANGDIENTHOAI as TENHANGDIENTHOAI, sp.TENSANPHAM, sp.SOLUONG, sp.MOTA, sp.GIATHANH from SAN_PHAM sp, HANG_DIEN_THOAI hdt where sp.ID_HANGDIENTHOAI = hdt.ID_HANGDIENTHOAI";
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

        public bool addSanPham(SanPham sanPhamInput)
        {
            cmd.CommandText = $"Insert into SAN_PHAM values ('{sanPhamInput.MaSanPham}',N'{sanPhamInput.MaHangDienThoai}',N'{sanPhamInput.TenSanPham}',N'{sanPhamInput.SoLuongSanPham}','{sanPhamInput.MoTaSanPham}','{sanPhamInput.GiaThanhSanPham}')";
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

        public bool updateSanPham(SanPham sanPhamInput)
        {
            cmd.CommandText = $"Update SAN_PHAM set  ID_HANGDIENTHOAI = N'{sanPhamInput.MaHangDienThoai}', TENSANPHAM = N'{sanPhamInput.TenSanPham}', SOLUONG = '{sanPhamInput.SoLuongSanPham}', MOTA = '{sanPhamInput.MoTaSanPham}', GIATHANH = '{sanPhamInput.GiaThanhSanPham}' Where ID_SANPHAM = '{sanPhamInput.MaSanPham}'";
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

        public bool deleteDataSanPham(string id_sanpham)
        {
            cmd.CommandText = $"Delete SAN_PHAM Where ID_SANPHAM = '{id_sanpham}'";
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

        public DataTable lowOnStockProduct()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select ID_SANPHAM, TENSANPHAM, SOLUONG from SAN_PHAM where SOLUONG <10";
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
    }
}
