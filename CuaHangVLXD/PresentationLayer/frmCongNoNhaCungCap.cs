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
    public partial class frmCongNoNhaCungCap : DevComponents.DotNetBar.Office2007RibbonForm
    {
        CongNoNhaCungCapBLL bll = new CongNoNhaCungCapBLL();
        NhaCungCapBLL nhaCungCapBLL = new NhaCungCapBLL();
        DonNhapHangBLL donNhapHangBLL = new DonNhapHangBLL();

        NhaCungCap nhaCungCap;
        DonNhapHang donNhapHang;

        public frmCongNoNhaCungCap()
        {
            InitializeComponent();
        }

        private void LoadInfo()
        {
            dgvKhachHang.DataSource = bll.GetDanhSachCongNoNhaCungCap();
            txtTongNo.Text = bll.GetTongCongNoNhaCungCap().ToString();
            txtTongKH.Text = (dgvKhachHang.Rows.Count - 1).ToString();
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (donNhapHang != null)
            {
                Form1 f = (Form1)Form.ActiveForm;
                f.AddNewTab("Danh sách ĐNH", new frmDSDonNhapHang(donNhapHang.MaNCC));
            }
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmCapNhatCongNo frm = new frmCapNhatCongNo(donNhapHang,nhaCungCap.Ten);
            frm.ShowDialog();
            LoadInfo();
        }

        private void frmCongNoNhaCungCap_Load_1(object sender, EventArgs e)
        {
            LoadInfo();

        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKhachHang_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string maKH = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                nhaCungCap = nhaCungCapBLL.GetNhaCungCapByID(maKH);
                dgvHoaDon.DataSource = bll.GetThongTinHoaDonNo(maKH);
                txtTenKH.Text = nhaCungCap.Ten;
                txtDiaChi.Text = nhaCungCap.DiaChi;
                txtEmail.Text = nhaCungCap.Email;
                txtSDT.Text = nhaCungCap.SoDienThoai;
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                donNhapHangBLL = new DonNhapHangBLL();
                string maHD = dgvHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString();
                donNhapHang = donNhapHangBLL.GetDonNhapHangByID(maHD);
                txtMaHD.Text = donNhapHang.MaDNH;
                txtNgayLap.Text = donNhapHang.NgayLap.ToString();
                txtConNo.Text = donNhapHang.ConLai.ToString();
                txtTongTien.Text = donNhapHang.TongTien.ToString();
            }
        }

    }
}
