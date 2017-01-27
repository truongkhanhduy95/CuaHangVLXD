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
    public partial class frmKhachHang : DevComponents.DotNetBar.Office2007RibbonForm
    {
        KhachHangBLL bll = new KhachHangBLL();
        KhachHang khachHang;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = bll.LoadDanhSachKH();
            khachHang = bll.GetKhachHangByID(dgvKhachHang.Rows[0].Cells[0].Value.ToString());
            ShowInfoKH(khachHang);
        }

        private void ShowInfoKH(KhachHang khachHang)
        {
            txtMaKH.Text = khachHang.Ma;
            txtTenKH.Text = khachHang.Ten;
            txtDiaChi.Text = khachHang.DiaChi;
            txtSDT.Text = khachHang.SoDienThoai;
            txtEmail.Text = khachHang.Email;
        }


        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                khachHang = bll.GetKhachHangByID(dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString());
                ShowInfoKH(khachHang);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GetInfo();
            if (khachHang.Ten == "")
            {
                MessageBoxEx.Show("Tên khách hàng không được để trống");
                return;
            }
            bll.Update(khachHang);
            dgvKhachHang.DataSource = bll.LoadDanhSachKH();
            MessageBoxEx.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void GetInfo()
        {
            khachHang.Ma = txtMaKH.Text;
            khachHang.SoDienThoai = txtSDT.Text;
            khachHang.Ten = txtTenKH.Text;
            khachHang.DiaChi = txtDiaChi.Text;
            khachHang.Email = txtEmail.Text;
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            txtMaKH.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();
            txtTenKH.ResetText();
            txtDiaChi.ResetText();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.AddNewTab("New đơn hàng", new frmAddHoaDon(khachHang));
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            khachHang = new KhachHang();
            khachHang.SoDienThoai = txtSDT.Text;
            khachHang.Ten = txtTenKH.Text;
            khachHang.DiaChi = txtDiaChi.Text;
            khachHang.Email = txtEmail.Text;

            if(bll.Insert(khachHang))
            {
                dgvKhachHang.DataSource = bll.LoadDanhSachKH();
                MessageBoxEx.Show("Thêm mới thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.AddNewTab("Danh sách Hóa Đơn", new frmDSHoaDon(khachHang.Ma));
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX1.Text != "")
                dgvKhachHang.DataSource = bll.SearchKH(textBoxX1.Text);
            else
                dgvKhachHang.DataSource = bll.LoadDanhSachKH();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = bll.SearchKhachHangBySDT(textBoxX2.Text);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.RemoveCurrentTab();
        }


    }
}
