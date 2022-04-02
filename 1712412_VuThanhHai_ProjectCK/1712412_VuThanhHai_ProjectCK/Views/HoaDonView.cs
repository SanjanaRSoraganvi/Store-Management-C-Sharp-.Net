using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using _1712412_VuThanhHai_ProjectCK.Objects;
using _1712412_VuThanhHai_ProjectCK.Models;
using _1712412_VuThanhHai_ProjectCK.Controllers;

namespace _1712412_VuThanhHai_ProjectCK.Views
{
    public partial class HoaDonView : Form
    {
        SanPham sPhamObject = new SanPham();
        HoaDon hDonObject = new HoaDon();
        ChiTietHoaDon cthdObject = new ChiTietHoaDon();

        SanPhamController sPhamController = new SanPhamController();
        NhanVienConTroller nVienController = new NhanVienConTroller();
        KhachHangController kHangController = new KhachHangController();
        HoaDonController hDonController = new HoaDonController();
        ChiTietHoaDonController cthdController = new ChiTietHoaDonController();

        DataTable dtDS = new System.Data.DataTable();
        DataTable dtDSCTHD = new System.Data.DataTable();

        private int flagLuu = 1;

        public HoaDonView()
        {
            InitializeComponent();
        }

        private bool checkHoaDonIDExist()
        {
            if (textBoxID.Text.Trim() != null)
                return false;
            else
                return true;
        }
        private void HoaDonView_Load(object sender, EventArgs e)
        {
            dtDS = hDonController.FetchAllData();
            dgvDSHD.DataSource = dtDS;

            dataBinding();
            disableControl(false);
        }

        //private void TextChanged_MHD(object sender, EventArgs e)
        //{

        //}
        private void refreshReceiptDetail()
        {
            dtDSCTHD = cthdController.FetchAllData(int.Parse(textBoxID.Text.Trim()));
            dgvCTHD.DataSource = dtDSCTHD;
            dataBindingCTHD();
            
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            refreshReceiptDetail();
            if (flagLuu == 1)
            {
                if(textBoxID.Text.Length>0)
                {
                    //MessageBox.Show("trong change!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshReceiptDetail();
                    disableControl(false);
                }
                else
                {
                    dgvCTHD.DataSource = null;
                }
                
            }

            //if (!checkHoaDonIDExist())
            //{
            //    dtDSCTHD = cthdController.FetchAllData(int.Parse(textBoxID.Text.Trim()));
            //    dgvCTHD.DataSource = dtDSCTHD;
            //    dataBindingCTHD();
            //    disableControl(false);
            //}
            //else
            //{
            //    dgvCTHD.DataSource = null;
            //}
        }

        private void dataBinding()
        {
           
            textBoxID.DataBindings.Clear();
            textBoxID.DataBindings.Add("Text", dgvDSHD.DataSource, "ID_HOADON");
            comboBoxTKH.DataBindings.Clear();
            comboBoxTKH.DataBindings.Add("Text", dgvDSHD.DataSource, "TENKHACHHANG");
            comboBoxTNV.DataBindings.Clear();
            comboBoxTNV.DataBindings.Add("Text", dgvDSHD.DataSource, "TENNHANVIEN");
            textBoxTT.DataBindings.Clear();
            textBoxTT.DataBindings.Add("Text", dgvDSHD.DataSource, "TONGTIEN");
            textBoxNL.DataBindings.Clear();
            textBoxNL.DataBindings.Add("Text", dgvDSHD.DataSource, "NGAYLAP");
            refreshReceiptDetail();
        }

        private void dataBindingCTHD()
        {
            textBoxMHD.DataBindings.Clear();
            textBoxMHD.DataBindings.Add("Text", dgvCTHD.DataSource, "ID_HOADON");
            comboBoxTSP.DataBindings.Clear();
            LoadCbTSP();
            comboBoxTSP.DataBindings.Add("Text", dgvCTHD.DataSource, "TENSANPHAM");
            textBoxSLCTHD.DataBindings.Clear();
            textBoxSLCTHD.DataBindings.Add("Text", dgvCTHD.DataSource, "SOLUONG");
            textBoxTTCTHD.DataBindings.Clear();
            textBoxTTCTHD.DataBindings.Add("Text", dgvCTHD.DataSource, "TONGGIA");
        }

