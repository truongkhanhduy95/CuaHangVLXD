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
    public partial class frmCongNoKhachHang : DevComponents.DotNetBar.Office2007RibbonForm
    {
        CongNoKhachHangBLL bll = new CongNoKhachHangBLL();
        KhachHangBLL khachhangBLL = new KhachHangBLL();
        HoaDonBLL hoadonBLL = new HoaDonBLL();

        KhachHang khachHang;
        HoaDon hoaDon;

        public frmCongNoKhachHang()
        {
            InitializeComponent();
        }

        private void frmCongNoKhachHang_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void LoadInfo()
        {
            dgvKhachHang.DataSource = bll.GetDanhSachCongNoKhachHang();
            txtTongNo.Text = bll.GetTongCongNoKhachHang().ToString();
            txtTongKH.Text = (dgvKhachHang.Rows.Count - 1).ToString();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string maKH = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                khachHang = khachhangBLL.GetKhachHangByID(maKH);
                dgvHoaDon.DataSource=bll.GetThongTinHoaDonNo(maKH);
                txtTenKH.Text = khachHang.Ten;
                txtDiaChi.Text = khachHang.DiaChi;
                txtEmail.Text = khachHang.Email;
                txtSDT.Text = khachHang.SoDienThoai;
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string maHD = dgvHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString();
                hoaDon = hoadonBLL.GetHoaDonByID(maHD);
                txtMaHD.Text = hoaDon.MaHD;
                txtNgayLap.Text = hoaDon.NgayLap.ToString();
                txtConNo.Text = hoaDon.ConLai.ToString();
                txtTongTien.Text = hoaDon.TongTien.ToString();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (hoaDon != null)
            {
                Form1 f = (Form1)Form.ActiveForm;
                f.AddNewTab("Danh sách Hóa Đơn", new frmDSHoaDon(hoaDon));
            }
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmCapNhatCongNo frm = new frmCapNhatCongNo(hoaDon,khachHang.Ten);
            frm.ShowDialog();
            LoadInfo();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = bll.TimKhachHang(txtTenTim.Text);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.RemoveCurrentTab();
        }

    }
}
