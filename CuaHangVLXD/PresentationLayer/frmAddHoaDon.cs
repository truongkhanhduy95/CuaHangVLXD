using CuaHangVLXD.BussinessLogicLayer;
using CuaHangVLXD.Model;
using DevComponents.DotNetBar;
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
    public partial class frmAddHoaDon : DevComponents.DotNetBar.Office2007RibbonForm
    {
        HoaDonBLL hoadonBLL = new HoaDonBLL();
        HangHoaBLL hangBLL = new HangHoaBLL();
        LoaiHangBLL loaiBLL = new LoaiHangBLL();
        KhachHangBLL khachhangBLL = new KhachHangBLL();

        HoaDon hoaDon;
        public frmAddHoaDon()
        {
            InitializeComponent();
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            txtTenKH.Enabled = true;
        }

        public frmAddHoaDon(KhachHang khachHang)
        {
            InitializeComponent();
            txtDiaChi.Text = khachHang.DiaChi;
            txtEmail.Text = khachHang.Email;
            txtSDT.Text = khachHang.SoDienThoai;
            txtTenKH.Text = khachHang.Ten;

            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
            txtSDT.Enabled = false;
            txtTenKH.Enabled = false;

        }


        private void frmAddHoaDon_Load(object sender, EventArgs e)
        {
            hoaDon = new HoaDon();
            dgvHangHoa.DataSource = hangBLL.LoadDanhSachHH(false);
            cboLoaiHang.DataSource = loaiBLL.LoadAll();
            cboLoaiHang.DisplayMember = "TenLoai";
            cboLoaiHang.ValueMember = "ID";
            cboLoaiHang.SelectedIndex = -1;

            if (dgvHangHoa.Rows.Count > 0)
            {
                txtMaHang.Text = dgvHangHoa.Rows[0].Cells[0].Value.ToString();
                txtTenHang.Text = dgvHangHoa.Rows[0].Cells[1].Value.ToString();
                txtLoai.Text = dgvHangHoa.Rows[0].Cells[2].Value.ToString();
                txtDonGia.Text = dgvHangHoa.Rows[0].Cells[3].Value.ToString();
                txtSoLuong.Text = "1";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            dgvHangHoa.DataSource = hangBLL.SearchByTen(txtTenHH.Text);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            txtTenHH.ResetText();
            dgvHangHoa.DataSource = hangBLL.LoadDanhSachHH(false);
            cboLoaiHang.SelectedIndex = -1;
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            HangHoa hh = hangBLL.GetHangHoaByID(dgvHangHoa.SelectedRows[0].Cells[0].Value.ToString());
            if (hh.SoLuong < 1)
            {
                MessageBox.Show("Số lượng không đủ");
                txtSoLuong.Text = "1";
            }
            else
            {
                hh.SoLuong = 1;
                hoaDon.AddHangHoa(hh);
                ShowDanhSachHangHoa();
                txtTotalPrice.Text = hoaDon.TongTien.ToString();
            }
        }

        public void ShowDanhSachHangHoa()
        {
            dgvHangMua.Rows.Clear();
            dgvHangMua.Refresh();
            foreach (HangHoa hh in hoaDon.DSHangHoa)
            {
                DataGridViewRow row = (DataGridViewRow)dgvHangMua.Rows[0].Clone();
                row.Cells[0].Value = hh.MaHH;
                row.Cells[1].Value = hh.TenHH;
                row.Cells[2].Value = hh.LoaiHang;
                row.Cells[3].Value = hh.GiaBan;
                row.Cells[4].Value = hh.SoLuong;
                int thanhtien = hh.GiaBan * hh.SoLuong;
                row.Cells[5].Value = thanhtien.ToString();

                dgvHangMua.Rows.Add(row);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int traTruoc = int.Parse(txtTraTruoc.Text);
                if (txtTenKH.Text == "")
                {
                    MessageBox.Show("Chưa điền thông tin khách hàng");
                    return;
                }
                //kiểm tra xem khách hàng cũ hay mới
                KhachHang khachHang = khachhangBLL.Contains(new KhachHang(txtTenKH.Text, txtDiaChi.Text));

                if (khachHang.Ma == null)    //TH1: Tìm không thấy => khách hàng này là mới
                {
                    //Tạo 1record khách hàng mới
                    khachHang.Ten = txtTenKH.Text;
                    khachHang.DiaChi = txtDiaChi.Text;
                    khachHang.Email = txtEmail.Text;
                    khachHang.SoDienThoai = txtSDT.Text;

                    //add KH
                    khachhangBLL.Insert(khachHang);
                    //Lấy lại mã mới tạo
                    khachHang = khachhangBLL.Contains(new KhachHang(txtTenKH.Text, txtDiaChi.Text));
                }
                //Tạo hóa đơn với mã KH vừa lấy
                hoaDon.MaKH = khachHang.Ma;
                hoaDon.NgayLap = DateTime.Now;
                hoaDon.DaTra = traTruoc;
                if (hoadonBLL.AddNewHoaDon(hoaDon))
                {
                    if (MessageBoxEx.Show("Đã lập hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        string maHD = hoadonBLL.GetMaHDLastest();
                        frmInHoaDon frm = new frmInHoaDon(maHD);
                        frm.Show();
                    }
                }
            }
            catch(FormatException)
            {
                MessageBoxEx.Show("Nhập sai");
            }
        }

        private void cboLoaiHang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = hangBLL.SearchByLoaiHang(cboLoaiHang.SelectedValue.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHangMua.SelectedRows[0].Cells[0].Value != null)
                {
                    HangHoa hh = hangBLL.GetHangHoaByID(dgvHangMua.SelectedRows[0].Cells[0].Value.ToString());
                    hoaDon.RemoveHanghoa(hh);
                    ShowDanhSachHangHoa();
                    txtTotalPrice.Text = hoaDon.TongTien.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nothing to clear!");
            }
        }

        private void grpPanel_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void txtTraTruoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX11_Click(object sender, EventArgs e)
        {

        }

        private void labelX10_Click(object sender, EventArgs e)
        {

        }

        private void cboLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void groupPanelLopCu_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainerPhanLop_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void nmSoLuong_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void txtTenHH_TextChanged(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = hangBLL.SearchByTen(txtTenHH.Text);
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void panelConTren_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelChaTrai_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelConPhai_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void labelX8_Click(object sender, EventArgs e)
        {

        }

        private void labelX7_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void txtNgayLap_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtMaHang.Text = dgvHangHoa.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenHang.Text = dgvHangHoa.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLoai.Text = dgvHangHoa.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDonGia.Text = dgvHangHoa.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSoLuong.Text = "1";
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.RemoveCurrentTab();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                HangHoa hh = hangBLL.GetHangHoaByID(dgvHangHoa.SelectedRows[0].Cells[0].Value.ToString());
                int sl = int.Parse(txtSoLuong.Text);
                if (hh.SoLuong < sl)
                {
                    MessageBox.Show("Số lượng không đủ");
                }
                else
                {
                    hh.SoLuong = sl;
                    hoaDon.AddHangHoa(hh);
                    ShowDanhSachHangHoa();
                    txtTotalPrice.Text = hoaDon.TongTien.ToString();
                }
                txtSoLuong.Text = "1";
            }
            catch(FormatException)
            {
                MessageBoxEx.Show("Nhập sai!");
            }
        }



    }
}
