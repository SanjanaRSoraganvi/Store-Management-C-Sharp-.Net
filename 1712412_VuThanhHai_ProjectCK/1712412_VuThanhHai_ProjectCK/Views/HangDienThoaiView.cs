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
    public partial class HangDienThoaiView : Form
    {
        HangDienThoai hDienThoaiObject = new HangDienThoai();
        DataTable dtDS = new System.Data.DataTable();
        HangDienThoaiController hDienThoaiController = new HangDienThoaiController();

        private int flagLuu = 0;

        public HangDienThoaiView()
        {
            InitializeComponent();
        }

        private void HangDienThoaiView_Load(object sender, EventArgs e)
        {
            dtDS = hDienThoaiController.FetchAllData();
            dgvDSHDT.DataSource = dtDS;
            dataBinding();
            disableControl(false);
        }

        private void dataBinding()
        {
            textBoxID.DataBindings.Clear();
            textBoxID.DataBindings.Add("Text", dgvDSHDT.DataSource, "ID_HANGDIENTHOAI");
            textBoxTHDT.DataBindings.Clear();
            textBoxTHDT.DataBindings.Add("Text", dgvDSHDT.DataSource, "TENHANGDIENTHOAI");
        }

        private void ClearData()
        {
            textBoxID.Text = "";
            textBoxTHDT.Text = "";
        }

        private void AddData(HangDienThoai hangDienThoaiInput)
        {
            hangDienThoaiInput.MaHangDienThoai = int.Parse(textBoxID.Text.Trim());
            hangDienThoaiInput.TenHangDienThoai = textBoxTHDT.Text.Trim();
        }

        private void disableControl(bool e)
        {
            buttonThem.Enabled = !e;
            buttonXoa.Enabled = !e;
            buttonSua.Enabled = !e;
            buttonLuu.Enabled = e;
            buttonHuy.Enabled = e;

            textBoxID.Enabled = e;
            textBoxTHDT.Enabled = e;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            ClearData();
            disableControl(true);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa hãng điện thoại này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (hDienThoaiController.DeleteDataHangDienThoai(textBoxID.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HangDienThoaiView_Load(sender, e);
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            disableControl(true);
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            AddData(hDienThoaiObject);
            if (flagLuu == 0)
            {
                if (hDienThoaiController.AddHangDienThoai(hDienThoaiObject))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (hDienThoaiController.UpdateHangDienThoai(hDienThoaiObject))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HangDienThoaiView_Load(sender, e);
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                HangDienThoaiView_Load(sender, e);
            else
                return;
        }
    }
}
