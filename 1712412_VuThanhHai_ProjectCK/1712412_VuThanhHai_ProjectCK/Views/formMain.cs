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
using _1712412_VuThanhHai_ProjectCK.Views;

namespace _1712412_VuThanhHai_ProjectCK
{
    public partial class formMain : Form
    {
        HoaDonController hDonController = new HoaDonController();

        DataTable monthlyReport = new System.Data.DataTable();
        DataTable hotProduct = new System.Data.DataTable();
        int month = 8;
        int year = 2021;

        public formMain()
        {
            InitializeComponent();
        }
        private void clearDataHP()
        {
            textBoxMHP.Text = "";
            textBoxMHP.Text = "";
        }

        private void clearDataMR()
        {
            textBoxMMR.Text = "";
            textBoxYMR.Text = "";
        }

        private void loadHP(int month, int year)
        {
            hotProduct = hDonController.fetchHotProductInMonth(month, year);//int.Parse(textBoxMHP.Text.Trim()), int.Parse(textBoxYHP.Text.Trim())
            dataGridViewHP.DataSource = hotProduct;
        }

        private void loadMR(int month, int year)
        {
            monthlyReport = hDonController.fetchMonthlyReport(month, year);//, int.Parse(textBoxYMR.Text.Trim())
            dataGridViewMR.DataSource = monthlyReport;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            month = int.Parse(textBoxMHP.Text.Trim());
            year = int.Parse(textBoxYHP.Text.Trim());
            clearDataMR();
            loadHP(month, year);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            month = int.Parse(textBoxMMR.Text.Trim());
            year = int.Parse(textBoxYMR.Text.Trim());
            clearDataHP();
            loadMR(month, year);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clearDataHP();
            clearDataMR();
            loadHP(month, year);
            loadMR(month, year);
        }

        private void khachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHangView khachHangView = new KhachHangView();
            khachHangView.Tag = this;
            khachHangView.Show(this);
            //Hide();
        }

        private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhanVienView nvView = new nhanVienView();
            nvView.Show();
        }

        private void hoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonView hdView = new HoaDonView();
            hdView.Show();
        }

        private void sanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SanPhamView spView = new SanPhamView();
            spView.Show();
        }

        private void hangDienThoaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HangDienThoaiView hdtView = new HangDienThoaiView();
            hdtView.Show();
        }
    }
}
