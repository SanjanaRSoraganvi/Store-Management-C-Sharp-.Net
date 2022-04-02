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
    class HangDienThoaiModel
    {
        Connections con = new Connections();
        SqlCommand cmd = new SqlCommand();

        public DataTable fetchAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select ID_HANGDIENTHOAI, TENHANGDIENTHOAI FROM HANG_DIEN_THOAI";
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

        public bool addHangDienTHoai(HangDienThoai hangDienThoaiInput)
        {
            cmd.CommandText = $"Insert into HANG_DIEN_THOAI values ('{hangDienThoaiInput.MaHangDienThoai}',N'{hangDienThoaiInput.TenHangDienThoai}')";
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

        public bool updateHangDienTHoai(HangDienThoai hangDienThoaiInput)
        {
            cmd.CommandText = $"Update HANG_DIEN_THOAI set  TENHANGDIENTHOAI = N'{hangDienThoaiInput.TenHangDienThoai}' Where ID_HANGDIENTHOAI = '{hangDienThoaiInput.MaHangDienThoai}'";
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

        public bool deleteDataHangDienTHoai(string id_hangdienthoai)
        {
            cmd.CommandText = $"Delete HANG_DIEN_THOAI Where ID_HANGDIENTHOAI = '{id_hangdienthoai}'";
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