        private void disableControl(bool e)
        {
            buttonThem.Enabled = !e;
            buttonXoa.Enabled = !e;
            buttonSua.Enabled = !e;
            buttonLuu.Enabled = e;
            buttonHuy.Enabled = e;

            textBoxID.Enabled = e;
            comboBoxTKH.Enabled = e;
            comboBoxTNV.Enabled = e;
            textBoxTT.Enabled = false;
            textBoxNL.Enabled = e;

            buttonThemCTHD.Enabled = !e;
            buttonXoaCTHD.Enabled = !e;
            buttonSuaCTHD.Enabled = !e;
            buttonLuuCTHD.Enabled = e;

            textBoxMHD.Enabled = e;
            //comboBoxTSP.Enabled = e;
            textBoxSLCTHD.Enabled = e;
            textBoxTTCTHD.Enabled = false;
        }

        private void ClearData()
        {
            textBoxID.Text = "";
            LoadCbTNV();
            LoadCbTKH();
            textBoxTT.Text = "";
            textBoxNL.Text = "";
        }

        private void ClearDataCTHD()
        {
            textBoxMHD.Text = "";
            LoadCbTSP();
            textBoxSLCTHD.Text = "";
            textBoxTTCTHD.Text = "";
        }

        private void LoadCbTNV()
        {
            comboBoxTNV.DataSource = nVienController.FetchAllData();
            comboBoxTNV.DisplayMember = "TENNHANVIEN";
            comboBoxTNV.ValueMember = "ID_NHANVIEN";
            comboBoxTNV.SelectedIndex = 0;
        }

        private void LoadCbTKH()
        {
            comboBoxTKH.DataSource = kHangController.FetchAllData();
            comboBoxTKH.DisplayMember = "TENKHACHHANG";
            comboBoxTKH.ValueMember = "ID_KHACHHANG";
            comboBoxTKH.SelectedIndex = 0;
        }

        private void LoadCbTSP()
        {
            comboBoxTSP.DataSource = sPhamController.FetchAllData();
            comboBoxTSP.DisplayMember = "TENSANPHAM";
            comboBoxTSP.ValueMember = "ID_SANPHAM";
            comboBoxTSP.SelectedIndex = 0;
        }

        private void AddDataHoaDon(HoaDon hoaDonInput)
        {
            hoaDonInput.MaHoaDon = int.Parse(textBoxID.Text.Trim());
            hoaDonInput.MaKhachHang = int.Parse(comboBoxTKH.SelectedValue.ToString());
            hoaDonInput.MaNhanVien = int.Parse(comboBoxTNV.SelectedValue.ToString());
            //hoaDonInput.TongTien = int.Parse(textBoxTT.Text.Trim());
            hoaDonInput.NgayLap = textBoxNL.Text.Trim();
        }

        private void AddDataCTHoaDon(ChiTietHoaDon ctHoaDonInput)
        {
            ctHoaDonInput.MaHoaDon = int.Parse(textBoxID.Text.Trim());//int.Parse(textBoxMHD.Text.Trim());
            ctHoaDonInput.MaSanPham = int.Parse(comboBoxTSP.SelectedValue.ToString());
            ctHoaDonInput.SoLuong = int.Parse(textBoxSLCTHD.Text.Trim());
            //ctHoaDonInput.DonGia = int.Parse(textBoxTTCTHD.Text.Trim());
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            ClearData();
            ClearDataCTHD();
            disableControl(true);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (cthdController.DeleteDataCTHD(comboBoxTSP?.SelectedValue?.ToString(), textBoxID.Text.Trim()) && hDonController.DeleteDataHoaDon(textBoxID.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HoaDonView_Load(sender, e);
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            disableControl(true);
            LoadCbTKH();
            LoadCbTNV();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            AddDataHoaDon(hDonObject);
            if (flagLuu == 0)
            {
                if (hDonController.AddHoaDon(hDonObject))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (hDonController.UpdateHoaDon(hDonObject))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            HoaDonView_Load(sender, e);
            
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                HoaDonView_Load(sender, e);
            else
                return;
        }

        private void buttonThemCTHD_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            ClearDataCTHD();
            disableControl(true);
        }

        private void buttonXoaCTHD_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa chi tiết  hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (cthdController.DeleteDataCTHD(comboBoxTSP?.SelectedValue?.ToString(), textBoxID.Text.Trim()))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshReceiptDetail();
                }
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HoaDonView_Load(sender, e);
            refreshReceiptDetail();
        }

        private void buttonSuaCTHD_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            LoadCbTSP();
        }

        private void buttonLuuCTHD_Click(object sender, EventArgs e)
        {
            AddDataCTHoaDon(cthdObject);
            //textBoxID.Text = 3.ToString;
            if (flagLuu == 0)
            {
                if (cthdController.AddCTHD(cthdObject))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshReceiptDetail();
                }
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cthdController.UpdateCTHD(cthdObject))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //HoaDonView_Load(sender, e);
        }
    }
}
