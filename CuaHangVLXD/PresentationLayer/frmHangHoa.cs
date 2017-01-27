using CuaHangVLXD.BussinessLogicLayer;
using CuaHangVLXD.Model;
using CuaHangVLXD.PresentationLayer;
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

namespace CuaHangVLXD.Presenter
{
    public partial class frmHangHoa : DevComponents.DotNetBar.Office2007RibbonForm
    {
        HangHoaBLL hhBLL = new HangHoaBLL();
        LoaiHangBLL lhBLL = new LoaiHangBLL();

        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            dgHangHoa.DataSource = hhBLL.LoadDanhSachHH(true);

            cboLoaiHang.DataSource = lhBLL.LoadAll();
            cboLoaiHang.DisplayMember = "TenLoai";
            cboLoaiHang.ValueMember = "ID";
            cboLoaiHang.SelectedIndex = -1;

            cboLoaiTim.DataSource = lhBLL.LoadAll();
            cboLoaiTim.DisplayMember = "TenLoai";
            cboLoaiTim.ValueMember = "ID";
            cboLoaiTim.SelectedIndex = -1;

            if (dgHangHoa.Rows.Count > 0)
            {
                string id = dgHangHoa.Rows[0].Cells[0].Value.ToString();
                HangHoa hh = hhBLL.GetHangHoaByID(id);
                ShowInfoHang(hh);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuVaoDS_Click(object sender, EventArgs e)
        {
            try
            {
                HangHoa hh = new HangHoa();
                hh.MaHH = txtMaHH.Text;
                hh.SoLuong = int.Parse(txtSoLuong.Text);
                hh.GiaBan = int.Parse(txtGia.Text);
                hh.DonViTinh = txtDonViTinh.Text;
                hh.TenHH = txtTenHH.Text;
                hh.LoaiHang = cboLoaiHang.SelectedValue.ToString();

                hhBLL.UpdateHH(hh);
                dgHangHoa.DataSource = hhBLL.LoadDanhSachHH(true);

                MessageBoxEx.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(FormatException)
            {
                MessageBoxEx.Show("Nhập sai!");
            }
        }

        private void dgHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) 
            {
                string id = dgHangHoa.Rows[e.RowIndex].Cells[0].Value.ToString();
                HangHoa hh = hhBLL.GetHangHoaByID(id);
                ShowInfoHang(hh);
            }
        }

        public void ShowInfoHang(HangHoa hh)
        {
            txtMaHH.Text = hh.MaHH;
            txtTenHH.Text = hh.TenHH;
            txtDonViTinh.Text = hh.DonViTinh;
            txtGia.Text = hh.GiaBan.ToString();
            txtSoLuong.Text = hh.SoLuong.ToString();
            cboLoaiHang.SelectedIndex = cboLoaiHang.FindStringExact(hh.LoaiHang);
        }

        private void dgHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
  
        }

        private void navPanelNhapDuLieu_Click(object sender, EventArgs e)
        {

        }

        private void txtTenHH_TextChanged(object sender, EventArgs e)
        {

        }

        private void navPaneLeft_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            frmAddHangHoa frm = new frmAddHangHoa();
            frm.ShowDialog();
            dgHangHoa.DataSource = hhBLL.LoadDanhSachHH(true);
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (dgHangHoa.Rows.Count > 0)
            {
                string id = dgHangHoa.SelectedRows[0].Cells[0].Value.ToString();
                HangHoa hh = hhBLL.GetHangHoaByID(id);

                if (MessageBoxEx.Show("Bạn có chắc muốn xóa: " + hh.TenHH + " không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (hhBLL.DeleteHH(hh))
                    {
                        dgHangHoa.DataSource = hhBLL.LoadDanhSachHH(true);
                    }
                    else
                        MessageBoxEx.Show("Có lỗi xảy ra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            dgHangHoa.DataSource = hhBLL.LoadDanhSachHH(true);    
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dgHangHoa.DataSource = hhBLL.SearchByTen(txtTenTim.Text);
        }

        private void navigationPanePanel1_Click(object sender, EventArgs e)
        {
        }

        private void cboLoaiTim_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboLoaiTim_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgHangHoa.DataSource = hhBLL.SearchByLoaiHang(cboLoaiTim.SelectedValue.ToString());
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.RemoveCurrentTab();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            dgHangHoa.DataSource = hhBLL.SearchByTen(textBoxX1.Text);
        }

        private void buttonItemTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void buttonItemNhapDuLieu_Click(object sender, EventArgs e)
        {

        }
    }
}
