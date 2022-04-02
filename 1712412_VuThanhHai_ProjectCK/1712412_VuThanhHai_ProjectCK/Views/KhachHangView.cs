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
    public partial class KhachHangView : Form
    {
        KhachHang nVienObject = new KhachHang();
        KhachHangController nVienController = new KhachHangController();
        DataTable dtDS = new System.Data.DataTable();
        private int flagLuu = 0;

        public KhachHangView()
        {
            InitializeComponent();
        }

        private void KhachHangView_Load_1(object sender, EventArgs e)
        {
            dtDS = nVienController.FetchAllData();
            dgvDSNV.DataSource = dtDS;
            dataBinding();
            disableControl(false);
        }

        private void dataBinding()
        {
            textBoxID.DataBindings.Clear();
            textBoxID.DataBindings.Add("Text", dgvDSNV.DataSource, "ID_KHACHHANG");
            textBoxTNV.DataBindings.Clear();
            textBoxTNV.DataBindings.Add("Text", dgvDSNV.DataSource, "TENKHACHHANG");
            comboBoxGT.DataBindings.Clear();
            comboBoxGT.DataBindings.Add("Text", dgvDSNV.DataSource, "GIOITINH");
            textBoxSDT.DataBindings.Clear();
            textBoxSDT.DataBindings.Add("Text", dgvDSNV.DataSource, "SDT");
            textBoxDC.DataBindings.Clear();
            textBoxDC.DataBindings.Add("Text", dgvDSNV.DataSource, "DIACHI");
        }

        private void loadCMB()
        {
            comboBoxGT.Items.Clear();
            comboBoxGT.Items.Add("Nam");
            comboBoxGT.Items.Add("Nữ");
            comboBoxGT.SelectedItem = 0;
            comboBoxGT.SelectedIndex = 0;
        }

        private void ClearData()
        {
            textBoxID.Text = "";
            textBoxTNV.Text = "";
            textBoxDC.Text = "";
            textBoxSDT.Text = "";
            loadCMB();
        }

        private void AddData(KhachHang khachHangInput)
        {
            khachHangInput.MaKhachHang = int.Parse(textBoxID.Text.Trim());
            khachHangInput.TenKhachHang = textBoxTNV.Text.Trim();
            khachHangInput.GioiTinhKhachHang = comboBoxGT.SelectedItem as string;
            khachHangInput.SdtKhachHang = textBoxSDT.Text.Trim();
            khachHangInput.DiaChiKhachHang = textBoxDC.Text.Trim();
        }

        private void disableControl(bool e)
        {
            buttonThem.Enabled = !e;
            buttonXoa.Enabled = !e;
            buttonSua.Enabled = !e;
            buttonLuu.Enabled = e;
            buttonHuy.Enabled = e;

            textBoxID.Enabled = e;
            textBoxTNV.Enabled = e;
            textBoxDC.Enabled = e;
            textBoxSDT.Enabled = e;
            comboBoxGT.Enabled = e;
        }


        private void buttonThem_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            ClearData();
            disableControl(true);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa Khách Hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (nVienController.DeleteDataKhachHang(textBoxID.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KhachHangView_Load_1(sender, e);
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            disableControl(true);
            loadCMB();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            AddData(nVienObject);
            if (flagLuu == 0)
            {
                if (nVienController.AddKhachHang(nVienObject))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (nVienController.UpdateKhachHang(nVienObject))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KhachHangView_Load_1(sender, e);
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                KhachHangView_Load_1(sender, e);
            else
                return;
        }
    }
}
