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
    public partial class frmNhaCungCap : DevComponents.DotNetBar.Office2007RibbonForm
    {
        NhaCungCapBLL nccBLL;
        NhaCungCap ncc;

        public frmNhaCungCap()
        {
            InitializeComponent();
            nccBLL = new NhaCungCapBLL();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvNhaCungCap.DataSource = nccBLL.LoadDanhSachNCC();
            ncc = nccBLL.GetNhaCungCapByID(dgvNhaCungCap.Rows[0].Cells[0].Value.ToString());
            ShowInfo(ncc);
        }

        private void ShowInfo(NhaCungCap ncc)
        {
            txtMaNCC.Text = ncc.Ma;
            txtTenNNC.Text = ncc.Ten;
            txtDiaChi.Text = ncc.DiaChi;
            txtSDT.Text = ncc.SoDienThoai;
            txtEmail.Text = ncc.Email;
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ncc = nccBLL.GetNhaCungCapByID(dgvNhaCungCap.Rows[e.RowIndex].Cells[0].Value.ToString());

                ShowInfo(ncc);
            }
        }

        public void GetInfo()
        {
            ncc.Ma = txtMaNCC.Text;
            ncc.SoDienThoai = txtSDT.Text;
            ncc.Ten = txtTenNNC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.Email = txtEmail.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GetInfo();
            if (ncc.Ten == "")
            {
                MessageBoxEx.Show("Chưa điền thông tin nhà cung cấp!");
                return;
            }
            nccBLL.Update(ncc);
            dgvNhaCungCap.DataSource = nccBLL.LoadDanhSachNCC();
            MessageBoxEx.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.AddNewTab("New đơn nhập hàng", new frmAddDonNhapHang(ncc));
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.AddNewTab("Danh sách DNH", new frmDSDonNhapHang(ncc.Ma));
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.RemoveCurrentTab();
        }

        
    }
}
