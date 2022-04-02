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
    class HoaDonModel
    {
        Connections con = new Connections();
        SqlCommand cmd = new SqlCommand();

        public DataTable fetchAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select hd.ID_HOADON, nv.TENNHANVIEN, kh.TENKHACHHANG, hd.NGAYLAP, hd.TONGTIEN from HOA_DON hd, NHAN_VIEN nv, KHACH_HANG kh where hd.ID_KHACHHANG = kh.ID_KHACHHANG and hd.ID_NHANVIEN = nv.ID_NHANVIEN";
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

        public bool addHoaDon(HoaDon hoaDonInput)
        {
            cmd.CommandText = $"Insert into HOA_DON values ('{hoaDonInput.MaHoaDon}',N'{hoaDonInput.MaKhachHang}',N'{hoaDonInput.MaNhanVien}',N'{hoaDonInput.TongTien}','{hoaDonInput.NgayLap}')";
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

        public bool updateHoaDon(HoaDon hoaDonInput)
        {
            cmd.CommandText = $"Update HOA_DON set  ID_KHACHHANG = N'{hoaDonInput.MaKhachHang}', ID_NHANVIEN = N'{hoaDonInput.MaNhanVien}', TONGTIEN = '{hoaDonInput.TongTien}', NGAYLAP = '{hoaDonInput.NgayLap}' Where ID_HOADON = '{hoaDonInput.MaHoaDon}'";
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

        public bool deleteDataHoaDon(string id_hoadon)
        {
            cmd.CommandText = $"Delete HOA_DON Where ID_HOADON = '{id_hoadon}'";
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

        public DataTable fetchMonthlyReport(int month, int year)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = $"select '{month}' as Thang, '{year}' as Nam, SUM(TONGTIEN) as DoanhThu from HOA_DON where NGAYLAP between '{year}-{month}-01' and '{year}-{month+1}-01'";
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

        public DataTable fetchHotProductInMonth(int month, int year)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = $"select  sp.TENSANPHAM as SanPhamBanChay, sum(cthd.SOLUONG) as NangXuatBanRa from SAN_PHAM sp, CHI_TIET_HOA_DON cthd, HOA_DON hd where sp.ID_SANPHAM = cthd.ID_SANPHAM and cthd.ID_HOADON = hd.ID_HOADON and hd.NGAYLAP between '{year}-{month}-01' and '{year}-{month + 1}-01' group by TENSANPHAM";
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
