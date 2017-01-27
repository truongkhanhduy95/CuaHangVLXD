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
    public partial class frmDSDonNhapHang : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DonNhapHangBLL donnhaphangBLL = new DonNhapHangBLL();
        NhaCungCapBLL nhacungcapBLL = new NhaCungCapBLL();
        HangHoaBLL hangBLL = new HangHoaBLL();

        DonNhapHang donNhapHang;
        NhaCungCap nhaCungCap;
        public frmDSDonNhapHang()
        {
            InitializeComponent();
            dgvDSDonNhapHang.DataSource = donnhaphangBLL.LoadAllDanhSach();
        }

        public frmDSDonNhapHang(string maNCC)
        {
            InitializeComponent();
            dgvDSDonNhapHang.DataSource = donnhaphangBLL.GetDNHFromNhaCungCap(maNCC);
        }

        private void frmDSDonNhapHang_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
        }

        private void dgvDSDonNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                donNhapHang = donnhaphangBLL.GetDonNhapHangByID(dgvDSDonNhapHang.Rows[e.RowIndex].Cells[0].Value.ToString());
                ShowInfoDonNhapHang(donNhapHang);
            }
        }

        private void ShowInfoDonNhapHang(DonNhapHang donNhapHang)
        {
            txtMaHD.Text = donNhapHang.MaDNH;
            nhaCungCap = nhacungcapBLL.GetNhaCungCapByID(donNhapHang.MaNCC);
            txtTenNCC.Text = nhaCungCap.Ten;
            txtNgayLap.Text = donNhapHang.NgayLap.ToString();
            txtSDT.Text = nhaCungCap.SoDienThoai;
            txtDiaChi.Text = nhaCungCap.DiaChi;
            txtEmail.Text = nhaCungCap.Email;

            dgvCTDNH.Rows.Clear();
            dgvCTDNH.Refresh();
            foreach (HangHoa hh in donNhapHang.DSHangHoa)
            {
                DataGridViewRow row = (DataGridViewRow)dgvCTDNH.Rows[0].Clone();
                row.Cells[0].Value = hh.MaHH;

                row.Cells[3].Value = hh.GiaGoc;
                row.Cells[4].Value = hh.SoLuong;
                int thanhtien = hh.GiaGoc * hh.SoLuong;
                row.Cells[5].Value = thanhtien.ToString();

                HangHoa hh2 = hangBLL.GetHangHoaByID(hh.MaHH);
                row.Cells[1].Value = hh2.TenHH;
                row.Cells[2].Value = hh2.LoaiHang;
                dgvCTDNH.Rows.Add(row);
            }

            lblTotalPrice.Text = donNhapHang.TongTien.ToString();
            lblDaTra.Text = donNhapHang.DaTra.ToString();
            lblConLai.Text = donNhapHang.ConLai.ToString();
        }

        private void txtTimKH_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKH.Text == "")
                dgvDSDonNhapHang.DataSource = donnhaphangBLL.LoadAllDanhSach();
            else
                dgvDSDonNhapHang.DataSource = donnhaphangBLL.GetDNHFromTenNhaCungCap(txtTimKH.Text);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("Nhập sai!");
            }
            else
                dgvDSDonNhapHang.DataSource = donnhaphangBLL.SearchByDate(dtpFrom.Value, dtpTo.Value);
        }
    }
}
