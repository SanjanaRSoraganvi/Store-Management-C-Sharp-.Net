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
    public partial class SanPhamView : Form
    {
        SanPham sPhamObject = new SanPham();

        SanPhamController sPhamController = new SanPhamController();
        HangDienThoaiController hDienThoaiController = new HangDienThoaiController();
        DataTable dtDS = new System.Data.DataTable();
        DataTable dtDSLOS = new System.Data.DataTable();
        private int flagLuu = 0;

        public SanPhamView()
        {
            InitializeComponent();
        }

        private void SanPhamView_Load(object sender, EventArgs e)
        {
            dtDS = sPhamController.FetchAllData();
            dtDSLOS = sPhamController.lowOnStockProduct();
            dgvDSSP.DataSource = dtDS;
            dataGridViewLOS.DataSource = dtDSLOS;
            dataBinding();
            disableControl(false);
        }

        private void dataBinding()
        {
            textBoxID.DataBindings.Clear();
            textBoxID.DataBindings.Add("Text", dgvDSSP.DataSource, "ID_SANPHAM");
            comboBoxHDT.DataBindings.Clear();
            //textBoxIDHDT.DataBindings.Add("Text", dgvDSSP.DataSource, "TENHANGDIENTHOAI");
            comboBoxHDT.DataBindings.Add("Text", dgvDSSP.DataSource, "TENHANGDIENTHOAI");
            textBoxTSP.DataBindings.Clear();
            textBoxTSP.DataBindings.Add("Text", dgvDSSP.DataSource, "TENSANPHAM");
            textBoxSL.DataBindings.Clear();
            textBoxSL.DataBindings.Add("Text", dgvDSSP.DataSource, "SOLUONG");
            textBoxDG.DataBindings.Clear();
            textBoxDG.DataBindings.Add("Text", dgvDSSP.DataSource, "GIATHANH");
            textBoxMT.DataBindings.Clear();
            textBoxMT.DataBindings.Add("Text", dgvDSSP.DataSource, "MOTA");
        }

        private void ClearData()
        {
            textBoxID.Text = "";
            //textBoxIDHDT.Text = "";
            LoadCbHDT();
            textBoxTSP.Text = "";
            textBoxSL.Text = "";
            textBoxDG.Text = "";
            textBoxMT.Text = "";
        }

        private void LoadCbHDT()
        {
            comboBoxHDT.DataSource = hDienThoaiController.FetchAllData();
            comboBoxHDT.DisplayMember = "TENHANGDIENTHOAI";
            comboBoxHDT.ValueMember = "ID_HANGDIENTHOAI";
            comboBoxHDT.SelectedIndex = 0;
        }

        private void AddData(SanPham sanphamInput)
        {
            sanphamInput.MaSanPham = int.Parse(textBoxID.Text.Trim());
            //sanphamInput.MaHangDienThoai = int.Parse(textBoxIDHDT.Text.Trim());//int.Parse(textBoxIDHDT.Text.Trim());
            sanphamInput.MaHangDienThoai = int.Parse(comboBoxHDT.SelectedValue.ToString());
            sanphamInput.TenSanPham = textBoxTSP.Text.Trim();
            sanphamInput.SoLuongSanPham = int.Parse(textBoxSL.Text.Trim());
            sanphamInput.GiaThanhSanPham =  int.Parse(textBoxDG.Text.Trim());
            sanphamInput.MoTaSanPham = textBoxMT.Text.Trim();
        }

        private void disableControl(bool e)
        {
            buttonThem.Enabled = !e;
            buttonXoa.Enabled = !e;
            buttonSua.Enabled = !e;
            buttonLuu.Enabled = e;
            buttonHuy.Enabled = e;

            textBoxID.Enabled = e;
            //textBoxIDHDT.Enabled = e;
            comboBoxHDT.Enabled = e;
            textBoxTSP.Enabled = e;
            textBoxSL.Enabled = e;
            textBoxDG.Enabled = e;
            textBoxMT.Enabled = e;
        }


        private void buttonThem_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            
            disableControl(true);
        }

        
        private void buttonThem_Click_1(object sender, EventArgs e)
        {
            flagLuu = 0;
            disableControl(true);
            ClearData();
            LoadCbHDT();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (sPhamController.DeleteDataSanPham(textBoxID.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SanPhamView_Load(sender, e);
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            disableControl(true);
            LoadCbHDT();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            AddData(sPhamObject);
            if (flagLuu == 0)
            {
                if (sPhamController.AddSanPham(sPhamObject))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sPhamController.UpdateSanPham(sPhamObject))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SanPhamView_Load(sender, e);
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                SanPhamView_Load(sender, e);
            else
                return;
        }
    }
}
