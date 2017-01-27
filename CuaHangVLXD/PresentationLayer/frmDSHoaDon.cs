using CuaHangVLXD.BussinessLogicLayer;
using CuaHangVLXD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangVLXD.PresentationLayer
{
    public partial class frmDSHoaDon : DevComponents.DotNetBar.Office2007RibbonForm
    {
        HoaDonBLL hoadonBLL = new HoaDonBLL();
        KhachHangBLL khachhangBLL = new KhachHangBLL();
        HangHoaBLL hangBLL = new HangHoaBLL();

        HoaDon hoaDon;
        KhachHang khachHang;

        public frmDSHoaDon()
        {
            InitializeComponent();
            dgvDSHoaDon.DataSource = hoadonBLL.LoadAllDanhSach();
            if (dgvDSHoaDon.Rows.Count > 0)
            {
                hoaDon = hoadonBLL.GetHoaDonByID(dgvDSHoaDon.Rows[0].Cells[0].Value.ToString());
                ShowInfoHoaDon(hoaDon);
            }
        }

        public frmDSHoaDon(string maKH)
        {
            InitializeComponent();
            dgvDSHoaDon.DataSource = hoadonBLL.GetHDFromKhachHang(maKH);
            if (dgvDSHoaDon.Rows.Count > 0)
            {
                hoaDon = hoadonBLL.GetHoaDonByID(dgvDSHoaDon.Rows[0].Cells[0].Value.ToString());
                ShowInfoHoaDon(hoaDon);
            }
        }

        public frmDSHoaDon(HoaDon hoaDon)
        {
            InitializeComponent();
            hoaDon = hoadonBLL.GetHoaDonByID(hoaDon.MaHD);
            this.hoaDon = hoaDon;
            ShowInfoHoaDon(hoaDon);
        }

        private void frmDSHoaDon_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
        }

        private void dgvDSHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                hoaDon = hoadonBLL.GetHoaDonByID(dgvDSHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString());
                ShowInfoHoaDon(hoaDon);
            }
        }

        private void ShowInfoHoaDon(HoaDon hoaDon)
        {
            txtMaHD.Text = hoaDon.MaHD;  
            khachHang = khachhangBLL.GetKhachHangByID(hoaDon.MaKH);
            txtTenKH.Text = khachHang.Ten;
            txtNgayLap.Text = hoaDon.NgayLap.ToString();
            txtSDT.Text = khachHang.SoDienThoai;
            txtDiaChi.Text = khachHang.DiaChi;
            txtEmail.Text = khachHang.Email;

            dgvCTHD.Rows.Clear();
            dgvCTHD.Refresh();
            foreach (HangHoa hh in hoaDon.DSHangHoa)
            {
                DataGridViewRow row = (DataGridViewRow)dgvCTHD.Rows[0].Clone();
                row.Cells[0].Value = hh.MaHH;

                row.Cells[3].Value = hh.GiaBan;
                row.Cells[4].Value = hh.SoLuong;
                int thanhtien = hh.GiaBan * hh.SoLuong;
                row.Cells[5].Value = thanhtien.ToString();

                HangHoa hh2 = hangBLL.GetHangHoaByID(hh.MaHH);
                row.Cells[1].Value = hh2.TenHH;
                row.Cells[2].Value = hh2.LoaiHang;
                dgvCTHD.Rows.Add(row);
            }

            lblTotalPrice.Text = hoaDon.TongTien.ToString();
            lblDaTra.Text = hoaDon.DaTra.ToString();
            lblConLai.Text = hoaDon.ConLai.ToString();

            if (hoaDon.ConLai > 0)
            {
                btnCapNhatCongNo.Enabled = true;
            }
            else
                btnCapNhatCongNo.Enabled = false;
        }

        private void txtTimKH_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKH.Text == "")
                dgvDSHoaDon.DataSource = hoadonBLL.LoadAllDanhSach();
            else
                dgvDSHoaDon.DataSource = hoadonBLL.GetHDFromTenKhachHang(txtTimKH.Text);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("Nhập sai!");
            }          
            else
                dgvDSHoaDon.DataSource = hoadonBLL.SearchByDate(dtpFrom.Value, dtpTo.Value);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            frmCapNhatCongNo frm = new frmCapNhatCongNo(hoaDon,khachHang.Ten);
            frm.ShowDialog();
            dgvDSHoaDon.DataSource = hoadonBLL.LoadAllDanhSach();
            hoaDon = hoadonBLL.GetHoaDonByID(dgvDSHoaDon.Rows[0].Cells[0].Value.ToString());
            ShowInfoHoaDon(hoaDon);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.RemoveCurrentTab();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            frmInHoaDon frm = new frmInHoaDon(hoaDon.MaHD);
            frm.Show();
        }
    }
}
